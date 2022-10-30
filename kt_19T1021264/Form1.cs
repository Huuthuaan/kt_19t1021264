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


namespace kt_19T1021264
{
    public partial class Form1 : Form
    {
        int manhom = 0;
        int manguoi = 0;
        public Form1()
        {
            InitializeComponent();
            NapDSNhom();
        }
        void NapDSNhom()
        {
            var list = NhomView.Getlist();
            dataGridView1.DataSource = list;
        }
        void NapDSNguoi(int id)
        {

            var list = NguoiView.Getlist(id);
            dataGridView2.DataSource = list;
        }
        private void ShowForm2()
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ShowForm2));
            thread.Start();
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_kt_netDataSet1.Nguoi' table. You can move, or remove it, as needed.
            this.nguoiTableAdapter.Fill(this._kt_netDataSet1.Nguoi);
            // TODO: This line of code loads data into the '_kt_netDataSet.Nhom' table. You can move, or remove it, as needed.
            this.nhomTableAdapter.Fill(this._kt_netDataSet.Nhom);

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            if (manhom != 0)
            {
                var rs = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Chú ý", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.OK)
                {
                    NhomView.DeleteNhom(manhom);
                    NapDSNhom();
                }
            }
        }
        private void ShowForm3()
        {
            Form3 f = new Form3();
            f.ShowDialog();
        }
        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ShowForm3));
            thread.Start();
            this.Close();
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            if (manguoi != 0)
            {
                var rs = MessageBox.Show("Ban co chac chan muon xoa lien lac nay?", "Chu y", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.OK)
                {
                    NguoiView.DeleteSinhVien(manguoi);
                    NapDSNhom();
                    NapDSNguoi(manhom);
                }
            }
        }
            private void CellclickNguoi(object sender, DataGridViewCellEventArgs e)
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataGridView2.Rows[e.RowIndex];
                txtTenGoi.Text = Convert.ToString(row.Cells["TenGoi"].Value);
                txtmail.Text = Convert.ToString(row.Cells["Email"].Value);
                txtsdt.Text = Convert.ToString(row.Cells["SDT"].Value);
                string email = Convert.ToString(row.Cells["Email"].Value);

                var list = NguoiView.GetlistAll();
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Email.Equals(email))
                    {
                        txtDiaChi.Text = list[i].DiaChi;
                        manguoi = list[i].ID;
                    }
                }
            }
        

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
