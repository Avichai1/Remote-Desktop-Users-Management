using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Security.Principal;
using System.Windows.Forms;
using Cassia;
using System.DirectoryServices;
using System.DirectoryServices.Protocols;
using System.DirectoryServices.AccountManagement;
using System.IO;

namespace RemoteControlUsers
{
    public partial class Form1 : Form
    {
        //מערך של שרתים
        List<string> servers = new List<string>(new string[] {});

        public Form1()
        {
            InitializeComponent();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            //משתמש במידע שיש בAD על פי כתובת דומיין
            using (var context = new PrincipalContext(ContextType.Domain, ""))
            {
                using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
                {
                    //מחפש את כל הנתנונים
                    foreach (var result in searcher.FindAll())
                    {
                        DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
                        //מוסיף את לרשימה יורדת
                        comboBox1.Items.Add(Convert.ToString(de.Properties["samAccountName"].Value));
                    }
                }
            }
            */
            string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Remote Control");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + "\\Remote Control";
                var fileName = Path.Combine(path, "serverslist.txt");
                using (StreamWriter file = File.CreateText(fileName))
                {
                    file.Close();
                }
            }
        }
        private void MoveUsersManagementForm_Click(object sender, EventArgs e)
        {
            //פותח את החלון של ניהול משתמשים בשרתים
            var UserManagementForm = new UserManagementForm();
            UserManagementForm.Show();
        }
    }
}
