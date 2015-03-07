using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucAdm.DataGen
{
    public class EnvironmentAttribute : Attribute
    {
        public IList<EnvironmentEnum> Environments { get; set; }

        public EnvironmentAttribute(params EnvironmentEnum[] environments)
        {
            this.Environments = environments;
        }
    }
}
