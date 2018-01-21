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

namespace HangManVisual
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnGuestPlay_Click(object sender, EventArgs e)
        {
            HangManUI hangmanui = new HangManUI();
            this.Hide();
            hangmanui.ShowDialog();
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            //HangManDBDataSetTableAdapters.UsersTableAdapter hangmandb = new HangManDBDataSetTableAdapters.UsersTableAdapter();
            //hangmandb.InsertQuery(txtbNewUser.Text, 0, 0);
            /*string connetionString = null;
            string sql = null;
            connetionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\HangManDB.mdf;Integrated Security=True;";
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                sql = "insert into Users ([User]) values(@user)";
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@user", txtbNewUser.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Row inserted !! ");  
                }
            }*/
        }
    }
}
