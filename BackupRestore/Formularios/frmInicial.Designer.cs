namespace BackupRestore
{
	partial class frmInicial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInicial));
            this.sts = new System.Windows.Forms.StatusStrip();
            this.stsLbl1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnSec = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lklblOpciones = new System.Windows.Forms.LinkLabel();
            this.llblLogs = new System.Windows.Forms.LinkLabel();
            this.lnkAcerca = new System.Windows.Forms.LinkLabel();
            this.lnkSalir = new System.Windows.Forms.LinkLabel();
            this.kryptonPanel2 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.lblHora = new System.Windows.Forms.Label();
            this.tmrSalida = new System.Windows.Forms.Timer(this.components);
            this.tmrEntrada = new System.Windows.Forms.Timer(this.components);
            this.tmrAcerca = new System.Windows.Forms.Timer(this.components);
            this.sts.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // sts
            // 
            this.sts.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.sts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsLbl1});
            this.sts.Location = new System.Drawing.Point(0, 329);
            this.sts.Name = "sts";
            this.sts.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.sts.Size = new System.Drawing.Size(649, 23);
            this.sts.TabIndex = 1;
            this.sts.Text = "statusStrip1";
            // 
            // stsLbl1
            // 
            this.stsLbl1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.stsLbl1.Name = "stsLbl1";
            this.stsLbl1.Size = new System.Drawing.Size(629, 18);
            this.stsLbl1.Spring = true;
            this.stsLbl1.Text = "¡¡¡ Hola !!!";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.kryptonPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(649, 84);
            this.panel1.TabIndex = 4;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.btnSec);
            this.kryptonPanel1.Controls.Add(this.label2);
            this.kryptonPanel1.Controls.Add(this.pictureBox1);
            this.kryptonPanel1.Controls.Add(this.label1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.SeparatorHighProfile;
            this.kryptonPanel1.Size = new System.Drawing.Size(647, 82);
            this.kryptonPanel1.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.RoundedTopLeftWhite;
            this.kryptonPanel1.TabIndex = 0;
            // 
            // btnSec
            // 
            this.btnSec.Location = new System.Drawing.Point(501, 14);
            this.btnSec.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSec.Name = "btnSec";
            this.btnSec.Size = new System.Drawing.Size(100, 28);
            this.btnSec.TabIndex = 1;
            this.btnSec.TabStop = false;
            this.btnSec.Text = "btnSec";
            this.btnSec.UseVisualStyleBackColor = true;
            this.btnSec.Visible = false;
            this.btnSec.Click += new System.EventHandler(this.btnSec_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(121, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(489, 2);
            this.label2.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 5);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(115, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Backup && Restore";
            // 
            // lklblOpciones
            // 
            this.lklblOpciones.AutoSize = true;
            this.lklblOpciones.BackColor = System.Drawing.Color.Transparent;
            this.lklblOpciones.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lklblOpciones.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lklblOpciones.Location = new System.Drawing.Point(252, 4);
            this.lklblOpciones.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lklblOpciones.Name = "lklblOpciones";
            this.lklblOpciones.Size = new System.Drawing.Size(87, 20);
            this.lklblOpciones.TabIndex = 1;
            this.lklblOpciones.TabStop = true;
            this.lklblOpciones.Text = "&Opciones";
            this.lklblOpciones.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklblOpciones_LinkClicked);
            this.lklblOpciones.MouseEnter += new System.EventHandler(this.llblMenus_MouseEnter);
            this.lklblOpciones.MouseLeave += new System.EventHandler(this.llblMenus_MouseLeave);
            // 
            // llblLogs
            // 
            this.llblLogs.AutoSize = true;
            this.llblLogs.BackColor = System.Drawing.Color.Transparent;
            this.llblLogs.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblLogs.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llblLogs.Location = new System.Drawing.Point(45, 4);
            this.llblLogs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llblLogs.Name = "llblLogs";
            this.llblLogs.Size = new System.Drawing.Size(153, 20);
            this.llblLogs.TabIndex = 0;
            this.llblLogs.TabStop = true;
            this.llblLogs.Text = "&Visor de Eventos";
            this.llblLogs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblLogs_LinkClicked);
            this.llblLogs.MouseEnter += new System.EventHandler(this.llblMenus_MouseEnter);
            this.llblLogs.MouseLeave += new System.EventHandler(this.llblMenus_MouseLeave);
            // 
            // lnkAcerca
            // 
            this.lnkAcerca.AutoSize = true;
            this.lnkAcerca.BackColor = System.Drawing.Color.Transparent;
            this.lnkAcerca.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAcerca.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkAcerca.Location = new System.Drawing.Point(393, 4);
            this.lnkAcerca.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkAcerca.Name = "lnkAcerca";
            this.lnkAcerca.Size = new System.Drawing.Size(111, 20);
            this.lnkAcerca.TabIndex = 2;
            this.lnkAcerca.TabStop = true;
            this.lnkAcerca.Text = "&Acerca de...";
            this.lnkAcerca.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAcerca_LinkClicked);
            this.lnkAcerca.MouseEnter += new System.EventHandler(this.llblMenus_MouseEnter);
            this.lnkAcerca.MouseLeave += new System.EventHandler(this.llblMenus_MouseLeave);
            // 
            // lnkSalir
            // 
            this.lnkSalir.AutoSize = true;
            this.lnkSalir.BackColor = System.Drawing.Color.Transparent;
            this.lnkSalir.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkSalir.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkSalir.Location = new System.Drawing.Point(555, 4);
            this.lnkSalir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkSalir.Name = "lnkSalir";
            this.lnkSalir.Size = new System.Drawing.Size(48, 20);
            this.lnkSalir.TabIndex = 3;
            this.lnkSalir.TabStop = true;
            this.lnkSalir.Text = "&Salir";
            this.lnkSalir.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSalir_LinkClicked);
            this.lnkSalir.MouseEnter += new System.EventHandler(this.llblMenus_MouseEnter);
            this.lnkSalir.MouseLeave += new System.EventHandler(this.llblMenus_MouseLeave);
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.panel3);
            this.kryptonPanel2.Controls.Add(this.panel2);
            this.kryptonPanel2.Controls.Add(this.lklblOpciones);
            this.kryptonPanel2.Controls.Add(this.btnCopiar);
            this.kryptonPanel2.Controls.Add(this.llblLogs);
            this.kryptonPanel2.Controls.Add(this.btnConfig);
            this.kryptonPanel2.Controls.Add(this.lnkAcerca);
            this.kryptonPanel2.Controls.Add(this.btnRestaurar);
            this.kryptonPanel2.Controls.Add(this.lnkSalir);
            this.kryptonPanel2.Controls.Add(this.lblHora);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 84);
            this.kryptonPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(649, 245);
            this.kryptonPanel2.StateCommon.Color1 = System.Drawing.Color.WhiteSmoke;
            this.kryptonPanel2.StateCommon.Color2 = System.Drawing.Color.LightGray;
            this.kryptonPanel2.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.GlassCenter;
            this.kryptonPanel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkGray;
            this.panel3.Location = new System.Drawing.Point(39, 30);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(571, 1);
            this.panel3.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Location = new System.Drawing.Point(39, 215);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(571, 1);
            this.panel2.TabIndex = 12;
            // 
            // btnCopiar
            // 
            this.btnCopiar.BackColor = System.Drawing.Color.Transparent;
            this.btnCopiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCopiar.FlatAppearance.BorderSize = 0;
            this.btnCopiar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCopiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnCopiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopiar.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopiar.Image = global::BackupRestore.Properties.Resources.iCandy_Junior_031_72x72;
            this.btnCopiar.Location = new System.Drawing.Point(239, 44);
            this.btnCopiar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(172, 156);
            this.btnCopiar.TabIndex = 5;
            this.btnCopiar.Text = "Co&piar";
            this.btnCopiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCopiar.UseVisualStyleBackColor = false;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            this.btnCopiar.MouseEnter += new System.EventHandler(this.BotonesCentrales_MouseEnter);
            this.btnCopiar.MouseLeave += new System.EventHandler(this.BotonesCentrales_MouseLeave);
            this.btnCopiar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCopiar_MouseMove);
            // 
            // btnConfig
            // 
            this.btnConfig.BackColor = System.Drawing.Color.Transparent;
            this.btnConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfig.FlatAppearance.BorderSize = 0;
            this.btnConfig.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfig.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfig.Image = global::BackupRestore.Properties.Resources.iCandy_Junior_047_72x72;
            this.btnConfig.Location = new System.Drawing.Point(37, 44);
            this.btnConfig.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(172, 156);
            this.btnConfig.TabIndex = 4;
            this.btnConfig.Text = "&Configurar";
            this.btnConfig.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConfig.UseVisualStyleBackColor = false;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            this.btnConfig.MouseEnter += new System.EventHandler(this.BotonesCentrales_MouseEnter);
            this.btnConfig.MouseLeave += new System.EventHandler(this.BotonesCentrales_MouseLeave);
            this.btnConfig.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnConfig_MouseMove);
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.BackColor = System.Drawing.Color.Transparent;
            this.btnRestaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestaurar.FlatAppearance.BorderSize = 0;
            this.btnRestaurar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRestaurar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurar.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestaurar.Image = global::BackupRestore.Properties.Resources.iCandy_Junior_056_72x72;
            this.btnRestaurar.Location = new System.Drawing.Point(439, 44);
            this.btnRestaurar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(172, 156);
            this.btnRestaurar.TabIndex = 6;
            this.btnRestaurar.Text = "&Restaurar";
            this.btnRestaurar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRestaurar.UseVisualStyleBackColor = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            this.btnRestaurar.MouseEnter += new System.EventHandler(this.BotonesCentrales_MouseEnter);
            this.btnRestaurar.MouseLeave += new System.EventHandler(this.BotonesCentrales_MouseLeave);
            this.btnRestaurar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnRestaurar_MouseMove);
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.BackColor = System.Drawing.Color.Transparent;
            this.lblHora.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.Location = new System.Drawing.Point(288, 226);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(72, 18);
            this.lblHora.TabIndex = 11;
            this.lblHora.Text = "00:00:00";
            this.lblHora.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tmrSalida
            // 
            this.tmrSalida.Interval = 25;
            this.tmrSalida.Tick += new System.EventHandler(this.tmrSalida_Tick);
            // 
            // tmrEntrada
            // 
            this.tmrEntrada.Interval = 25;
            this.tmrEntrada.Tick += new System.EventHandler(this.tmrEntrada_Tick);
            // 
            // tmrAcerca
            // 
            this.tmrAcerca.Interval = 25;
            // 
            // frmInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 352);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup & Restore";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInicial_FormClosing);
            this.Load += new System.EventHandler(this.frmInicial_Load);
            this.sts.ResumeLayout(false);
            this.sts.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.StatusStrip sts;
        private System.Windows.Forms.ToolStripStatusLabel stsLbl1;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.LinkLabel llblLogs;
        private System.Windows.Forms.LinkLabel lnkAcerca;
        private System.Windows.Forms.LinkLabel lnkSalir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel2;
        private System.Windows.Forms.Button btnRestaurar;
        private System.Windows.Forms.Button btnCopiar;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnSec;
        private System.Windows.Forms.Timer tmrSalida;
        private System.Windows.Forms.Timer tmrEntrada;
        private System.Windows.Forms.Timer tmrAcerca;
        private System.Windows.Forms.LinkLabel lklblOpciones;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}

