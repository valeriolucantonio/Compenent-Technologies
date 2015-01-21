using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Repository;

namespace AdminRepo
{
    public partial class Admin : Form
    {
        private IAdminRepository adminRepo;
        private List<string> compList;
        private string pathDB = "..\\..\\..\\BackEndLibraries\\Repository.mdb";
        
        public Admin()
        {
            adminRepo = new Components(pathDB);
            InitializeComponent();
        }

        private void checkBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAll.Checked)
            {
                compList = null;
                compList = new List<string>();
                checkBoxNET.Checked = false;
                checkBoxJava.Checked = false;
                checkBoxCOM.Checked = false;
                compList = adminRepo.GetComponents(null);
                checkBoxCOM.Enabled = false;
                checkBoxJava.Enabled = false;
                checkBoxNET.Enabled = false;
            }
            else
            {
                compList = null;
                checkBoxCOM.Enabled = true;
                checkBoxJava.Enabled = true;
                checkBoxNET.Enabled = true;
            }
            updateList();
        }

        private void checkBoxJava_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxJava.Checked)
            {
                if (compList == null)
                {
                    compList = new List<string>();
                    compList = adminRepo.GetComponents("JAVA");
                }
                else
                {
                    List<string> aux = adminRepo.GetComponents("JAVA");
                    foreach (string c in aux)
                        compList.Add(c);
                }
            }
            else
            {
                List<string> ToRemove = new List<string>();
                foreach (string c in compList)
                {
                    string[] s = c.Split(';');
                    if (s[4] == "JAVA")
                        ToRemove.Add(c);
                }
                foreach (string c in ToRemove)
                    compList.Remove(c);
            }
            updateList();
        }

        private void checkBoxCOM_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCOM.Checked)
            {
                if (compList == null)
                {
                    compList = new List<string>();
                    compList = adminRepo.GetComponents("COM");
                }
                else
                {
                    List<string> aux= adminRepo.GetComponents("COM");
                    foreach(string c in aux)
                        compList.Add(c);
                }
            }
            else
            {
                List<string> ToRemove = new List<string>();
                foreach (string c in compList)
                {
                    string[] s = c.Split(';');
                    if (s[4] == "COM")
                        ToRemove.Add(c);
                }
                foreach (string c in ToRemove)
                    compList.Remove(c);
            }
            updateList();
        }

        private void checkBoxNET_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNET.Checked)
            {
                if (compList == null)
                {
                    compList = new List<string>();
                    compList = adminRepo.GetComponents("NET");
                }
                else
                {
                    List<string> aux = adminRepo.GetComponents("NET");
                    foreach (string c in aux)
                        compList.Add(c);
                }
            }
            else
            {
                List<string> ToRemove = new List<string>();
                foreach (string c in compList)
                {
                    string[] s = c.Split(';');
                    if (s[4] == "NET")
                        ToRemove.Add(c);
                }
                foreach (string c in ToRemove)
                    compList.Remove(c);
            }
            updateList();
        }


        

        private void updateList()
        {
            string[] singleComp;
            while (ComponentList.RowCount > 1)
            {
                for (int j = 6; j >= 0; j--)
                {
                    Control ToRemove = ComponentList.GetControlFromPosition(j, 1);
                    ComponentList.Controls.Remove(ToRemove);
                }
                ComponentList.RowCount--;
                ComponentList.Update();
            }
            if (compList!=null)
                foreach (string comp in compList)
                {
                    singleComp = comp.Split(';');
                    ComponentList.RowCount+=1;

                    for(int j=0 ; j<5 ; j++)
                    {
                        RichTextBox tb = new RichTextBox { Text = singleComp[j], BorderStyle = BorderStyle.None, Enabled = false, Height=100};
                        /*using (Graphics g = CreateGraphics())
                        {
                            tb.Height = (int)g.MeasureString(tb.Text, tb.Font, tb.Width).Height;
                        }*/
                        
                        ComponentList.Controls.Add(tb);
                    }

                    CustomizedLinkLabel Edit = new CustomizedLinkLabel(Convert.ToInt32(singleComp[0])) { Text = "Edit" };
                    CustomizedLinkLabel Delete = new CustomizedLinkLabel(Convert.ToInt32(singleComp[0])) { Text = "Delete" };
                    Delete.MouseClick += new MouseEventHandler(Delete_LinkClicked);
                    Edit.MouseClick += new MouseEventHandler(Edit_LinkClicked);

                    ComponentList.Controls.Add(Edit);
                    ComponentList.Controls.Add(Delete);
                }
        }

        private void Delete_LinkClicked(object sender, EventArgs e)
        {
            Int32 index = ((CustomizedLinkLabel)sender).ID;
            compList.Remove(searchInTheList(index));
            adminRepo.Delete(index);
            updateList();
        }

        private void Edit_LinkClicked(object sender, EventArgs e)
        {
            string[] comp = searchInTheList(((CustomizedLinkLabel)sender).ID).Split(';');
            Edit edit = new Edit(adminRepo, comp[0], comp[1], comp[2], comp[3], comp[4]);
            edit.Visible = true;
            edit.FormClosed += new FormClosedEventHandler(Edit_FormClosed);
        }

        private void Edit_FormClosed(object sender, EventArgs e)
        {
            compList = null;
            if (checkBoxAll.Checked)
            {
                checkBoxAll_CheckedChanged(sender, e);
            }

            if (checkBoxJava.Checked)
            {
                checkBoxJava_CheckedChanged(sender, e);
            }

            if (checkBoxCOM.Checked)
            {
                checkBoxCOM_CheckedChanged(sender, e);
            }

            if (checkBoxNET.Checked)
            {
                checkBoxNET_CheckedChanged(sender, e);
            }
        }

        private string searchInTheList(Int32 id)
        {
            foreach (string s in compList)
            {
                string[] aux = s.Split(';');
                if (Convert.ToInt32(aux[0]) == id)
                    return s;
            }
            return null;
        }

        private void AddComp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Add add = new Add(adminRepo);
            add.Visible = true;
            add.FormClosed += new FormClosedEventHandler(Add_FormClosed);
        }

        private void Add_FormClosed(object sender, EventArgs e)
        {
            compList = null;
            if (checkBoxAll.Checked)
            {
                checkBoxAll_CheckedChanged(sender, e);
            }

            if (checkBoxJava.Checked)
            {
                checkBoxJava_CheckedChanged(sender, e);
            }

            if (checkBoxCOM.Checked)
            {
                checkBoxCOM_CheckedChanged(sender, e);
            }

            if (checkBoxNET.Checked)
            {
                checkBoxNET_CheckedChanged(sender, e);
            }
        }



    }

    public class CustomizedLinkLabel : LinkLabel
    {
        public Int32 ID;
        public CustomizedLinkLabel(Int32 id)
        {
            ID = id;
        }
    }

}
