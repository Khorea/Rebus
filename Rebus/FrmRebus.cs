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
using System.Globalization;

namespace Rebus
{
    public partial class rebusForm : Form
    {
        public rebusForm()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;

        DataTable rebusuriDT = new DataTable();
        DataTable rezolvariDT = new DataTable();

        inregistrareForm iform = new inregistrareForm();

        Button[,] b;

        Bitmap bmp;

        int tip = 0, id = 0;
        int h = 0, m = 0, s = 0;

        char[,] rezolvari;

        public void GetTip(int i)
        {
            tip = i;
        }

        public void GetId(int i)
        {
            id = i;
        }

        private void FillRebusuriDT(int id)
        {
            try
            {
                rebusuriDT = new DataTable();

                using (con = new SqlConnection(Services.connectionString))
                {
                    con.Open();

                    string sqlSelect = "SELECT * FROM Rebusuri WHERE IdRebus = @id";

                    cmd = new SqlCommand(sqlSelect, con);
                    cmd.Parameters.AddWithValue("@id", id);

                    adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(rebusuriDT);
                    adapter.Dispose();
                }
            }
            catch { }         
        }

        private void FillRezolvariDT(int id)
        {
            try
            {
                rezolvariDT = new DataTable();

                using (con = new SqlConnection(Services.connectionString))
                {
                    con.Open();

                    string sqlSelect = "SELECT * FROM Rezolvari WHERE IdRebus = @id";

                    cmd = new SqlCommand(sqlSelect, con);
                    cmd.Parameters.AddWithValue("@id", id);

                    adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(rezolvariDT);
                    adapter.Dispose();
                }
            }
            catch { }
        }

        private void rebusForm_Load(object sender, EventArgs e)
        {
            rez1TableAdapter.Connection = new SqlConnection(Services.connectionString);
            rezOrizontalTableAdapter.Connection = new SqlConnection(Services.connectionString);
            rezVerticalTableAdapter.Connection = new SqlConnection(Services.connectionString);
            rebusuriTableAdapter.Connection = new SqlConnection(Services.connectionString);
            rez2TableAdapter.Connection = new SqlConnection(Services.connectionString);

            rebusuriTableAdapter.Fill(rEBUSDataSet.Rebusuri);

            openFileDialog1.InitialDirectory = Environment.CurrentDirectory.Replace(@"\bin\Debug", @"\Resurse_D");
                  

            dataGridView1.Font = new Font("Times New Roman", 16, FontStyle.Bold);

            chart1.Series[0].LegendText = "Timp estimat";

            try
            {
                if (tip != 1)
                {
                    logareToolStripMenuItem.Enabled = false;
                    inregistrareUtilizatorToolStripMenuItem.Enabled = false;
                    adaugareRebusToolStripMenuItem.Enabled = false;

                    tabControl1.SelectedTab = tabPage2;
                    tabPage1.Dispose();
                }
                else
                {
                    rebusComboBox.SelectedIndex = 0;
                    rebusComboBox_SelectedIndexChanged(null, null);
                }
                rebusComboBox2.SelectedIndex = 0;
                rebusComboBox2_SelectedIndexChanged(null, null);
            }
            catch { }              
        }

        private void rebusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool ok = true;
          
            try
            {
                this.rez1TableAdapter.Fill(this.rEBUSDataSet.Rez1, ((int)(System.Convert.ChangeType(rebusComboBox.SelectedValue, typeof(int)))));
            }
            catch { ok = false; }

            try
            {
                this.rez2TableAdapter.Fill(this.rEBUSDataSet.Rez2, ((int)(System.Convert.ChangeType(rebusComboBox.SelectedValue, typeof(int)))));
                dataGridView3.DataSource = rEBUSDataSet.Rez2;
                dataGridView3.Refresh();
                dataGridView3.Update();
            }
            catch { }

            if (ok)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                FillRezolvariDT((int)rebusComboBox.SelectedValue);
                FillRebusuriDT((int)rebusComboBox.SelectedValue);

                int linii = (int)rebusuriDT.Rows[0][3], coloane = (int)rebusuriDT.Rows[0][2];

                for (int j = 0; j < coloane; j++)
                {
                    DataGridViewButtonColumn bc = new DataGridViewButtonColumn();

                    dataGridView1.Columns.Insert(j, bc);
                }

                for (int i = 0; i < linii; i++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.Height = dataGridView1.Height / linii;

                    dataGridView1.Rows.Insert(i, row);
                }

