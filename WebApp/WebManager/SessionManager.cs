using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.WebManager
{
    public class SessionManager : ISessionManager
    {
        
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionManager(IHttpContextAccessor _httpContextAccessor)
        {
            this._httpContextAccessor = _httpContextAccessor;
        }

        public string GetSessionObject(string name)
        {

            return _httpContextAccessor.HttpContext.Session.GetString(name);

        }

        public bool SaveSessionObject(string _value, string _key)
        {

            _httpContextAccessor.HttpContext.Session.SetString(_key, _value);
            return true;

        }

        public bool RemoveSessionObject(string _key)
        {

            _httpContextAccessor.HttpContext.Session.Remove(_key);
            return true;

        }

        public bool ClearAllSession()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
            return true;
        }

    }
}
