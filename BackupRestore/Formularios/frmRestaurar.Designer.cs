namespace BackupRestore
{
    partial class frmRestaurar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRestaurar));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Comprimidas", 1, 1);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Sin Comprimir", 2, 2);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Restaurar", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.imgTree = new System.Windows.Forms.ImageList(this.components);
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRestIndividual = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnRestaurarTodo = new System.Windows.Forms.Button();
            this.gbRestaurar = new System.Windows.Forms.GroupBox();
            this.pbInfo = new System.Windows.Forms.PictureBox();
            this.chkRutasOrig = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnDestino = new System.Windows.Forms.Button();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.lblDest1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMostrarTodoPaneles = new System.Windows.Forms.Button();
            this.btnNoColapsarDerecho = new System.Windows.Forms.Button();
            this.btnColapsarIzquierdo = new System.Windows.Forms.Button();
            this.lblInfo1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblCopias = new System.Windows.Forms.Label();
            this.tvCopias = new System.Windows.Forms.TreeView();
            this.lblRuta = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();
            this.lblTamaño = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblHoraCreacion = new System.Windows.Forms.Label();
            this.lblTamanyo = new System.Windows.Forms.Label();
            this.lblFechaCreacion = new System.Windows.Forms.Label();
            this.ttInfo = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbRestaurar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgTree
            // 
            this.imgTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTree.ImageStream")));
            this.imgTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imgTree.Images.SetKeyName(0, "hdd_mount.png");
            this.imgTree.Images.SetKeyName(1, "tgz.png");
            this.imgTree.Images.SetKeyName(2, "tar.png");
            this.imgTree.Images.SetKeyName(3, "folder_blue.png");
            this.imgTree.Images.SetKeyName(4, "folder_documents.png");
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.panel1);
            this.kryptonPanel1.Controls.Add(this.gbRestaurar);
            this.kryptonPanel1.Controls.Add(this.groupBox1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.kryptonPanel1.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.FormMain;
            this.kryptonPanel1.Size = new System.Drawing.Size(748, 676);
            this.kryptonPanel1.StateCommon.Color1 = System.Drawing.Color.Black;
            this.kryptonPanel1.StateCommon.Color2 = System.Drawing.Color.Sienna;
            this.kryptonPanel1.StateCommon.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.RoundedTopLight;
            this.kryptonPanel1.StateCommon.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.kryptonPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnRestIndividual);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.btnRestaurarTodo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 611);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 65);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnRestIndividual
            // 
            this.btnRestIndividual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestIndividual.AutoSize = true;
            this.btnRestIndividual.BackColor = System.Drawing.Color.Transparent;
            this.btnRestIndividual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestIndividual.Enabled = false;
            this.btnRestIndividual.FlatAppearance.BorderSize = 0;
            this.btnRestIndividual.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnRestIndividual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestIndividual.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestIndividual.ForeColor = System.Drawing.Color.Black;
            this.btnRestIndividual.Image = global::BackupRestore.Properties.Resources.DossierRecherche32x32;
            this.btnRestIndividual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRestIndividual.Location = new System.Drawing.Point(42, 4);
            this.btnRestIndividual.Margin = new System.Windows.Forms.Padding(4);
            this.btnRestIndividual.Name = "btnRestIndividual";
            this.btnRestIndividual.Size = new System.Drawing.Size(240, 54);
            this.btnRestIndividual.TabIndex = 5;
            this.btnRestIndividual.Text = "Restauración &individual";
            this.btnRestIndividual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRestIndividual.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRestIndividual.UseVisualStyleBackColor = false;
            this.btnRestIndividual.Click += new System.EventHandler(this.btnRestIndividual_Click);
            this.btnRestIndividual.Enter += new System.EventHandler(this.Acciones_Enter);
            this.btnRestIndividual.Leave += new System.EventHandler(this.Acciones_Mouse_Leave);
            this.btnRestIndividual.MouseEnter += new System.EventHandler(this.Acciones_Mouse_Enter);
            this.btnRestIndividual.MouseLeave += new System.EventHandler(this.Acciones_Mouse_Leave);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.AutoSize = true;
            this.btnSalir.BackColor = System.Drawing.Color.Transparent;
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.Black;
            this.btnSalir.Image = global::BackupRestore.Properties.Resources.Arreter32x32;
            this.btnSalir.Location = new System.Drawing.Point(592, 4);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(111, 54);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            this.btnSalir.Enter += new System.EventHandler(this.Acciones_Enter);
            this.btnSalir.Leave += new System.EventHandler(this.Acciones_Mouse_Leave);
            this.btnSalir.MouseEnter += new System.EventHandler(this.Acciones_Mouse_Enter);
            this.btnSalir.MouseLeave += new System.EventHandler(this.Acciones_Mouse_Leave);
            // 
            // btnRestaurarTodo
            // 
            this.btnRestaurarTodo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestaurarTodo.AutoSize = true;
            this.btnRestaurarTodo.BackColor = System.Drawing.Color.Transparent;
            this.btnRestaurarTodo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestaurarTodo.Enabled = false;
            this.btnRestaurarTodo.FlatAppearance.BorderSize = 0;
            this.btnRestaurarTodo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnRestaurarTodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurarTodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestaurarTodo.ForeColor = System.Drawing.Color.Black;
            this.btnRestaurarTodo.Image = global::BackupRestore.Properties.Resources.Mes_Documents32x32;
            this.btnRestaurarTodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRestaurarTodo.Location = new System.Drawing.Point(346, 4);
            this.btnRestaurarTodo.Margin = new System.Windows.Forms.Padding(4);
            this.btnRestaurarTodo.Name = "btnRestaurarTodo";
            this.btnRestaurarTodo.Size = new System.Drawing.Size(182, 54);
            this.btnRestaurarTodo.TabIndex = 6;
            this.btnRestaurarTodo.Text = "Restaurar &todo";
            this.btnRestaurarTodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRestaurarTodo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRestaurarTodo.UseVisualStyleBackColor = false;
            this.btnRestaurarTodo.Click += new System.EventHandler(this.btnRestaurar_Click);
            this.btnRestaurarTodo.Enter += new System.EventHandler(this.Acciones_Enter);
            this.btnRestaurarTodo.Leave += new System.EventHandler(this.Acciones_Mouse_Leave);
            this.btnRestaurarTodo.MouseEnter += new System.EventHandler(this.Acciones_Mouse_Enter);
            this.btnRestaurarTodo.MouseLeave += new System.EventHandler(this.Acciones_Mouse_Leave);
            // 
            // gbRestaurar
            // 
            this.gbRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRestaurar.BackColor = System.Drawing.Color.Transparent;
            this.gbRestaurar.Controls.Add(this.pbInfo);
            this.gbRestaurar.Controls.Add(this.chkRutasOrig);
            this.gbRestaurar.Controls.Add(this.pictureBox2);
            this.gbRestaurar.Controls.Add(this.btnDestino);
            this.gbRestaurar.Controls.Add(this.txtDestino);
            this.gbRestaurar.Controls.Add(this.lblDest1);
            this.gbRestaurar.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRestaurar.ForeColor = System.Drawing.Color.Gold;
            this.gbRestaurar.Location = new System.Drawing.Point(16, 426);
            this.gbRestaurar.Margin = new System.Windows.Forms.Padding(4);
            this.gbRestaurar.Name = "gbRestaurar";
            this.gbRestaurar.Padding = new System.Windows.Forms.Padding(4);
            this.gbRestaurar.Size = new System.Drawing.Size(715, 164);
            this.gbRestaurar.TabIndex = 1;
            this.gbRestaurar.TabStop = false;
            this.gbRestaurar.Text = "Destino para restaurar";
            // 
            // pbInfo
            // 
            this.pbInfo.Image = global::BackupRestore.Properties.Resources.Information32x32;
            this.pbInfo.Location = new System.Drawing.Point(309, 40);
            this.pbInfo.Margin = new System.Windows.Forms.Padding(4);
            this.pbInfo.Name = "pbInfo";
            this.pbInfo.Size = new System.Drawing.Size(35, 35);
            this.pbInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbInfo.TabIndex = 33;
            this.pbInfo.TabStop = false;
            this.pbInfo.MouseEnter += new System.EventHandler(this.pbInfo_MouseEnter);
            this.pbInfo.MouseLeave += new System.EventHandler(this.pbInfo_MouseLeave);
            // 
            // chkRutasOrig
            // 
            this.chkRutasOrig.AutoSize = true;
            this.chkRutasOrig.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRutasOrig.ForeColor = System.Drawing.Color.White;
            this.chkRutasOrig.Location = new System.Drawing.Point(21, 40);
            this.chkRutasOrig.Margin = new System.Windows.Forms.Padding(4);
            this.chkRutasOrig.Name = "chkRutasOrig";
            this.chkRutasOrig.Size = new System.Drawing.Size(280, 24);
            this.chkRutasOrig.TabIndex = 1;
            this.chkRutasOrig.Text = "R&estaurar en rutas originales";
            this.chkRutasOrig.UseVisualStyleBackColor = true;
            this.chkRutasOrig.CheckedChanged += new System.EventHandler(this.chkRutasOrig_CheckedChanged);
            this.chkRutasOrig.MouseEnter += new System.EventHandler(this.chkRutasOrig_MouseEnter);
            this.chkRutasOrig.MouseLeave += new System.EventHandler(this.chkRutasOrig_MouseLeave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::BackupRestore.Properties.Resources.DossierAide64x64;
            this.pictureBox2.Location = new System.Drawing.Point(638, 18);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(69, 67);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 30;
            this.pictureBox2.TabStop = false;
            // 
            // btnDestino
            // 
            this.btnDestino.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDestino.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDestino.FlatAppearance.BorderSize = 0;
            this.btnDestino.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDestino.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDestino.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDestino.Image = global::BackupRestore.Properties.Resources.viewmag;
            this.btnDestino.Location = new System.Drawing.Point(669, 119);
            this.btnDestino.Margin = new System.Windows.Forms.Padding(4);
            this.btnDestino.Name = "btnDestino";
            this.btnDestino.Size = new System.Drawing.Size(24, 24);
            this.btnDestino.TabIndex = 4;
            this.btnDestino.UseVisualStyleBackColor = true;
            this.btnDestino.Click += new System.EventHandler(this.btnDestino_Click);
            // 
            // txtDestino
            // 
            this.txtDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtDestino.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.txtDestino.BackColor = System.Drawing.Color.LightGray;
            this.txtDestino.Location = new System.Drawing.Point(21, 118);
            this.txtDestino.Margin = new System.Windows.Forms.Padding(4);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(640, 28);
            this.txtDestino.TabIndex = 3;
            // 
            // lblDest1
            // 
            this.lblDest1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDest1.AutoSize = true;
            this.lblDest1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDest1.ForeColor = System.Drawing.Color.White;
            this.lblDest1.Location = new System.Drawing.Point(17, 88);
            this.lblDest1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDest1.Name = "lblDest1";
            this.lblDest1.Size = new System.Drawing.Size(210, 20);
            this.lblDest1.TabIndex = 2;
            this.lblDest1.Text = "Destino para restaurar:";
            this.lblDest1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.btnMostrarTodoPaneles);
            this.groupBox1.Controls.Add(this.btnNoColapsarDerecho);
            this.groupBox1.Controls.Add(this.btnColapsarIzquierdo);
            this.groupBox1.Controls.Add(this.lblInfo1);
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Gold;
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(715, 403);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información de las copias";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::BackupRestore.Properties.Resources.DownloadCD;
            this.pictureBox1.Location = new System.Drawing.Point(638, 18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(69, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // btnMostrarTodoPaneles
            // 
            this.btnMostrarTodoPaneles.BackColor = System.Drawing.Color.Transparent;
            this.btnMostrarTodoPaneles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMostrarTodoPaneles.FlatAppearance.BorderSize = 0;
            this.btnMostrarTodoPaneles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnMostrarTodoPaneles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarTodoPaneles.Image = global::BackupRestore.Properties.Resources.insert_table_row;
            this.btnMostrarTodoPaneles.Location = new System.Drawing.Point(475, 28);
            this.btnMostrarTodoPaneles.Margin = new System.Windows.Forms.Padding(4);
            this.btnMostrarTodoPaneles.Name = "btnMostrarTodoPaneles";
            this.btnMostrarTodoPaneles.Size = new System.Drawing.Size(44, 34);
            this.btnMostrarTodoPaneles.TabIndex = 2;
            this.btnMostrarTodoPaneles.UseVisualStyleBackColor = false;
            this.btnMostrarTodoPaneles.Visible = false;
            this.btnMostrarTodoPaneles.Click += new System.EventHandler(this.btnMostrarTodoPaneles_Click);
            // 
            // btnNoColapsarDerecho
            // 
            this.btnNoColapsarDerecho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNoColapsarDerecho.FlatAppearance.BorderSize = 0;
            this.btnNoColapsarDerecho.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNoColapsarDerecho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNoColapsarDerecho.Image = global::BackupRestore.Properties.Resources.build2_32x32;
            this.btnNoColapsarDerecho.Location = new System.Drawing.Point(559, 23);
            this.btnNoColapsarDerecho.Margin = new System.Windows.Forms.Padding(4);
            this.btnNoColapsarDerecho.Name = "btnNoColapsarDerecho";
            this.btnNoColapsarDerecho.Size = new System.Drawing.Size(45, 39);
            this.btnNoColapsarDerecho.TabIndex = 3;
            this.btnNoColapsarDerecho.UseVisualStyleBackColor = true;
            this.btnNoColapsarDerecho.Visible = false;
            this.btnNoColapsarDerecho.Click += new System.EventHandler(this.btnColapsarDerecho_Click);
            // 
            // btnColapsarIzquierdo
            // 
            this.btnColapsarIzquierdo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnColapsarIzquierdo.FlatAppearance.BorderSize = 0;
            this.btnColapsarIzquierdo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnColapsarIzquierdo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColapsarIzquierdo.Image = global::BackupRestore.Properties.Resources.build1_32x32;
            this.btnColapsarIzquierdo.Location = new System.Drawing.Point(514, 23);
            this.btnColapsarIzquierdo.Margin = new System.Windows.Forms.Padding(4);
            this.btnColapsarIzquierdo.Name = "btnColapsarIzquierdo";
            this.btnColapsarIzquierdo.Size = new System.Drawing.Size(43, 42);
            this.btnColapsarIzquierdo.TabIndex = 1;
            this.btnColapsarIzquierdo.UseVisualStyleBackColor = true;
            this.btnColapsarIzquierdo.Visible = false;
            this.btnColapsarIzquierdo.Click += new System.EventHandler(this.btnColapsarIzquierdo_Click);
            // 
            // lblInfo1
            // 
            this.lblInfo1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo1.ForeColor = System.Drawing.Color.White;
            this.lblInfo1.Location = new System.Drawing.Point(16, 28);
            this.lblInfo1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.Size = new System.Drawing.Size(467, 34);
            this.lblInfo1.TabIndex = 0;
            this.lblInfo1.Text = "Elegir una copia para restaurar...";
            this.lblInfo1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(21, 91);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblCopias);
            this.splitContainer1.Panel1.Controls.Add(this.tvCopias);
            this.splitContainer1.Panel1MinSize = 120;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblRuta);
            this.splitContainer1.Panel2.Controls.Add(this.lblPath);
            this.splitContainer1.Panel2.Controls.Add(this.lblTamaño);
            this.splitContainer1.Panel2.Controls.Add(this.lblHora);
            this.splitContainer1.Panel2.Controls.Add(this.lblFecha);
            this.splitContainer1.Panel2.Controls.Add(this.lblHoraCreacion);
            this.splitContainer1.Panel2.Controls.Add(this.lblTamanyo);
            this.splitContainer1.Panel2.Controls.Add(this.lblFechaCreacion);
            this.splitContainer1.Panel2MinSize = 130;
            this.splitContainer1.Size = new System.Drawing.Size(673, 292);
            this.splitContainer1.SplitterDistance = 301;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 28;
            // 
            // lblCopias
            // 
            this.lblCopias.BackColor = System.Drawing.Color.DimGray;
            this.lblCopias.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCopias.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopias.ForeColor = System.Drawing.Color.White;
            this.lblCopias.Location = new System.Drawing.Point(0, 0);
            this.lblCopias.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCopias.Name = "lblCopias";
            this.lblCopias.Size = new System.Drawing.Size(301, 22);
            this.lblCopias.TabIndex = 8;
            this.lblCopias.Text = "Copias de seguridad";
            this.lblCopias.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCopias.Paint += new System.Windows.Forms.PaintEventHandler(this.Etiquietas_Paint);
            // 
            // tvCopias
            // 
            this.tvCopias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvCopias.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tvCopias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvCopias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvCopias.HideSelection = false;
            this.tvCopias.HotTracking = true;
            this.tvCopias.ImageIndex = 0;
            this.tvCopias.ImageList = this.imgTree;
            this.tvCopias.Location = new System.Drawing.Point(0, 24);
            this.tvCopias.Margin = new System.Windows.Forms.Padding(4);
            this.tvCopias.Name = "tvCopias";
            treeNode1.ImageIndex = 1;
            treeNode1.Name = "nodoComprimir";
            treeNode1.SelectedImageIndex = 1;
            treeNode1.Tag = "comprimidas";
            treeNode1.Text = "Comprimidas";
            treeNode2.ImageIndex = 2;
            treeNode2.Name = "nodoSinComprimir";
            treeNode2.SelectedImageIndex = 2;
            treeNode2.Tag = "sincomprimir";
            treeNode2.Text = "Sin Comprimir";
            treeNode3.ImageIndex = 0;
            treeNode3.Name = "nodoRaiz";
            treeNode3.Text = "Restaurar";
            this.tvCopias.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.tvCopias.SelectedImageIndex = 0;
            this.tvCopias.Size = new System.Drawing.Size(303, 268);
            this.tvCopias.TabIndex = 0;
            this.tvCopias.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvCopias_AfterSelect);
            this.tvCopias.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvCopias_NodeMouseClick);
            // 
            // lblRuta
            // 
            this.lblRuta.BackColor = System.Drawing.Color.DimGray;
            this.lblRuta.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRuta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuta.ForeColor = System.Drawing.Color.White;
            this.lblRuta.Location = new System.Drawing.Point(0, 0);
            this.lblRuta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(367, 22);
            this.lblRuta.TabIndex = 3;
            this.lblRuta.Text = "Ruta de la copia";
            this.lblRuta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRuta.Paint += new System.Windows.Forms.PaintEventHandler(this.Etiquietas_Paint);
            // 
            // lblPath
            // 
            this.lblPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPath.AutoEllipsis = true;
            this.lblPath.BackColor = System.Drawing.Color.Transparent;
            this.lblPath.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPath.ForeColor = System.Drawing.Color.White;
            this.lblPath.Location = new System.Drawing.Point(0, 24);
            this.lblPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(367, 115);
            this.lblPath.TabIndex = 1;
            // 
            // lblTamaño
            // 
            this.lblTamaño.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTamaño.BackColor = System.Drawing.Color.Transparent;
            this.lblTamaño.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTamaño.ForeColor = System.Drawing.Color.White;
            this.lblTamaño.Location = new System.Drawing.Point(2, 267);
            this.lblTamaño.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTamaño.Name = "lblTamaño";
            this.lblTamaño.Size = new System.Drawing.Size(364, 25);
            this.lblTamaño.TabIndex = 7;
            // 
            // lblHora
            // 
            this.lblHora.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHora.BackColor = System.Drawing.Color.Transparent;
            this.lblHora.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.ForeColor = System.Drawing.Color.White;
            this.lblHora.Location = new System.Drawing.Point(2, 217);
            this.lblHora.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(364, 25);
            this.lblHora.TabIndex = 5;
            // 
            // lblFecha
            // 
            this.lblFecha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFecha.BackColor = System.Drawing.Color.Transparent;
            this.lblFecha.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.White;
            this.lblFecha.Location = new System.Drawing.Point(2, 165);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(364, 25);
            this.lblFecha.TabIndex = 3;
            // 
            // lblHoraCreacion
            // 
            this.lblHoraCreacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHoraCreacion.BackColor = System.Drawing.Color.DimGray;
            this.lblHoraCreacion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoraCreacion.ForeColor = System.Drawing.Color.White;
            this.lblHoraCreacion.Location = new System.Drawing.Point(2, 193);
            this.lblHoraCreacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHoraCreacion.Name = "lblHoraCreacion";
            this.lblHoraCreacion.Size = new System.Drawing.Size(364, 22);
            this.lblHoraCreacion.TabIndex = 4;
            this.lblHoraCreacion.Text = "Hora de creación";
            this.lblHoraCreacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHoraCreacion.Paint += new System.Windows.Forms.PaintEventHandler(this.Etiquietas_Paint);
            // 
            // lblTamanyo
            // 
            this.lblTamanyo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTamanyo.BackColor = System.Drawing.Color.DimGray;
            this.lblTamanyo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTamanyo.ForeColor = System.Drawing.Color.White;
            this.lblTamanyo.Location = new System.Drawing.Point(2, 245);
            this.lblTamanyo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTamanyo.Name = "lblTamanyo";
            this.lblTamanyo.Size = new System.Drawing.Size(364, 22);
            this.lblTamanyo.TabIndex = 6;
            this.lblTamanyo.Text = "Tamaño";
            this.lblTamanyo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTamanyo.Paint += new System.Windows.Forms.PaintEventHandler(this.Etiquietas_Paint);
            // 
            // lblFechaCreacion
            // 
            this.lblFechaCreacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaCreacion.BackColor = System.Drawing.Color.DimGray;
            this.lblFechaCreacion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaCreacion.ForeColor = System.Drawing.Color.White;
            this.lblFechaCreacion.Location = new System.Drawing.Point(2, 141);
            this.lblFechaCreacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaCreacion.Name = "lblFechaCreacion";
            this.lblFechaCreacion.Size = new System.Drawing.Size(364, 22);
            this.lblFechaCreacion.TabIndex = 2;
            this.lblFechaCreacion.Text = "Fecha de creación";
            this.lblFechaCreacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFechaCreacion.Paint += new System.Windows.Forms.PaintEventHandler(this.Etiquietas_Paint);
            // 
            // ttInfo
            // 
            this.ttInfo.AutoPopDelay = 10000;
            this.ttInfo.InitialDelay = 250;
            this.ttInfo.IsBalloon = true;
            this.ttInfo.ReshowDelay = 100;
            this.ttInfo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // frmRestaurar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 676);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(737, 622);
            this.Name = "frmRestaurar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restaurar Copias...";
            this.Load += new System.EventHandler(this.frmRestaurar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRestaurar_KeyDown);
            this.Resize += new System.EventHandler(this.frmRestaurar_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbRestaurar.ResumeLayout(false);
            this.gbRestaurar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imgTree;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbRestaurar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnDestino;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Label lblDest1;
        private System.Windows.Forms.CheckBox chkRutasOrig;
        private System.Windows.Forms.ToolTip ttInfo;
        private System.Windows.Forms.PictureBox pbInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblInfo1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvCopias;
        private System.Windows.Forms.Label lblTamaño;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label lblHoraCreacion;
        private System.Windows.Forms.Label lblTamanyo;
        private System.Windows.Forms.Label lblFechaCreacion;
        private System.Windows.Forms.Button btnNoColapsarDerecho;
        private System.Windows.Forms.Button btnColapsarIzquierdo;
        private System.Windows.Forms.Button btnMostrarTodoPaneles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRestIndividual;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnRestaurarTodo;
        private System.Windows.Forms.Label lblRuta;
        private System.Windows.Forms.Label lblCopias;
    }
}