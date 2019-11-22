namespace BackupRestore
{
    partial class frmCopiar
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCopiar));
            this.panel1 = new System.Windows.Forms.Panel();
            this.kpnlErrores = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.pbErrores = new System.Windows.Forms.PictureBox();
            this.kryptonPanel4 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblListadoErrores = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.krpnlErrores = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel5 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblInfoErrores = new System.Windows.Forms.Label();
            this.ssInfoErrores = new System.Windows.Forms.StatusStrip();
            this.tsslblNumErrores = new System.Windows.Forms.ToolStripStatusLabel();
            this.lvErrores = new System.Windows.Forms.ListView();
            this.chOrigenError = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDescErr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgLstErrores = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.krpnlCopias = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblCiclo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.kryptonPanel3 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblXciento = new System.Windows.Forms.Label();
            this.lblDirCopias = new System.Windows.Forms.Label();
            this.chkApagar = new System.Windows.Forms.CheckBox();
            this.btnParar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.krpnlabajo = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnErrores = new System.Windows.Forms.Button();
            this.lblErrores = new System.Windows.Forms.Label();
            this.pbCopiando = new System.Windows.Forms.PictureBox();
            this.lblContador = new System.Windows.Forms.Label();
            this.lblObjeto = new System.Windows.Forms.Label();
            this.lblCopiando = new System.Windows.Forms.Label();
            this.btnSalir = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnEmpezar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnConfigurar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProgreso = new System.Windows.Forms.Label();
            this.tmrCopiando = new System.Windows.Forms.Timer(this.components);
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxEstado = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlErrores)).BeginInit();
            this.kpnlErrores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbErrores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel4)).BeginInit();
            this.kryptonPanel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.krpnlErrores)).BeginInit();
            this.krpnlErrores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel5)).BeginInit();
            this.ssInfoErrores.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.krpnlCopias)).BeginInit();
            this.krpnlCopias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnParar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.krpnlabajo)).BeginInit();
            this.krpnlabajo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCopiando)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEmpezar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConfigurar)).BeginInit();
            this.ctxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.kpnlErrores);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.kryptonPanel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(923, 688);
            this.panel1.TabIndex = 0;
            // 
            // kpnlErrores
            // 
            this.kpnlErrores.Controls.Add(this.label4);
            this.kpnlErrores.Controls.Add(this.pbErrores);
            this.kpnlErrores.Controls.Add(this.kryptonPanel4);
            this.kpnlErrores.Controls.Add(this.panel3);
            this.kpnlErrores.Controls.Add(this.ssInfoErrores);
            this.kpnlErrores.Controls.Add(this.lvErrores);
            this.kpnlErrores.Location = new System.Drawing.Point(0, 316);
            this.kpnlErrores.Margin = new System.Windows.Forms.Padding(4);
            this.kpnlErrores.Name = "kpnlErrores";
            this.kpnlErrores.Size = new System.Drawing.Size(920, 370);
            this.kpnlErrores.StateCommon.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.kpnlErrores.StateCommon.Color2 = System.Drawing.Color.GhostWhite;
            this.kpnlErrores.StateCommon.ColorAngle = 120F;
            this.kpnlErrores.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Rounded;
            this.kpnlErrores.TabIndex = 12;
            this.kpnlErrores.Visible = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 135);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 204);
            this.label4.TabIndex = 18;
            this.label4.Text = "Aquí se enumera una lista con los errores ocurridos durante el proceso de copias " +
    "de seguridad. Si se han producido errores, reviselos e intente arreglarlo ya que" +
    " sino la copias serán erroneas.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbErrores
            // 
            this.pbErrores.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbErrores.BackColor = System.Drawing.Color.Transparent;
            this.pbErrores.Image = ((System.Drawing.Image)(resources.GetObject("pbErrores.Image")));
            this.pbErrores.Location = new System.Drawing.Point(53, 59);
            this.pbErrores.Margin = new System.Windows.Forms.Padding(4);
            this.pbErrores.Name = "pbErrores";
            this.pbErrores.Size = new System.Drawing.Size(64, 64);
            this.pbErrores.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbErrores.TabIndex = 8;
            this.pbErrores.TabStop = false;
            // 
            // kryptonPanel4
            // 
            this.kryptonPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonPanel4.Controls.Add(this.lblListadoErrores);
            this.kryptonPanel4.Location = new System.Drawing.Point(169, 59);
            this.kryptonPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonPanel4.Name = "kryptonPanel4";
            this.kryptonPanel4.Size = new System.Drawing.Size(736, 36);
            this.kryptonPanel4.StateCommon.Color1 = System.Drawing.Color.Black;
            this.kryptonPanel4.StateCommon.Color2 = System.Drawing.Color.CornflowerBlue;
            this.kryptonPanel4.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.GlassTrackingSimple;
            this.kryptonPanel4.TabIndex = 17;
            // 
            // lblListadoErrores
            // 
            this.lblListadoErrores.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblListadoErrores.AutoSize = true;
            this.lblListadoErrores.BackColor = System.Drawing.Color.Transparent;
            this.lblListadoErrores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListadoErrores.ForeColor = System.Drawing.Color.White;
            this.lblListadoErrores.Location = new System.Drawing.Point(60, 7);
            this.lblListadoErrores.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblListadoErrores.Name = "lblListadoErrores";
            this.lblListadoErrores.Size = new System.Drawing.Size(535, 20);
            this.lblListadoErrores.TabIndex = 9;
            this.lblListadoErrores.Text = "Listado de los errores ocurridos durante el proceso de copia...";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.krpnlErrores);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(920, 32);
            this.panel3.TabIndex = 16;
            // 
            // krpnlErrores
            // 
            this.krpnlErrores.Controls.Add(this.kryptonPanel5);
            this.krpnlErrores.Controls.Add(this.lblInfoErrores);
            this.krpnlErrores.Dock = System.Windows.Forms.DockStyle.Top;
            this.krpnlErrores.Location = new System.Drawing.Point(0, 0);
            this.krpnlErrores.Margin = new System.Windows.Forms.Padding(4);
            this.krpnlErrores.Name = "krpnlErrores";
            this.krpnlErrores.Size = new System.Drawing.Size(918, 31);
            this.krpnlErrores.StateCommon.Color1 = System.Drawing.Color.Azure;
            this.krpnlErrores.StateCommon.Color2 = System.Drawing.Color.SteelBlue;
            this.krpnlErrores.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.GlassPressedStump;
            this.krpnlErrores.TabIndex = 15;
            // 
            // kryptonPanel5
            // 
            this.kryptonPanel5.Location = new System.Drawing.Point(0, 54);
            this.kryptonPanel5.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonPanel5.Name = "kryptonPanel5";
            this.kryptonPanel5.Size = new System.Drawing.Size(920, 316);
            this.kryptonPanel5.TabIndex = 12;
            // 
            // lblInfoErrores
            // 
            this.lblInfoErrores.AutoSize = true;
            this.lblInfoErrores.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoErrores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoErrores.ForeColor = System.Drawing.Color.Black;
            this.lblInfoErrores.Location = new System.Drawing.Point(16, 5);
            this.lblInfoErrores.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfoErrores.Name = "lblInfoErrores";
            this.lblInfoErrores.Size = new System.Drawing.Size(215, 20);
            this.lblInfoErrores.TabIndex = 1;
            this.lblInfoErrores.Text = "Información de errores...";
            // 
            // ssInfoErrores
            // 
            this.ssInfoErrores.BackColor = System.Drawing.Color.Transparent;
            this.ssInfoErrores.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ssInfoErrores.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslblNumErrores});
            this.ssInfoErrores.Location = new System.Drawing.Point(0, 345);
            this.ssInfoErrores.Name = "ssInfoErrores";
            this.ssInfoErrores.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.ssInfoErrores.Size = new System.Drawing.Size(920, 25);
            this.ssInfoErrores.TabIndex = 15;
            this.ssInfoErrores.Text = "Número de errores: 0";
            // 
            // tsslblNumErrores
            // 
            this.tsslblNumErrores.Name = "tsslblNumErrores";
            this.tsslblNumErrores.Size = new System.Drawing.Size(149, 20);
            this.tsslblNumErrores.Text = "Número de errores: 0";
            // 
            // lvErrores
            // 
            this.lvErrores.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lvErrores.BackColor = System.Drawing.Color.White;
            this.lvErrores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chOrigenError,
            this.chDescErr});
            this.lvErrores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvErrores.FullRowSelect = true;
            this.lvErrores.GridLines = true;
            this.lvErrores.Location = new System.Drawing.Point(169, 95);
            this.lvErrores.Margin = new System.Windows.Forms.Padding(4);
            this.lvErrores.Name = "lvErrores";
            this.lvErrores.Size = new System.Drawing.Size(735, 244);
            this.lvErrores.SmallImageList = this.imgLstErrores;
            this.lvErrores.TabIndex = 10;
            this.lvErrores.UseCompatibleStateImageBehavior = false;
            this.lvErrores.View = System.Windows.Forms.View.Details;
            // 
            // chOrigenError
            // 
            this.chOrigenError.Text = "Origen";
            this.chOrigenError.Width = 192;
            // 
            // chDescErr
            // 
            this.chDescErr.Text = "Descripción";
            this.chDescErr.Width = 350;
            // 
            // imgLstErrores
            // 
            this.imgLstErrores.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLstErrores.ImageStream")));
            this.imgLstErrores.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLstErrores.Images.SetKeyName(0, "110.ICO");
            this.imgLstErrores.Images.SetKeyName(1, "kedit.png");
            this.imgLstErrores.Images.SetKeyName(2, "error.png");
            this.imgLstErrores.Images.SetKeyName(3, "folder_home.png");
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.krpnlCopias);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(921, 52);
            this.panel2.TabIndex = 10;
            // 
            // krpnlCopias
            // 
            this.krpnlCopias.Controls.Add(this.lblCiclo);
            this.krpnlCopias.Controls.Add(this.pictureBox1);
            this.krpnlCopias.Controls.Add(this.label2);
            this.krpnlCopias.Dock = System.Windows.Forms.DockStyle.Top;
            this.krpnlCopias.Location = new System.Drawing.Point(0, 0);
            this.krpnlCopias.Margin = new System.Windows.Forms.Padding(4);
            this.krpnlCopias.Name = "krpnlCopias";
            this.krpnlCopias.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.FormMain;
            this.krpnlCopias.Size = new System.Drawing.Size(919, 53);
            this.krpnlCopias.StateCommon.Color1 = System.Drawing.Color.Azure;
            this.krpnlCopias.StateCommon.Color2 = System.Drawing.Color.SteelBlue;
            this.krpnlCopias.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.OneNote;
            this.krpnlCopias.TabIndex = 0;
            // 
            // lblCiclo
            // 
            this.lblCiclo.BackColor = System.Drawing.Color.Transparent;
            this.lblCiclo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCiclo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCiclo.Location = new System.Drawing.Point(655, 28);
            this.lblCiclo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCiclo.Name = "lblCiclo";
            this.lblCiclo.Size = new System.Drawing.Size(241, 21);
            this.lblCiclo.TabIndex = 3;
            this.lblCiclo.Text = "Último ciclo:";
            this.lblCiclo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::BackupRestore.Properties.Resources.desktop;
            this.pictureBox1.Location = new System.Drawing.Point(11, 5);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(69, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(492, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Formulario para realizar las copias de seguridad...";
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Controls.Add(this.lblXciento);
            this.kryptonPanel3.Controls.Add(this.lblDirCopias);
            this.kryptonPanel3.Controls.Add(this.chkApagar);
            this.kryptonPanel3.Controls.Add(this.btnParar);
            this.kryptonPanel3.Controls.Add(this.krpnlabajo);
            this.kryptonPanel3.Controls.Add(this.pbCopiando);
            this.kryptonPanel3.Controls.Add(this.lblContador);
            this.kryptonPanel3.Controls.Add(this.lblObjeto);
            this.kryptonPanel3.Controls.Add(this.lblCopiando);
            this.kryptonPanel3.Controls.Add(this.btnSalir);
            this.kryptonPanel3.Controls.Add(this.btnEmpezar);
            this.kryptonPanel3.Controls.Add(this.btnConfigurar);
            this.kryptonPanel3.Controls.Add(this.progressBar1);
            this.kryptonPanel3.Controls.Add(this.lblProgreso);
            this.kryptonPanel3.Location = new System.Drawing.Point(0, 53);
            this.kryptonPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Size = new System.Drawing.Size(920, 263);
            this.kryptonPanel3.StateCommon.Color1 = System.Drawing.Color.White;
            this.kryptonPanel3.StateCommon.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.kryptonPanel3.StateCommon.ColorAngle = 70F;
            this.kryptonPanel3.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Linear;
            this.kryptonPanel3.TabIndex = 0;
            // 
            // lblXciento
            // 
            this.lblXciento.AutoSize = true;
            this.lblXciento.BackColor = System.Drawing.Color.Transparent;
            this.lblXciento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXciento.Location = new System.Drawing.Point(228, 58);
            this.lblXciento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblXciento.Name = "lblXciento";
            this.lblXciento.Size = new System.Drawing.Size(35, 20);
            this.lblXciento.TabIndex = 17;
            this.lblXciento.Text = "0%";
            // 
            // lblDirCopias
            // 
            this.lblDirCopias.AutoSize = true;
            this.lblDirCopias.BackColor = System.Drawing.Color.Transparent;
            this.lblDirCopias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDirCopias.ForeColor = System.Drawing.Color.Black;
            this.lblDirCopias.Location = new System.Drawing.Point(105, 18);
            this.lblDirCopias.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDirCopias.Name = "lblDirCopias";
            this.lblDirCopias.Size = new System.Drawing.Size(189, 20);
            this.lblDirCopias.TabIndex = 16;
            this.lblDirCopias.Text = "Destino de copia: 1/1";
            this.lblDirCopias.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkApagar
            // 
            this.chkApagar.AutoSize = true;
            this.chkApagar.BackColor = System.Drawing.Color.Transparent;
            this.chkApagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkApagar.Location = new System.Drawing.Point(440, 17);
            this.chkApagar.Margin = new System.Windows.Forms.Padding(4);
            this.chkApagar.Name = "chkApagar";
            this.chkApagar.Size = new System.Drawing.Size(402, 24);
            this.chkApagar.TabIndex = 15;
            this.chkApagar.Text = "Apagar el &equipo al finalizar la copia de seguridad";
            this.chkApagar.UseVisualStyleBackColor = false;
            this.chkApagar.CheckedChanged += new System.EventHandler(this.chkApagar_CheckedChanged);
            // 
            // btnParar
            // 
            this.btnParar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnParar.Enabled = false;
            this.btnParar.Location = new System.Drawing.Point(464, 177);
            this.btnParar.Margin = new System.Windows.Forms.Padding(4);
            this.btnParar.Name = "btnParar";
            this.btnParar.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnParar.Size = new System.Drawing.Size(120, 31);
            this.btnParar.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParar.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParar.TabIndex = 7;
            this.btnParar.Values.Text = "&Parar";
            this.btnParar.Click += new System.EventHandler(this.btnParar_Click);
            // 
            // krpnlabajo
            // 
            this.krpnlabajo.Controls.Add(this.btnErrores);
            this.krpnlabajo.Controls.Add(this.lblErrores);
            this.krpnlabajo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.krpnlabajo.Location = new System.Drawing.Point(0, 227);
            this.krpnlabajo.Margin = new System.Windows.Forms.Padding(4);
            this.krpnlabajo.Name = "krpnlabajo";
            this.krpnlabajo.Size = new System.Drawing.Size(920, 36);
            this.krpnlabajo.StateCommon.Color1 = System.Drawing.Color.Azure;
            this.krpnlabajo.StateCommon.Color2 = System.Drawing.Color.SteelBlue;
            this.krpnlabajo.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.GlassPressedStump;
            this.krpnlabajo.TabIndex = 14;
            this.krpnlabajo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.krpnlabajo_MouseDoubleClick);
            // 
            // btnErrores
            // 
            this.btnErrores.BackColor = System.Drawing.Color.Transparent;
            this.btnErrores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnErrores.FlatAppearance.BorderSize = 0;
            this.btnErrores.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnErrores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnErrores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnErrores.Image = global::BackupRestore.Properties.Resources.Abajo;
            this.btnErrores.Location = new System.Drawing.Point(875, 4);
            this.btnErrores.Margin = new System.Windows.Forms.Padding(4);
            this.btnErrores.Name = "btnErrores";
            this.btnErrores.Size = new System.Drawing.Size(32, 28);
            this.btnErrores.TabIndex = 3;
            this.btnErrores.UseVisualStyleBackColor = false;
            this.btnErrores.Click += new System.EventHandler(this.btnErrores_Click);
            // 
            // lblErrores
            // 
            this.lblErrores.AutoSize = true;
            this.lblErrores.BackColor = System.Drawing.Color.Transparent;
            this.lblErrores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrores.ForeColor = System.Drawing.Color.Black;
            this.lblErrores.Location = new System.Drawing.Point(13, 7);
            this.lblErrores.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblErrores.Name = "lblErrores";
            this.lblErrores.Size = new System.Drawing.Size(156, 20);
            this.lblErrores.TabIndex = 2;
            this.lblErrores.Text = "Mostrar errores...";
            this.lblErrores.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lblErrores_MouseDoubleClick);
            // 
            // pbCopiando
            // 
            this.pbCopiando.BackColor = System.Drawing.Color.Transparent;
            this.pbCopiando.Image = global::BackupRestore.Properties.Resources.CD;
            this.pbCopiando.Location = new System.Drawing.Point(19, 18);
            this.pbCopiando.Margin = new System.Windows.Forms.Padding(4);
            this.pbCopiando.Name = "pbCopiando";
            this.pbCopiando.Size = new System.Drawing.Size(69, 65);
            this.pbCopiando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCopiando.TabIndex = 8;
            this.pbCopiando.TabStop = false;
            // 
            // lblContador
            // 
            this.lblContador.BackColor = System.Drawing.Color.Transparent;
            this.lblContador.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContador.Location = new System.Drawing.Point(449, 58);
            this.lblContador.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(448, 25);
            this.lblContador.TabIndex = 1;
            this.lblContador.Text = "0 / 0 archivos";
            this.lblContador.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblObjeto
            // 
            this.lblObjeto.AutoEllipsis = true;
            this.lblObjeto.BackColor = System.Drawing.Color.Transparent;
            this.lblObjeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObjeto.Location = new System.Drawing.Point(213, 116);
            this.lblObjeto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblObjeto.Name = "lblObjeto";
            this.lblObjeto.Size = new System.Drawing.Size(680, 43);
            this.lblObjeto.TabIndex = 4;
            this.lblObjeto.Text = "Haga click en el botón empezar para comenzar la copia de seguridad...";
            // 
            // lblCopiando
            // 
            this.lblCopiando.AutoSize = true;
            this.lblCopiando.BackColor = System.Drawing.Color.Transparent;
            this.lblCopiando.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopiando.Location = new System.Drawing.Point(105, 116);
            this.lblCopiando.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCopiando.Name = "lblCopiando";
            this.lblCopiando.Size = new System.Drawing.Size(93, 20);
            this.lblCopiando.TabIndex = 3;
            this.lblCopiando.Text = "Copiando:";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(592, 177);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnSalir.Size = new System.Drawing.Size(120, 31);
            this.btnSalir.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Values.Text = "&Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEmpezar
            // 
            this.btnEmpezar.Location = new System.Drawing.Point(336, 177);
            this.btnEmpezar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEmpezar.Name = "btnEmpezar";
            this.btnEmpezar.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnEmpezar.Size = new System.Drawing.Size(120, 31);
            this.btnEmpezar.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmpezar.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmpezar.TabIndex = 6;
            this.btnEmpezar.Values.Text = "&Empezar";
            this.btnEmpezar.Click += new System.EventHandler(this.btnEmpezar_Click);
            // 
            // btnConfigurar
            // 
            this.btnConfigurar.Location = new System.Drawing.Point(208, 177);
            this.btnConfigurar.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfigurar.Name = "btnConfigurar";
            this.btnConfigurar.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnConfigurar.Size = new System.Drawing.Size(120, 31);
            this.btnConfigurar.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfigurar.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfigurar.TabIndex = 5;
            this.btnConfigurar.Values.Text = "&Configurar...";
            this.btnConfigurar.Click += new System.EventHandler(this.btnConfigurar_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(109, 84);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(784, 28);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 2;
            // 
            // lblProgreso
            // 
            this.lblProgreso.AutoSize = true;
            this.lblProgreso.BackColor = System.Drawing.Color.Transparent;
            this.lblProgreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgreso.Location = new System.Drawing.Point(105, 58);
            this.lblProgreso.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProgreso.Name = "lblProgreso";
            this.lblProgreso.Size = new System.Drawing.Size(100, 20);
            this.lblProgreso.TabIndex = 0;
            this.lblProgreso.Text = "Progreso...";
            // 
            // tmrCopiando
            // 
            this.tmrCopiando.Tick += new System.EventHandler(this.tmrCopiando_Tick);
            // 
            // ctxMenu
            // 
            this.ctxMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ctxMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxEstado,
            this.toolStripSeparator1,
            this.cancelarToolStripMenuItem});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(215, 65);
            // 
            // ctxEstado
            // 
            this.ctxEstado.AutoSize = false;
            this.ctxEstado.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ctxEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ctxEstado.Name = "ctxEstado";
            this.ctxEstado.ReadOnly = true;
            this.ctxEstado.Size = new System.Drawing.Size(150, 27);
            this.ctxEstado.Text = "Estado";
            this.ctxEstado.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(211, 6);
            // 
            // cancelarToolStripMenuItem
            // 
            this.cancelarToolStripMenuItem.Image = global::BackupRestore.Properties.Resources.editdelete;
            this.cancelarToolStripMenuItem.Name = "cancelarToolStripMenuItem";
            this.cancelarToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.cancelarToolStripMenuItem.Text = "&Cancelar copia";
            this.cancelarToolStripMenuItem.Click += new System.EventHandler(this.cancelarToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipTitle = "Backup&Restore";
            this.notifyIcon1.ContextMenuStrip = this.ctxMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            // 
            // frmCopiar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 688);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmCopiar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copias de seguridad...";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCopiar_FormClosing);
            this.Load += new System.EventHandler(this.frmCopiar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCopiar_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlErrores)).EndInit();
            this.kpnlErrores.ResumeLayout(false);
            this.kpnlErrores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbErrores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel4)).EndInit();
            this.kryptonPanel4.ResumeLayout(false);
            this.kryptonPanel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.krpnlErrores)).EndInit();
            this.krpnlErrores.ResumeLayout(false);
            this.krpnlErrores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel5)).EndInit();
            this.ssInfoErrores.ResumeLayout(false);
            this.ssInfoErrores.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.krpnlCopias)).EndInit();
            this.krpnlCopias.ResumeLayout(false);
            this.krpnlCopias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            this.kryptonPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnParar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.krpnlabajo)).EndInit();
            this.krpnlabajo.ResumeLayout(false);
            this.krpnlabajo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCopiando)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEmpezar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConfigurar)).EndInit();
            this.ctxMenu.ResumeLayout(false);
            this.ctxMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel3;
        private System.Windows.Forms.PictureBox pbCopiando;
        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.Label lblObjeto;
        private System.Windows.Forms.Label lblCopiando;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSalir;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnEmpezar;
        private System.Windows.Forms.Label lblProgreso;
        private System.Windows.Forms.Panel panel2;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel krpnlCopias;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kpnlErrores;
        private System.Windows.Forms.ListView lvErrores;
        private System.Windows.Forms.Label lblListadoErrores;
        private System.Windows.Forms.PictureBox pbErrores;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel krpnlabajo;
        private System.Windows.Forms.Button btnErrores;
        private System.Windows.Forms.Label lblErrores;
        private System.Windows.Forms.StatusStrip ssInfoErrores;
        private System.Windows.Forms.ToolStripStatusLabel tsslblNumErrores;
        private System.Windows.Forms.Panel panel3;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel krpnlErrores;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel5;
        private System.Windows.Forms.Label lblInfoErrores;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader chOrigenError;
        private System.Windows.Forms.ColumnHeader chDescErr;
        private System.Windows.Forms.ImageList imgLstErrores;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnParar;
        private System.Windows.Forms.CheckBox chkApagar;
        private System.Windows.Forms.Label lblDirCopias;
        private System.Windows.Forms.Label lblCiclo;
        private System.Windows.Forms.Label lblXciento;
        private System.Windows.Forms.Timer tmrCopiando;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnConfigurar;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripTextBox ctxEstado;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cancelarToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}