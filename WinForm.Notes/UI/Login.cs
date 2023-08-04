using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm.Notes.Entities;

namespace WinForm.Notes.UI
{
    public partial class Login : Form
    {

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Notes;Integrated Security=true");
        public Login()
        {
            InitializeComponent();
        }

        public void Login_Load(object sender, EventArgs e)
        {
          
       

            



        }

        public void btnLogin_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();
            string userGet = txtAppUser.Text;
            string passGet = txtPass.Text;
         // güzel bir SQL injection açığı 
            SqlCommand cmd2 = new SqlCommand("select Username, Password From Users where Username = @username and Password=@password",con);
            cmd2.Parameters.AddWithValue("@username",userGet);
            cmd2.Parameters.AddWithValue("@password",passGet);
            SqlDataReader dr = cmd2.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();
                this.Hide();
                MainForm f = new MainForm();
                f.Show();

            }

            else
            {
                errorLabel.Text = "Kullanıcı Adı veya Şifre Yanlış!!!";
                  txtAppUser.Text = string.Empty;

                 txtPass.Text = string.Empty;
            }






            // UserManager usermanager = new UserManager();
            //bool test=  usermanager.Test(userGet,passGet);

            // if (test==true)
            // {
            //     MessageBox.Show("Ok");
            // }
            // else
            // {
            //     MessageBox.Show(users.Username, users.Password);
            //     errorLabel.Text = test.ToString()+""userGet+passGet;
            // }


            //if (users.Username == userGet && users.Password==passGet)
            //{
            //    MainForm mainForm = new MainForm();
            //    mainForm.Show();
            //    this.Hide();
            //}
            //else
            //{
            //    errorLabel.Text = "Kullanıcı Adı veya Şifre Yanlış!!!";
            //    txtAppUser.Text = string.Empty;

            //    txtPass.Text = string.Empty;

            //}

        }

        private void txtAppUser_Click(object sender, EventArgs e)
        {
            errorLabel.Text = string.Empty;
        }
    }
}
