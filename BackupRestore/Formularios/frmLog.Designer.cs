namespace BackupRestore
{
    partial class frmLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLog));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.kryptonPanel3 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lvInfo = new System.Windows.Forms.ListView();
            this.chFecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chHora = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEvento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEquipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUsuario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.krpnlCopias = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbAcciones = new System.Windows.Forms.GroupBox();
            this.btnImprimir = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnGuardar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnConsultar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtUsuarioHasta = new System.Windows.Forms.TextBox();
            this.txtUsuarioDesde = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEquipoHasta = new System.Windows.Forms.TextBox();
            this.txtEquipoDesde = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpHoraHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraDesde = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEliminarTodos = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBorrarEventos = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSalir = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label6 = new System.Windows.Forms.Label();
            this.kryptonPanel4 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblEventos = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblListadoErrores = new System.Windows.Forms.Label();
            this.pdoc = new System.Drawing.Printing.PrintDocument();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmStripConsultas = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmnuFecha = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnuHoras = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnuEquipos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmnuFechaErrores = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmnuTodo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmnuBuscar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmStripListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmnuCopiar = new System.Windows.Forms.ToolStripMenuItem();
            this.pdlg = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.krpnlCopias)).BeginInit();
            this.krpnlCopias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnImprimir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConsultar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEliminarTodos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBorrarEventos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel4)).BeginInit();
            this.kryptonPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.cmStripConsultas.SuspendLayout();
            this.cmStripListView.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Controls.Add(this.lvInfo);
            this.kryptonPanel3.Controls.Add(this.panel1);
            this.kryptonPanel3.Controls.Add(this.gbAcciones);
            this.kryptonPanel3.Controls.Add(this.kryptonPanel4);
            this.kryptonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel3.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Size = new System.Drawing.Size(891, 542);
            this.kryptonPanel3.StateCommon.Color1 = System.Drawing.Color.White;
            this.kryptonPanel3.StateCommon.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(225)))), ((int)(((byte)(252)))));
            this.kryptonPanel3.StateCommon.ColorAngle = 70F;
            this.kryptonPanel3.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Linear;
            this.kryptonPanel3.TabIndex = 1;
            // 
            // lvInfo
            // 
            this.lvInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvInfo.BackColor = System.Drawing.Color.Ivory;
            this.lvInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFecha,
            this.chHora,
            this.chEvento,
            this.chEquipo,
            this.chUsuario});
            this.lvInfo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvInfo.ForeColor = System.Drawing.Color.Black;
            this.lvInfo.FullRowSelect = true;
            this.lvInfo.GridLines = true;
            this.lvInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvInfo.HideSelection = false;
            this.lvInfo.Location = new System.Drawing.Point(13, 284);
            this.lvInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvInfo.Name = "lvInfo";
            this.lvInfo.Size = new System.Drawing.Size(864, 244);
            this.lvInfo.TabIndex = 3;
            this.lvInfo.UseCompatibleStateImageBehavior = false;
            this.lvInfo.View = System.Windows.Forms.View.Details;
            this.lvInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvInfo_MouseClick);
            // 
            // chFecha
            // 
            this.chFecha.Text = "Fecha";
            this.chFecha.Width = 93;
            // 
            // chHora
            // 
            this.chHora.Text = "Hora";
            this.chHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chHora.Width = 79;
            // 
            // chEvento
            // 
            this.chEvento.Text = "Evento";
            this.chEvento.Width = 304;
            // 
            // chEquipo
            // 
            this.chEquipo.Text = "Equipo";
            this.chEquipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chEquipo.Width = 78;
            // 
            // chUsuario
            // 
            this.chUsuario.Text = "Usuario";
            this.chUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chUsuario.Width = 80;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.krpnlCopias);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(891, 52);
            this.panel1.TabIndex = 2;
            // 
            // krpnlCopias
            // 
            this.krpnlCopias.Controls.Add(this.pictureBox1);
            this.krpnlCopias.Controls.Add(this.label2);
            this.krpnlCopias.Dock = System.Windows.Forms.DockStyle.Top;
            this.krpnlCopias.Location = new System.Drawing.Point(0, 0);
            this.krpnlCopias.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.krpnlCopias.Name = "krpnlCopias";
            this.krpnlCopias.Size = new System.Drawing.Size(889, 53);
            this.krpnlCopias.StateCommon.Color1 = System.Drawing.Color.Azure;
            this.krpnlCopias.StateCommon.Color2 = System.Drawing.Color.SteelBlue;
            this.krpnlCopias.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.HalfCut;
            this.krpnlCopias.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 41);
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
            this.label2.Size = new System.Drawing.Size(430, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Información de los sucesos de la aplicación";
            // 
            // gbAcciones
            // 
            this.gbAcciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAcciones.BackColor = System.Drawing.Color.Transparent;
            this.gbAcciones.Controls.Add(this.btnImprimir);
            this.gbAcciones.Controls.Add(this.btnGuardar);
            this.gbAcciones.Controls.Add(this.btnConsultar);
            this.gbAcciones.Controls.Add(this.txtUsuarioHasta);
            this.gbAcciones.Controls.Add(this.txtUsuarioDesde);
            this.gbAcciones.Controls.Add(this.label11);
            this.gbAcciones.Controls.Add(this.label12);
            this.gbAcciones.Controls.Add(this.label13);
            this.gbAcciones.Controls.Add(this.txtEquipoHasta);
            this.gbAcciones.Controls.Add(this.txtEquipoDesde);
            this.gbAcciones.Controls.Add(this.label10);
            this.gbAcciones.Controls.Add(this.label9);
            this.gbAcciones.Controls.Add(this.label8);
            this.gbAcciones.Controls.Add(this.label7);
            this.gbAcciones.Controls.Add(this.dtpFechaDesde);
            this.gbAcciones.Controls.Add(this.dtpFechaHasta);
            this.gbAcciones.Controls.Add(this.label3);
            this.gbAcciones.Controls.Add(this.label1);
            this.gbAcciones.Controls.Add(this.dtpHoraHasta);
            this.gbAcciones.Controls.Add(this.dtpHoraDesde);
            this.gbAcciones.Controls.Add(this.label5);
            this.gbAcciones.Controls.Add(this.btnEliminarTodos);
            this.gbAcciones.Controls.Add(this.label4);
            this.gbAcciones.Controls.Add(this.btnBorrarEventos);
            this.gbAcciones.Controls.Add(this.btnSalir);
            this.gbAcciones.Controls.Add(this.label6);
            this.gbAcciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAcciones.Location = new System.Drawing.Point(12, 55);
            this.gbAcciones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbAcciones.Name = "gbAcciones";
            this.gbAcciones.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbAcciones.Size = new System.Drawing.Size(865, 186);
            this.gbAcciones.TabIndex = 0;
            this.gbAcciones.TabStop = false;
            this.gbAcciones.Text = "Acciones";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(524, 142);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnImprimir.Size = new System.Drawing.Size(120, 31);
            this.btnImprimir.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.TabIndex = 25;
            this.btnImprimir.Values.Text = "&Imprimir...";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(396, 142);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnGuardar.Size = new System.Drawing.Size(120, 31);
            this.btnGuardar.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.TabIndex = 24;
            this.btnGuardar.Values.Text = "&Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(12, 142);
            this.btnConsultar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnConsultar.Size = new System.Drawing.Size(120, 31);
            this.btnConsultar.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.TabIndex = 20;
            this.btnConsultar.Values.Text = "&Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // txtUsuarioHasta
            // 
            this.txtUsuarioHasta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsuarioHasta.Location = new System.Drawing.Point(720, 90);
            this.txtUsuarioHasta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUsuarioHasta.MaxLength = 50;
            this.txtUsuarioHasta.Name = "txtUsuarioHasta";
            this.txtUsuarioHasta.Size = new System.Drawing.Size(128, 26);
            this.txtUsuarioHasta.TabIndex = 19;
            // 
            // txtUsuarioDesde
            // 
            this.txtUsuarioDesde.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsuarioDesde.Location = new System.Drawing.Point(720, 58);
            this.txtUsuarioDesde.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUsuarioDesde.MaxLength = 50;
            this.txtUsuarioDesde.Name = "txtUsuarioDesde";
            this.txtUsuarioDesde.Size = new System.Drawing.Size(128, 26);
            this.txtUsuarioDesde.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(652, 94);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 20);
            this.label11.TabIndex = 18;
            this.label11.Text = "Hasta:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(647, 62);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 20);
            this.label12.TabIndex = 16;
            this.label12.Text = "Desde:";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(629, 30);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 20);
            this.label13.TabIndex = 15;
            this.label13.Text = "<Usuario>";
            // 
            // txtEquipoHasta
            // 
            this.txtEquipoHasta.Location = new System.Drawing.Point(504, 90);
            this.txtEquipoHasta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEquipoHasta.MaxLength = 50;
            this.txtEquipoHasta.Name = "txtEquipoHasta";
            this.txtEquipoHasta.Size = new System.Drawing.Size(120, 26);
            this.txtEquipoHasta.TabIndex = 14;
            // 
            // txtEquipoDesde
            // 
            this.txtEquipoDesde.Location = new System.Drawing.Point(504, 58);
            this.txtEquipoDesde.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEquipoDesde.MaxLength = 50;
            this.txtEquipoDesde.Name = "txtEquipoDesde";
            this.txtEquipoDesde.Size = new System.Drawing.Size(120, 26);
            this.txtEquipoDesde.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(436, 94);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 20);
            this.label10.TabIndex = 13;
            this.label10.Text = "Hasta:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(431, 62);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 20);
            this.label9.TabIndex = 11;
            this.label9.Text = "Desde:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(415, 30);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "<Equipo>";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(237, 30);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "<Hora>";
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(104, 58);
            this.dtpFechaDesde.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(127, 26);
            this.dtpFechaDesde.TabIndex = 2;
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(104, 90);
            this.dtpFechaHasta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(127, 26);
            this.dtpFechaHasta.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "<Fecha>";
            // 
            // dtpHoraHasta
            // 
            this.dtpHoraHasta.CustomFormat = "HH:mm";
            this.dtpHoraHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraHasta.Location = new System.Drawing.Point(325, 90);
            this.dtpHoraHasta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpHoraHasta.Name = "dtpHoraHasta";
            this.dtpHoraHasta.ShowUpDown = true;
            this.dtpHoraHasta.Size = new System.Drawing.Size(80, 26);
            this.dtpHoraHasta.TabIndex = 9;
            // 
            // dtpHoraDesde
            // 
            this.dtpHoraDesde.CustomFormat = "HH:mm";
            this.dtpHoraDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraDesde.Location = new System.Drawing.Point(325, 58);
            this.dtpHoraDesde.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpHoraDesde.Name = "dtpHoraDesde";
            this.dtpHoraDesde.ShowUpDown = true;
            this.dtpHoraDesde.Size = new System.Drawing.Size(80, 26);
            this.dtpHoraDesde.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(259, 94);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Hasta:";
            // 
            // btnEliminarTodos
            // 
            this.btnEliminarTodos.Location = new System.Drawing.Point(268, 142);
            this.btnEliminarTodos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEliminarTodos.Name = "btnEliminarTodos";
            this.btnEliminarTodos.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnEliminarTodos.Size = new System.Drawing.Size(120, 31);
            this.btnEliminarTodos.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarTodos.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarTodos.TabIndex = 22;
            this.btnEliminarTodos.Values.Text = "&Borrar todo";
            this.btnEliminarTodos.Click += new System.EventHandler(this.btnEliminarTodos_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(253, 62);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Desde:";
            // 
            // btnBorrarEventos
            // 
            this.btnBorrarEventos.Location = new System.Drawing.Point(140, 142);
            this.btnBorrarEventos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBorrarEventos.Name = "btnBorrarEventos";
            this.btnBorrarEventos.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnBorrarEventos.Size = new System.Drawing.Size(120, 31);
            this.btnBorrarEventos.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarEventos.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarEventos.TabIndex = 21;
            this.btnBorrarEventos.Values.Text = "&Eliminar";
            this.btnBorrarEventos.Click += new System.EventHandler(this.btnBorrarEventos_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Location = new System.Drawing.Point(729, 142);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.btnSalir.Size = new System.Drawing.Size(120, 31);
            this.btnSalir.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.TabIndex = 23;
            this.btnSalir.Values.Text = "&Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 62);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Desde:";
            // 
            // kryptonPanel4
            // 
            this.kryptonPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonPanel4.Controls.Add(this.lblEventos);
            this.kryptonPanel4.Controls.Add(this.pictureBox2);
            this.kryptonPanel4.Controls.Add(this.lblListadoErrores);
            this.kryptonPanel4.Location = new System.Drawing.Point(13, 249);
            this.kryptonPanel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kryptonPanel4.Name = "kryptonPanel4";
            this.kryptonPanel4.Size = new System.Drawing.Size(865, 36);
            this.kryptonPanel4.StateCommon.Color1 = System.Drawing.Color.Black;
            this.kryptonPanel4.StateCommon.Color2 = System.Drawing.Color.CornflowerBlue;
            this.kryptonPanel4.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.GlassTrackingSimple;
            this.kryptonPanel4.TabIndex = 0;
            // 
            // lblEventos
            // 
            this.lblEventos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEventos.BackColor = System.Drawing.Color.Transparent;
            this.lblEventos.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventos.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblEventos.Location = new System.Drawing.Point(673, 7);
            this.lblEventos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEventos.Name = "lblEventos";
            this.lblEventos.Size = new System.Drawing.Size(192, 20);
            this.lblEventos.TabIndex = 1;
            this.lblEventos.Text = "0 eventos";
            this.lblEventos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // lblListadoErrores
            // 
            this.lblListadoErrores.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblListadoErrores.AutoSize = true;
            this.lblListadoErrores.BackColor = System.Drawing.Color.Transparent;
            this.lblListadoErrores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListadoErrores.ForeColor = System.Drawing.Color.White;
            this.lblListadoErrores.Location = new System.Drawing.Point(311, 7);
            this.lblListadoErrores.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblListadoErrores.Name = "lblListadoErrores";
            this.lblListadoErrores.Size = new System.Drawing.Size(214, 20);
            this.lblListadoErrores.TabIndex = 0;
            this.lblListadoErrores.Text = "Eventos de la aplicación";
            // 
            // pdoc
            // 
            this.pdoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdoc_PrintPage);
            // 
            // cmStripConsultas
            // 
            this.cmStripConsultas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmStripConsultas.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmStripConsultas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmnuFecha,
            this.tsmnuHoras,
            this.tsmnuEquipos,
            this.tsmnuUsuarios,
            this.tsmnuFechaErrores,
            this.toolStripSeparator1,
            this.tsmnuTodo,
            this.toolStripSeparator3,
            this.tsmnuBuscar});
            this.cmStripConsultas.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.cmStripConsultas.Name = "cmStip";
            this.cmStripConsultas.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cmStripConsultas.Size = new System.Drawing.Size(260, 198);
            // 
            // tsmnuFecha
            // 
            this.tsmnuFecha.Font = new System.Drawing.Font("Verdana", 9F);
            this.tsmnuFecha.Image = ((System.Drawing.Image)(resources.GetObject("tsmnuFecha.Image")));
            this.tsmnuFecha.Name = "tsmnuFecha";
            this.tsmnuFecha.Size = new System.Drawing.Size(259, 26);
            this.tsmnuFecha.Text = "Por Fechas";
            this.tsmnuFecha.Click += new System.EventHandler(this.tsmnuFecha_Click);
            // 
            // tsmnuHoras
            // 
            this.tsmnuHoras.Font = new System.Drawing.Font("Verdana", 9F);
            this.tsmnuHoras.Image = global::BackupRestore.Properties.Resources.kalarm;
            this.tsmnuHoras.Name = "tsmnuHoras";
            this.tsmnuHoras.Size = new System.Drawing.Size(259, 26);
            this.tsmnuHoras.Text = "Por Fecha y Hora";
            this.tsmnuHoras.Click += new System.EventHandler(this.tsmnuHoras_Click);
            // 
            // tsmnuEquipos
            // 
            this.tsmnuEquipos.Font = new System.Drawing.Font("Verdana", 9F);
            this.tsmnuEquipos.Image = global::BackupRestore.Properties.Resources.mycomputer;
            this.tsmnuEquipos.Name = "tsmnuEquipos";
            this.tsmnuEquipos.Size = new System.Drawing.Size(259, 26);
            this.tsmnuEquipos.Text = "Por Equipos";
            this.tsmnuEquipos.Click += new System.EventHandler(this.tsmnuEquipos_Click);
            // 
            // tsmnuUsuarios
            // 
            this.tsmnuUsuarios.Font = new System.Drawing.Font("Verdana", 9F);
            this.tsmnuUsuarios.Image = global::BackupRestore.Properties.Resources.kuser;
            this.tsmnuUsuarios.Name = "tsmnuUsuarios";
            this.tsmnuUsuarios.Size = new System.Drawing.Size(259, 26);
            this.tsmnuUsuarios.Text = "Por Usuarios";
            this.tsmnuUsuarios.Click += new System.EventHandler(this.tsmnuUsuarios_Click);
            // 
            // tsmnuFechaErrores
            // 
            this.tsmnuFechaErrores.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmnuFechaErrores.Image = global::BackupRestore.Properties.Resources.editdelete;
            this.tsmnuFechaErrores.Name = "tsmnuFechaErrores";
            this.tsmnuFechaErrores.Size = new System.Drawing.Size(259, 26);
            this.tsmnuFechaErrores.Text = "Por Fecha y con Errores";
            this.tsmnuFechaErrores.Click += new System.EventHandler(this.tsmnuFechaErrores_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(256, 6);
            // 
            // tsmnuTodo
            // 
            this.tsmnuTodo.Font = new System.Drawing.Font("Verdana", 9F);
            this.tsmnuTodo.Image = global::BackupRestore.Properties.Resources.reload;
            this.tsmnuTodo.Name = "tsmnuTodo";
            this.tsmnuTodo.Size = new System.Drawing.Size(259, 26);
            this.tsmnuTodo.Text = "Todo los Eventos";
            this.tsmnuTodo.Click += new System.EventHandler(this.tsmnuTodo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(256, 6);
            // 
            // tsmnuBuscar
            // 
            this.tsmnuBuscar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmnuBuscar.Image = global::BackupRestore.Properties.Resources.AQUA_ICONS_SYSTEM_SEARCH;
            this.tsmnuBuscar.Name = "tsmnuBuscar";
            this.tsmnuBuscar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.tsmnuBuscar.Size = new System.Drawing.Size(259, 26);
            this.tsmnuBuscar.Text = "Buscar...";
            this.tsmnuBuscar.Click += new System.EventHandler(this.tsmnuBuscar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(182, 6);
            // 
            // cmStripListView
            // 
            this.cmStripListView.BackColor = System.Drawing.SystemColors.Menu;
            this.cmStripListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmStripListView.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmStripListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmnuCopiar});
            this.cmStripListView.Name = "cmStripListView";
            this.cmStripListView.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cmStripListView.Size = new System.Drawing.Size(125, 30);
            // 
            // tsmnuCopiar
            // 
            this.tsmnuCopiar.BackColor = System.Drawing.SystemColors.Menu;
            this.tsmnuCopiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.tsmnuCopiar.Image = global::BackupRestore.Properties.Resources.editcopy;
            this.tsmnuCopiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsmnuCopiar.Name = "tsmnuCopiar";
            this.tsmnuCopiar.Size = new System.Drawing.Size(124, 26);
            this.tsmnuCopiar.Text = "&Copiar";
            this.tsmnuCopiar.Click += new System.EventHandler(this.tsmnuCopiar_Click);
            // 
            // pdlg
            // 
            this.pdlg.Document = this.pdoc;
            this.pdlg.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.pdoc;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // frmLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 542);
            this.Controls.Add(this.kryptonPanel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(807, 403);
            this.Name = "frmLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Información de eventos...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLog_FormClosing);
            this.Load += new System.EventHandler(this.frmLog_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLog_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.krpnlCopias)).EndInit();
            this.krpnlCopias.ResumeLayout(false);
            this.krpnlCopias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbAcciones.ResumeLayout(false);
            this.gbAcciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnImprimir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConsultar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEliminarTodos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBorrarEventos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel4)).EndInit();
            this.kryptonPanel4.ResumeLayout(false);
            this.kryptonPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.cmStripConsultas.ResumeLayout(false);
            this.cmStripListView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel3;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel4;
        private System.Windows.Forms.Label lblListadoErrores;
        private System.Windows.Forms.GroupBox gbAcciones;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpHoraHasta;
        private System.Windows.Forms.DateTimePicker dtpHoraDesde;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEquipoHasta;
        private System.Windows.Forms.TextBox txtEquipoDesde;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel krpnlCopias;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsuarioHasta;
        private System.Windows.Forms.TextBox txtUsuarioDesde;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListView lvInfo;
        private System.Windows.Forms.ColumnHeader chFecha;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader chHora;
        private System.Windows.Forms.ColumnHeader chEvento;
        private System.Windows.Forms.ColumnHeader chEquipo;
        private System.Windows.Forms.ColumnHeader chUsuario;
        private System.Windows.Forms.Label lblEventos;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ContextMenuStrip cmStripConsultas;
        private System.Windows.Forms.ToolStripMenuItem tsmnuFecha;
        private System.Windows.Forms.ToolStripMenuItem tsmnuHoras;
        private System.Windows.Forms.ToolStripMenuItem tsmnuEquipos;
        private System.Windows.Forms.ToolStripMenuItem tsmnuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem tsmnuTodo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip cmStripListView;
        private System.Windows.Forms.ToolStripMenuItem tsmnuCopiar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnConsultar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnEliminarTodos;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnBorrarEventos;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSalir;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnImprimir;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnGuardar;
        private System.Drawing.Printing.PrintDocument pdoc;
        private System.Windows.Forms.PrintDialog pdlg;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.ToolStripMenuItem tsmnuFechaErrores;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmnuBuscar;

    }
}