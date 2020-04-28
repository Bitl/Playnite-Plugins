using Playnite.SDK;
using Playnite.SDK.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ModDB-Metadata
{
    public class ModDB-Metadata : MetadataPlugin
    {
        private static readonly ILogger logger = LogManager.GetLogger();

        private ModDB-MetadataSettings settings { get; set; }

        public override Guid Id { get; } = Guid.Parse("b74d078d-db90-47ca-9e9f-775ea2f4411e");

        public override List<MetadataField> SupportedFields { get; } = new List<MetadataField>
        {
            MetadataField.Description
            // Include addition fields if supported by the metadata source
        };

        // Change to something more appropriate
        public override string Name => "Custom Metadata";

        public ModDB-Metadata(IPlayniteAPI api) : base(api)
        {
            settings = new ModDB-MetadataSettings(this);
        }

        public override OnDemandMetadataProvider GetMetadataProvider(MetadataRequestOptions options)
        {
            return new ModDB-MetadataProvider(options, this);
        }

        public override ISettings GetSettings(bool firstRunSettings)
        {
            return settings;
        }

        public override UserControl GetSettingsView(bool firstRunSettings)
        {
            return new ModDB-MetadataSettingsView();
        }
    }
}