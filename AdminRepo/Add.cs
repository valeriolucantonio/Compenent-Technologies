using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AdminRepo
{
    public partial class Add : Form
    {
        Repository.IAdminRepository repository;
        string file;
        public Add(Repository.IAdminRepository repo)
        {
            repository = repo;
            InitializeComponent();
            CompPath.Enabled = false;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (CompName.Text != "" && CompPath.Text != "" && CompDesc.Text != "" && compType.Text != "")
            {
                if (repository.Add(CompName.Text, "ComponentsToInspect\\"+file, CompDesc.Text, compType.Text))
                {
                    if (!File.Exists("..\\..\\..\\ComponentsToInspect\\" + file))
                        File.Copy(CompPath.Text, "..\\..\\..\\ComponentsToInspect\\" + file );
                    this.Close();
                }
                else
                {
                    ErrorAdd.Text = "An error occured while Adding...";
                    ErrorAdd.ForeColor = Color.Red;
                    ErrorAdd.Visible = true;
                }
            }
            else
            {
                ErrorAdd.Text = "Please fill all the previous fields";
                ErrorAdd.ForeColor = Color.Red;
                ErrorAdd.Visible = true;
            }
        }

        private void browse_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            openFileDialog1.Multiselect = false;
            CompName.Text = Path.GetFileName(openFileDialog1.FileName);
            file = Path.GetFileName(openFileDialog1.FileName);
            CompPath.Text = openFileDialog1.FileName;
        }
    }
}
