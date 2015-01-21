using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Data;

namespace BackEndLibraries
{
    public class Component
    {

        // Constants
        private String StrCon = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=..\\..\\..\\BackEndLibraries\\bin\\Debug\\Repository.mdb"; // Fix relative path problem
        private const String Create = "INSERT INTO ComponentRepository (Name, Description, Path, Type) VALUES (@name, @desc, @fp, @type)";
        private const String Modify = "UPDATE ComponentRepository SET";

        // Component Object Variables
        private Int32 ID;
        private String Name;
        private String Description;
        private String Path;
        private int Download_counter;
        private String Type;
        //private String Date_added;
        private string DB_path;

        // Constructs
        public Component(string pathDB){
            DB_path = pathDB;
            if (pathDB != null)
                StrCon = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + pathDB;
            this.ID = -1;
            this.Name = null;
            this.Description = null;
            this.Path = null;
            //this.Date_added = "NULL";
            this.Download_counter = 0;
            this.Type = null;
        }

        public Component(string pathDB, int Id)
        {
            this.ID = Id;
            if (pathDB != null)
                StrCon = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + pathDB;
        }

        public Component(string pathDB, String name, String description, String path, String type)
        {

            if (pathDB != null)
                StrCon = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + pathDB;
            this.Name = name;
            this.Description = description;
            this.Path = path;
            this.Download_counter = 0;
            this.Type = type;

            // This must be changed
            //this.Date_added = "NULL";


         }

        // Object Methods

        public void modify(int Id, string name, string path, string description, string type)
        {
            using (OleDbConnection connexion = new OleDbConnection(StrCon))
            {
                connexion.Open();
                OleDbCommand com = connexion.CreateCommand();
                com.CommandText = Modify + " Name = '" + name + "', Description = '" + description + "', Path = '" + path + "', Type = '" + type + "' WHERE ID =" + Id + ";";

                try
                {
                    com.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connexion.Close();
                }
            
            }

        }

        public void updateDownload(int id)
        {
            using (OleDbConnection connexion = new OleDbConnection(StrCon))
            {
                connexion.Open();
                OleDbCommand com = connexion.CreateCommand();
                com.CommandText = "UPDATE ComponentRepository SET Download=Download +" + 1 + " WHERE Id=" + id + ";";


                try
                {
                    com.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connexion.Close();
                }

            }

        }

        public void store()
        {
            using (OleDbConnection conexion = new OleDbConnection(StrCon))
            {
                // Open conexion with the database
                conexion.Open();

                // Create the command SQL that we are gonna use
                OleDbCommand com = conexion.CreateCommand();

                com.CommandText = Create;

                com.Parameters.Add("@name", this.Name);
                com.Parameters.Add("@desc", this.Description);
                com.Parameters.Add("@fp", this.Path);
                //com.Parameters.Add("@da", this.Date_added);
                //com.Parameters.Add("@dc", this.Download_counter);
                com.Parameters.Add("@type", this.Type);

                // Execute the command

                try
                {
                    com.ExecuteNonQuery();
                 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    conexion.Close();
                }
            }
        }
        public void delete()
        {
   
            using (OleDbConnection conexion = new OleDbConnection(StrCon))
            {
                conexion.Open();
                OleDbCommand com = conexion.CreateCommand();

                com.CommandText = "DELETE FROM ComponentRepository WHERE ID=" + this.ID;
                try
                {
                    com.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    conexion.Close();
                }
            }
            
        }

    

        // Class Methods
        public List<Component> getComponentList()
        {
            //Get all components


                List<Component> auxList = new List<Component>();
                Component aux = null;

                string query = "SELECT * FROM ComponentRepository";
                //OleDbConnection conn = new OleDbConnection(StrCon);

                // Read all the table
                OleDbConnection conexion;
                OleDbDataReader rdr;

                /*SqlEngine engine = new SqlEngine(StrCon);
                engine.Upgrade();*/

                try
                {

                    conexion = new OleDbConnection(StrCon);
                    OleDbCommand cmd = new OleDbCommand(query, conexion);
                    conexion.Open();
                    rdr = cmd.ExecuteReader();
                    // Iterate through the results
                    while (rdr.Read())
                    {
                        // Create the component
                        aux = new Component(DB_path);

                        string type = Convert.ToString(rdr.GetValue(0).GetType());

                        aux.ID = Convert.ToInt32(rdr.GetInt32(0));
                        aux.Name = rdr.GetString(1);
                        aux.Description = rdr.GetString(2);
                        aux.Path = rdr.GetString(3);
                        aux.setType(rdr.GetString(4));
                        //aux.Date_added = rdr.GetString(4);
                        aux.Download_counter = rdr.GetInt32(5);
                        /*if (!rdr.IsDBNull(6))
                        {
                            aux.Type = rdr.GetString(6);
                        }*/

                        // Add the component to the list
                        auxList.Add(aux);
                        Console.WriteLine(aux.toString());
                        
                    }
                    rdr.Close();
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    Component c = new Component(DB_path);
                    c.setDescription(ex.Message);
                    auxList.Add(c);
                    Console.WriteLine(ex.ToString());
                }
                /*finally
                {
                    // Always call Close when done reading
                    //rdr.Close();

                    // Always call Close when done reading
                    //conexion.Close();
                }*/
            
                return auxList;
            
            
        }

