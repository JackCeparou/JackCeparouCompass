namespace Turbo.Plugins.Jack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Turbo.Plugins.Default;

    public class EventHandlerPlugin : BasePlugin, IAfterCollectHandler
    {
        public List<EventItem> Events { get; private set; }

        public EventHandlerPlugin()
        {
            Enabled = true;
            Events = new List<EventItem>();
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            //AddEvent(false, (_hud) => _hud.Game.Me.Powers.BuffIsActive(437711, 1), null, (_hud) => _hud.Sound.Speak("necrosis"));
        }

        /// <summary>
        /// Registers the event.
        /// </summary>
        /// <example>
        /// Hud.RunOnPlugin<EventHandlerPlugin>(plugin =>
        /// {
        ///     plugin.AddEvent(
        ///         defaultState: false,
        ///         stateFunc: (_hud) => _hud.Game.Me.Powers.BuffIsActive(437711, 1),
        ///         enterFunc: null, //null will do nothing
        ///         exitFunc: (_hud) => _hud.Sound.Speak("necrosis"),
        ///         name: "necrosis" //optional
        ///     );
        /// });
        /// </example>
        /// <param name="defaultState">if set to <c>true</c> [default state].</param>
        /// <param name="stateFunc">The state function.</param>
        /// <param name="enterFunc">The enter function.</param>
        /// <param name="exitFunc">The exit function.</param>
        /// <param name="name">The name.</param>
        public void AddEvent(bool defaultState, Func<IController, bool> stateFunc, Action<IController> enterFunc, Action<IController> exitFunc = null, string name = null)
        {
            var @event = new EventItem(Hud, defaultState, stateFunc, enterFunc, exitFunc, name);
            Events.Add(@event);
        }

        public void RemoveEvent(string name)
        {
            var events = Events.Where(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            foreach (var @event in events)
            {
                Events.Remove(@event);
                @event.Dispose();
            }
        }

        public void AfterCollect()
        {
            foreach (var @event in Events)
            {
                @event.Process();
            }
        }
    }

    public class EventItem : IDisposable
    {
        public string Name { get; private set; }
        public Action<IController> EnterFunc { get; private set; }
        public Action<IController> ExitFunc { get; private set; }
        public Func<IController, bool> StateFunc { get; private set; }
        public bool DefaultState { get; private set; }
        public bool LastState { get; private set; }

        private IController hud;
        private static readonly Action<IController> noop = (hud) => { };

        public EventItem(IController hud, bool defaultState, Func<IController, bool> stateFunc, Action<IController> enterFunc = null, Action<IController> exitFunc = null, string name = null)
        {
            this.hud = hud;
            StateFunc = stateFunc;
            EnterFunc = enterFunc ?? noop;
            ExitFunc = exitFunc ?? noop;
            Name = name ?? Guid.NewGuid().ToString();
            DefaultState = defaultState;
        }

        public void Process()
        {
            if (StateFunc == null) return;
            var state = StateFunc.Invoke(hud);
            if (state == LastState) return;

            if (state == DefaultState && ExitFunc != noop)
            {
                ExitFunc(hud);
            }
            if (state != DefaultState && EnterFunc != noop)
            {
                EnterFunc(hud);
            }

            LastState = state;
        }

        public void Dispose()
        {
            hud = null;
            StateFunc = null;
            EnterFunc = null;
            ExitFunc = null;
            Name = null;
        }
    }
}