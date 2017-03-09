namespace Turbo.Plugins.Jack.Alerts
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Turbo.Plugins.Default;
    using Turbo.Plugins.Jack.Models;
    using Turbo.Plugins.Jack.Extensions;

    /// <summary>
    /// Helper class to display visual alerts
    /// </summary>
    public class Alert
    {
        public IController Hud { get; private set; }
        public IPlayer Player { get { return Hud.Game.Me; } }

        // state
        public bool Enabled { get; set; }

        public bool MultiLine { get; set; }

        public bool Visible
        {
            get
            {
                return Rule != null && Rule.VisibleCondition != null && Rule.VisibleCondition.Invoke(Player);
            }
        }

        // conditions
        public AlertRule Rule { get; set; }

        // decorators
        public TopLabelDecorator Label { get; set; }

        public WorldDecoratorCollection PlayerDecorators { get; set; }
        public WorldDecoratorCollection ActorDecorators { get; set; }

        // text
        public string MessageFormat { get; set; }

        public uint TextSnoId { get; set; }
        public string AlertText { get; set; }
        public Func<uint, string> AlertTextFunc { get; set; }
        public Func<IEnumerable<string>> LinesFunc { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Alert" /> class.
        /// </summary>
        /// <param name="hud">The hud.</param>
        /// <param name="heroClass">The hero class.</param>
        /// <param name="text">The text.</param>
        public Alert(IController hud, HeroClass heroClass = HeroClass.None, string text = null)
        {
            Hud = hud;
            Enabled = true;
            MessageFormat = "{0}";

            AlertText = text;
            if (text == null)
                AlertTextFunc = (id) => Hud.GuessLocalizedName(id);
            else
                AlertTextFunc = (id) => text;

            Rule = new AlertRule(hud, heroClass);
            Label = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 11, 255, 244, 30, 30, false, false, 242, 0, 0, 0, true),
                TextFunc = () => string.Format(CultureInfo.InvariantCulture, MessageFormat, AlertText ?? AlertTextFunc.Invoke(TextSnoId)),
            };
        }
    }
}