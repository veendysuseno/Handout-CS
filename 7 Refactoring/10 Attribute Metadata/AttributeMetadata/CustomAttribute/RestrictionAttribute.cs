using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeMetadata.CustomAttribute
{
    /*
     * AttributeUsage ini bisa digunakan untuk class atau interface.
     */
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class RestrictionAttribute : Attribute
    {
        public string SystemName { get; set; }
        public int Version { get; set; }
        public RestrictionAttribute(string systemName, int version) {
            this.SystemName = systemName;
            this.Version = version;
        }
    }
}
