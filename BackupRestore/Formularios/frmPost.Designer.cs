namespace BackupRestore
{
    partial class frmPost
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblEfecto2 = new System.Windows.Forms.Label();
            this.lblEfecto1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblEfecto2);
            this.panel1.Controls.Add(this.lblEfecto1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 106);
            this.panel1.TabIndex = 0;
            // 
            // lblEfecto2
            // 
            this.lblEfecto2.BackColor = System.Drawing.Color.Lime;
            this.lblEfecto2.Location = new System.Drawing.Point(320, 93);
            this.lblEfecto2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEfecto2.Name = "lblEfecto2";
            this.lblEfecto2.Size = new System.Drawing.Size(113, 2);
            this.lblEfecto2.TabIndex = 19;
            // 
            // lblEfecto1
            // 
            this.lblEfecto1.BackColor = System.Drawing.Color.Lime;
            this.lblEfecto1.Location = new System.Drawing.Point(8, 7);
            this.lblEfecto1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEfecto1.Name = "lblEfecto1";
            this.lblEfecto1.Size = new System.Drawing.Size(113, 2);
            this.lblEfecto1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(4, 98);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(442, 4);
            this.panel2.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(4, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(442, 4);
            this.panel4.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(446, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(4, 102);
            this.panel3.TabIndex = 12;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(4, 102);
            this.panel5.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(89)))), ((int)(((byte)(101)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = global::BackupRestore.Properties.Resources.desktop;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label1.Size = new System.Drawing.Size(450, 102);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ejecutando tarea post respaldo, espere...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 106);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPost";
            this.Opacity = 0.9D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmPost";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPost_FormClosing);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmPost_MouseMove);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEfecto1;
        private System.Windows.Forms.Label lblEfecto2;
    }
}