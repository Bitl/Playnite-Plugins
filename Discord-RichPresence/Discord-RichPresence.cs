using Playnite.SDK;
using Playnite.SDK.Models;
using Playnite.SDK.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Discord-RichPresence
{
    public class Discord-RichPresence : Plugin
    {
        private static readonly ILogger logger = LogManager.GetLogger();

        private Discord-RichPresenceSettings settings { get; set; }

        public override Guid Id { get; } = Guid.Parse("d5eebd91-604b-47aa-9ea1-4576840a775a");

        public Discord-RichPresence(IPlayniteAPI api) : base(api)
        {
            settings = new Discord-RichPresenceSettings(this);
        }

        public override IEnumerable<ExtensionFunction> GetFunctions()
        {
            return new List<ExtensionFunction>
            {
                new ExtensionFunction(
                    "Execute function from GenericPlugin",
                    () =>
                    {
                        // Add code to be execute when user invokes this menu entry.
                        PlayniteApi.Dialogs.ShowMessage("Code executed from a plugin!");
                    })
            };
        }

        public override void OnGameInstalled(Game game)
        {
            // Add code to be executed when game is finished installing.
        }

        public override void OnGameStarted(Game game)
        {
            // Add code to be executed when game is started running.
        }

        public override void OnGameStarting(Game game)
        {
            // Add code to be executed when game is preparing to be started.
        }

        public override void OnGameStopped(Game game, long elapsedSeconds)
        {
            // Add code to be executed when game is preparing to be started.
        }

        public override void OnGameUninstalled(Game game)
        {
            // Add code to be executed when game is uninstalled.
        }

        public override void OnApplicationStarted()
        {
            // Add code to be executed when Playnite is initialized.
        }

        public override void OnApplicationStopped()
        {
            // Add code to be executed when Playnite is shutting down.
        }

        public override void OnLibraryUpdated()
        {
            // Add code to be executed when library is updated.
        }

        public override ISettings GetSettings(bool firstRunSettings)
        {
            return settings;
        }

        public override UserControl GetSettingsView(bool firstRunSettings)
        {
            return new Discord-RichPresenceSettingsView();
        }
    }
}