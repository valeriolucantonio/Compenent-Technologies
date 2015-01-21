using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repository;
using JavaReflection2;
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
            Label2.Visible = false;
            string path = Server.MapPath("/");
            string tobesearched = "WebUserRepo\\";
            rootPath = path.Substring(0,path.IndexOf(tobesearched));
            componenentsPath = rootPath + "\\ComponentsToInspect\\";
            string dbPath = rootPath + "\\BackEndLibraries\\Repository.mdb";
            webRepo = new Components(dbPath, rootPath);
            
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
                dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4], singleComp[5]);
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
                            new DataColumn("Type", typeof(string)),
                            new DataColumn("Num Download", typeof(string))});
           

            showList();
        }

        protected void checkBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            ClearInspectTables();
            if (checkBoxAll.Checked)
            {
                compList = webRepo.GetComponents(null);
                initializeTable();
                checkBoxNET.Checked = false;
                checkBoxJava.Checked = false;
                checkBoxCOM.Checked = false;
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
            ClearInspectTables();
            if (checkBoxJava.Checked)
            {
                dt.Clear();

                foreach (string comp in compList)
                {

                    singleComp = comp.Split(';');
                    if (singleComp[4] == "JAVA")
                    {
                        dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4], singleComp[5]);
                    }
                }
                if (checkBoxCOM.Checked)
                {
                    foreach (string comp in compList)
                    {

                        singleComp = comp.Split(';');
                        if (singleComp[4] == "COM")
                        {
                            dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4], singleComp[5]);
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
                            dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4], singleComp[5]);
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
                            dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4], singleComp[5]);
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
                            dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4], singleComp[5]);
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
            ClearInspectTables();
            string[] singleComp;
            if (checkBoxCOM.Checked)
            {
                dt.Clear();
                foreach (string comp in compList)
                {

                    singleComp = comp.Split(';');
                    if (singleComp[4] == "COM")
                    {
                        dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4], singleComp[5]);
                    }
                }
                if (checkBoxJava.Checked)
                {
                    foreach (string comp in compList)
                    {

                        singleComp = comp.Split(';');
                        if (singleComp[4] == "JAVA")
                        {
                            dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4], singleComp[5]);
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
                            dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4], singleComp[5]);
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
                            dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4], singleComp[5]);
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
                            dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4], singleComp[5]);
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
            ClearInspectTables();
            if (checkBoxNET.Checked)
            {
                dt.Clear();
                foreach (string comp in compList)
                {

                    singleComp = comp.Split(';');
                    if (singleComp[4] == "NET")
                    {
                        dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4], singleComp[5]);
                    }
                }
                if (checkBoxJava.Checked)
                {
                    foreach (string comp in compList)
                    {

                        singleComp = comp.Split(';');
                        if (singleComp[4] == "JAVA")
                        {
                            dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4], singleComp[5]);
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
                            dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4], singleComp[5]);
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
                            dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4], singleComp[5]);
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
                            dt.Rows.Add(singleComp[0], singleComp[1], singleComp[2], singleComp[3], singleComp[4], singleComp[5]);
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
            try
            {
                Label3.Visible = false;
                Label4.Visible = false;
                dt2.Clear();
                dt3.Clear();
                dt4.Clear();
                dt2.AcceptChanges();
                dt3.AcceptChanges();
                dt4.AcceptChanges();
                GridView3.DataSource = null;
                GridView5.DataSource = null;
                GridView4.DataSource = null;
                GridView3.DataBind();
                GridView4.DataBind();
                GridView5.DataBind();
            }
            catch(Exception e) { }
        }
        protected void InspectComponent(Int32 id) {
            Dictionary<string, List<string>> InspectResult = webRepo.inspectMethods(id);
            Dictionary<string, List<string>> InspectResultInterf = webRepo.inspectInterfaces(id);
            Dictionary<string, List<string>> classes = webRepo.inspectClasses(id);
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
                try
                {
                    foreach (string s in k.Value)
                    {
                        dt2.Rows.Add(s.Split(' ')[2], s.Split(' ')[0], s.Split(' ')[1]);
                    }
                }
                catch
                {
                    foreach (string s in k.Value)
                    {
                        string j = s;
                        if (s.StartsWith(" "))
                        {
                            j = s.Substring(1, s.Length - 1);
                        }
                        if (s == "")
                        {
                            j = "empty empty";
                        }
                        dt2.Rows.Add(k.Key.Replace("class:", "").Replace("interface:", ""), j.Split(' ')[0], j.Split(' ')[1]);
                    }
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

                InspectComponent(Convert.ToInt32(row.Cells[1].Text));
            
        }

        protected void a() { Label2.Text = rootPath;
        Label1.Text = rootPath;
        }

        protected void Download(object sender, EventArgs e)
        {
            /* ClearInspectTables() does not have any effect in this method...
             * this.ClearInspectTables();*/
            GridViewRow row = (GridViewRow)((LinkButton)sender).NamingContainer;
            int idD = Convert.ToInt32(row.Cells[1].Text);
            webRepo.UpdateDownload(idD);
            String filePath = rootPath + row.Cells[4].Text;
            Response.AppendHeader("content-disposition", "attachment; filename=" + filePath.Trim().Split('\\').Last());
            Response.ContentType = "application/octet-stream";
            Response.WriteFile(filePath.Trim());
            Response.Flush();
            Response.End();
        }     
      }
   }
        



       
        
        

