using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public interface IWebUserRepository
    {
        List<string> GetComponents(string type);
        System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> inspectClasses(Int32 id);
        System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> inspectInterfaces(Int32 id);
        System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> inspectMethods(Int32 id);
        void UpdateDownload(int id);        
    }
}
