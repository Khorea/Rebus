using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;

namespace Rebus
{
    public partial class logareForm : Form
    {
        public logareForm()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;

        inregistrareForm iform = new inregistrareForm();
        rebusForm rform = new rebusForm();

        private void label3_Click(object sender, EventArgs e)
        {
            if (iform.IsDisposed)
            {
                iform = new inregistrareForm();
                iform.Show();
                this.Hide();
            }
            else if (iform.Visible == false)
            {               
                iform.Show();
                this.Hide();
            }
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            using (con = new SqlConnection(Services.connectionString))
            {
                con.Open();

                string sqlSelect = "SELECT count(*) FROM Utilizatori WHERE Parola = @parola AND NumeUtilizator = @nume";

                cmd = new SqlCommand(sqlSelect, con);
                cmd.Parameters.AddWithValue("@parola", textBox2.Text);
                cmd.Parameters.AddWithValue("@nume", textBox1.Text);

                int count = (int)cmd.ExecuteScalar();

                if (count == 1)
                {                   
                    string sqlSelect2 = "SELECT count(*) FROM Utilizatori WHERE Parola = @parola AND NumeUtilizator = @nume AND TipUtilizator = 1";
                    string sqlSelect3 = "SELECT IdUtilizator FROM Utilizatori WHERE Parola = @parola AND NumeUtilizator = @nume";
                   
                    cmd = new SqlCommand(sqlSelect2, con);
                    cmd.Parameters.AddWithValue("@parola", textBox2.Text);
                    cmd.Parameters.AddWithValue("@nume", textBox1.Text);
                    
                    count = (int)cmd.ExecuteScalar();

                    cmd = new SqlCommand(sqlSelect3, con);
                    cmd.Parameters.AddWithValue("@parola", textBox2.Text);
                    cmd.Parameters.AddWithValue("@nume", textBox1.Text);

                    reader = cmd.ExecuteReader();
                    reader.Read();
                    int id = reader.GetInt32(0);
                    reader.Close();

                    if (rform.IsDisposed)
                    {
                        rform = new rebusForm();
                        rform.GetTip(count);
                        rform.GetId(id);
                        rform.Show();
                        this.Hide();
                    }
                    else if(rform.Visible == false)
                    {
                        rform.GetTip(count);
                        rform.GetId(id);
                        rform.Show();
                        this.Hide();
                    }

                    textBox1.Clear();
                    textBox2.Clear();
                }
                else
                {
                    MessageBox.Show("Eroare autentificare!", "Eroare");
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
        }

        private void RemoveData()
        {
            try
            {
                using (con = new SqlConnection(Services.connectionString))
                {
                    con.Open();

                    string sqlTruncate1 = "TRUNCATE TABLE Rebusuri";
                    string sqlTruncate2 = "TRUNCATE TABLE Rezolvari";

                    cmd = new SqlCommand(sqlTruncate1, con); cmd.ExecuteNonQuery();
                    cmd = new SqlCommand(sqlTruncate2, con); cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                MessageBox.Show("Database connection timeout", "Eroare");
            }           
        }   

        private void logareForm_Load(object sender, EventArgs e)
        {
            //RemoveData();
            logButton.Enabled = true;
            label3.Enabled = true;
        }
    }
}
