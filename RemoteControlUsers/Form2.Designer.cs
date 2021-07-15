
namespace RemoteControlUsers
{
    partial class UserManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManagementForm));
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Userslist = new System.Windows.Forms.ListView();
            this.UserNameCo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ServerCo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SessionCo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IDCo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StateCo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IdleTimeCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LogOnTimeCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Logoffalldisconnectedusers = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.refreshbtn = new System.Windows.Forms.Button();
            this.DuplicateBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.savebtn = new System.Windows.Forms.Button();
            this.AddServerBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.ServerList = new System.Windows.Forms.ListView();
            this.IPAddressCo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ServerShowBtn = new System.Windows.Forms.Button();
            this.StatusCo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(248, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Users";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(280, 684);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "Total Disconnected:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(439, 684);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(64, 20);
            this.textBox1.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(300, 710);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "Total Connected:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(439, 707);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(64, 20);
            this.textBox2.TabIndex = 25;
            // 
            // Userslist
            // 
            this.Userslist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UserNameCo,
            this.ServerCo,
            this.SessionCo,
            this.IDCo,
            this.StateCo,
            this.IdleTimeCol,
            this.LogOnTimeCol});
            this.Userslist.HideSelection = false;
            this.Userslist.Location = new System.Drawing.Point(243, 68);
            this.Userslist.Name = "Userslist";
            this.Userslist.Size = new System.Drawing.Size(585, 589);
            this.Userslist.TabIndex = 27;
            this.Userslist.UseCompatibleStateImageBehavior = false;
            this.Userslist.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.Userslist_ColumnClick);
            this.Userslist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Userslist_MouseClick);
            // 
            // UserNameCo
            // 
            this.UserNameCo.Text = "UserName";
            // 
            // ServerCo
            // 
            this.ServerCo.Text = "Server";
            // 
            // SessionCo
            // 
            this.SessionCo.Text = "Session";
            // 
            // IDCo
            // 
            this.IDCo.Text = "ID";
            // 
            // StateCo
            // 
            this.StateCo.Text = "State";
            // 
            // IdleTimeCol
            // 
            this.IdleTimeCol.Text = "Idle Time";
            // 
            // LogOnTimeCol
            // 
            this.LogOnTimeCol.Text = "LogOn Time";
            // 
            // Logoffalldisconnectedusers
            // 
            this.Logoffalldisconnectedusers.Location = new System.Drawing.Point(0, 0);
            this.Logoffalldisconnectedusers.Name = "Logoffalldisconnectedusers";
            this.Logoffalldisconnectedusers.Size = new System.Drawing.Size(75, 23);
            this.Logoffalldisconnectedusers.TabIndex = 35;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(325, 40);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(120, 20);
            this.textBox3.TabIndex = 30;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(248, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "Search:";
            // 
            // refreshbtn
            // 
            this.refreshbtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("refreshbtn.BackgroundImage")));
            this.refreshbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refreshbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(27)))), ((int)(((byte)(46)))));
            this.refreshbtn.Location = new System.Drawing.Point(864, 68);
            this.refreshbtn.Name = "refreshbtn";
            this.refreshbtn.Size = new System.Drawing.Size(93, 67);
            this.refreshbtn.TabIndex = 18;
            this.refreshbtn.UseVisualStyleBackColor = true;
            this.refreshbtn.Click += new System.EventHandler(this.refreshbtn_Click);
            // 
            // DuplicateBtn
            // 
            this.DuplicateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.DuplicateBtn.Location = new System.Drawing.Point(873, 157);
            this.DuplicateBtn.Name = "DuplicateBtn";
            this.DuplicateBtn.Size = new System.Drawing.Size(84, 47);
            this.DuplicateBtn.TabIndex = 33;
            this.DuplicateBtn.Text = "Find Duplicate";
            this.DuplicateBtn.UseVisualStyleBackColor = true;
            this.DuplicateBtn.Click += new System.EventHandler(this.DuplicateBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Controls.Add(this.savebtn);
            this.panel1.Controls.Add(this.AddServerBtn);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.ServerList);
            this.panel1.Controls.Add(this.ServerShowBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 956);
            this.panel1.TabIndex = 34;
            // 
            // savebtn
            // 
            this.savebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.savebtn.Location = new System.Drawing.Point(80, 368);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(75, 33);
            this.savebtn.TabIndex = 5;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // AddServerBtn
            // 
            this.AddServerBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddServerBtn.BackgroundImage")));
            this.AddServerBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddServerBtn.Location = new System.Drawing.Point(191, 147);
            this.AddServerBtn.Name = "AddServerBtn";
            this.AddServerBtn.Size = new System.Drawing.Size(50, 38);
            this.AddServerBtn.TabIndex = 4;
            this.AddServerBtn.UseVisualStyleBackColor = true;
            this.AddServerBtn.Click += new System.EventHandler(this.AddServerBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(-2, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Add Server:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(71, 157);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(120, 20);
            this.textBox4.TabIndex = 2;
            // 
            // ServerList
            // 
            this.ServerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IPAddressCo,
            this.StatusCo});
            this.ServerList.HideSelection = false;
            this.ServerList.Location = new System.Drawing.Point(6, 201);
            this.ServerList.Name = "ServerList";
            this.ServerList.Size = new System.Drawing.Size(229, 154);
            this.ServerList.TabIndex = 1;
            this.ServerList.UseCompatibleStateImageBehavior = false;
            this.ServerList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ServerList_ColumnClick);
            this.ServerList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ServerList_MouseClick);
            // 
            // IPAddressCo
            // 
            this.IPAddressCo.Text = "IP Address";
            this.IPAddressCo.Width = 200;
            // 
            // ServerShowBtn
            // 
            this.ServerShowBtn.Location = new System.Drawing.Point(0, 99);
            this.ServerShowBtn.Name = "ServerShowBtn";
            this.ServerShowBtn.Size = new System.Drawing.Size(242, 45);
            this.ServerShowBtn.TabIndex = 0;
            this.ServerShowBtn.Text = "Servers";
            this.ServerShowBtn.UseVisualStyleBackColor = true;
            // 
            // StatusCo
            // 
            this.StatusCo.Text = "Status";
            // 
            // UserManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(976, 956);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DuplicateBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.Logoffalldisconnectedusers);
            this.Controls.Add(this.Userslist);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.refreshbtn);
            this.Controls.Add(this.label4);
            this.Name = "UserManagementForm";
            this.Text = "Users Management";
            this.Load += new System.EventHandler(this.UsersSateForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ListView Userslist;
        private System.Windows.Forms.Button Logoffalldisconnectedusers;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button refreshbtn;
        private System.Windows.Forms.ColumnHeader UserNameCo;
        private System.Windows.Forms.ColumnHeader ServerCo;
        private System.Windows.Forms.ColumnHeader SessionCo;
        private System.Windows.Forms.ColumnHeader IDCo;
        private System.Windows.Forms.ColumnHeader StateCo;
        private System.Windows.Forms.ColumnHeader IdleTimeCol;
        private System.Windows.Forms.ColumnHeader LogOnTimeCol;
        private System.Windows.Forms.Button DuplicateBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView ServerList;
        private System.Windows.Forms.Button ServerShowBtn;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button AddServerBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader IPAddressCo;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.ColumnHeader StatusCo;
    }
}