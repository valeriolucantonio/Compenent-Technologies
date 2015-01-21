using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public interface IAdminRepository
    {
        bool Add(string name, string path, string description, string type);
        bool Delete(int id);
        bool Modify(int id, string name, string path, string description, string type);
        List<string> GetComponents(string type);
    }
   
}
