namespace AdminRepo
{
    partial class Admin
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
            this.checkBoxAll = new System.Windows.Forms.CheckBox();
            this.checkBoxJava = new System.Windows.Forms.CheckBox();
            this.checkBoxCOM = new System.Windows.Forms.CheckBox();
            this.checkBoxNET = new System.Windows.Forms.CheckBox();
            this.ComponentList = new System.Windows.Forms.TableLayoutPanel();
            this.CompID = new System.Windows.Forms.Label();
            this.CompName = new System.Windows.Forms.Label();
            this.CompType = new System.Windows.Forms.Label();
            this.CompEdit = new System.Windows.Forms.Label();
            this.CompDelete = new System.Windows.Forms.Label();
            this.CompDesc = new System.Windows.Forms.Label();
            this.CompPath = new System.Windows.Forms.Label();
            this.AddComp = new System.Windows.Forms.LinkLabel();
            this.ComponentList.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Get components by type : ";
            // 
            // checkBoxAll
            // 
            this.checkBoxAll.AutoSize = true;
            this.checkBoxAll.Location = new System.Drawing.Point(161, 16);
            this.checkBoxAll.Name = "checkBoxAll";
            this.checkBoxAll.Size = new System.Drawing.Size(37, 17);
            this.checkBoxAll.TabIndex = 1;
            this.checkBoxAll.Text = "All";
            this.checkBoxAll.UseVisualStyleBackColor = true;
            this.checkBoxAll.CheckedChanged += new System.EventHandler(this.checkBoxAll_CheckedChanged);
            // 
            // checkBoxJava
            // 
            this.checkBoxJava.AutoSize = true;
            this.checkBoxJava.Location = new System.Drawing.Point(230, 16);
            this.checkBoxJava.Name = "checkBoxJava";
            this.checkBoxJava.Size = new System.Drawing.Size(49, 17);
            this.checkBoxJava.TabIndex = 2;
            this.checkBoxJava.Text = "Java";
            this.checkBoxJava.UseVisualStyleBackColor = true;
            this.checkBoxJava.CheckedChanged += new System.EventHandler(this.checkBoxJava_CheckedChanged);
            // 
            // checkBoxCOM
            // 
            this.checkBoxCOM.AutoSize = true;
            this.checkBoxCOM.Location = new System.Drawing.Point(298, 16);
            this.checkBoxCOM.Name = "checkBoxCOM";
            this.checkBoxCOM.Size = new System.Drawing.Size(50, 17);
            this.checkBoxCOM.TabIndex = 3;
            this.checkBoxCOM.Text = "COM";
            this.checkBoxCOM.UseVisualStyleBackColor = true;
            this.checkBoxCOM.CheckedChanged += new System.EventHandler(this.checkBoxCOM_CheckedChanged);
            // 
            // checkBoxNET
            // 
            this.checkBoxNET.AutoSize = true;
            this.checkBoxNET.Location = new System.Drawing.Point(372, 16);
            this.checkBoxNET.Name = "checkBoxNET";
            this.checkBoxNET.Size = new System.Drawing.Size(51, 17);
            this.checkBoxNET.TabIndex = 4;
            this.checkBoxNET.Text = ".NET";
            this.checkBoxNET.UseVisualStyleBackColor = true;
            this.checkBoxNET.CheckedChanged += new System.EventHandler(this.checkBoxNET_CheckedChanged);
            // 
            // ComponentList
            // 
            this.ComponentList.AutoSize = true;
            this.ComponentList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ComponentList.ColumnCount = 7;
            this.ComponentList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ComponentList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ComponentList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ComponentList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 195F));
            this.ComponentList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ComponentList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ComponentList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ComponentList.Controls.Add(this.CompID, 0, 0);
            this.ComponentList.Controls.Add(this.CompName, 1, 0);
            this.ComponentList.Controls.Add(this.CompType, 4, 0);
            this.ComponentList.Controls.Add(this.CompEdit, 5, 0);
            this.ComponentList.Controls.Add(this.CompDelete, 6, 0);
            this.ComponentList.Controls.Add(this.CompDesc, 2, 0);
            this.ComponentList.Controls.Add(this.CompPath, 3, 0);
            this.ComponentList.Location = new System.Drawing.Point(27, 75);
            this.ComponentList.MaximumSize = new System.Drawing.Size(0, 600);
            this.ComponentList.Name = "ComponentList";
            this.ComponentList.RowCount = 1;
            this.ComponentList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ComponentList.Size = new System.Drawing.Size(623, 13);
            this.ComponentList.TabIndex = 5;
            // 
            // CompID
            // 
            this.CompID.AutoSize = true;
            this.CompID.Location = new System.Drawing.Point(3, 0);
            this.CompID.Name = "CompID";
            this.CompID.Size = new System.Drawing.Size(75, 13);
            this.CompID.TabIndex = 0;
            this.CompID.Text = "Component ID";
            // 
            // CompName
            // 
            this.CompName.AutoSize = true;
            this.CompName.Location = new System.Drawing.Point(84, 0);
            this.CompName.Name = "CompName";
            this.CompName.Size = new System.Drawing.Size(92, 13);
            this.CompName.TabIndex = 1;
            this.CompName.Text = "Component Name";
            // 
            // CompType
            // 
            this.CompType.AutoSize = true;
            this.CompType.Location = new System.Drawing.Point(500, 0);
            this.CompType.Name = "CompType";
            this.CompType.Size = new System.Drawing.Size(88, 13);
            this.CompType.TabIndex = 4;
            this.CompType.Text = "Component Type";
            // 
            // CompEdit
            // 
            this.CompEdit.AutoSize = true;
            this.CompEdit.Location = new System.Drawing.Point(594, 0);
            this.CompEdit.Name = "CompEdit";
            this.CompEdit.Size = new System.Drawing.Size(10, 13);
            this.CompEdit.TabIndex = 5;
            this.CompEdit.Text = " ";
            // 
            // CompDelete
            // 
            this.CompDelete.AutoSize = true;
            this.CompDelete.Location = new System.Drawing.Point(610, 0);
            this.CompDelete.Name = "CompDelete";
            this.CompDelete.Size = new System.Drawing.Size(10, 13);
            this.CompDelete.TabIndex = 6;
            this.CompDelete.Text = " ";
            // 
            // CompDesc
            // 
            this.CompDesc.AutoSize = true;
            this.CompDesc.Location = new System.Drawing.Point(182, 0);
            this.CompDesc.Name = "CompDesc";
            this.CompDesc.Size = new System.Drawing.Size(117, 13);
            this.CompDesc.TabIndex = 3;
            this.CompDesc.Text = "Component Description";
            // 
            // CompPath
            // 
            this.CompPath.AutoSize = true;
            this.CompPath.Location = new System.Drawing.Point(305, 0);
            this.CompPath.Name = "CompPath";
            this.CompPath.Size = new System.Drawing.Size(86, 13);
            this.CompPath.TabIndex = 2;
            this.CompPath.Text = "Component Path";
            // 
            // AddComp
            // 
            this.AddComp.AutoSize = true;
            this.AddComp.Location = new System.Drawing.Point(30, 46);
            this.AddComp.Name = "AddComp";
            this.AddComp.Size = new System.Drawing.Size(83, 13);
            this.AddComp.TabIndex = 6;
            this.AddComp.TabStop = true;
            this.AddComp.Text = "Add Component";
            this.AddComp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AddComp_LinkClicked);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.AddComp);
            this.Controls.Add(this.ComponentList);
            this.Controls.Add(this.checkBoxNET);
            this.Controls.Add(this.checkBoxCOM);
            this.Controls.Add(this.checkBoxJava);
            this.Controls.Add(this.checkBoxAll);
            this.Controls.Add(this.label1);
            this.Name = "Admin";
            this.Text = "Welcome Master!";
            this.ComponentList.ResumeLayout(false);
            this.ComponentList.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxAll;
        private System.Windows.Forms.CheckBox checkBoxJava;
        private System.Windows.Forms.CheckBox checkBoxCOM;
        private System.Windows.Forms.CheckBox checkBoxNET;
        private System.Windows.Forms.TableLayoutPanel ComponentList;
        private System.Windows.Forms.Label CompID;
        private System.Windows.Forms.Label CompName;
        private System.Windows.Forms.Label CompPath;
        private System.Windows.Forms.Label CompDesc;
        private System.Windows.Forms.Label CompType;
        private System.Windows.Forms.Label CompEdit;
        private System.Windows.Forms.Label CompDelete;
        private System.Windows.Forms.LinkLabel AddComp;
    }
}