                int count = rezolvariDT.Rows.Count;

                for (int k = 0; k < count; k++)
                {
                    char[] c = rezolvariDT.Rows[k][4].ToString().ToCharArray();

                    if(rezolvariDT.Rows[k][3].ToString() == "orizontal")
                    {
                        int lstart = (int)rezolvariDT.Rows[k][2] - 1;
                        int cstart = (int)rezolvariDT.Rows[k][1] - 1;
                        int chars = c.Count();

                        for (int j = cstart; j < cstart + chars; j++)
                        {
                            dataGridView1.Rows[lstart].Cells[j].Value = c[j - cstart];
                        }
                    }
                    else
                    {
                        int lstart = (int)rezolvariDT.Rows[k][2] - 1;
                        int cstart = (int)rezolvariDT.Rows[k][1] - 1;
                        int chars = c.Count();

                        for (int i = lstart; i < lstart + chars; i++)
                        {                           
                            dataGridView1.Rows[i].Cells[cstart].Value = c[i - lstart];
                        }
                    }                  
                }
            }
        }

        private void rebusComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.rezOrizontalTableAdapter.Fill(this.rEBUSDataSet.RezOrizontal, ((int)(System.Convert.ChangeType(rebusComboBox2.SelectedValue, typeof(int)))));
            }
            catch { }

            try
            {
                this.rezVerticalTableAdapter.Fill(this.rEBUSDataSet.RezVertical, ((int)(System.Convert.ChangeType(rebusComboBox2.SelectedValue, typeof(int)))));
            }
            catch { }

            try
            {
                this.rez2TableAdapter.Fill(this.rEBUSDataSet.Rez2, ((int)(System.Convert.ChangeType(rebusComboBox2.SelectedValue, typeof(int)))));
                dataGridView3.DataSource = rEBUSDataSet.Rez2;
                dataGridView3.Refresh();
                dataGridView3.Update();
            }
            catch { }

            try
            {
                FillRebusuriDT((int)rebusComboBox2.SelectedValue);
                FillRezolvariDT((int)rebusComboBox2.SelectedValue);

                // Timp
                s = (int)rebusuriDT.Rows[0][4];
                h = (int)s / 3600;
                for (int i = 0; i < h; i++)
                {
                    s -= 3600;
                }
                m = (int)s / 60;
                for (int i = 0; i < m; i++)
                {
                    s -= 60;
                }

                if (h < 10) h1TextBox.Text = "0" + h.ToString();
                else h1TextBox.Text = h.ToString();
                if (m < 10) m1TextBox.Text = "0" + m.ToString();
                else m1TextBox.Text = m.ToString();
                if (s < 10) s1TextBox.Text = "0" + s.ToString();
                else s1TextBox.Text = s.ToString();

                int linii = (int)rebusuriDT.Rows[0][3], coloane = (int)rebusuriDT.Rows[0][2];
                int bX = 0, bY = 0;
                int bH = panel1.Height / linii, bW = panel1.Width / coloane;

                panel1.Controls.Clear();

                b = new Button[linii, coloane];

                rezolvari = new char[linii, coloane];

                for (int i = 0; i < linii; i++)
                {
                    for (int j = 0; j < coloane; j++)
                    {
                        b[i, j] = new Button();
                        b[i,j].Enabled = false;
                        b[i,j].BackColor = Color.Black;
                        b[i,j].Size = new Size(bW, bH);
                        b[i,j].Location = new Point(bX, bY);
                        b[i,j].Name = i.ToString() + j.ToString() + "Button";
                        b[i, j].KeyDown += new KeyEventHandler(ButtonKeyDown);
                        bX += bW;
                        rezolvari[i, j] = '0';

                        panel1.Controls.Add(b[i, j]); 
                    }
                    bX = 0;
                    bY += bH;
                }

                int count = rezolvariDT.Rows.Count;

                

                for (int k = 0; k < count; k++)
                {
                    char[] c = rezolvariDT.Rows[k][4].ToString().ToCharArray();

                    if (rezolvariDT.Rows[k][3].ToString() == "orizontal")
                    {
                        int lstart = (int)rezolvariDT.Rows[k][2] - 1;
                        int cstart = (int)rezolvariDT.Rows[k][1] - 1;
                        int chars = c.Count();

                        for (int j = cstart; j < cstart + chars; j++)
                        {
                            b[lstart, j].Enabled = true;
                            b[lstart, j].BackColor = Color.Transparent;
                            rezolvari[lstart, j] = c[j - cstart];
                        }
                    }
                    else
                    {
                        int lstart = (int)rezolvariDT.Rows[k][2] - 1;
                        int cstart = (int)rezolvariDT.Rows[k][1] - 1;
                        int chars = c.Count();

                        for (int i = lstart; i < lstart + chars; i++)
                        {
                            b[i, cstart].Enabled = true;
                            b[i, cstart].BackColor = Color.Transparent;
                            rezolvari[i, cstart] = c[i - lstart];
                        }
                    }
                }

                timer1.Start();

                
            }
            catch { }         
        }

        private void ButtonKeyDown(object sender, KeyEventArgs e)
        {
            Button b = (Button)sender;
            if(e.KeyValue >= '0' && e.KeyValue <= '9' || (e.KeyValue >= 'A' && e.KeyValue <= 'Z'))
            {
                b.Text = ((char)e.KeyValue).ToString();
            }                   
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (s > 0) s--;
            else
            {
                if (m > 0)
                {
                    s = 59;
                    m--;
                }
                else
                {
                    if (h > 0)
                    {
                        m = 59;
                        s = 59;
                        h--;
                    }
                    else timer1.Stop();
                }
            }

            if (h < 10) h2TextBox.Text = "0" + h.ToString();
            else h2TextBox.Text = h.ToString();
            if (m < 10) m2TextBox.Text = "0" + m.ToString();
            else m2TextBox.Text = m.ToString();
            if (s < 10) s2TextBox.Text = "0" + s.ToString();
            else s2TextBox.Text = s.ToString();
        }

        private void GetInfo(string path)
        {
            string[] date = new string[500];
            int idrebus = 0;

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {

                    char[] c = new char[1];
                    c[0] = '|';

                    date = sr.ReadLine().Split(c, StringSplitOptions.RemoveEmptyEntries);
                    idrebus = Convert.ToInt32(date[0]);

                    try
                    {
                        using (con = new SqlConnection(Services.connectionString))
                        {
                            con.Open();

                            string sqlInsert1 = "INSERT INTO Rebusuri Values (@id, UPPER(LEFT(@denumire,1)) + LOWER(SUBSTRING(@denumire,2,LEN(@denumire))), @nrcol, @nrl, @timp)";

                            cmd = new SqlCommand(sqlInsert1, con);
                            cmd.Parameters.AddWithValue("@id", date[0]);
                            cmd.Parameters.AddWithValue("@denumire", date[1]);
                            cmd.Parameters.AddWithValue("@nrcol", date[2]);
                            cmd.Parameters.AddWithValue("@nrl", date[3]);
                            cmd.Parameters.AddWithValue("@timp", date[4]);

                            cmd.ExecuteNonQuery();

                            while (!sr.EndOfStream)
                            {
                                date = sr.ReadLine().Split(c, StringSplitOptions.RemoveEmptyEntries);

                                int count = date.Count();

                                string sqlInsert2 = "INSERT INTO Rezolvari Values (@id, @cstart, @lstart, @orientare, UPPER(@sol), @textdef)";

                                cmd = new SqlCommand(sqlInsert2, con);
                                cmd.Parameters.AddWithValue("@id", idrebus);
                                cmd.Parameters.AddWithValue("@cstart", date[0]);
                                cmd.Parameters.AddWithValue("@lstart", date[1]);
                                cmd.Parameters.AddWithValue("@orientare", date[2]);
                                cmd.Parameters.AddWithValue("@sol", date[3]);
                                cmd.Parameters.AddWithValue("@textdef", date[4].ToString());

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Rebusul exista in baza de date", "Eroare");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Fisier incompatibil", "Eroare");
            }
        }

        private void adaugareRebusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    GetInfo(openFileDialog1.FileName);
                    rebusuriTableAdapter.Fill(rEBUSDataSet.Rebusuri);

                    if (tip == 1)
                    {
                        rebusComboBox_SelectedIndexChanged(null, null);
                        rebusComboBox.SelectedIndex = 0;
                    }
                    rebusComboBox2_SelectedIndexChanged(null, null);
                    rebusComboBox2.SelectedIndex = 0;
                }
                catch
                {
                    MessageBox.Show("Fisier incompatibil", "Eroare");
                }
            }
        }

        private void inregistrareUtilizatorToolStripMenuItem_Click(object sender, EventArgs e)
        {          
            if (iform.IsDisposed)
            {
                iform = new inregistrareForm();
                iform.IsAdmin(true);
                iform.Show();
                this.Hide();
            }
            else if (iform.Visible == false)
            {
                iform.IsAdmin(true);
                iform.Show();
                this.Hide();
            }
        }

        private void tiparireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(tip == 1)
            {
                tabControl1.SelectedTab = tabControl1.TabPages[1];
            }
            else tabControl1.SelectedTab = tabControl1.TabPages[0];

            bmp = new Bitmap(panel1.Width, panel1.Height);

            panel1.DrawToBitmap(bmp, new Rectangle(0, 0, panel1.Width, panel1.Height));

            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int pageW = printDocument1.DefaultPageSettings.PaperSize.Width;
            int pageH = printDocument1.DefaultPageSettings.PaperSize.Height;

            int y = panel1.Size.Height;

            Font f = new Font("Times New Roman", 9);
            int fontH = (int)f.GetHeight();


            e.Graphics.DrawImage(bmp, (pageW - panel1.Size.Width) / 2, 20);       

            string stringToPrint = rebusComboBox2.Text;

            e.Graphics.DrawString(stringToPrint, new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(e.MarginBounds.X, y + 50));

            stringToPrint = "-------------------------------------------------------------------------------------------------------------------------";

            e.Graphics.DrawString(stringToPrint, new Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(e.MarginBounds.X, y + 60));

            int count = rEBUSDataSet.RezOrizontal.Rows.Count;

            for (int i = 0; i < count; i++)
            {
                y += fontH + 1;

                stringToPrint = rEBUSDataSet.RezOrizontal.Rows[i][0].ToString();

                e.Graphics.DrawString(stringToPrint, f, Brushes.Black, new Point(e.MarginBounds.X, y + 70));

                stringToPrint = "Orizontal";

                e.Graphics.DrawString(stringToPrint, f, Brushes.Black, new Point(e.MarginBounds.X + 50, y + 70));

                stringToPrint = rEBUSDataSet.RezOrizontal.Rows[i][1].ToString();

                e.Graphics.DrawString(stringToPrint, f, Brushes.Black, new Point(e.MarginBounds.X + 200, y + 70));
            }

            count = rEBUSDataSet.RezVertical.Rows.Count;

            for (int i = 0; i < count; i++)
            {               
                y += fontH + 1;

                stringToPrint = rEBUSDataSet.RezVertical.Rows[i][0].ToString();

                e.Graphics.DrawString(stringToPrint, f, Brushes.Black, new Point(e.MarginBounds.X, y + 70));

                stringToPrint = "Vertical";

                e.Graphics.DrawString(stringToPrint, f, Brushes.Black, new Point(e.MarginBounds.X + 50, y + 70));

                stringToPrint = rEBUSDataSet.RezVertical.Rows[i][1].ToString();

                e.Graphics.DrawString(stringToPrint, f, Brushes.Black, new Point(e.MarginBounds.X + 200, y + 70));
            }
        }

        private void salvareButton_Click(object sender, EventArgs e)
        {
            int greseli = 0;

            int l = b.GetLength(0), c = b.GetLength(1);

            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if(b[i,j].Text != rezolvari[i,j].ToString() && b[i,j].Enabled == true)
                    {
                        greseli++;
                    }
                }
            }
            if (greseli == 1) MessageBox.Show(greseli.ToString() + " greseala", "Greseli");
            else if (greseli > 1)
            {
                MessageBox.Show(greseli.ToString() + " greseli", "Greseli");
            }
            else MessageBox.Show("Nici o greseala", "Felicitari!");


            using (con = new SqlConnection(Services.connectionString))
            {
                con.Open();

                string sqlInsert = "INSERT INTO Statistica VALUES (@idu, @idr, @timp, @gr, @stare)";

                int timp = h * 3600 + m * 60 + s;

                cmd = new SqlCommand(sqlInsert, con);
                cmd.Parameters.AddWithValue("@idu", id);
                cmd.Parameters.AddWithValue("@idr", rebusComboBox2.SelectedValue);
                cmd.Parameters.AddWithValue("@timp",timp);
                cmd.Parameters.AddWithValue("@gr", greseli);
                if(greseli>0 || timp == 0)
                {
                    cmd.Parameters.AddWithValue("@stare", 2);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@stare", 1);
                }

                cmd.ExecuteNonQuery();        
            }
        }

        private void delogareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.OpenForms["logareForm"].Visible = true;
            this.Close();
        }

        private void iesireDinAplicatieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
