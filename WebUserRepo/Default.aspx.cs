using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repository;
using System.Net;

namespace WebUserRepo
{
    public partial class _Default : System.Web.UI.Page
    {
        IWebUserRepository webRepo;
        static List<string> compList;
        static DataTable dt;
        static DataTable dt2;
        static DataTable dt3;
        static DataTable dt4;
        static int count = 0;
        static int initializeInspectTables = 0;
        static string rootPath;
        static string componenentsPath;
        protected void Page_Load(object sender, EventArgs e)
        {   
            string path = Server.MapPath("/");
            string tobesearched = "WebUserRepo\\";
            rootPath = path.Substring(0,path.IndexOf(tobesearched));
            componenentsPath = rootPath + "\\ComponentsToInspect\\";
            string dbPath = rootPath + "\\BackEndLibraries\\Repository.mdb";
            webRepo = new Components(dbPath);
            
            Label1.Text = rootPath;
            compList = webRepo.GetComponents(null);
            if (count==0) {
                initializeTable();
            }
            
            
             
           
        }
        protected void showList() {
            string[] singleComp;
            foreach (string comp in compList)
            {    
                singleComp = comp.Split(';');
                dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4]);
            }

            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
        protected void initializeTable() {
        
            count = 1;
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] { 
                            new DataColumn("Id",typeof(string)),
                            new DataColumn("Name", typeof(string)),
                            new DataColumn("Description",typeof(string)),
                            new DataColumn("Path",typeof(string)),                        
                            new DataColumn("Type", typeof(string))});
           

            showList();
           
        }
        protected void checkBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAll.Checked)
            {
                initializeTable();
                checkBoxNET.Checked = false;
                checkBoxJava.Checked = false;
                checkBoxCOM.Checked = false;
                compList = webRepo.GetComponents(null);
                checkBoxCOM.Enabled = false;
                checkBoxJava.Enabled = false;
                checkBoxNET.Enabled = false;
            }
            else
            {
                checkBoxCOM.Enabled = true;
                checkBoxJava.Enabled = true;
                checkBoxNET.Enabled = true;
            }
        }

        protected void checkBoxJava_CheckedChanged(object sender, EventArgs e)
        {
            string[] singleComp;
            if (checkBoxJava.Checked)
            {
                dt.Clear();

                foreach (string comp in compList)
                {

                    singleComp = comp.Split(';');
                    if (singleComp[4] == "JAVA")
                    {
                        dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4]);
                    }
                }
                if (checkBoxCOM.Checked)
                {
                    foreach (string comp in compList)
                    {

                        singleComp = comp.Split(';');
                        if (singleComp[4] == "COM")
                        {
                            dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4]);
                        }
                    }
                }
                if (checkBoxNET.Checked)
                {
                    foreach (string comp in compList)
                    {

                        singleComp = comp.Split(';');
                        if (singleComp[4] == "NET")
                        {
                            dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4]);
                        }
                    }
                }
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
            else
            {
                dt.Clear();
                if (checkBoxCOM.Checked)
                {
                    foreach (string comp in compList)
                    {

                        singleComp = comp.Split(';');
                        if (singleComp[4] == "COM")
                        {
                            dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4]);
                        }
                    }
                }
                if (checkBoxNET.Checked)
                {
                    foreach (string comp in compList)
                    {

                        singleComp = comp.Split(';');
                        if (singleComp[4] == "NET")
                        {
                            dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4]);
                        }
                    }
                }
                GridView2.DataSource = dt;
                GridView2.DataBind();
                if ((!checkBoxAll.Checked) && (!checkBoxJava.Checked) && (!checkBoxCOM.Checked) && (!checkBoxNET.Checked)) {
                showList();
            }
            }
        }

        protected void checkBoxCOM_CheckedChanged(object sender, EventArgs e)
        {
            string[] singleComp;
            if (checkBoxCOM.Checked)
            {
                dt.Clear();
                foreach (string comp in compList)
                {

                    singleComp = comp.Split(';');
                    if (singleComp[4] == "COM")
                    {
                        dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4]);
                    }
                }
                if (checkBoxJava.Checked)
                {
                    foreach (string comp in compList)
                    {

                        singleComp = comp.Split(';');
                        if (singleComp[4] == "JAVA")
                        {
                            dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4]);
                        }
                    }
                }
                if (checkBoxNET.Checked)
                {
                    foreach (string comp in compList)
                    {

                        singleComp = comp.Split(';');
                        if (singleComp[4] == "NET")
                        {
                            dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4]);
                        }
                    }
                }
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
            else {
                dt.Clear();
                if (checkBoxJava.Checked)
                {
                    foreach (string comp in compList)
                    {

                        singleComp = comp.Split(';');
                        if (singleComp[4] == "JAVA")
                        {
                            dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4]);
                        }
                    }
                }
                if (checkBoxNET.Checked)
                {
                    foreach (string comp in compList)
                    {

                        singleComp = comp.Split(';');
                        if (singleComp[4] == "NET")
                        {
                            dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4]);
                        }
                    }
                }
                GridView2.DataSource = dt;
                GridView2.DataBind();
                if ((!checkBoxAll.Checked) && (!checkBoxJava.Checked) && (!checkBoxCOM.Checked) && (!checkBoxNET.Checked))
                {
                    showList();
                }
            }
        
        }

        protected void checkBoxNET_CheckedChanged(object sender, EventArgs e){
            string[] singleComp;
            if (checkBoxNET.Checked)
            {
                dt.Clear();
                foreach (string comp in compList)
                {

                    singleComp = comp.Split(';');
                    if (singleComp[4] == "NET")
                    {
                        dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4]);
                    }
                }
                if (checkBoxJava.Checked)
                {
                    foreach (string comp in compList)
                    {

                        singleComp = comp.Split(';');
                        if (singleComp[4] == "JAVA")
                        {
                            dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4]);
                        }
                    }
                }
                if (checkBoxCOM.Checked)
                {
                    foreach (string comp in compList)
                    {

                        singleComp = comp.Split(';');
                        if (singleComp[4] == "COM")
                        {
                            dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4]);
                        }
                    }
                }
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
            else {
                dt.Clear();
                if (checkBoxJava.Checked)
                {
                    foreach (string comp in compList)
                    {

                        singleComp = comp.Split(';');
                        if (singleComp[4] == "JAVA")
                        {
                            dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4]);
                        }
                    }
                }
                if (checkBoxCOM.Checked)
                {
                    foreach (string comp in compList)
                    {

                        singleComp = comp.Split(';');
                        if (singleComp[4] == "COM")
                        {
                            dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4]);
                        }
                    }
                }
                GridView2.DataSource = dt;
                GridView2.DataBind();
                if ((!checkBoxAll.Checked) && (!checkBoxJava.Checked) && (!checkBoxCOM.Checked) && (!checkBoxNET.Checked))
                {
                    showList();
                }
            }
        
        }
        protected void InitializeInspectTables() {
            initializeInspectTables = 1;
            dt2 = new DataTable();
            dt2.Columns.AddRange(new DataColumn[3] { 
                            new DataColumn("Class Name",typeof(string)),
                            new DataColumn("Return type",typeof(string)),
                            new DataColumn("Method Name",typeof(string))});

            dt3 = new DataTable();
            dt3.Columns.AddRange(new DataColumn[1] { 
                            new DataColumn("Interfaces",typeof(string))});
            dt4 = new DataTable();
            dt4.Columns.AddRange(new DataColumn[1] { 
                            new DataColumn("Classes",typeof(string))});
        }
        protected void ClearInspectTables() {
            Label3.Visible = false;
            Label4.Visible = false;
            dt2.Clear();
            dt3.Clear();
            dt4.Clear();
            GridView3.DataSource = null;
            GridView5.DataSource = null;
            GridView4.DataSource = null;
            GridView3.DataBind();
            GridView4.DataBind();
            GridView5.DataBind();

        }
        protected void InspectNetComponent(string compname) {
            Dictionary<string, List<string>> InspectResult = webRepo.inspectNETMethods(componenentsPath+compname);
            Dictionary<string, List<string>> InspectResultInterf = webRepo.inspectNETInterfaces(componenentsPath+compname);
            Dictionary<string, List<string>> classes = webRepo.inspectNETClasses(componenentsPath+compname);
            foreach (KeyValuePair<string, List<string>> k in classes)
            {
                foreach (string s in k.Value)
                {
                    dt4.Rows.Add(s);
                }
                GridView5.DataSource = dt4;
                GridView5.DataBind();
            }
            foreach (KeyValuePair<string, List<string>> k in InspectResult)
            {
                foreach (string s in k.Value)
                {
                   dt2.Rows.Add(s.Split(' ')[2], s.Split(' ')[0], s.Split(' ')[1]);
                }
                GridView3.DataSource = dt2;
                GridView3.DataBind();
            }
            foreach (KeyValuePair<string, List<string>> k in InspectResultInterf)
            {
                foreach (string s in k.Value)
                {
                    dt3.Rows.Add(s);
                }
                GridView4.DataSource = dt3;
                GridView4.DataBind();
            }
        }
        protected void InspectCOMComponent(string component)
        {
            Dictionary<string, List<string>> InspectResult = webRepo.inspectCOMMethods(rootPath, component);
            Dictionary<string, List<string>> InspectResultInterf = webRepo.inspectCOMInterfaces(rootPath, component);
            Dictionary<string, List<string>> classes = webRepo.inspectCOMClasses(rootPath, component);
            foreach (KeyValuePair<string, List<string>> k in classes)
            {
                foreach (string s in k.Value)
                {
                    dt4.Rows.Add(s);
                }
                GridView5.DataSource = dt4;
                GridView5.DataBind();
            }
            foreach (KeyValuePair<string, List<string>> k in InspectResult)
            {
                foreach (string s in k.Value)
                {
                    dt2.Rows.Add(s.Split(' ')[2], s.Split(' ')[0], s.Split(' ')[1]);
                }
                GridView3.DataSource = dt2;
                GridView3.DataBind();
            }
            foreach (KeyValuePair<string, List<string>> k in InspectResultInterf)
            {
                foreach (string s in k.Value)
                {
                    dt3.Rows.Add(s);
                }
                GridView4.DataSource = dt3;
                GridView4.DataBind();
            }
        }

        protected void Inspect(object sender, EventArgs e)
        {
            if (initializeInspectTables == 0)
            {
                InitializeInspectTables();
            }
            GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
            ClearInspectTables();
            Label3.Visible = true;
            Label3.Text ="Component: "+ row.Cells[2].Text;
            Label4.Visible = true;
            Label4.Text = "Methods:";
            if (row.Cells[5].Text == "NET")
            {
                InspectNetComponent(row.Cells[2].Text);
            }
            else
            {
                if (row.Cells[5].Text == "COM") {
                    InspectCOMComponent(row.Cells[2].Text);
                }
               
            }
        }

        protected void a() { Label2.Text = rootPath;
        Label1.Text = rootPath;
        }
        
        protected void Download(object sender, EventArgs e) {

          
            GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
            this.Label1.Text = componenentsPath + row.Cells[2].Text;
            Label2.Text = rootPath + row.Cells[2].Text;
            Label2.DataBind();
            Label1.DataBind();
            String filePath = rootPath + row.Cells[2].Text;
            Response.AppendHeader("content-disposition", "attachment; filename=" + filePath.Trim().Split('\\').Last());
            Response.ContentType = "application/octet-stream";
            Response.WriteFile(filePath.Trim());
            Response.Flush();
            Response.End();
            ClearInspectTables();
            this.a();
        }



     
        
        
            
      }
   }
        



       
        
        

