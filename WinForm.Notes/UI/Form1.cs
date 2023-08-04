using DevExpress.DataAccess.Native.DataFederation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm.Notes
{
    public partial class MainForm : Form
    {

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Notes;Integrated Security=true");
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           
            ListeCek();


        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            Kaydet();
            ListeCek();
        }
         

        public void ListeCek()
        {
          //  listNote.Items.Clear();
            con.Open();
            SqlCommand cmd = new SqlCommand("select Id,Notes from mynotes", con);
           // SqlDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
               
            //    listNote.Items.Add(dr["Notes"]);
            //}
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            listNote.DataSource = dt;
            listNote.DisplayMember = "Notes";
            listNote.ValueMember= "Id";
            
            con.Close();
        }

            public void Kaydet()
            {
                con.Open();
                string deger = txtEnter.Text;
                SqlCommand cmd = new SqlCommand("insert into mynotes (Notes) values (@deger)", con);
            cmd.Parameters.AddWithValue("@deger", deger);
                cmd.ExecuteNonQuery();
                con.Close();
                txtEnter.Text = string.Empty;
            MessageBox.Show("Kayıt Başarılı");
            }

        public void Guncelle()
        {

            con.Open();
            string deger = txtEnter.Text;
            int secilen = (int)listNote.SelectedValue;
            SqlCommand cmd = new SqlCommand("update mynotes set Notes= @deger where Id=@secilen", con);
            cmd.Parameters.AddWithValue("@deger", deger);
            cmd.Parameters.AddWithValue("@secilen", secilen);
            cmd.ExecuteNonQuery();
            con.Close();
        }



        public void Sil()
        {
            DialogResult result= MessageBox.Show("Silmek İstediğinize Emin misiniz?","Uyarı", MessageBoxButtons.YesNo);

            if (result==DialogResult.Yes)
            {
                con.Open();
                int secilen = (int)listNote.SelectedValue;
                SqlCommand cmd = new SqlCommand("delete from mynotes  where Id=@secilen", con);
                cmd.Parameters.AddWithValue("@secilen", secilen);
                cmd.ExecuteNonQuery();
                con.Close();
            }
         
            
        }
        private void listNote_Click(object sender, EventArgs e)
        {
          
            txtEnter.Text=listNote.Text;
           // MessageBox.Show(listNote.SelectedValue.ToString());
           
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Guncelle();
            ListeCek();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Sil();
            ListeCek();
        }
    }


    }

