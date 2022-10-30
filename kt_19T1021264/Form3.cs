using kt_19T1021264.Model;
using kt_19T1021264.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace kt_19T1021264
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            NapDSNhom();
        }
        private void ShowForm1()
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }
        void NapDSNhom()
        {
            var list = NhomView.Getlist();
            //bdsSinhVien.DataSource = list;
            for (int i = 0; i < list.Count; i++)
            {
                comboBox1.Items.Add(list[i].TenNhom);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var list = NhomView.Getlist();
            var id = 0;
            var chimuc = comboBox1.SelectedIndex;
            for (int i = 0; i < list.Count; i++)
            {
                if (i == chimuc)
                {
                    id = list[i].ID;
                }
            }
            var sv = new Nguoi
            {
                TenGoi = textBox1.Text,
                Email = textBox2.Text,
                
                PhoneNumber = textBox3.Text,
                IDNhom = id,

            };
            NguoiView.AddSinhVien(sv);
            Thread thread = new Thread(new ThreadStart(ShowForm1));
            thread.Start();
            this.Close();
        }
    }
}
