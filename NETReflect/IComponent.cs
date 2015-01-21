using System;

public interface IComponent
{
    System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> inspectClasses();
    System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> inspectInterfaces();
    System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> inspectMethods();
    void loadAssembly();
}
