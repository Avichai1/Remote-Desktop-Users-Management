using System;
using System.Collections;
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
using System.Net.NetworkInformation;
using Microsoft.VisualBasic;

namespace RemoteControlUsers
{
    public partial class UserManagementForm : Form
    {
        //העמודות מתחילות מ0 לכן אני שם משתנה שווה ל-1 כדי לבדוק שהאינדקס שלהם שונה מ-1 
        private int sortColumn = -1;
        //הוספתי את הכותרות של העמודות למערך
        private string [] userslist_ColumnTitle = {"UserName", "Server", "Session", "ID", "State", "Idle Time", "LogOn Time"};
        private string[] ServerList_ColumnTitle = { "IP Address", "Status" };
        //מערך של השרתים שמהם המידע נשאב

        List<string> ServerListArray = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + "\\Remote Control", "serverslist.txt").ToString()).ToList();
        void LogOffSession(string serverIP, string user_name)
        {
            ITerminalServicesManager manager = new TerminalServicesManager();
            using(ITerminalServer server = manager.GetRemoteServer(serverIP))
            {
                server.Open();
                foreach (ITerminalServicesSession session in server.GetSessions())
                {
                    if (session.UserName.ToString() == user_name)
                    {
                        session.Logoff();
                    }
                }
            }
        }
        void CheckingServerConnection()
        {
            Ping p = new Ping();
            PingReply r;
            for (int i = 0; i < ServerList.Items.Count; i++)
            {
                r = p.Send(ServerList.Items[i].Text);
                if (r.Status == IPStatus.Success)
                {
                    ServerList.Items[i].SubItems.Add("Active");
                }
                else
                {
                    ServerList.Items[i].SubItems.Add("Not Responding");
                }
            }
        }
        void CheckingConnectionState(string serverIP)
        {
            // אפשרות של ניהול שרת על ידי package-cassia
            ITerminalServicesManager manager = new TerminalServicesManager();
            //  ניהול שרת מרוחק על ידי מערך של ServerIP
            using (ITerminalServer server = manager.GetRemoteServer(serverIP))
            {
                // פתיחת תקשורת לכל שרת
                server.Open();
                //סריקה של כל הסשנים בשרת
                foreach (ITerminalServicesSession session in server.GetSessions())
                {
                    if (session.UserName.ToString() != "")
                    {
                        //הכנסה של הנתונים לתוך טבלה בשם connecteduserslist על ידי USIC מכניסה נתונים כמו שם משתמש,שרת וסשן איידי  
                        ListViewItem SUSISIL = new ListViewItem(session.UserName.ToString()); //Users, Server, ID, - Connected //שם משתשמש מיקום 0
                        SUSISIL.SubItems.Add(serverIP);//כתובת שרת מיקום 1
                        if (session.ConnectionState.ToString() == "Disconnected")
                        {
                            SUSISIL.SubItems.Add("Disconnected");
                        }
                        else
                        {
                            SUSISIL.SubItems.Add(session.WindowStationName.ToString());//שם סשן מיקום 2
                        }
                        SUSISIL.SubItems.Add(session.SessionId.ToString()); //סשן איידי מיקום 3
                        SUSISIL.SubItems.Add(session.ConnectionState.ToString());// מצב חיבור מנותק או מחובר מיקום 4
                        //idle time display
                            string idletime_minute = null, idletime_hour = null, idletime_days = null, idletime = null;
                            if (session.IdleTime.Minutes == 0)
                            {
                                idletime_minute = "";
                            }
                            else
                            {
                                idletime_minute = session.IdleTime.Minutes.ToString() + "m";
                            }
                            if (session.IdleTime.Hours == 0)
                            {
                                idletime_hour = "";
                            }
                            else
                            {
                                idletime_hour = session.IdleTime.Hours.ToString() + "h";
                            }
                            if (session.IdleTime.Days == 0)
                            {
                                idletime_days = "";
                            }
                            else
                            {
                                idletime_days = session.IdleTime.Days.ToString() + "d";
                            }
                        //idle time display
                        idletime = idletime_days + idletime_hour + idletime_minute;
                        SUSISIL.SubItems.Add(idletime);//Idle-Time מיקום 5
                        SUSISIL.SubItems.Add(session.LoginTime.ToString());//LogOn Time מיקום 6
                        Userslist.Items.Add(SUSISIL);//מוסיף אותם לטבלה בשם connecteduserslist מיקום 7                       
                    }
                }
            }
        }
        // לחצן REFRESH
        private void refreshbtn_Click(object sender, EventArgs e)
        {
            UpdateUsersList();//מעדכן את רשימת המשתמשים והפרטים שלהם
            CheckingServerConnection();
        }

        public UserManagementForm()
        {
            InitializeComponent();
        }
        public void  UpdateUsersList()
        {
            Userslist.BeginUpdate();
            Userslist.Items.Clear();//מנקה את כל הנתונים בטבלה
            //לולאה שעוברת על כל השרתים ובונה את הטבלה על ידי נתונים כמו שם משתמש, שרת,
            for (int i = 0; i < ServerList.Items.Count; i++)
            {
                if (ServerList.Items[i].SubItems[1].Text == "Active")
                {
                    CheckingConnectionState(ServerList.Items[i].Text);//הפונקציה חלה על כל השרתים על ידי לולאות פור במיקום איי
                }                
            }
            //טבלה של משתמשים
            Userslist.View = View.Details;//מציג את הנתונים בעמודות
            //Userslist.GridLines = true;//מציג תצוגה רשתית של קווים
            Userslist.FullRowSelect = true;//שורה כחולה כאשר עומדים על תא כלשהו בטבלה
            UpdatingConnectionStateStats();//מעדכן את הנתונים לגבי כמה משתמשים מנותקים וכמה מחוברים
            Userslist.EndUpdate();

        }
        private void UpdateServerList()
        {
            ServerList.BeginUpdate();
            ServerList.Items.Clear();
            ServerList.View = View.Details;
            ServerList.FullRowSelect = true;
            for (int i = 0; i < ServerListArray.Count; i++)
            {
                ServerList.Items.Add(ServerListArray[i].ToString());
            }
            ServerList.EndUpdate();
        }
        private void UsersSateForm_Load(object sender, EventArgs e)
        {
            AutoScroll = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            UpdateServerList();
            CheckingServerConnection();
            UpdateUsersList();//מעדכן את רשימת המשתמשים והפרטים שלהם
            UpdatingConnectionStateStats();//מעדכן את הנתונים לגבי כמה משתמשים מנותקים וכמה מחוברים
        }
        void UpdatingConnectionStateStats()//פונקציה שמעדכנת נתוהים לגבי משתמשים מנותקים ומחוברים
        {
            int count_disconnect_users = 0, count_connected_users = 0;//איפוס המונים שסופרים כמה משתמשים מנותקים ומחוברים
            for (int i = 0; i < Userslist.Items.Count; i++)//לולאה שעוברת על כל הפריטים בטבלה
            {
                if (Userslist.Items[i].SubItems[4].Text == "Disconnected") //אם יש פריט בעמודה החמישית שהערך שלו מנותק
                {
                    count_disconnect_users++;//תעלה את המונה של המנותקים באחד
                }
                if (Userslist.Items[i].SubItems[4].Text == "Active") //אם יש פריט בעמודה החמישית שהערך שלו מחובר
                {
                    count_connected_users++;//תעלה את המונה של המחוברים באחד
                }
            }
            textBox2.Text = count_connected_users.ToString();//תעדכן את הטקסט בוקס של המחוברים בכמות משתמשים מחוברים
            textBox1.Text = count_disconnect_users.ToString();//תעדכן את הטקסט בוקס של המנותקים בכמות משתמשים שמנותקים
        }
        private void Userslist_MouseClick(object sender, MouseEventArgs e)
        {
            ContextMenuStrip users_options = new ContextMenuStrip();//רשימה נפתחת כשלוחצים מקש ימני על העכבר בטבלה של משתמשים מנותקים          
            users_options.Items.Add("Remote Control");//לחצן Remote Control             
            users_options.Items.Add("Logoff");// לחצן Logoff
            if (e.Button == MouseButtons.Right)//אם המשתמש לחץ על המקש היממני בעכבור
            {
                users_options.Show(Cursor.Position.X, Cursor.Position.Y);//פותח את הרשימה איפה שהעכבר נמצא                       
                users_options.ItemClicked += new ToolStripItemClickedEventHandler(Item_Click);//הוספת איבנט של לחיצה על אפשרות כלשהי ברשימה 
            }
            void Item_Click(object send, ToolStripItemClickedEventArgs c)
            {
                string username_users_selected = Userslist.FocusedItem.SubItems[0].Text; // קולט את המידע מהתא שהמשתמש נמצא עליו קולט את שם המשתמש
                string server_users_selected = Userslist.FocusedItem.SubItems[1].Text; // קולט את המידע מהתא שהמשתמש נמצא עליו קולט את כתובת השרת                                                 
                string session_users_selected = Userslist.FocusedItem.SubItems[3].Text; //קולט את המידע מהתא שהמשתמש נמצא עליו קולט את הסשן  
                if (c.ClickedItem.Text == "Remote Control")  //כאשר לוחצים על אפשרות רימוט קונטרול
                {
                    users_options.Close();//סגירה של הרשימה
                    string RemoteControl_Users_CMD = "/C mstsc.exe /Shadow:" + session_users_selected + " /Control /v:" + server_users_selected + " /noConsentPrompt"; //יצירה של הפקודת התשלטות על משתמש שהוא מנותק
                    System.Diagnostics.Process.Start("CMD.exe", RemoteControl_Users_CMD); //הוצאת הפקודה השתלטות לפועל
                }
                else if (c.ClickedItem.Text == "Logoff")//כאשר לוחצים על אפשרות לוגאוף קונטרול
                {

                    users_options.Close();//סגירה של הרשימה                    
                    foreach (ListViewItem itemSelected in Userslist.SelectedItems)
                    {
                        string name = itemSelected.SubItems[0].Text;
                        for (int i = 0; i < ServerList.Items.Count; i++)
                        {
                            LogOffSession(ServerList.Items[i].Text, name);
                        }
                        Userslist.Items.Remove(itemSelected);
                        UpdatingConnectionStateStats();//מעדכן את הנתונים לגבי משתמשים מנותקים ומחוברים
                    }
                    UpdateUsersList();//מעדכן את הטבלה עם כל הפריטים הנחוצים                    
                }
            }
        }
        private void Userslist_ColumnClick(object sender, ColumnClickEventArgs e)//כאשר לוחצים על הכותרת של העמודה
        {
            if (e.Column != sortColumn)//בודק שהעמודה לא נלחצה
            {
                sortColumn = e.Column;//האינדקס של עמודה שווה למשתנה סורט קולומן
                Userslist.Sorting = SortOrder.Ascending;//מיון העמודה מהקטן לגדול
                Userslist.Columns[sortColumn].Text = userslist_ColumnTitle[sortColumn] + " ▼";//הוספת חץ שממחיש את אופן המיון

            }
            else//אם העמודה נלחצה
            {
                if (Userslist.Sorting == SortOrder.Ascending)//אם העמודה מסודרת מהקטן לגדול 
                { 
                    Userslist.Sorting = SortOrder.Descending; //מיון העמודה מהגדול לקטן
                    Userslist.Columns[sortColumn].Text = userslist_ColumnTitle[sortColumn] + " ▲";//הוספת חץ שממחיש את אופן המיון 
                }
                else //אם העמודה מסודרת מהגדול לקטן 
                { 
                    Userslist.Sorting = SortOrder.Ascending; //מיון העמודה מהקטן לגדול
                    Userslist.Columns[sortColumn].Text = userslist_ColumnTitle[sortColumn] + " ▼"; //הוספת חץ שממחיש את אופן המיון
                }
            }
            Userslist.Sort(); //סידור הטבלה
            this.Userslist.ListViewItemSorter = new MyListViewComparer(e.Column, Userslist.Sorting);
        }
        //יצירת פונקציה שמשווה בין פריטים בעמודה
        class MyListViewComparer : IComparer
        {
            private int col;
            private SortOrder order;
            public MyListViewComparer()
            {
                col = 0;
                order = SortOrder.Ascending;
            }
            public MyListViewComparer(int column, SortOrder order)
            {
                col = column;
                this.order = order;
            }
            public int Compare(object x, object y)
            {
                int returnVal = -1;
                returnVal = string.Compare(((ListViewItem)x).SubItems[col].Text,
                    ((ListViewItem)y).SubItems[col].Text);
                if (order == SortOrder.Descending)
                {
                    returnVal *= -1;
                }
                return returnVal;
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "")//אם בערך של הטקסט בוקס 3 לא ריק (טקסט בוקס 3 משמש לחיפוש לפי שם)
            {                
                foreach(ListViewItem item in Userslist.Items)//על כל פריט בטבלה
                {
                    if (item.Text.ToLower().StartsWith(textBox3.Text.ToLower()))//ממיר את הטקסט של הפריט לאותיות קטנות ובודק אם הטקסט בפריט מתחיל עם האותיות שרשמות בחיפוש
                    {
                        item.Selected = true; //מסמן את הפריט
                        item.BackColor = SystemColors.HighlightText;
                        item.ForeColor = SystemColors.InfoText;                          
                    }                        
                    else
                    {
                        Userslist.Items.Remove(item);//מוחק את שאר הפריטים כדי שלא יוצגו למשתמש
                    }                        
                }
                if (Userslist.SelectedItems.Count == 1)//אם יש פריט אחד שנמצא על ידי החיפוש
                {
                    Userslist.Focus();//מסמן את הפריט בהדגשה
                }
            }
            else//אם הערך של החיפוש כן ריק
            {
                UpdateUsersList();//מעדכן את הטבלה עם כל הפריטים הנחוצים
                UpdatingConnectionStateStats();//מעדכן את הנתונים לגבי משתמשים מנותקים ומחוברים
            }
        }
        private void DuplicateBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Userslist.Items.Count; i++)
            {
                int count_how_much_items_are_duplicated = 0;
                string userslist_firstitem = Userslist.Items[i].Text;
                for (int j = 0; j < Userslist.Items.Count; j++)
                {
                    string userslist_seconditem = Userslist.Items[j].Text;
                    if (userslist_firstitem == userslist_seconditem)
                    {
                        count_how_much_items_are_duplicated++;
                    }
                }
                if (count_how_much_items_are_duplicated >= 2)
                {
                    Userslist.Items[i].BackColor = Color.Red;
                }
            }
        }
        private void AddServerBtn_Click(object sender, EventArgs e)
        {

            ServerList.Items.Add(textBox4.Text);
            ServerListArray.Add(textBox4.Text);
            textBox4.Text = "";
            textBox4.Focus();
            UpdateUsersList();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Remote Control");
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + "\\Remote Control";
                var fileName = Path.Combine(path, "serverslist.txt");
                File.Delete(fileName);
                using (StreamWriter file = File.AppendText(fileName))
                {
                    for (int i = 0; i < ServerList.Items.Count; i++)
                    {
                        file.WriteLine(ServerList.Items[i].Text);
                    }
                    file.Close();
                    MessageBox.Show("Saved!");
                }
            }
            catch (Exception f)
            {
               System.Diagnostics.Debug.Write(f);
            }
        }
        private void ServerList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != sortColumn)//בודק שהעמודה לא נלחצה
            {
                sortColumn = e.Column;//האינדקס של עמודה שווה למשתנה סורט קולומן
                ServerList.Sorting = SortOrder.Ascending;//מיון העמודה מהקטן לגדול
                ServerList.Columns[sortColumn].Text = ServerList_ColumnTitle[sortColumn] + " ▼";//הוספת חץ שממחיש את אופן המיון

            }
            else//אם העמודה נלחצה
            {
                if (ServerList.Sorting == SortOrder.Ascending)//אם העמודה מסודרת מהקטן לגדול 
                {
                    ServerList.Sorting = SortOrder.Descending; //מיון העמודה מהגדול לקטן
                    ServerList.Columns[sortColumn].Text = ServerList_ColumnTitle[sortColumn] + " ▲";//הוספת חץ שממחיש את אופן המיון 
                }
                else //אם העמודה מסודרת מהגדול לקטן 
                {
                    ServerList.Sorting = SortOrder.Ascending; //מיון העמודה מהקטן לגדול
                    ServerList.Columns[sortColumn].Text = ServerList_ColumnTitle[sortColumn] + " ▼"; //הוספת חץ שממחיש את אופן המיון
                }
            }
           ServerList.Sort(); //סידור הטבלה
            this.ServerList.ListViewItemSorter = new MyListViewComparer(e.Column, ServerList.Sorting);
        }

        private void ServerList_MouseClick(object sender, MouseEventArgs e)
        {
            ContextMenuStrip servers_options = new ContextMenuStrip();//רשימה נפתחת כשלוחצים מקש ימני על העכבר בטבלה של משתמשים מנותקים          
            servers_options.Items.Add("Rename");//לחצן Remote Control             
            servers_options.Items.Add("Delete");// לחצן Logoff
            if (e.Button == MouseButtons.Right)//אם המשתמש לחץ על המקש היממני בעכבור
            {
                servers_options.Show(Cursor.Position.X, Cursor.Position.Y);//פותח את הרשימה איפה שהעכבר נמצא                       
                servers_options.ItemClicked += new ToolStripItemClickedEventHandler(Item_Click);//הוספת איבנט של לחיצה על אפשרות כלשהי ברשימה 
            }
            void Item_Click(object send, ToolStripItemClickedEventArgs c)
            {
                string username_users_selected = ServerList.FocusedItem.SubItems[0].Text; // קולט את המידע מהתא שהמשתמש נמצא עליו קולט את שם המשתמש
                if (c.ClickedItem.Text == "Rename")  //כאשר לוחצים על אפשרות רימוט קונטרול
                {
                    servers_options.Close();//סגירה של הרשימה
                    ServerList.LabelEdit = true;
                    ServerList.SelectedItems[0].BeginEdit();
                    CheckingServerConnection();
                    UpdateUsersList();
                }
                else if (c.ClickedItem.Text == "Delete")//כאשר לוחצים על אפשרות לוגאוף קונטרול
                {

                    servers_options.Close();//סגירה של הרשימה                    
                    foreach (ListViewItem listViewItem in ((ListView)sender).SelectedItems)
                    {
                        listViewItem.Remove();
                    }
                    UpdateUsersList();
                }
            }
        }
    }
}
