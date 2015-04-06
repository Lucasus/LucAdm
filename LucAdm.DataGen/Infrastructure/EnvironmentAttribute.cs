using System;
using System.Collections.Generic;

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
