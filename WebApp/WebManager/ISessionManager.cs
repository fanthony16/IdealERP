using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.WebManager
{
    public interface ISessionManager
    {
        public bool SaveSessionObject(string _value, string _key);
        public string GetSessionObject(string name);

        public bool RemoveSessionObject(string _key);
        public bool ClearAllSession();
    }
}
