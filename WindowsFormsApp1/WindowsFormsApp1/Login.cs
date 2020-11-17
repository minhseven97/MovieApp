using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "zYoFVrTRU4MOFdBQmJ7YNPmgnDegUSgJRTwN3F8p",
            BasePath = "https://sample-notification-12baf.firebaseio.com/"
        };

        IFirebaseClient client1;
        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                client1 = new FireSharp.FirebaseClient(ifc);
            }

            catch
            {
                MessageBox.Show("Kết nối mạng ko thành công", "Cảnh báo!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistrationForm reg = new RegistrationForm();
            reg.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameTbox.Text) &&
               string.IsNullOrWhiteSpace(passTbox.Text))
            {
                MessageBox.Show("Điền đầy đủ thông tin", "Cảnh báo!");
                return;
            }

            FirebaseResponse res = client1.Get(@"Admins/" + UsernameTbox.Text);
            Admin ResUser = res.ResultAs<Admin>();

            Admin CurUser = new Admin()
            {
                Username = UsernameTbox.Text,
                Password = passTbox.Text
            };

            if (Admin.IsEqual(ResUser, CurUser))
            {
                Form1 real = new Form1();
                real.ShowDialog();
            }

            else
            {
                Admin.ShowError();
            }
        }
    }
}
