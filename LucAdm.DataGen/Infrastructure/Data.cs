using System.Collections.Generic;

namespace LucAdm.DataGen
{
    public class Data<T> where T : Entity, new()
    {
        public virtual IEnumerable<T> GetData(EnvironmentEnum environment)
        {
            return null;
        }
    }
}