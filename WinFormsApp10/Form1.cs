using System.Data.SqlClient;

namespace WinFormsApp10
{
    public partial class Form1 : Form
    {
        string connection = @"Data Source=DESKTOP-DAG0R02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; Database=Login/Register";

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            Menuform menuform = new Menuform();
            menuform.ShowDialog();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;

            string user = tbox_username.Text;
            string pass = tbox_password.Text;


            using (SqlConnection conn = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand();

                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM UserLogin WHERE Username='" + tbox_username.Text + "' AND Password='" + tbox_password.Text + "'";
                dr = cmd.ExecuteReader();

                if (dr.Read())
                    MessageBox.Show("Welcome");
                else MessageBox.Show("Invalid Login");
            }

        }
    }
}