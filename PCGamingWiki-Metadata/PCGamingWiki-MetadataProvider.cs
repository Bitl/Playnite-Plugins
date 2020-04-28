using Playnite.SDK.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCGamingWiki-Metadata
{
    public class PCGamingWiki-MetadataProvider : OnDemandMetadataProvider
    {
        private readonly MetadataRequestOptions options;
        private readonly PCGamingWiki-Metadata plugin;

        public override List<MetadataField> AvailableFields => throw new NotImplementedException();

        public PCGamingWiki-MetadataProvider(MetadataRequestOptions options, PCGamingWiki-Metadata plugin)
        {
            this.options = options;
            this.plugin = plugin;
        }

        // Override additional methods based on supported metadata fields.
        public override string GetDescription()
        {
            return options.GameData.Name + " description";
        }
    }
}