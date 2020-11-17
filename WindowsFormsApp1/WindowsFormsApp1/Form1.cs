using FastMember;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public ObservableCollection<Movies> WatchList
        {
            get;
            set;
        }
        public Form1()
        {
            InitializeComponent();
        }
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "zYoFVrTRU4MOFdBQmJ7YNPmgnDegUSgJRTwN3F8p",
            BasePath = "https://sample-notification-12baf.firebaseio.com/"
        };

        IFirebaseClient client1;

        private async void Them_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TheLoai.Text) &&
               string.IsNullOrWhiteSpace(Link.Text) &&
               string.IsNullOrWhiteSpace(IDPhim.Text) &&
               string.IsNullOrWhiteSpace(MoTa.Text) &&
               string.IsNullOrWhiteSpace(TenPhim.Text) &&
               string.IsNullOrWhiteSpace(Url.Text) &&
               string.IsNullOrWhiteSpace(HinhAnh.Text))
            {
                MessageBox.Show("Điền đầy đủ thông tin", "Cảnh báo!");
                return;
            }
            Movies user = new Movies()
            {
                Category = TheLoai.Text,
                Link = Link.Text,
                MovieId = IDPhim.Text,
                Synopsis = MoTa.Text,
                Thumbnail = HinhAnh.Text,
                Title = TenPhim.Text,
                Url = Url.Text
            };

            SetResponse set = client1.Set(@"Movies/" + IDPhim.Text, user);
            if (set.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show($"Thêm phim {TenPhim.Text} thành công!", "Thông báo!");
            }
            var client = new HttpClient();
            var result = await client.GetStringAsync("https://sample-notification-12baf.firebaseio.com/Movies/.json");
            var listmovie = result.Replace("null,", " ");
            WatchList = JsonConvert.DeserializeObject<ObservableCollection<Movies>>(listmovie);
            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(WatchList))
            {
                table.Load(reader);
            }
            dataGridView1.DataSource = table;
        }

        private async void Sua_Click(object sender, EventArgs e)
        {
            Movies user = new Movies()
            {
                Category = TheLoai.Text,
                Link = Link.Text,
                MovieId = IDPhim.Text,
                Synopsis = MoTa.Text,
                Thumbnail = HinhAnh.Text,
                Title = TenPhim.Text,
                Url = Url.Text
            };
            var update = client1.Update(@"Movies/" + IDPhim.Text, user);
            if (update.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show($"Sửa phim {TenPhim.Text} thành công!", "Thông báo!");
            }
            var client = new HttpClient();
            var result = await client.GetStringAsync("https://sample-notification-12baf.firebaseio.com/Movies/.json");
            var listmovie = result.Replace("null,", " ");
            WatchList = JsonConvert.DeserializeObject<ObservableCollection<Movies>>(listmovie);
            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(WatchList))
            {
                table.Load(reader);
            }
            dataGridView1.DataSource = table;
        }

        private async void Xoa_Click(object sender, EventArgs e)
        {
            Movies user = new Movies()
            {
                Category = TheLoai.Text,
                Link = Link.Text,
                MovieId = IDPhim.Text,
                Synopsis = MoTa.Text,
                Thumbnail = HinhAnh.Text,
                Title = TenPhim.Text,
                Url = Url.Text
            };
            var delete = client1.Delete(@"Movies/" + TenPhim.Text);
            if (delete.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show($"Xoá phim {TenPhim.Text} thành công!", "Thông báo!");
            }
            var client = new HttpClient();
            var result = await client.GetStringAsync("https://sample-notification-12baf.firebaseio.com/Movies/.json");
            var listmovie = result.Replace("null,", " ");
            WatchList = JsonConvert.DeserializeObject<ObservableCollection<Movies>>(listmovie);
            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(WatchList))
            {
                table.Load(reader);
            }
            dataGridView1.DataSource = table;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                client1 = new FireSharp.FirebaseClient(ifc);
                var client = new HttpClient();
                var result = await client.GetStringAsync("https://sample-notification-12baf.firebaseio.com/Movies/.json");
                var listmovie = result.Replace("null,", " ");
                WatchList = JsonConvert.DeserializeObject<ObservableCollection<Movies>>(listmovie);
                DataTable table = new DataTable();
                using (var reader = ObjectReader.Create(WatchList))
                {
                    table.Load(reader);
                }
                dataGridView1.DataSource = table;
            }

            catch
            {
                MessageBox.Show("Kết nối mạng ko thành công", "Cảnh báo!");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            TheLoai.Text = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
            Link.Text= dataGridView1.Rows[numrow].Cells[1].Value.ToString();
            IDPhim.Text = dataGridView1.Rows[numrow].Cells[2].Value.ToString();
            MoTa.Text = dataGridView1.Rows[numrow].Cells[3].Value.ToString();
            HinhAnh.Text = dataGridView1.Rows[numrow].Cells[4].Value.ToString();
            TenPhim.Text = dataGridView1.Rows[numrow].Cells[5].Value.ToString();
            Url.Text = dataGridView1.Rows[numrow].Cells[6].Value.ToString();
        }
    }
}
