using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeSerialize
{
    public abstract class ContentSerialize<T>
    {
        private ISerialize serialize;

        public abstract Task<T> GetRacesAsync(string path);
        
        public ISerialize TypeSerialize { set { serialize = value; } }

        public virtual void Serialize(string pathSave)
        {
            serialize.Serialize(pathSave);
        }
 
    }
}
