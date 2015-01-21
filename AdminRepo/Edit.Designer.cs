namespace AdminRepo
{
    partial class Edit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.CompID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CompName = new System.Windows.Forms.TextBox();
            this.CompPath = new System.Windows.Forms.TextBox();
            this.CompDesc = new System.Windows.Forms.RichTextBox();
            this.CompType = new System.Windows.Forms.ComboBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.ErrorEdit = new System.Windows.Forms.Label();
            this.browse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Component ID :";
            // 
            // CompID
            // 
            this.CompID.AutoSize = true;
            this.CompID.Location = new System.Drawing.Point(90, 36);
            this.CompID.Name = "CompID";
            this.CompID.Size = new System.Drawing.Size(18, 13);
            this.CompID.TabIndex = 1;
            this.CompID.Text = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Component Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Component Description";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(288, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Component Path";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(286, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Component Type";
            // 
            // CompName
            // 
            this.CompName.Location = new System.Drawing.Point(15, 79);
            this.CompName.Name = "CompName";
            this.CompName.Size = new System.Drawing.Size(100, 20);
            this.CompName.TabIndex = 6;
            // 
            // CompPath
            // 
            this.CompPath.Location = new System.Drawing.Point(289, 52);
            this.CompPath.Name = "CompPath";
            this.CompPath.Size = new System.Drawing.Size(100, 20);
            this.CompPath.TabIndex = 7;
            // 
            // CompDesc
            // 
            this.CompDesc.Location = new System.Drawing.Point(15, 159);
            this.CompDesc.Name = "CompDesc";
            this.CompDesc.Size = new System.Drawing.Size(235, 151);
            this.CompDesc.TabIndex = 9;
            this.CompDesc.Text = "";
            // 
            // CompType
            // 
            this.CompType.FormattingEnabled = true;
            this.CompType.Items.AddRange(new object[] {
            "JAVA",
            "COM",
            "NET"});
            this.CompType.Location = new System.Drawing.Point(289, 159);
            this.CompType.Name = "CompType";
            this.CompType.Size = new System.Drawing.Size(121, 21);
            this.CompType.TabIndex = 10;
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(330, 270);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 11;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(473, 270);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 23);
            this.EditButton.TabIndex = 12;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // ErrorEdit
            // 
            this.ErrorEdit.AutoSize = true;
            this.ErrorEdit.Location = new System.Drawing.Point(277, 309);
            this.ErrorEdit.Name = "ErrorEdit";
            this.ErrorEdit.Size = new System.Drawing.Size(35, 13);
            this.ErrorEdit.TabIndex = 13;
            this.ErrorEdit.Text = "label2";
            this.ErrorEdit.Visible = false;
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(413, 49);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(75, 23);
            this.browse.TabIndex = 14;
            this.browse.Text = "Browse";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 322);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.ErrorEdit);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.CompType);
            this.Controls.Add(this.CompDesc);
            this.Controls.Add(this.CompPath);
            this.Controls.Add(this.CompName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CompID);
            this.Controls.Add(this.label1);
            this.Name = "Edit";
            this.Text = "Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CompID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CompName;
        private System.Windows.Forms.TextBox CompPath;
        private System.Windows.Forms.RichTextBox CompDesc;
        private System.Windows.Forms.ComboBox CompType;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Label ErrorEdit;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}