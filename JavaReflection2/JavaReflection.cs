using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaReflection2
{
    public class JavaReflection : IComponent
    {
        readonly Dictionary<string, string> pair = new Dictionary<string, string>();

        string dict;

        private string file_path;

        public JavaReflection(string path)
        {
            file_path = (path.Split(';'))[0];
        }

        public void loadAssembly(/*string file_path2*/)
        {
            //this.file_path = file_path2;
            Main m = new Main();
            dict = m.sinspect(file_path);
            //inspect();
        }

       /* public void loadAssembly()
        {
        }*/

        public void AddJVMOption(string name, string value)
        {
            if (!pair.ContainsKey(name))
                pair.Add(name, value);
        }

        /*public void inspect()
        {

            JavaNativeInterface Java = new JavaNativeInterface();
            // Set the path where the java class is located
            AddJVMOption("-Djava.class.path", AppDomain.CurrentDomain.BaseDirectory);
            string bla = AppDomain.CurrentDomain.BaseDirectory;
            System.Console.Error.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            Java.LoadVM(pair, false);


            /* WORKING
            Java.InstantiateJavaObject("Count");

            System.Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            System.Console.ReadLine();

            List<object> olParameters = new List<object>();
            olParameters.Add(3);
            olParameters.Add(4);
            //Java.CallVoidMethod("sum", "(II)I", olParameters);
            System.Console.WriteLine(Java.CallMethod<int>("sum", "(II)I", olParameters));
            System.Console.ReadLine();
            //

            // Here we make an object of the Java class
            Java.InstantiateJavaObject("Main");

            // Here we create list of parameters for the method that we will call
            List<object> olParameters = new List<object>();
            //olParameters.Add("C:/Users/filip/Documents/NetBeansProjects/MyEJBShop/build/MyEJBShop-ejb.jar");
            olParameters.Add(this.file_path);

            // Here we call the method from Java class called "sinspect" and it returns the string of the component inspection
            // info - classes and methods
            dict = Java.CallMethod<string>("sinspect", "(Ljava/lang/String;)Ljava/lang/String;", olParameters);
        }
    */

        public Dictionary<string, List<string>> inspectMethods()
        {
            return parseString(dict);
        }

        public Dictionary<string, List<string>> inspectClasses()
        {
            Dictionary<string, List<string>> classes = new Dictionary<string, List<string>>();
            List<string> classNames = new List<string>();

            foreach (KeyValuePair<string, List<string>> entry in parseString(dict))
            {
                if (entry.Key.Contains("class"))
                {
                    classNames.Add(entry.Key.Replace("class:", ""));
                }
            }
            classes["java"] = classNames;
            return classes;
        }

        public Dictionary<string, List<string>> inspectInterfaces()
        {
            Dictionary<string, List<string>> interfaces = new Dictionary<string, List<string>>();
            List<string> interfaceNames = new List<string>();

            foreach (KeyValuePair<string, List<string>> entry in parseString(dict))
            {
                if (entry.Key.Contains("interface"))
                {
                    interfaceNames.Add(entry.Key.Replace("interface:", ""));
                }
            }
            interfaces["java"] = interfaceNames;
            return interfaces;
        }

        // This methods converts the string that we get from java class and it fills the Dictionary.. 
        public Dictionary<string, List<string>> parseString(string sx)
        {
            sx = sx.Replace("[", "");
            sx = sx.Replace("]", "");
            var items = sx.Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Split(new[] { '=' }));

            // dictionary that is filled
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            foreach (var item in items)
            {
                List<string> list = new List<string>();

                string[] words = item[1].Split(',');
                foreach (string word in words)
                {
                    list.Add(word);
                }

                dict.Add(item[0], list);
            }

            return dict;
        }
    }
}
