namespace BackupRestore
{
    partial class frmInfoRestComp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInfoRestComp));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblTamaño = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.prgRest = new System.Windows.Forms.ProgressBar();
            this.lvZips = new System.Windows.Forms.ListView();
            this.chNombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTam = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCrc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblInfo0 = new System.Windows.Forms.Label();
            this.btnPausar = new System.Windows.Forms.Button();
            this.btnParar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.lblTamaño);
            this.kryptonPanel1.Controls.Add(this.label1);
            this.kryptonPanel1.Controls.Add(this.btnPausar);
            this.kryptonPanel1.Controls.Add(this.lblInfo);
            this.kryptonPanel1.Controls.Add(this.btnParar);
            this.kryptonPanel1.Controls.Add(this.prgRest);
            this.kryptonPanel1.Controls.Add(this.lvZips);
            this.kryptonPanel1.Controls.Add(this.lblInfo0);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(909, 573);
            this.kryptonPanel1.StateCommon.Color1 = System.Drawing.Color.White;
            this.kryptonPanel1.StateCommon.Color2 = System.Drawing.Color.Gray;
            this.kryptonPanel1.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Linear;
            this.kryptonPanel1.TabIndex = 0;
            // 
            // lblTamaño
            // 
            this.lblTamaño.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTamaño.AutoSize = true;
            this.lblTamaño.BackColor = System.Drawing.Color.Transparent;
            this.lblTamaño.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTamaño.ForeColor = System.Drawing.Color.White;
            this.lblTamaño.Location = new System.Drawing.Point(243, 498);
            this.lblTamaño.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTamaño.Name = "lblTamaño";
            this.lblTamaño.Size = new System.Drawing.Size(40, 20);
            this.lblTamaño.TabIndex = 7;
            this.lblTamaño.Text = "x / x";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 498);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tamaño restante del archivo:";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblInfo.Location = new System.Drawing.Point(13, 39);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(879, 25);
            this.lblInfo.TabIndex = 4;
            // 
            // prgRest
            // 
            this.prgRest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgRest.Location = new System.Drawing.Point(17, 522);
            this.prgRest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.prgRest.Name = "prgRest";
            this.prgRest.Size = new System.Drawing.Size(623, 28);
            this.prgRest.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.prgRest.TabIndex = 2;
            // 
            // lvZips
            // 
            this.lvZips.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvZips.BackColor = System.Drawing.Color.Silver;
            this.lvZips.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNombre,
            this.chFecha,
            this.chTam,
            this.chCrc});
            this.lvZips.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvZips.FullRowSelect = true;
            this.lvZips.GridLines = true;
            this.lvZips.Location = new System.Drawing.Point(13, 68);
            this.lvZips.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvZips.Name = "lvZips";
            this.lvZips.Size = new System.Drawing.Size(883, 416);
            this.lvZips.TabIndex = 1;
            this.lvZips.UseCompatibleStateImageBehavior = false;
            this.lvZips.View = System.Windows.Forms.View.Details;
            // 
            // chNombre
            // 
            this.chNombre.Text = "Nombre";
            this.chNombre.Width = 335;
            // 
            // chFecha
            // 
            this.chFecha.Text = "Fecha";
            this.chFecha.Width = 101;
            // 
            // chTam
            // 
            this.chTam.Text = "Tamaño (KB)";
            this.chTam.Width = 100;
            // 
            // chCrc
            // 
            this.chCrc.Text = "CRC";
            this.chCrc.Width = 117;
            // 
            // lblInfo0
            // 
            this.lblInfo0.AutoSize = true;
            this.lblInfo0.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblInfo0.Location = new System.Drawing.Point(8, 9);
            this.lblInfo0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo0.Name = "lblInfo0";
            this.lblInfo0.Size = new System.Drawing.Size(378, 25);
            this.lblInfo0.TabIndex = 0;
            this.lblInfo0.Text = "Restaurando copias comprimidas de...";
            // 
            // btnPausar
            // 
            this.btnPausar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPausar.BackColor = System.Drawing.Color.Transparent;
            this.btnPausar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPausar.FlatAppearance.BorderSize = 0;
            this.btnPausar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnPausar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPausar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPausar.ForeColor = System.Drawing.Color.White;
            this.btnPausar.Image = global::BackupRestore.Properties.Resources.Pause32x32;
            this.btnPausar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPausar.Location = new System.Drawing.Point(654, 513);
            this.btnPausar.Margin = new System.Windows.Forms.Padding(4);
            this.btnPausar.Name = "btnPausar";
            this.btnPausar.Size = new System.Drawing.Size(133, 48);
            this.btnPausar.TabIndex = 5;
            this.btnPausar.Text = "P&ausar";
            this.btnPausar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPausar.UseVisualStyleBackColor = false;
            this.btnPausar.Click += new System.EventHandler(this.btnPausar_Click);
            // 
            // btnParar
            // 
            this.btnParar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParar.BackColor = System.Drawing.Color.Transparent;
            this.btnParar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnParar.FlatAppearance.BorderSize = 0;
            this.btnParar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnParar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParar.ForeColor = System.Drawing.Color.White;
            this.btnParar.Image = global::BackupRestore.Properties.Resources.Error32x32;
            this.btnParar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnParar.Location = new System.Drawing.Point(789, 513);
            this.btnParar.Margin = new System.Windows.Forms.Padding(4);
            this.btnParar.Name = "btnParar";
            this.btnParar.Size = new System.Drawing.Size(104, 48);
            this.btnParar.TabIndex = 3;
            this.btnParar.Text = "&Parar";
            this.btnParar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnParar.UseVisualStyleBackColor = false;
            this.btnParar.Click += new System.EventHandler(this.btnParar_Click);
            // 
            // frmInfoRestComp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 573);
            this.Controls.Add(this.kryptonPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimizeBox = false;
            this.Name = "frmInfoRestComp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restaurando...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInfoRestComp_FormClosing);
            this.Load += new System.EventHandler(this.frmInfoRestComp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.Button btnParar;
        private System.Windows.Forms.ProgressBar prgRest;
        private System.Windows.Forms.ListView lvZips;
        private System.Windows.Forms.Label lblInfo0;
        private System.Windows.Forms.ColumnHeader chNombre;
        private System.Windows.Forms.ColumnHeader chFecha;
        private System.Windows.Forms.ColumnHeader chTam;
        private System.Windows.Forms.ColumnHeader chCrc;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnPausar;
        private System.Windows.Forms.Label lblTamaño;
        private System.Windows.Forms.Label label1;
    }
}