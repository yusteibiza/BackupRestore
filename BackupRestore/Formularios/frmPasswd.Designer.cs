namespace BackupRestore
{
    partial class frmPasswd
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPasswd));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPasswd = new System.Windows.Forms.TextBox();
            this.pbVerPasswordSMTP = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.lblIntentos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVerPasswordSMTP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.groupBox1);
            this.kryptonPanel1.Controls.Add(this.btnSalir);
            this.kryptonPanel1.Controls.Add(this.btnEntrar);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonPanel1.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ButtonStandalone;
            this.kryptonPanel1.Size = new System.Drawing.Size(428, 181);
            this.kryptonPanel1.StateCommon.Color1 = System.Drawing.Color.White;
            this.kryptonPanel1.StateCommon.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.kryptonPanel1.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.RoundedTopLight;
            this.kryptonPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lblIntentos);
            this.groupBox1.Controls.Add(this.txtPasswd);
            this.groupBox1.Controls.Add(this.pbVerPasswordSMTP);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(17, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(393, 113);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de acceso";
            // 
            // txtPasswd
            // 
            this.txtPasswd.Location = new System.Drawing.Point(123, 64);
            this.txtPasswd.Name = "txtPasswd";
            this.txtPasswd.Size = new System.Drawing.Size(220, 26);
            this.txtPasswd.TabIndex = 22;
            this.txtPasswd.UseSystemPasswordChar = true;
            this.txtPasswd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPasswd_KeyDown_1);
            // 
            // pbVerPasswordSMTP
            // 
            this.pbVerPasswordSMTP.BackColor = System.Drawing.Color.White;
            this.pbVerPasswordSMTP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbVerPasswordSMTP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbVerPasswordSMTP.Image = global::BackupRestore.Properties.Resources.thumb_Password_Reveal_button;
            this.pbVerPasswordSMTP.Location = new System.Drawing.Point(342, 64);
            this.pbVerPasswordSMTP.Margin = new System.Windows.Forms.Padding(4);
            this.pbVerPasswordSMTP.Name = "pbVerPasswordSMTP";
            this.pbVerPasswordSMTP.Size = new System.Drawing.Size(31, 26);
            this.pbVerPasswordSMTP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbVerPasswordSMTP.TabIndex = 21;
            this.pbVerPasswordSMTP.TabStop = false;
            this.pbVerPasswordSMTP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbVerPasswordSMTP_MouseDown);
            this.pbVerPasswordSMTP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbVerPasswordSMTP_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(119, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Password:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::BackupRestore.Properties.Resources.Lock;
            this.pictureBox1.Location = new System.Drawing.Point(21, 27);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 69);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(246, 135);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(131, 37);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEntrar
            // 
            this.btnEntrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrar.Location = new System.Drawing.Point(51, 135);
            this.btnEntrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(131, 37);
            this.btnEntrar.TabIndex = 3;
            this.btnEntrar.Text = "&Entrar";
            this.btnEntrar.UseVisualStyleBackColor = true;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // lblIntentos
            // 
            this.lblIntentos.AutoSize = true;
            this.lblIntentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntentos.Location = new System.Drawing.Point(258, 12);
            this.lblIntentos.Name = "lblIntentos";
            this.lblIntentos.Size = new System.Drawing.Size(133, 17);
            this.lblIntentos.TabIndex = 23;
            this.lblIntentos.Text = "3 intentos restantes";
            // 
            // frmPasswd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 181);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmPasswd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acceso a Restaurar Copias...";
            this.Load += new System.EventHandler(this.frmPasswd_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPasswd_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmPasswd_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVerPasswordSMTP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbVerPasswordSMTP;
        private System.Windows.Forms.TextBox txtPasswd;
        private System.Windows.Forms.Label lblIntentos;
    }
}