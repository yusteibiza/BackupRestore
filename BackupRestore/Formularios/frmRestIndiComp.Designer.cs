namespace BackupRestore
{
    partial class frmRestIndiComp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRestIndiComp));
            this.ssInfo = new System.Windows.Forms.StatusStrip();
            this.tsslblArchivo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsSeparador1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblSel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnOpciones = new System.Windows.Forms.ToolStripSplitButton();
            this.mnuSelTodo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDesSelTodo = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlArriba = new System.Windows.Forms.Panel();
            this.pbInfoBuscar = new System.Windows.Forms.PictureBox();
            this.pbBuscarSiguiente = new System.Windows.Forms.PictureBox();
            this.pbBorrarBuscar = new System.Windows.Forms.PictureBox();
            this.pbBuscar = new System.Windows.Forms.PictureBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.llblDestino = new System.Windows.Forms.LinkLabel();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlCentro = new System.Windows.Forms.Panel();
            this.lblCargando = new System.Windows.Forms.Label();
            this.lvArchivos = new System.Windows.Forms.ListView();
            this.CHNombre = new System.Windows.Forms.ColumnHeader();
            this.CHTamaño = new System.Windows.Forms.ColumnHeader();
            this.chTamComp = new System.Windows.Forms.ColumnHeader();
            this.chCRC = new System.Windows.Forms.ColumnHeader();
            this.pnlAbajo = new System.Windows.Forms.Panel();
            this.pbRestaurando = new System.Windows.Forms.PictureBox();
            this.lblEspere = new System.Windows.Forms.Label();
            this.lblRestaurado = new System.Windows.Forms.Label();
            this.prgRestaurado = new System.Windows.Forms.ProgressBar();
            this.llblParar = new System.Windows.Forms.LinkLabel();
            this.llblSalir = new System.Windows.Forms.LinkLabel();
            this.llblRestaurar = new System.Windows.Forms.LinkLabel();
            this.tmrRestaurando = new System.Windows.Forms.Timer(this.components);
            this.ctxMenuStripItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuMarcar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDesmarcar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMarcarTodo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDesmarcartodo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAbrir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEjecutar = new System.Windows.Forms.ToolStripMenuItem();
            this.ttAyudaBuscar = new System.Windows.Forms.ToolTip(this.components);
            this.chCompresion = new System.Windows.Forms.ColumnHeader();
            this.ssInfo.SuspendLayout();
            this.pnlArriba.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfoBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBuscarSiguiente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBorrarBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBuscar)).BeginInit();
            this.pnlCentro.SuspendLayout();
            this.pnlAbajo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRestaurando)).BeginInit();
            this.ctxMenuStripItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // ssInfo
            // 
            this.ssInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ssInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslblArchivo,
            this.tsSeparador1,
            this.tslblSel,
            this.toolStripStatusLabel1,
            this.btnOpciones});
            this.ssInfo.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ssInfo.Location = new System.Drawing.Point(0, 542);
            this.ssInfo.Name = "ssInfo";
            this.ssInfo.Size = new System.Drawing.Size(734, 22);
            this.ssInfo.TabIndex = 2;
            this.ssInfo.Text = "statusStrip1";
            // 
            // tsslblArchivo
            // 
            this.tsslblArchivo.Name = "tsslblArchivo";
            this.tsslblArchivo.Size = new System.Drawing.Size(92, 17);
            this.tsslblArchivo.Text = "Restaurando de:";
            // 
            // tsSeparador1
            // 
            this.tsSeparador1.Name = "tsSeparador1";
            this.tsSeparador1.Size = new System.Drawing.Size(12, 17);
            this.tsSeparador1.Text = "-";
            // 
            // tslblSel
            // 
            this.tslblSel.Name = "tslblSel";
            this.tslblSel.Size = new System.Drawing.Size(94, 17);
            this.tslblSel.Text = "Seleccionados: 0";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(12, 17);
            this.toolStripStatusLabel1.Text = "-";
            // 
            // btnOpciones
            // 
            this.btnOpciones.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSelTodo,
            this.mnuDesSelTodo});
            this.btnOpciones.Image = global::BackupRestore.Properties.Resources.graphic_design;
            this.btnOpciones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpciones.Name = "btnOpciones";
            this.btnOpciones.Size = new System.Drawing.Size(32, 20);
            this.btnOpciones.Text = "toolStripSplitButton1";
            // 
            // mnuSelTodo
            // 
            this.mnuSelTodo.Image = global::BackupRestore.Properties.Resources.SNOW_E_AQUA_DROP_BOX_32x32;
            this.mnuSelTodo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuSelTodo.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.mnuSelTodo.Name = "mnuSelTodo";
            this.mnuSelTodo.Size = new System.Drawing.Size(174, 38);
            this.mnuSelTodo.Text = "Marcar todo";
            this.mnuSelTodo.Click += new System.EventHandler(this.mnuSelTodo_Click);
            // 
            // mnuDesSelTodo
            // 
            this.mnuDesSelTodo.Image = global::BackupRestore.Properties.Resources.SNOW_E_AQUA_PRIVATE_32x32;
            this.mnuDesSelTodo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuDesSelTodo.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.mnuDesSelTodo.Name = "mnuDesSelTodo";
            this.mnuDesSelTodo.Size = new System.Drawing.Size(174, 38);
            this.mnuDesSelTodo.Text = "Desmarcar todo";
            this.mnuDesSelTodo.Click += new System.EventHandler(this.mnuDesSelTodo_Click);
            // 
            // pnlArriba
            // 
            this.pnlArriba.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(237)))));
            this.pnlArriba.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlArriba.Controls.Add(this.pbInfoBuscar);
            this.pnlArriba.Controls.Add(this.pbBuscarSiguiente);
            this.pnlArriba.Controls.Add(this.pbBorrarBuscar);
            this.pnlArriba.Controls.Add(this.pbBuscar);
            this.pnlArriba.Controls.Add(this.txtBuscar);
            this.pnlArriba.Controls.Add(this.llblDestino);
            this.pnlArriba.Controls.Add(this.txtDestino);
            this.pnlArriba.Controls.Add(this.label1);
            this.pnlArriba.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlArriba.Location = new System.Drawing.Point(0, 0);
            this.pnlArriba.Name = "pnlArriba";
            this.pnlArriba.Size = new System.Drawing.Size(734, 90);
            this.pnlArriba.TabIndex = 0;
            this.pnlArriba.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelesPaint);
            // 
            // pbInfoBuscar
            // 
            this.pbInfoBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbInfoBuscar.BackColor = System.Drawing.Color.Transparent;
            this.pbInfoBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbInfoBuscar.Image = global::BackupRestore.Properties.Resources.Help2;
            this.pbInfoBuscar.Location = new System.Drawing.Point(612, 51);
            this.pbInfoBuscar.Name = "pbInfoBuscar";
            this.pbInfoBuscar.Size = new System.Drawing.Size(24, 22);
            this.pbInfoBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbInfoBuscar.TabIndex = 8;
            this.pbInfoBuscar.TabStop = false;
            this.pbInfoBuscar.MouseLeave += new System.EventHandler(this.pbInfoBuscar_MouseLeave);
            this.pbInfoBuscar.MouseEnter += new System.EventHandler(this.pbInfoBuscar_MouseEnter);
            // 
            // pbBuscarSiguiente
            // 
            this.pbBuscarSiguiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbBuscarSiguiente.BackColor = System.Drawing.Color.Transparent;
            this.pbBuscarSiguiente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbBuscarSiguiente.Image = global::BackupRestore.Properties.Resources.WMP11;
            this.pbBuscarSiguiente.Location = new System.Drawing.Point(566, 51);
            this.pbBuscarSiguiente.Name = "pbBuscarSiguiente";
            this.pbBuscarSiguiente.Size = new System.Drawing.Size(24, 22);
            this.pbBuscarSiguiente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBuscarSiguiente.TabIndex = 7;
            this.pbBuscarSiguiente.TabStop = false;
            this.pbBuscarSiguiente.Click += new System.EventHandler(this.pbBuscarSiguiente_Click);
            this.pbBuscarSiguiente.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxBuscarMouseDown);
            this.pbBuscarSiguiente.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBoxBuscarMouseUp);
            // 
            // pbBorrarBuscar
            // 
            this.pbBorrarBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbBorrarBuscar.BackColor = System.Drawing.Color.Transparent;
            this.pbBorrarBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbBorrarBuscar.Image = global::BackupRestore.Properties.Resources.editdelete;
            this.pbBorrarBuscar.Location = new System.Drawing.Point(589, 51);
            this.pbBorrarBuscar.Name = "pbBorrarBuscar";
            this.pbBorrarBuscar.Size = new System.Drawing.Size(24, 22);
            this.pbBorrarBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBorrarBuscar.TabIndex = 6;
            this.pbBorrarBuscar.TabStop = false;
            this.pbBorrarBuscar.Click += new System.EventHandler(this.pbBorrarBuscar_Click);
            this.pbBorrarBuscar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxBuscarMouseDown);
            this.pbBorrarBuscar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBoxBuscarMouseUp);
            // 
            // pbBuscar
            // 
            this.pbBuscar.BackColor = System.Drawing.Color.Transparent;
            this.pbBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbBuscar.Image = global::BackupRestore.Properties.Resources.AQUA_ICONS_SYSTEM_SEARCH;
            this.pbBuscar.Location = new System.Drawing.Point(113, 51);
            this.pbBuscar.Name = "pbBuscar";
            this.pbBuscar.Size = new System.Drawing.Size(24, 22);
            this.pbBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBuscar.TabIndex = 5;
            this.pbBuscar.TabStop = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBuscar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBuscar.BackColor = System.Drawing.Color.White;
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(136, 51);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(431, 22);
            this.txtBuscar.TabIndex = 3;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            this.txtBuscar.Leave += new System.EventHandler(this.txtBuscar_Leave);
            this.txtBuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyUp);
            this.txtBuscar.Enter += new System.EventHandler(this.txtBuscar_Enter);
            // 
            // llblDestino
            // 
            this.llblDestino.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llblDestino.BackColor = System.Drawing.Color.Transparent;
            this.llblDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblDestino.Image = global::BackupRestore.Properties.Resources.folder;
            this.llblDestino.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.llblDestino.Location = new System.Drawing.Point(642, 22);
            this.llblDestino.Name = "llblDestino";
            this.llblDestino.Size = new System.Drawing.Size(78, 23);
            this.llblDestino.TabIndex = 2;
            this.llblDestino.TabStop = true;
            this.llblDestino.Text = "Buscar";
            this.llblDestino.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.llblDestino.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblDestino_LinkClicked);
            // 
            // txtDestino
            // 
            this.txtDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtDestino.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.txtDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestino.Location = new System.Drawing.Point(113, 22);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(523, 23);
            this.txtDestino.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Restaurar en:";
            // 
            // pnlCentro
            // 
            this.pnlCentro.BackColor = System.Drawing.Color.DimGray;
            this.pnlCentro.Controls.Add(this.lblCargando);
            this.pnlCentro.Controls.Add(this.lvArchivos);
            this.pnlCentro.Controls.Add(this.pnlAbajo);
            this.pnlCentro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCentro.Location = new System.Drawing.Point(0, 90);
            this.pnlCentro.Name = "pnlCentro";
            this.pnlCentro.Size = new System.Drawing.Size(734, 452);
            this.pnlCentro.TabIndex = 3;
            // 
            // lblCargando
            // 
            this.lblCargando.BackColor = System.Drawing.Color.LightGray;
            this.lblCargando.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCargando.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargando.Image = global::BackupRestore.Properties.Resources._95_128;
            this.lblCargando.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblCargando.Location = new System.Drawing.Point(92, 57);
            this.lblCargando.Name = "lblCargando";
            this.lblCargando.Size = new System.Drawing.Size(426, 197);
            this.lblCargando.TabIndex = 2;
            this.lblCargando.Text = "Cargando archivo comprimido";
            this.lblCargando.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lvArchivos
            // 
            this.lvArchivos.BackColor = System.Drawing.Color.DimGray;
            this.lvArchivos.BackgroundImageTiled = true;
            this.lvArchivos.CheckBoxes = true;
            this.lvArchivos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CHNombre,
            this.CHTamaño,
            this.chTamComp,
            this.chCompresion,
            this.chCRC});
            this.lvArchivos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvArchivos.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvArchivos.ForeColor = System.Drawing.Color.Yellow;
            this.lvArchivos.FullRowSelect = true;
            this.lvArchivos.GridLines = true;
            this.lvArchivos.HideSelection = false;
            this.lvArchivos.Location = new System.Drawing.Point(0, 0);
            this.lvArchivos.Name = "lvArchivos";
            this.lvArchivos.Size = new System.Drawing.Size(734, 391);
            this.lvArchivos.TabIndex = 1;
            this.lvArchivos.UseCompatibleStateImageBehavior = false;
            this.lvArchivos.View = System.Windows.Forms.View.Details;
            this.lvArchivos.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvArchivos_ItemChecked_1);
            this.lvArchivos.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvArchivos_ColumnClick);
            this.lvArchivos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvArchivos_MouseDown);
            // 
            // CHNombre
            // 
            this.CHNombre.Text = "Nombre";
            this.CHNombre.Width = 316;
            // 
            // CHTamaño
            // 
            this.CHTamaño.Text = "Tamaño";
            this.CHTamaño.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CHTamaño.Width = 106;
            // 
            // chTamComp
            // 
            this.chTamComp.Text = "Tam. Comp.";
            this.chTamComp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chTamComp.Width = 106;
            // 
            // chCRC
            // 
            this.chCRC.Text = "CRC";
            this.chCRC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chCRC.Width = 100;
            // 
            // pnlAbajo
            // 
            this.pnlAbajo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(237)))));
            this.pnlAbajo.Controls.Add(this.pbRestaurando);
            this.pnlAbajo.Controls.Add(this.lblEspere);
            this.pnlAbajo.Controls.Add(this.lblRestaurado);
            this.pnlAbajo.Controls.Add(this.prgRestaurado);
            this.pnlAbajo.Controls.Add(this.llblParar);
            this.pnlAbajo.Controls.Add(this.llblSalir);
            this.pnlAbajo.Controls.Add(this.llblRestaurar);
            this.pnlAbajo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAbajo.Location = new System.Drawing.Point(0, 391);
            this.pnlAbajo.Name = "pnlAbajo";
            this.pnlAbajo.Size = new System.Drawing.Size(734, 61);
            this.pnlAbajo.TabIndex = 2;
            this.pnlAbajo.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelesPaint);
            // 
            // pbRestaurando
            // 
            this.pbRestaurando.BackColor = System.Drawing.Color.Transparent;
            this.pbRestaurando.Image = global::BackupRestore.Properties.Resources.burn2;
            this.pbRestaurando.Location = new System.Drawing.Point(16, 20);
            this.pbRestaurando.Name = "pbRestaurando";
            this.pbRestaurando.Size = new System.Drawing.Size(28, 25);
            this.pbRestaurando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbRestaurando.TabIndex = 6;
            this.pbRestaurando.TabStop = false;
            this.pbRestaurando.Visible = false;
            // 
            // lblEspere
            // 
            this.lblEspere.AutoSize = true;
            this.lblEspere.BackColor = System.Drawing.Color.Transparent;
            this.lblEspere.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEspere.ForeColor = System.Drawing.Color.Maroon;
            this.lblEspere.Location = new System.Drawing.Point(45, 18);
            this.lblEspere.Name = "lblEspere";
            this.lblEspere.Size = new System.Drawing.Size(117, 29);
            this.lblEspere.TabIndex = 0;
            this.lblEspere.Text = "Espere...";
            this.lblEspere.Visible = false;
            // 
            // lblRestaurado
            // 
            this.lblRestaurado.AutoSize = true;
            this.lblRestaurado.BackColor = System.Drawing.Color.Transparent;
            this.lblRestaurado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestaurado.Location = new System.Drawing.Point(175, 27);
            this.lblRestaurado.Name = "lblRestaurado";
            this.lblRestaurado.Size = new System.Drawing.Size(109, 17);
            this.lblRestaurado.TabIndex = 2;
            this.lblRestaurado.Text = "0 / 0 restaurado";
            this.lblRestaurado.Visible = false;
            // 
            // prgRestaurado
            // 
            this.prgRestaurado.Location = new System.Drawing.Point(50, 28);
            this.prgRestaurado.Name = "prgRestaurado";
            this.prgRestaurado.Size = new System.Drawing.Size(119, 14);
            this.prgRestaurado.TabIndex = 2;
            this.prgRestaurado.Visible = false;
            // 
            // llblParar
            // 
            this.llblParar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llblParar.BackColor = System.Drawing.Color.Transparent;
            this.llblParar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblParar.Image = global::BackupRestore.Properties.Resources.fileclose1;
            this.llblParar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.llblParar.Location = new System.Drawing.Point(585, 18);
            this.llblParar.Name = "llblParar";
            this.llblParar.Size = new System.Drawing.Size(69, 24);
            this.llblParar.TabIndex = 4;
            this.llblParar.TabStop = true;
            this.llblParar.Text = "Parar";
            this.llblParar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.llblParar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblParar_LinkClicked);
            // 
            // llblSalir
            // 
            this.llblSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llblSalir.BackColor = System.Drawing.Color.Transparent;
            this.llblSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblSalir.Image = global::BackupRestore.Properties.Resources.agt_action_fail;
            this.llblSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.llblSalir.Location = new System.Drawing.Point(660, 18);
            this.llblSalir.Name = "llblSalir";
            this.llblSalir.Size = new System.Drawing.Size(62, 24);
            this.llblSalir.TabIndex = 5;
            this.llblSalir.TabStop = true;
            this.llblSalir.Text = "Salir";
            this.llblSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.llblSalir.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblSalir_LinkClicked);
            // 
            // llblRestaurar
            // 
            this.llblRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llblRestaurar.BackColor = System.Drawing.Color.Transparent;
            this.llblRestaurar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblRestaurar.Image = global::BackupRestore.Properties.Resources.agt_action_success;
            this.llblRestaurar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.llblRestaurar.Location = new System.Drawing.Point(483, 18);
            this.llblRestaurar.Name = "llblRestaurar";
            this.llblRestaurar.Size = new System.Drawing.Size(96, 24);
            this.llblRestaurar.TabIndex = 3;
            this.llblRestaurar.TabStop = true;
            this.llblRestaurar.Text = "Restaurar";
            this.llblRestaurar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.llblRestaurar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblRestaurar_LinkClicked);
            // 
            // tmrRestaurando
            // 
            this.tmrRestaurando.Enabled = true;
            this.tmrRestaurando.Tick += new System.EventHandler(this.tmrRestaurando_Tick);
            // 
            // ctxMenuStripItems
            // 
            this.ctxMenuStripItems.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ctxMenuStripItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMarcar,
            this.mnuDesmarcar,
            this.toolStripSeparator1,
            this.mnuMarcarTodo,
            this.mnuDesmarcartodo,
            this.toolStripSeparator2,
            this.mnuAbrir,
            this.mnuEjecutar});
            this.ctxMenuStripItems.Name = "ctxMenuStripItems";
            this.ctxMenuStripItems.Size = new System.Drawing.Size(159, 148);
            // 
            // mnuMarcar
            // 
            this.mnuMarcar.Name = "mnuMarcar";
            this.mnuMarcar.Size = new System.Drawing.Size(158, 22);
            this.mnuMarcar.Text = "Marcar";
            this.mnuMarcar.Click += new System.EventHandler(this.mnuMarcar_Click);
            // 
            // mnuDesmarcar
            // 
            this.mnuDesmarcar.Name = "mnuDesmarcar";
            this.mnuDesmarcar.Size = new System.Drawing.Size(158, 22);
            this.mnuDesmarcar.Text = "Desmarcar";
            this.mnuDesmarcar.Click += new System.EventHandler(this.mnuDesmarcar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
            // 
            // mnuMarcarTodo
            // 
            this.mnuMarcarTodo.Name = "mnuMarcarTodo";
            this.mnuMarcarTodo.Size = new System.Drawing.Size(158, 22);
            this.mnuMarcarTodo.Text = "Marcar todo";
            this.mnuMarcarTodo.Click += new System.EventHandler(this.mnuMarcarTodo_Click);
            // 
            // mnuDesmarcartodo
            // 
            this.mnuDesmarcartodo.Name = "mnuDesmarcartodo";
            this.mnuDesmarcartodo.Size = new System.Drawing.Size(158, 22);
            this.mnuDesmarcartodo.Text = "Desmarcar todo";
            this.mnuDesmarcartodo.Click += new System.EventHandler(this.mnuDesmarcartodo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(155, 6);
            // 
            // mnuAbrir
            // 
            this.mnuAbrir.Image = global::BackupRestore.Properties.Resources.folder;
            this.mnuAbrir.Name = "mnuAbrir";
            this.mnuAbrir.Size = new System.Drawing.Size(158, 22);
            this.mnuAbrir.Text = "Abrir ruta";
            this.mnuAbrir.Click += new System.EventHandler(this.mnuAbrir_Click);
            // 
            // mnuEjecutar
            // 
            this.mnuEjecutar.Image = global::BackupRestore.Properties.Resources.Options;
            this.mnuEjecutar.Name = "mnuEjecutar";
            this.mnuEjecutar.Size = new System.Drawing.Size(158, 22);
            this.mnuEjecutar.Text = "Ejecutar";
            this.mnuEjecutar.Click += new System.EventHandler(this.mnuEjecutar_Click);
            // 
            // ttAyudaBuscar
            // 
            this.ttAyudaBuscar.AutoPopDelay = 1000000;
            this.ttAyudaBuscar.InitialDelay = 300;
            this.ttAyudaBuscar.IsBalloon = true;
            this.ttAyudaBuscar.ReshowDelay = 100;
            this.ttAyudaBuscar.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttAyudaBuscar.ToolTipTitle = "Ayuda para las búsquedas";
            // 
            // chCompresion
            // 
            this.chCompresion.Text = "Compresión";
            this.chCompresion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chCompresion.Width = 87;
            // 
            // frmRestIndiComp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 564);
            this.Controls.Add(this.pnlCentro);
            this.Controls.Add(this.pnlArriba);
            this.Controls.Add(this.ssInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(590, 460);
            this.Name = "frmRestIndiComp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRestaurarIndiComp";
            this.Load += new System.EventHandler(this.frmRestIndiComp_Load);
            this.SizeChanged += new System.EventHandler(this.frmRestIndiComp_SizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRestIndiComp_FormClosing);
            this.Resize += new System.EventHandler(this.frmRestIndiComp_Resize);
            this.ssInfo.ResumeLayout(false);
            this.ssInfo.PerformLayout();
            this.pnlArriba.ResumeLayout(false);
            this.pnlArriba.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfoBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBuscarSiguiente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBorrarBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBuscar)).EndInit();
            this.pnlCentro.ResumeLayout(false);
            this.pnlAbajo.ResumeLayout(false);
            this.pnlAbajo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRestaurando)).EndInit();
            this.ctxMenuStripItems.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip ssInfo;
        private System.Windows.Forms.Panel pnlArriba;
        private System.Windows.Forms.Panel pnlCentro;
        private System.Windows.Forms.LinkLabel llblRestaurar;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel llblSalir;
        private System.Windows.Forms.LinkLabel llblDestino;
        private System.Windows.Forms.Panel pnlAbajo;
        private System.Windows.Forms.LinkLabel llblParar;
        private System.Windows.Forms.ToolStripStatusLabel tsSeparador1;
        private System.Windows.Forms.ToolStripStatusLabel tslblSel;
        private System.Windows.Forms.ToolStripStatusLabel tsslblArchivo;
        private System.Windows.Forms.Label lblRestaurado;
        private System.Windows.Forms.ProgressBar prgRestaurado;
        private System.Windows.Forms.ToolStripSplitButton btnOpciones;
        private System.Windows.Forms.ToolStripMenuItem mnuSelTodo;
        private System.Windows.Forms.ToolStripMenuItem mnuDesSelTodo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label lblCargando;
        private System.Windows.Forms.Label lblEspere;
        private System.Windows.Forms.ListView lvArchivos;
        private System.Windows.Forms.ColumnHeader CHNombre;
        private System.Windows.Forms.ColumnHeader CHTamaño;
        private System.Windows.Forms.ColumnHeader chTamComp;
        private System.Windows.Forms.ColumnHeader chCRC;
        private System.Windows.Forms.PictureBox pbBuscar;
        private System.Windows.Forms.PictureBox pbBorrarBuscar;
        private System.Windows.Forms.PictureBox pbBuscarSiguiente;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.PictureBox pbRestaurando;
        private System.Windows.Forms.Timer tmrRestaurando;
        private System.Windows.Forms.ContextMenuStrip ctxMenuStripItems;
        private System.Windows.Forms.ToolStripMenuItem mnuEjecutar;
        private System.Windows.Forms.ToolStripMenuItem mnuMarcar;
        private System.Windows.Forms.ToolStripMenuItem mnuDesmarcar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuAbrir;
        private System.Windows.Forms.ToolStripMenuItem mnuMarcarTodo;
        private System.Windows.Forms.ToolStripMenuItem mnuDesmarcartodo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.PictureBox pbInfoBuscar;
        private System.Windows.Forms.ToolTip ttAyudaBuscar;
        private System.Windows.Forms.ColumnHeader chCompresion;
    }
}