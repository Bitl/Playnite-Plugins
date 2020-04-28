using Newtonsoft.Json;
using Playnite.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordPresencePlaynite
{
    public class DiscordPresencePlayniteSettings : ISettings
    {
        private readonly DiscordPresencePlaynite plugin;
        private DiscordPresencePlayniteSettings editingClone;

        public string AppID { get; set; } = "704803731211812885";

        // Playnite serializes settings object to a JSON object and saves it as text file.
        // If you want to exclude some property from being saved then use `JsonIgnore` ignore attribute.
        /*
        [JsonIgnore]
        public bool OptionThatWontBeSaved { get; set; } = false;
        */

        // Parameterless constructor must exist if you want to use LoadPluginSettings method.
        public DiscordPresencePlayniteSettings()
        {
        }

        public DiscordPresencePlayniteSettings(DiscordPresencePlaynite plugin)
        {
            // Injecting your plugin instance is required for Save/Load method because Playnite saves data to a location based on what plugin requested the operation.
            this.plugin = plugin;

            // Load saved settings.
            var savedSettings = plugin.LoadPluginSettings<DiscordPresencePlayniteSettings>();

            // LoadPluginSettings returns null if not saved data is available.
            if (savedSettings == null) return;
            AppID = savedSettings.AppID;
        }

        public void BeginEdit()
        {
            // Code executed when settings view is opened and user starts editing values.
            editingClone = this.GetClone();
        }

        public void CancelEdit()
        {
            // Code executed when user decides to cancel any changes made since BeginEdit was called.
            // This method should revert any changes made to Option1 and Option2.
            LoadValues(editingClone);
        }

        public void LoadValues(DiscordPresencePlayniteSettings source)
        {
            source.CopyProperties(this, false, null, true);
        }

        public void EndEdit()
        {
            // Code executed when user decides to confirm changes made since BeginEdit was called.
            // This method should save settings made to Option1 and Option2.
            plugin.SavePluginSettings(this);
        }

        public bool VerifySettings(out List<string> errors)
        {
            // Code execute when user decides to confirm changes made since BeginEdit was called.
            // Executed before EndEdit is called and EndEdit is not called if false is returned.
            // List of errors is presented to user if verification fails.
            errors = new List<string>();
            return true;
        }
    }
}