        public List<Component> getComponentListByName(String name)
        {
            //Get components Name == name

            List<Component> auxList = new List<Component>();
            Component aux = null;

            string query = "SELECT * FROM component WHERE Name='" + name + "'";
            OleDbConnection conn = new OleDbConnection(StrCon);
            OleDbCommand cmd = new OleDbCommand(query, conn);

            conn.Open();
            OleDbDataReader rdr = cmd.ExecuteReader();


            try
            {
                // Iterate through the results
                //
                while (rdr.Read())
                {
                    aux = new Component(DB_path);

                    aux.ID = rdr.GetInt32(0);
                    aux.Name = rdr.GetString(1);
                    aux.Description = rdr.GetString(2);
                    aux.Path = rdr.GetString(3);
                    //aux.Date_added = rdr.GetString(4);
                    //aux.Download_counter = rdr.GetInt32(5);
                    if (!rdr.IsDBNull(6))
                    {
                        aux.Type = rdr.GetString(6);
                    }

                    auxList.Add(aux);
                    Console.WriteLine(aux.toString());
                }
            }
            finally
            {
                // Always call Close when done reading
                rdr.Close();

                // Always call Close when done reading
                conn.Close();
            }

            return auxList;
        }
        public List<Component> getComponentListByType(String type)
        {

            //Get components Type == type


            /*SqlCeEngine engine = new SqlCeEngine(StrCon);
            engine.Upgrade();*/

            List<Component> auxList = new List<Component>();
            Component aux = null;

            string query = "SELECT * FROM ComponentRepository WHERE Type='" + type + "'";
            OleDbConnection conn = new OleDbConnection(StrCon);
            OleDbCommand cmd = new OleDbCommand(query, conn);

            conn.Open();
            OleDbDataReader rdr = cmd.ExecuteReader();


            try
            {
                // Iterate through the results
                //
                while (rdr.Read())
                {
                    aux = new Component(DB_path);

                    aux.ID = rdr.GetInt32(0);
                    aux.Name = rdr.GetString(1);
                    aux.Description = rdr.GetString(2);
                    aux.Path = rdr.GetString(3);
                    aux.setType(rdr.GetString(4));
                    //aux.Date_added = rdr.GetString(4);
                    //aux.Download_counter = rdr.GetInt32(5);
                    /*if (!rdr.IsDBNull(6))
                    {
                        aux.Type = rdr.GetString(6);
                    }*/

                    auxList.Add(aux);
                    Console.WriteLine(aux.toString());
                }
            }
            finally
            {
                // Always call Close when done reading
                rdr.Close();

                // Always call Close when done reading
                conn.Close();
            }
            return auxList;
        }
        

        // Not sure if it's useful
        private Component getComponent(int id)
        {
            Component aux = new Component(DB_path);

            string query = "SELECT * FROM component WHERE id LIKE " + id;
            OleDbConnection conn = new OleDbConnection(StrCon);
            OleDbCommand cmd = new OleDbCommand(query, conn);
           
            conn.Open();

            OleDbDataReader rdr = null;
            try
            {
                rdr = cmd.ExecuteReader();
                rdr.Read();

                aux.ID = rdr.GetInt32(0);
                aux.Name = rdr.GetString(1);
                aux.Description = rdr.GetString(2);
                aux.Path = rdr.GetString(3);
                //aux.Date_added = rdr.GetString(4);
                //aux.Download_counter = rdr.GetInt32(5);
                if (!rdr.IsDBNull(6))
                {
                    aux.Type = rdr.GetString(6);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                // Always call Close when done reading
                rdr.Close();

                // Always call Close when done reading
                conn.Close();
            }

            return aux;
        }


     
        // Getters and Setters

        public int getID(){
            return this.ID;
        }
        public String getName()
        {
            return this.Name;
        }
        public String getDescription()
        {
            return this.Description;
        }
        public String getPath()
        {
            return this.Path;
        }
        public int getDownload_counter()
        {
            return this.Download_counter;
        }
        public String getType()
        {
            return this.Type;
        }
        public void setID(int id)
        {
            this.ID=id;
        }
        public void setName(String name)
        {
            this.Name = name;
        }
        public void setDescription(String description)
        {
            this.Description = description;
        }
        public void getPath(String path)
        {
            this.Path = path;
        }
        /*public void setDownload_counter(int dc)
        {
            this.Download_counter = dc;
        }*/
        public void setType(String type)
        {
            this.Type = type;
        }

        public String toString()
        {
            return "Id: " + this.ID + " / Name: " + this.Name + " / Description: " + this.Description + " / Path: " + this.Path + /*" / Date_Added: " + this.Date_added + " / DC: " + this.Download_counter +*/ " / Type: " + this.Type;
        }

    }
}
