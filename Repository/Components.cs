using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace Repository
{
  

    public class Components : IAdminRepository, IWebUserRepository
    {

        Dictionary<Int32, IComponent> components;

        private string BeLPath=null;
        private BackEndLibraries.IUtilsRepo BeL;
        string rootpath;

        public Components(string pathDB)
        {
            BeLPath = pathDB;
        }
        public Components(string pathDB, string root)
        {
            BeLPath = pathDB;
            rootpath = root;
        }

        public bool Add(string name, string path, string description, string type)
        {
            BeL = new BackEndLibraries.Uils_Repo(BeLPath);
            return BeL.Add(name, path, description, type);
        }
        public bool Delete(int id)
        {
            BeL = new BackEndLibraries.Uils_Repo(BeLPath);
            return BeL.Delete(id);
        }
        public bool Modify(int id, string name, string path, string description, string type)
        {
            BeL = new BackEndLibraries.Uils_Repo(BeLPath);
            return BeL.ModifyInDB(id, name, path, description, type);
        }
        public List<string> GetComponents(string type)
        {
            BeL = new BackEndLibraries.Uils_Repo(BeLPath);
            List<string> complist = BeL.GetComponents(type);
            BeL = null;
            components = null;
            components = new Dictionary<int, IComponent>();
            foreach (string singleComp in complist)
            {
                string[] comp = singleComp.Split(';');
                if (comp[4] == "COM")
                    components[Convert.ToInt32(comp[0])] = new COMReflection.COMReflect(rootpath + comp[3]+";"+rootpath);
                if (comp[4] == "NET")
                    components[Convert.ToInt32(comp[0])] = new NETReflection.NETReflect(rootpath + comp[3] + ";");
                if (comp[4] == "JAVA")
                    components[Convert.ToInt32(comp[0])] = new JavaReflection2.JavaReflection(rootpath + comp[3] + ";");
            }
            return complist;
        }
        public System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> inspectMethods(Int32 id)
        {
            components[id].loadAssembly();
            Dictionary<string, List<string>> InspectResult = components[id].inspectMethods();

            return InspectResult;
        }
        public System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> inspectInterfaces(Int32 id)
        {
            components[id].loadAssembly();
            Dictionary<string, List<string>> InspectResult = components[id].inspectInterfaces();
            return InspectResult;
        }
        public System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> inspectClasses(Int32 id)
        {
            components[id].loadAssembly();
            Dictionary<string, List<string>> InspectResult = components[id].inspectClasses();
            return InspectResult;
        }
        public void UpdateDownload(int id)
        {
            BeL = new BackEndLibraries.Uils_Repo(BeLPath);
            BeL.updateDownload(id);

        }
    }
}
