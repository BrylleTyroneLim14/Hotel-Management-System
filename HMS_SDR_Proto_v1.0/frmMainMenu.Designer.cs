namespace HMS_SDR_Proto_v1._0
{
    partial class frmMainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainMenu));
            this.tmTime = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTimeDisplay = new System.Windows.Forms.Label();
            this.lblDateDisplay = new System.Windows.Forms.Label();
            this.lblLogout = new System.Windows.Forms.Label();
            this.lblUserTypeDisplay = new System.Windows.Forms.Label();
            this.lblUserNameDisplay = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.icoUtilities = new System.Windows.Forms.PictureBox();
            this.navUtilities = new System.Windows.Forms.Label();
            this.icoReports = new System.Windows.Forms.PictureBox();
            this.navReports = new System.Windows.Forms.Label();
            this.icoInventory = new System.Windows.Forms.PictureBox();
            this.navInventory = new System.Windows.Forms.Label();
            this.icoReservations = new System.Windows.Forms.PictureBox();
            this.navReservations = new System.Windows.Forms.Label();
            this.icoRM = new System.Windows.Forms.PictureBox();
            this.navRM = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tabInventory = new HMS_SDR_Proto_v1._0.tabInventory();
            this.tabUtilities = new HMS_SDR_Proto_v1._0.tabUtilities();
            this.tabRM = new HMS_SDR_Proto_v1._0.tabRM();
            this.tabReservation = new HMS_SDR_Proto_v1._0.tabReservation();
            this.tabReports = new HMS_SDR_Proto_v1._0.tabReports();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icoUtilities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icoReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icoInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icoReservations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icoRM)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmTime
            // 
            this.tmTime.Enabled = true;
            this.tmTime.Interval = 1000;
            this.tmTime.Tick += new System.EventHandler(this.tmTime_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1294, 682);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1294, 80);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(34)))), ((int)(((byte)(39)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 80);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(34)))), ((int)(((byte)(39)))));
            this.panel2.Controls.Add(this.lblTimeDisplay);
            this.panel2.Controls.Add(this.lblDateDisplay);
            this.panel2.Controls.Add(this.lblLogout);
            this.panel2.Controls.Add(this.lblUserTypeDisplay);
            this.panel2.Controls.Add(this.lblUserNameDisplay);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(150, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1144, 80);
            this.panel2.TabIndex = 1;
            // 
            // lblTimeDisplay
            // 
            this.lblTimeDisplay.AutoSize = true;
            this.lblTimeDisplay.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeDisplay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(146)))), ((int)(((byte)(150)))));
            this.lblTimeDisplay.Location = new System.Drawing.Point(286, 10);
            this.lblTimeDisplay.Name = "lblTimeDisplay";
            this.lblTimeDisplay.Size = new System.Drawing.Size(54, 18);
            this.lblTimeDisplay.TabIndex = 24;
            this.lblTimeDisplay.Text = "TIme : ";
            // 
            // lblDateDisplay
            // 
            this.lblDateDisplay.AutoSize = true;
            this.lblDateDisplay.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateDisplay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(146)))), ((int)(((byte)(150)))));
            this.lblDateDisplay.Location = new System.Drawing.Point(285, 28);
            this.lblDateDisplay.Name = "lblDateDisplay";
            this.lblDateDisplay.Size = new System.Drawing.Size(62, 17);
            this.lblDateDisplay.TabIndex = 23;
            this.lblDateDisplay.Text = "Today is ";
            this.lblDateDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLogout
            // 
            this.lblLogout.AutoSize = true;
            this.lblLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLogout.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.lblLogout.Location = new System.Drawing.Point(6, 47);
            this.lblLogout.Name = "lblLogout";
            this.lblLogout.Size = new System.Drawing.Size(77, 19);
            this.lblLogout.TabIndex = 22;
            this.lblLogout.Text = "(Log out)";
            this.lblLogout.Click += new System.EventHandler(this.lblLogout_Click);
            // 
            // lblUserTypeDisplay
            // 
            this.lblUserTypeDisplay.AutoSize = true;
            this.lblUserTypeDisplay.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserTypeDisplay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(146)))), ((int)(((byte)(150)))));
            this.lblUserTypeDisplay.Location = new System.Drawing.Point(6, 30);
            this.lblUserTypeDisplay.Name = "lblUserTypeDisplay";
            this.lblUserTypeDisplay.Size = new System.Drawing.Size(65, 17);
            this.lblUserTypeDisplay.TabIndex = 21;
            this.lblUserTypeDisplay.Text = "User Type";
            // 
            // lblUserNameDisplay
            // 
            this.lblUserNameDisplay.AutoSize = true;
            this.lblUserNameDisplay.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserNameDisplay.ForeColor = System.Drawing.Color.White;
            this.lblUserNameDisplay.Location = new System.Drawing.Point(6, 9);
            this.lblUserNameDisplay.Name = "lblUserNameDisplay";
            this.lblUserNameDisplay.Size = new System.Drawing.Size(133, 19);
            this.lblUserNameDisplay.TabIndex = 20;
            this.lblUserNameDisplay.Text = "User\'s Full Name";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel3.Controls.Add(this.icoUtilities);
            this.panel3.Controls.Add(this.navUtilities);
            this.panel3.Controls.Add(this.icoReports);
            this.panel3.Controls.Add(this.navReports);
            this.panel3.Controls.Add(this.icoInventory);
            this.panel3.Controls.Add(this.navInventory);
            this.panel3.Controls.Add(this.icoReservations);
            this.panel3.Controls.Add(this.navReservations);
            this.panel3.Controls.Add(this.icoRM);
            this.panel3.Controls.Add(this.navRM);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 80);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1294, 30);
            this.panel3.TabIndex = 1;
            // 
            // icoUtilities
            // 
            this.icoUtilities.Cursor = System.Windows.Forms.Cursors.Hand;
            this.icoUtilities.Image = ((System.Drawing.Image)(resources.GetObject("icoUtilities.Image")));
            this.icoUtilities.Location = new System.Drawing.Point(557, 3);
            this.icoUtilities.Name = "icoUtilities";
            this.icoUtilities.Size = new System.Drawing.Size(28, 24);
            this.icoUtilities.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.icoUtilities.TabIndex = 33;
            this.icoUtilities.TabStop = false;
            this.icoUtilities.Click += new System.EventHandler(this.icoUtilities_Click);
            // 
            // navUtilities
            // 
            this.navUtilities.AutoSize = true;
            this.navUtilities.Cursor = System.Windows.Forms.Cursors.Hand;
            this.navUtilities.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navUtilities.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(146)))), ((int)(((byte)(150)))));
            this.navUtilities.Location = new System.Drawing.Point(591, 6);
            this.navUtilities.Name = "navUtilities";
            this.navUtilities.Size = new System.Drawing.Size(131, 18);
            this.navUtilities.TabIndex = 34;
            this.navUtilities.Text = "Utilities and Tools";
            this.navUtilities.Click += new System.EventHandler(this.navUtilities_Click);
            // 
            // icoReports
            // 
            this.icoReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.icoReports.Image = ((System.Drawing.Image)(resources.GetObject("icoReports.Image")));
            this.icoReports.Location = new System.Drawing.Point(455, 3);
            this.icoReports.Name = "icoReports";
            this.icoReports.Size = new System.Drawing.Size(28, 24);
            this.icoReports.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.icoReports.TabIndex = 31;
            this.icoReports.TabStop = false;
            this.icoReports.Click += new System.EventHandler(this.icoReports_Click);
            // 
            // navReports
            // 
            this.navReports.AutoSize = true;
            this.navReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.navReports.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(146)))), ((int)(((byte)(150)))));
            this.navReports.Location = new System.Drawing.Point(489, 6);
            this.navReports.Name = "navReports";
            this.navReports.Size = new System.Drawing.Size(62, 18);
            this.navReports.TabIndex = 32;
            this.navReports.Text = "Reports";
            this.navReports.Click += new System.EventHandler(this.navReports_Click);
            // 
            // icoInventory
            // 
            this.icoInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.icoInventory.Image = ((System.Drawing.Image)(resources.GetObject("icoInventory.Image")));
            this.icoInventory.Location = new System.Drawing.Point(339, 3);
            this.icoInventory.Name = "icoInventory";
            this.icoInventory.Size = new System.Drawing.Size(28, 24);
            this.icoInventory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.icoInventory.TabIndex = 29;
            this.icoInventory.TabStop = false;
            this.icoInventory.Click += new System.EventHandler(this.icoInventory_Click);
            // 
            // navInventory
            // 
            this.navInventory.AutoSize = true;
            this.navInventory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.navInventory.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navInventory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(146)))), ((int)(((byte)(150)))));
            this.navInventory.Location = new System.Drawing.Point(373, 6);
            this.navInventory.Name = "navInventory";
            this.navInventory.Size = new System.Drawing.Size(76, 18);
            this.navInventory.TabIndex = 30;
            this.navInventory.Text = "Inventory";
            this.navInventory.Click += new System.EventHandler(this.navInventory_Click);
            // 
            // icoReservations
            // 
            this.icoReservations.Cursor = System.Windows.Forms.Cursors.Hand;
            this.icoReservations.Image = ((System.Drawing.Image)(resources.GetObject("icoReservations.Image")));
            this.icoReservations.Location = new System.Drawing.Point(200, 3);
            this.icoReservations.Name = "icoReservations";
            this.icoReservations.Size = new System.Drawing.Size(28, 24);
            this.icoReservations.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.icoReservations.TabIndex = 27;
            this.icoReservations.TabStop = false;
            this.icoReservations.Click += new System.EventHandler(this.icoReservations_Click);
            // 
            // navReservations
            // 
            this.navReservations.AutoSize = true;
            this.navReservations.Cursor = System.Windows.Forms.Cursors.Hand;
            this.navReservations.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navReservations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(146)))), ((int)(((byte)(150)))));
            this.navReservations.Location = new System.Drawing.Point(234, 6);
            this.navReservations.Name = "navReservations";
            this.navReservations.Size = new System.Drawing.Size(99, 18);
            this.navReservations.TabIndex = 28;
            this.navReservations.Text = "Reservations";
            this.navReservations.Click += new System.EventHandler(this.navReservations_Click);
            // 
            // icoRM
            // 
            this.icoRM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.icoRM.Image = ((System.Drawing.Image)(resources.GetObject("icoRM.Image")));
            this.icoRM.Location = new System.Drawing.Point(7, 3);
            this.icoRM.Name = "icoRM";
            this.icoRM.Size = new System.Drawing.Size(28, 24);
            this.icoRM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.icoRM.TabIndex = 25;
            this.icoRM.TabStop = false;
            this.icoRM.Click += new System.EventHandler(this.icoRM_Click);
            // 
            // navRM
            // 
            this.navRM.AutoSize = true;
            this.navRM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.navRM.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navRM.ForeColor = System.Drawing.Color.White;
            this.navRM.Location = new System.Drawing.Point(40, 6);
            this.navRM.Name = "navRM";
            this.navRM.Size = new System.Drawing.Size(155, 18);
            this.navRM.TabIndex = 26;
            this.navRM.Text = "Room Management";
            this.navRM.Click += new System.EventHandler(this.navRM_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tabReports);
            this.panel4.Controls.Add(this.tabReservation);
            this.panel4.Controls.Add(this.tabInventory);
            this.panel4.Controls.Add(this.tabUtilities);
            this.panel4.Controls.Add(this.tabRM);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 110);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1294, 572);
            this.panel4.TabIndex = 2;
            // 
            // tabInventory
            // 
            this.tabInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabInventory.Location = new System.Drawing.Point(0, 0);
            this.tabInventory.Name = "tabInventory";
            this.tabInventory.Size = new System.Drawing.Size(1294, 572);
            this.tabInventory.TabIndex = 2;
            // 
            // tabUtilities
            // 
            this.tabUtilities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabUtilities.Location = new System.Drawing.Point(0, 0);
            this.tabUtilities.Name = "tabUtilities";
            this.tabUtilities.Size = new System.Drawing.Size(1294, 572);
            this.tabUtilities.TabIndex = 1;
            // 
            // tabRM
            // 
            this.tabRM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabRM.Location = new System.Drawing.Point(0, 0);
            this.tabRM.Name = "tabRM";
            this.tabRM.Size = new System.Drawing.Size(1294, 572);
            this.tabRM.TabIndex = 0;
            // 
            // tabReservation
            // 
            this.tabReservation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabReservation.Location = new System.Drawing.Point(0, 0);
            this.tabReservation.Name = "tabReservation";
            this.tabReservation.Size = new System.Drawing.Size(1294, 572);
            this.tabReservation.TabIndex = 3;
            // 
            // tabReports
            // 
            this.tabReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabReports.Location = new System.Drawing.Point(0, 0);
            this.tabReports.Name = "tabReports";
            this.tabReports.Size = new System.Drawing.Size(1294, 572);
            this.tabReports.TabIndex = 4;
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 682);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMainMenu";
            this.Text = "Hotel Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMainMenu_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icoUtilities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icoReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icoInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icoReservations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icoRM)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTimeDisplay;
        private System.Windows.Forms.Label lblDateDisplay;
        private System.Windows.Forms.Label lblLogout;
        private System.Windows.Forms.Label lblUserTypeDisplay;
        private System.Windows.Forms.Label lblUserNameDisplay;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox icoUtilities;
        private System.Windows.Forms.Label navUtilities;
        private System.Windows.Forms.PictureBox icoReports;
        private System.Windows.Forms.Label navReports;
        private System.Windows.Forms.PictureBox icoInventory;
        private System.Windows.Forms.Label navInventory;
        private System.Windows.Forms.PictureBox icoReservations;
        private System.Windows.Forms.Label navReservations;
        private System.Windows.Forms.PictureBox icoRM;
        private System.Windows.Forms.Label navRM;
        private System.Windows.Forms.Panel panel4;
        private tabRM tabRM;
        private tabUtilities tabUtilities;
        private tabInventory tabInventory;
        private tabReports tabReports;
        private tabReservation tabReservation;
    }
}