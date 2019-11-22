namespace BackupRestore
{
    partial class frmCalculando
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnOculto = new System.Windows.Forms.Button();
            this.btnCancelar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label1 = new System.Windows.Forms.Label();
            this.prgb = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.kryptonPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(531, 112);
            this.panel1.TabIndex = 0;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.btnOculto);
            this.kryptonPanel1.Controls.Add(this.btnCancelar);
            this.kryptonPanel1.Controls.Add(this.label1);
            this.kryptonPanel1.Controls.Add(this.prgb);
            this.kryptonPanel1.Controls.Add(this.pictureBox1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonPanel1.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.FormCustom1;
            this.kryptonPanel1.Size = new System.Drawing.Size(529, 110);
            this.kryptonPanel1.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.GlassNormalFull;
            this.kryptonPanel1.TabIndex = 1;
            // 
            // btnOculto
            // 
            this.btnOculto.Location = new System.Drawing.Point(417, 77);
            this.btnOculto.Name = "btnOculto";
            this.btnOculto.Size = new System.Drawing.Size(75, 23);
            this.btnOculto.TabIndex = 6;
            this.btnOculto.Text = "button1";
            this.btnOculto.UseVisualStyleBackColor = true;
            this.btnOculto.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Custom1;
            this.btnCancelar.Location = new System.Drawing.Point(209, 72);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 28);
            this.btnCancelar.StateCommon.Back.Color2 = System.Drawing.Color.LightSlateGray;
            this.btnCancelar.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounded;
            this.btnCancelar.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCancelar.StateCommon.Border.Rounding = 6;
            this.btnCancelar.StateCommon.Border.Width = 2;
            this.btnCancelar.StateCommon.Content.DrawFocus = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.btnCancelar.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.StateDisabled.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCancelar.StateDisabled.Border.Rounding = 6;
            this.btnCancelar.StateDisabled.Border.Width = 2;
            this.btnCancelar.StateDisabled.Content.DrawFocus = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.btnCancelar.StateNormal.Back.Color2 = System.Drawing.Color.LightSlateGray;
            this.btnCancelar.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCancelar.StateNormal.Border.Rounding = 6;
            this.btnCancelar.StateNormal.Border.Width = 2;
            this.btnCancelar.StateNormal.Content.DrawFocus = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.btnCancelar.StatePressed.Back.Color1 = System.Drawing.Color.LightSteelBlue;
            this.btnCancelar.StatePressed.Back.Color2 = System.Drawing.Color.AliceBlue;
            this.btnCancelar.StatePressed.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounded;
            this.btnCancelar.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCancelar.StatePressed.Border.Rounding = 6;
            this.btnCancelar.StatePressed.Border.Width = 2;
            this.btnCancelar.StatePressed.Content.DrawFocus = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.btnCancelar.StateTracking.Back.Color1 = System.Drawing.Color.GhostWhite;
            this.btnCancelar.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
                        | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCancelar.StateTracking.Border.Rounding = 6;
            this.btnCancelar.StateTracking.Border.Width = 2;
            this.btnCancelar.StateTracking.Content.DrawFocus = ComponentFactory.Krypton.Toolkit.InheritBool.False;
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Values.Text = "&Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma Console", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(383, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Calculando el tamaño de los archivos, espere...";
            // 
            // prgb
            // 
            this.prgb.Location = new System.Drawing.Point(70, 40);
            this.prgb.Name = "prgb";
            this.prgb.Size = new System.Drawing.Size(444, 23);
            this.prgb.Step = 1;
            this.prgb.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.prgb.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::BackupRestore.Properties.Resources.Options;
            this.pictureBox1.Location = new System.Drawing.Point(11, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // frmCalculando
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 112);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCalculando";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGuardar";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCalculando_KeyDown);
            this.Leave += new System.EventHandler(this.frmCalculando_Leave);
            this.Load += new System.EventHandler(this.frmCalculando_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar prgb;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancelar;
        private System.Windows.Forms.Button btnOculto;


    }
}