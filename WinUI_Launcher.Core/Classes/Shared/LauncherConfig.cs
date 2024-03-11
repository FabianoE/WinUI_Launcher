using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hi3Helper.Shared.Region
{
    public struct CDNURLProperty : IEquatable<CDNURLProperty>
    {
        public string URLPrefix
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public string Description
        {
            get; set;
        }
        public bool PartialDownloadSupport
        {
            get; set;
        }
        public bool Equals(CDNURLProperty other) => URLPrefix == other.URLPrefix && Name == other.Name && Description == other.Description;
    }

    public static class LauncherConfig
    {
        public static List<CDNURLProperty> CDNList => new List<CDNURLProperty>
        {
            new CDNURLProperty
            {
                Name = "GitHub",
                URLPrefix = "https://github.com/neon-nyan/CollapseLauncher-ReleaseRepo/raw/main",
                Description =  "",
                PartialDownloadSupport = true
            },
            new CDNURLProperty
            {
                Name = "Cloudflare",
                URLPrefix = "https://r2.bagelnl.my.id/cl-cdn",
                Description =  "",
                PartialDownloadSupport = true
            },
            new CDNURLProperty
            {
                Name = "Bitbucket",
                URLPrefix = "https://bitbucket.org/neon-nyan/collapselauncher-releaserepo/raw/main",
                Description = "",
            }
        };
    }
}
