﻿using System.Data.SqlClient;

namespace WinFormsApp10
{
    public partial class Menuform : Form
    {
        public Menuform()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string connection = @"Data Source=DESKTOP-DAG0R02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; Database=Login/Register";

            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                string query = "INSERT INTO UserLogin(Name,UserName,Password)" +
                    " VALUES('" + tbox_name.Text + "', '" + tbox_username.Text + "', '" + tbox_password.Text + "')";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);

                da.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Data saved succesfully");
            }
        }
    }
}
