using Playnite.SDK;
using Playnite.SDK.Models;
using Playnite.SDK.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DiscordPresencePlaynite
{
    public class DiscordPresencePlaynite : Plugin
    {
        private static readonly ILogger logger = LogManager.GetLogger();
        private DiscordPresencePlayniteSettings settings { get; set; }
        public override Guid Id { get; } = Guid.Parse("02330dd0-ec45-4da9-a626-4a625aa15cc8");
        public static readonly string version = "1.0.0";
        public static DiscordRpc.RichPresence presence;
        public static long Timestamp;
        private DiscordRpc.EventHandlers handlers;

        public DiscordPresencePlaynite(IPlayniteAPI api) : base(api)
        {
            settings = new DiscordPresencePlayniteSettings(this);
            Timestamp = UnixTimeNow();
        }

        public void ReadyCallback()
        {
            logger.Info("[Playnite Discord RPC] Ready.");
            PlayniteApi.Dialogs.ShowMessage("DEBUG Ready");
        }

        public void DisconnectedCallback(int errorCode, string message)
        {
            logger.Info("[Playnite Discord RPC] Disconnected. Reason: " + errorCode + ": " + message);
            PlayniteApi.Dialogs.ShowMessage("DEBUG Disconnected. Reason: " + errorCode + ": " + message);
        }

        public void ErrorCallback(int errorCode, string message)
        {
            logger.Info("[Playnite Discord RPC] Error. Reason: " + errorCode + ": " + message);
            PlayniteApi.Dialogs.ShowMessage("DEBUG Error. Reason: " + errorCode + ": " + message);
        }

        public void JoinCallback(string secret)
        {
        }

        public void SpectateCallback(string secret)
        {
        }

        public void RequestCallback(DiscordRpc.JoinRequest request)
        {
        }

        public void StartDiscord()
        {
            handlers = new DiscordRpc.EventHandlers();
            handlers.readyCallback = ReadyCallback;
            handlers.disconnectedCallback += DisconnectedCallback;
            handlers.errorCallback += ErrorCallback;
            handlers.joinCallback += JoinCallback;
            handlers.spectateCallback += SpectateCallback;
            handlers.requestCallback += RequestCallback;
            DiscordRpc.Initialize(settings.AppID, ref handlers, true, "");
        }

        public override IEnumerable<ExtensionFunction> GetFunctions()
        {
            return new List<ExtensionFunction>
            {
                new ExtensionFunction(
                    "Playnite Discord Rich Presence Plugin",
                    () =>
                    {
                        // Add code to be execute when user invokes this menu entry.
                        PlayniteApi.Dialogs.ShowMessage("Playnite Discord Rich Presence Plugin by Bitl - Version: " + version + Environment.NewLine + settings.AppID);
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
            presence.largeImageKey = "playnite_logo";
            presence.details = game.Name;
            presence.state = "In-Game";
            presence.largeImageText = game.Name + " | In-Game";
        }

        public override void OnGameStopped(Game game, long elapsedSeconds)
        {
            // Add code to be executed when game is preparing to be started.
            presence.largeImageKey = "playnite_logo";
            presence.state = "Idle";
            presence.largeImageText = "Idle";
        }

        public override void OnGameUninstalled(Game game)
        {
            // Add code to be executed when game is uninstalled.
        }

        public override void OnApplicationStarted()
        {
            // Add code to be executed when Playnite is initialized.
            StartDiscord();
        }

        public override void OnApplicationStopped()
        {
            // Add code to be executed when Playnite is shutting down.
            DiscordRpc.Shutdown();
        }

        public override void OnLibraryUpdated()
        {
            // Add code to be executed when library is updated.
            presence.largeImageKey = "playnite_logo";
            presence.state = "Idle";
            presence.largeImageText = "Idle";
            //we initalized. start the timestamp.
            presence.startTimestamp = Timestamp;
        }

        public override ISettings GetSettings(bool firstRunSettings)
        {
            return settings;
        }

        public override UserControl GetSettingsView(bool firstRunSettings)
        {
            return new DiscordPresencePlayniteSettingsView();
        }

        public static long UnixTimeNow()
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)timeSpan.TotalSeconds;
        }
    }
}