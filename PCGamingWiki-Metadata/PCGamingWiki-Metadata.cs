using Playnite.SDK;
using Playnite.SDK.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PCGamingWiki-Metadata
{
    public class PCGamingWiki-Metadata : MetadataPlugin
    {
        private static readonly ILogger logger = LogManager.GetLogger();

        private PCGamingWiki-MetadataSettings settings { get; set; }

        public override Guid Id { get; } = Guid.Parse("8ddc4779-2cbb-4341-acc9-e07f6027f290");

        public override List<MetadataField> SupportedFields { get; } = new List<MetadataField>
        {
            MetadataField.Description
            // Include addition fields if supported by the metadata source
        };

        // Change to something more appropriate
        public override string Name => "Custom Metadata";

        public PCGamingWiki-Metadata(IPlayniteAPI api) : base(api)
        {
            settings = new PCGamingWiki-MetadataSettings(this);
        }

        public override OnDemandMetadataProvider GetMetadataProvider(MetadataRequestOptions options)
        {
            return new PCGamingWiki-MetadataProvider(options, this);
        }

        public override ISettings GetSettings(bool firstRunSettings)
        {
            return settings;
        }

        public override UserControl GetSettingsView(bool firstRunSettings)
        {
            return new PCGamingWiki-MetadataSettingsView();
        }
    }
}