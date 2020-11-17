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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "zYoFVrTRU4MOFdBQmJ7YNPmgnDegUSgJRTwN3F8p",
            BasePath = "https://sample-notification-12baf.firebaseio.com/"
        };
        IFirebaseClient client;
        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(ifc);
            }

            catch
            {
                MessageBox.Show("Kết nối mạng ko thành công", "Cảnh báo!");
            }
        }

        private void regBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameTbox.Text) &&
               string.IsNullOrWhiteSpace(passTbox.Text) &&
               string.IsNullOrWhiteSpace(Passtb2.Text))
            {
                MessageBox.Show("Điền đầy đủ thông tin", "Cảnh báo!");
                return;
            }

            if (passTbox.Text == Passtb2.Text)
            {
                Admin user = new Admin()
                {
                    Username = UsernameTbox.Text,
                    Password = passTbox.Text
                };

                SetResponse set = client.Set(@"Admins/" + UsernameTbox.Text, user);
                if (set.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show($"Đăng ký thành công {UsernameTbox.Text}!", "Thông báo!");
                }
            }
            else
                MessageBox.Show("Nhập lại mật khẩu không chính xác", "Thông báo!");
        }
    }
}
