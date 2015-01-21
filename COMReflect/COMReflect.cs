using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace COMReflection
{
    public class COMReflect : IComponent
    {
        
        Type[] Types;
        private string ComponentPath;
        Assembly assembly;
        static string rootpath;


        public COMReflect()
        {
            ComponentPath = "";
        }

        public COMReflect(string path)
        {
            string[] s = path.Split(';');
            ComponentPath = Path.GetFullPath(s[0]);
            rootpath=s[1];
        }

        public Dictionary<string, List<string>> inspectMethods()
        {
            Dictionary<string, List<string>> L_types = new Dictionary<string, List<string>>();
            foreach (Type t in Types)
            {
                List<string> methods = new List<string>();
                if (t.IsPublic)
                {
                    foreach (MethodInfo m in t.GetMethods())
                        if (m.IsPublic)
                            methods.Add(m.ReturnType.Name + " " + m.Name+ " "+t.Name);

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
                if (t.IsPublic && !t.IsInterface)
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

        public void loadAssembly(/*string path*/)
        {
            string targetDir = Path.GetDirectoryName(ComponentPath)+ "\\COMToInspect";
            string targetFile;
            if (ComponentPath != "")
            {
                string ext = Path.GetExtension(ComponentPath);
                if (ext == ".tlb")
                {
                    string commandstr;
                    targetFile = targetDir + "\\" + (Path.GetFileName(ComponentPath));
                    targetFile = Path.ChangeExtension(targetFile, ".dll");
                    commandstr = "\"" + ComponentPath + "\" /out:\"" + targetFile+ "\"";
                    string tlbimp;
                    tlbimp = rootpath+"\\TlbImp.exe";

                    Process proc = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = tlbimp,
                            Arguments = commandstr,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            CreateNoWindow = true
                        }
                    };
                    proc.Start();
                    proc.WaitForExit();
                    proc.Close();
                    proc.Dispose();
                    ComponentPath = targetFile;
                    assembly = Assembly.LoadFrom(ComponentPath);
                    Types = assembly.GetTypes();
                    //THIS PART OF CODE DOESN'T WORK, STILL TO FIX
                    /*if (File.Exists(@ComponentPath))
                    {
                        DirectoryInfo dInfo = new DirectoryInfo(Path.GetDirectoryName(ComponentPath));
                        SecurityIdentifier everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
                        FileSystemAccessRule fsar = new FileSystemAccessRule(everyone, FileSystemRights.FullControl, AccessControlType.Allow);
                        FileSecurity fs = File.GetAccessControl(ComponentPath);
                        fs.SetAccessRule(fsar);
                        File.SetAccessControl(ComponentPath,fs);
                        File.Delete(ComponentPath);
                    }*/
                }
                else
                {
                    assembly = Assembly.LoadFrom(ComponentPath);
                    Types = assembly.GetTypes();
                }
                
            }
        }
    }
}
