namespace AdminRepo
{
    partial class Add
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CompName = new System.Windows.Forms.TextBox();
            this.CompPath = new System.Windows.Forms.TextBox();
            this.CompDesc = new System.Windows.Forms.RichTextBox();
            this.compType = new System.Windows.Forms.ComboBox();
            this.Cancel = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.ErrorAdd = new System.Windows.Forms.Label();
            this.browse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Component Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Component Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(383, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Component Path";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(383, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Component Type";
            // 
            // CompName
            // 
            this.CompName.Location = new System.Drawing.Point(30, 70);
            this.CompName.Name = "CompName";
            this.CompName.Size = new System.Drawing.Size(100, 20);
            this.CompName.TabIndex = 4;
            // 
            // CompPath
            // 
            this.CompPath.Location = new System.Drawing.Point(386, 70);
            this.CompPath.Name = "CompPath";
            this.CompPath.Size = new System.Drawing.Size(181, 20);
            this.CompPath.TabIndex = 5;
            // 
            // CompDesc
            // 
            this.CompDesc.Location = new System.Drawing.Point(30, 197);
            this.CompDesc.Name = "CompDesc";
            this.CompDesc.Size = new System.Drawing.Size(261, 144);
            this.CompDesc.TabIndex = 7;
            this.CompDesc.Text = "";
            // 
            // compType
            // 
            this.compType.FormattingEnabled = true;
            this.compType.Items.AddRange(new object[] {
            "JAVA",
            "COM",
            "NET"});
            this.compType.Location = new System.Drawing.Point(386, 197);
            this.compType.Name = "compType";
            this.compType.Size = new System.Drawing.Size(121, 21);
            this.compType.TabIndex = 8;
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(432, 301);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 9;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(573, 301);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 10;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ErrorAdd
            // 
            this.ErrorAdd.AutoSize = true;
            this.ErrorAdd.Location = new System.Drawing.Point(311, 341);
            this.ErrorAdd.Name = "ErrorAdd";
            this.ErrorAdd.Size = new System.Drawing.Size(35, 13);
            this.ErrorAdd.TabIndex = 11;
            this.ErrorAdd.Text = "label5";
            this.ErrorAdd.Visible = false;
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(573, 67);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(75, 23);
            this.browse.TabIndex = 12;
            this.browse.Text = "Browse";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 353);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.ErrorAdd);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.compType);
            this.Controls.Add(this.CompDesc);
            this.Controls.Add(this.CompPath);
            this.Controls.Add(this.CompName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Add";
            this.Text = "New Component";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox CompName;
        private System.Windows.Forms.TextBox CompPath;
        private System.Windows.Forms.RichTextBox CompDesc;
        private System.Windows.Forms.ComboBox compType;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label ErrorAdd;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}