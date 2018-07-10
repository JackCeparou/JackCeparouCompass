using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.Linq;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.Jack.Keyboard
{
    /// <summary>
    /// A centralized method to specify key event actions.
    /// </summary>
    /// <seealso cref="Turbo.Plugins.Default.BasePlugin" />
    /// <seealso cref="Turbo.Plugins.IKeyEventHandler" />
    public class OptionTogglerPlugin : BasePlugin, IKeyEventHandler
    {
        private Dictionary<IKeyEvent, List<Action<IController>>> KeyEvents;

        /// <summary>
        /// Initializes a new instance of the <see cref="OptionTogglerPlugin"/> class.
        /// </summary>
        public OptionTogglerPlugin()
        {
            Enabled = true;
            KeyEvents = new Dictionary<IKeyEvent, List<Action<IController>>>();
        }

        /// <summary>
        /// Adds an action or multiple actions binded to an IKeyEvent.
        /// </summary>
        /// <param name="keyEvent">The key event.</param>
        /// <param name="keyEvents">The actions.</param>
        public void AddAction(IKeyEvent keyEvent, params Action<IController>[] keyEvents)
        {
            var @event = GetActions(keyEvent, true);
            @event.Value.AddRange(keyEvents);
        }

        /// <summary>
        /// Adds an action or multiple actions binded to a key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="keyEvents">The actions.</param>
        public void AddAction(Key key, params Action<IController>[] keyEvents)
        {
            var keyEvent = Hud.Input.CreateKeyEvent(true, key, false, false, false);
            AddAction(keyEvent, keyEvents);
        }

        /// <summary>
        /// Called when the player pressed or released a key. This method is called during the data collection phase, which means no rendering is possible!
        /// </summary>
        /// <param name="keyEvent"></param>
        public void OnKeyEvent(IKeyEvent keyEvent)
        {
            var @event = GetActions(keyEvent);

            if (!IsDefault(@event))
            {
                foreach (var action in @event.Value)
                {
                    action.Invoke(Hud);
                }
            }
        }

        /// <summary>
        /// Gets the actions registered for this key event.
        /// </summary>
        /// <param name="keyEvent">The key event.</param>
        /// <param name="createIfNotFound">if set to <c>true</c> [create if not found].</param>
        /// <returns></returns>
        private KeyValuePair<IKeyEvent, List<Action<IController>>> GetActions(IKeyEvent keyEvent, bool createIfNotFound = false)
        {
            var @event = KeyEvents.SingleOrDefault(x => x.Key.Matches(keyEvent));

            if (IsDefault(@event) && createIfNotFound)
            {
                @event = new KeyValuePair<IKeyEvent, List<Action<IController>>>(keyEvent, new List<Action<IController>>());
                KeyEvents.Add(@event.Key, @event.Value);
            }

            return @event;
        }

        /// <summary>
        /// Determines whether the specified object is default.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="object">The object.</param>
        /// <returns>
        ///   <c>true</c> if the specified object is default; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsDefault<T>(T @object)
        {
            return default(T).Equals(@object);
        }
    }
}
