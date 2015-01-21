using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEndLibraries
{

    public interface IUtilsRepo
    {
        bool Add(string name, string path, string description, string type);
        bool Delete(int Id);
        List<string> GetComponents(string type);
        bool ModifyInDB(int Id, string name, string path, string description, string type);
        void updateDownload(int id);
    }

    public class Uils_Repo : IUtilsRepo
    {
        private Component component;
        private string DB_Path;

        public Uils_Repo(string pathDB)
        {
            DB_Path = pathDB;
        }

        public bool Add(string name, string path, string description, string type)
        {
            try
            {
                component = new Component(DB_Path,name,description,path,type);
                component.store();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public bool Delete(int Id)
        {
            try
            {
                component = new Component(DB_Path,Id);
                component.delete();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool ModifyInDB(int Id, string name, string path, string description, string type)
        {
            try
            {
                component = new Component(DB_Path);
                component.modify(Id, name, path, description, type);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public void updateDownload(int Id)
        {
            try
            {
                component = new Component(DB_Path, Id);
                component.updateDownload(Id);
            }
            catch (Exception e)
            {

            }

        }

        public List<string> GetComponents(string type)
        {
            List<string> components = new List<string>();

            component = new Component(DB_Path);
            //int nComp = component;

            List<Component> list;

            try
            {
                if (type != null)
                {
                    list = component.getComponentListByType(type);
                    foreach( Component comp in list)
                        components.Add(Convert.ToString(comp.getID()) + ";" + comp.getName() + ";" + comp.getPath() + ";" + comp.getDescription() + ";" + comp.getType() + ";" + comp.getDownload_counter() + ";");
                }
                else
                {
                    list = component.getComponentList();
                    foreach (Component comp in list)
                        components.Add(Convert.ToString(comp.getID()) + ";" + comp.getName() + ";" + comp.getPath() + ";" + comp.getDescription() + ";" + comp.getType() + ";" + comp.getDownload_counter() + ";");
                }
            }
            catch(Exception e)
            {
                return null;
            }

            return components;
        }



    }
}
