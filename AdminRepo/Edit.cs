using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdminRepo
{
    public partial class Edit : Form
    {
        /*private Int32 ID;
        private string Name;
        private string Path;
        private string Desc;
        private string Type;*/

        private Repository.IAdminRepository repository;

        public Edit(Repository.IAdminRepository repo, string id, string name, string description, string path, string type)
        {
            repository = repo;
            InitializeComponent();
            CompID.Text = id;
            CompName.Text = name;
            CompPath.Text = path;
            CompDesc.Text = description;
            CompType.Text = type;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (CompName.Text != "" && CompPath.Text != "" && CompDesc.Text != "" && CompType.Text != "")
            {
                if (repository.Modify(Convert.ToInt32(CompID.Text), CompName.Text, CompPath.Text, CompDesc.Text, CompType.Text))
                    this.Close();
                else
                {
                    ErrorEdit.Text = "An error occured while editing...";
                    ErrorEdit.ForeColor = Color.Red;
                    ErrorEdit.Visible = true;
                }
            }
            else
            {
                ErrorEdit.Text = "Please fill all the fields";
                ErrorEdit.ForeColor = Color.Red;
                ErrorEdit.Visible = true;
            }
        }

        private void browse_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            openFileDialog1.Multiselect = false;
            CompPath.Text = openFileDialog1.FileName;
        }
    }
}
