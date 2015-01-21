using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;



namespace NETReflection
{
    public class NETReflect : IComponent
    {

        Assembly assembly;
        Type[] Types;

        private string ComponentPath;

        public NETReflect()
        {
            ComponentPath = "";
        }

        public NETReflect(string path)
        {
            ComponentPath = (path.Split(';'))[0];
        }

        public void loadAssembly()
        {
            if (ComponentPath != "")
            {
                assembly = Assembly.LoadFrom(ComponentPath);
                Types = assembly.GetTypes();
            }
        }

        private string GetPath()
        {
            return ComponentPath;
        }

        private void SetPath(string path)
        {
            ComponentPath = path;
        }

        public Dictionary<string, List<string>> inspectMethods()
        {
            Dictionary<string, List<string>> L_types = new Dictionary<string, List<string>>();
            foreach (Type t in Types)
            {
                List<string> methods=new List<string>();
                if (t.IsPublic)
                {
                    foreach (MethodInfo m in t.GetMethods(/*BindingFlags.Public*/))
                        if(m.IsPublic)
                            methods.Add(m.ReturnType.Name + " " + m.Name+ " "+ t.Name);

                    L_types[t.FullName] = methods;
                }
            }
            return L_types;
        }
        public Dictionary<string, List<string>> inspectClasses()
        {
            Dictionary<string, List<string>> L_types = new Dictionary<string, List<string>>();
            foreach (Type t in Types)
            {
                List<string> classes = new List<string>();
                if (t.IsPublic&&!t.IsInterface)
                {
                    classes.Add(t.Name);

                    L_types[t.FullName] = classes;
                }
            }
            return L_types;
        }
        public Dictionary<string, List<string>> inspectInterfaces()
        {
            Dictionary<string, List<string>> L_types = new Dictionary<string, List<string>>();
            foreach (Type t in Types)
            {
                List<string> interfaces = new List<string>();
                if (t.IsPublic)
                {
                    foreach (Type interf in t.GetInterfaces())
                            interfaces.Add(interf.Name);
                            L_types[t.FullName] = interfaces;
                }
            }
            return L_types;
        }
    
    }
}
