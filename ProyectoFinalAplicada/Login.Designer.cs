namespace ProyectoFinalAplicada
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            this.Ingresarbutton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ContrasenatextBox = new System.Windows.Forms.TextBox();
            this.NombretextBox = new System.Windows.Forms.TextBox();
            this.Cancelartbutton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // Ingresarbutton
            // 
            this.Ingresarbutton.Location = new System.Drawing.Point(185, 100);
            this.Ingresarbutton.Name = "Ingresarbutton";
            this.Ingresarbutton.Size = new System.Drawing.Size(76, 23);
            this.Ingresarbutton.TabIndex = 9;
            this.Ingresarbutton.Text = "Ingresar";
            this.Ingresarbutton.UseVisualStyleBackColor = true;
            this.Ingresarbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nombre:";
            // 
            // ContrasenatextBox
            // 
            this.ContrasenatextBox.Location = new System.Drawing.Point(211, 53);
            this.ContrasenatextBox.Name = "ContrasenatextBox";
            this.ContrasenatextBox.Size = new System.Drawing.Size(139, 20);
            this.ContrasenatextBox.TabIndex = 6;
            // 
            // NombretextBox
            // 
            this.NombretextBox.Location = new System.Drawing.Point(211, 14);
            this.NombretextBox.Name = "NombretextBox";
            this.NombretextBox.Size = new System.Drawing.Size(139, 20);
            this.NombretextBox.TabIndex = 5;
            // 
            // Cancelartbutton
            // 
            this.Cancelartbutton.Location = new System.Drawing.Point(267, 100);
            this.Cancelartbutton.Name = "Cancelartbutton";
            this.Cancelartbutton.Size = new System.Drawing.Size(76, 24);
            this.Cancelartbutton.TabIndex = 11;
            this.Cancelartbutton.Text = "Cancelar";
            this.Cancelartbutton.UseVisualStyleBackColor = true;
            this.Cancelartbutton.Click += new System.EventHandler(this.Cancelartbutton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::ProyectoFinalAplicada.Properties.Resources.icono_del_azul_del_usuario_43464682;
            this.pictureBox1.Location = new System.Drawing.Point(12, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(366, 144);
            this.Controls.Add(this.Cancelartbutton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Ingresarbutton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ContrasenatextBox);
            this.Controls.Add(this.NombretextBox);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Ingresarbutton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ContrasenatextBox;
        private System.Windows.Forms.TextBox NombretextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Cancelartbutton;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}

