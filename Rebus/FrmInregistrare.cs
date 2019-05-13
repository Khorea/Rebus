using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Rebus
{
    public partial class inregistrareForm : Form
    {
        public inregistrareForm()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;

        bool admin = false;

        public void IsAdmin(bool a)
        {
            admin = a;
        }

        private void inregistrareForm_Load(object sender, EventArgs e)
        {
            tipComboBox.SelectedIndex = 0;

            if(admin)
            {
                tipComboBox.Items.Add("Administrator");
            }
            else
            {
                try
                {
                    tipComboBox.Items.Remove("Administrator");
                }
                catch
                {

                }
            }
        }

        private void renuntaButton_Click(object sender, EventArgs e)
        {
            if(admin)
            {
                Application.OpenForms["rebusForm"].Visible = true;
                this.Close();
            }
            else
            {
                Application.OpenForms["logareForm"].Visible = true;
                this.Close();
            }
        }

        private bool IsEmail(string email)
        {
            bool ok = false;
            bool punct = false;

            try
            {
                var adress = new System.Net.Mail.MailAddress(email);

                if (adress.Address != email) return false;

                string emaiSubstring = email.Split('@')[1];

                char[] c = emaiSubstring.ToCharArray();

                if (c[0] == '.') return false;

                for (int i = 0; i < c.Count(); i++)
                {
                    if (punct && c[i] == '.') return false;
                    if (punct) ok = true;
                    if (c[i] == '.') punct = true;                                                        
                }

                return ok;
            }
            catch
            {
                return false;
            }

        }

        private void inregistrareButton_Click(object sender, EventArgs e)
        {
            if(IsEmail(emailTextBox.Text))
            {
                if(parolaTextBox.Text == rparolaTextBox.Text)
                {
                    using (con = new SqlConnection(Services.connectionString))
                    {
                        con.Open();

                        int count = 0;

                        string sqlSelect = "SELECT count(*) FROM Utilizatori WHERE NumeUtilizator = @nume OR Email = @email";

                        cmd = new SqlCommand(sqlSelect, con);
                        cmd.Parameters.AddWithValue("@nume", utilizatorTextBox.Text);
                        cmd.Parameters.AddWithValue("@email", emailTextBox.Text);

                        count = (int)cmd.ExecuteScalar();

                        if (count == 1)
                        {
                            MessageBox.Show("Utilizatorul există în baza de date!", "Error");
                            utilizatorTextBox.Clear();
                            emailTextBox.Clear();
                            parolaTextBox.Clear();
                            rparolaTextBox.Clear();
                            
                        }
                        else
                        {
                            string sqlInsert = "INSERT INTO Utilizatori VALUES (@parola, @nume, @email, @tip)";

                            cmd = new SqlCommand(sqlInsert, con);
                            cmd.Parameters.AddWithValue("@parola", parolaTextBox.Text);
                            cmd.Parameters.AddWithValue("@nume", utilizatorTextBox.Text);
                            cmd.Parameters.AddWithValue("@email", emailTextBox.Text);
                            if (tipComboBox.Text == "Utilizator")
                            {
                                cmd.Parameters.AddWithValue("@tip", 0);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@tip", 1);
                            }

                            count = cmd.ExecuteNonQuery();

                            if (count == 1)
                            {
                                MessageBox.Show("Contul a fost creat cu succes!", "Succes!");

                                if(admin)
                                {
                                    utilizatorTextBox.Clear();
                                    emailTextBox.Clear();
                                    parolaTextBox.Clear();
                                    rparolaTextBox.Clear();
                                }
                                else
                                {
                                    Application.OpenForms["logareForm"].Visible = true;
                                    this.Close();
                                }                             
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Parolele nu sunt identice", "Eroare");
                    parolaTextBox.Clear();
                    rparolaTextBox.Clear();
                }
            }
            else
            {
                MessageBox.Show("Adresa de email nu este valida", "Eroare");
                emailTextBox.Clear();
            }
        }
    }
}
