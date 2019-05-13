namespace Rebus
{
    partial class inregistrareForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(inregistrareForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.utilizatorTextBox = new System.Windows.Forms.TextBox();
            this.parolaTextBox = new System.Windows.Forms.TextBox();
            this.rparolaTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.tipComboBox = new System.Windows.Forms.ComboBox();
            this.renuntaButton = new System.Windows.Forms.Button();
            this.inregistrareButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nume utilizator";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Parola";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Repetati parola";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 337);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 23);
            this.label5.TabIndex = 5;
            this.label5.Text = "Tip utilizator";
            // 
            // utilizatorTextBox
            // 
            this.utilizatorTextBox.Location = new System.Drawing.Point(186, 181);
            this.utilizatorTextBox.Name = "utilizatorTextBox";
            this.utilizatorTextBox.Size = new System.Drawing.Size(213, 20);
            this.utilizatorTextBox.TabIndex = 6;
            // 
            // parolaTextBox
            // 
            this.parolaTextBox.Location = new System.Drawing.Point(186, 221);
            this.parolaTextBox.Name = "parolaTextBox";
            this.parolaTextBox.PasswordChar = '*';
            this.parolaTextBox.Size = new System.Drawing.Size(213, 20);
            this.parolaTextBox.TabIndex = 7;
            // 
            // rparolaTextBox
            // 
            this.rparolaTextBox.Location = new System.Drawing.Point(186, 261);
            this.rparolaTextBox.Name = "rparolaTextBox";
            this.rparolaTextBox.PasswordChar = '*';
            this.rparolaTextBox.Size = new System.Drawing.Size(213, 20);
            this.rparolaTextBox.TabIndex = 8;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(186, 301);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(213, 20);
            this.emailTextBox.TabIndex = 9;
            // 
            // tipComboBox
            // 
            this.tipComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipComboBox.FormattingEnabled = true;
            this.tipComboBox.Items.AddRange(new object[] {
            "Utilizator"});
            this.tipComboBox.Location = new System.Drawing.Point(186, 341);
            this.tipComboBox.Name = "tipComboBox";
            this.tipComboBox.Size = new System.Drawing.Size(213, 21);
            this.tipComboBox.TabIndex = 10;
            // 
            // renuntaButton
            // 
            this.renuntaButton.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.renuntaButton.Location = new System.Drawing.Point(16, 429);
            this.renuntaButton.Name = "renuntaButton";
            this.renuntaButton.Size = new System.Drawing.Size(95, 35);
            this.renuntaButton.TabIndex = 11;
            this.renuntaButton.Text = "Renunta";
            this.renuntaButton.UseVisualStyleBackColor = true;
            this.renuntaButton.Click += new System.EventHandler(this.renuntaButton_Click);
            // 
            // inregistrareButton
            // 
            this.inregistrareButton.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inregistrareButton.Location = new System.Drawing.Point(304, 429);
            this.inregistrareButton.Name = "inregistrareButton";
            this.inregistrareButton.Size = new System.Drawing.Size(95, 35);
            this.inregistrareButton.TabIndex = 12;
            this.inregistrareButton.Text = "Inregistrare";
            this.inregistrareButton.UseVisualStyleBackColor = true;
            this.inregistrareButton.Click += new System.EventHandler(this.inregistrareButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(383, 138);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // inregistrareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightYellow;
            this.ClientSize = new System.Drawing.Size(411, 477);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.inregistrareButton);
            this.Controls.Add(this.renuntaButton);
            this.Controls.Add(this.tipComboBox);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.rparolaTextBox);
            this.Controls.Add(this.parolaTextBox);
            this.Controls.Add(this.utilizatorTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "inregistrareForm";
            this.Text = "FrmInregistrare";
            this.Load += new System.EventHandler(this.inregistrareForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox utilizatorTextBox;
        private System.Windows.Forms.TextBox parolaTextBox;
        private System.Windows.Forms.TextBox rparolaTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.ComboBox tipComboBox;
        private System.Windows.Forms.Button renuntaButton;
        private System.Windows.Forms.Button inregistrareButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}