namespace HMS_SDR_Proto_v1._0
{
    partial class frmExtendRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExtendRoom));
            this.bunifuElipse1 = new ns1.BunifuElipse(this.components);
            this.bunifuCards1 = new ns1.BunifuCards();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExtend = new System.Windows.Forms.Button();
            this.lblRatePreview = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtHour = new System.Windows.Forms.TextBox();
            this.rdoPerHour = new System.Windows.Forms.RadioButton();
            this.rdoRate_3 = new System.Windows.Forms.RadioButton();
            this.rdoRate_2 = new System.Windows.Forms.RadioButton();
            this.rdoRate_1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.bunifuCards1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.SystemColors.Menu;
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.DarkTurquoise;
            this.bunifuCards1.Controls.Add(this.btnCancel);
            this.bunifuCards1.Controls.Add(this.btnExtend);
            this.bunifuCards1.Controls.Add(this.lblRatePreview);
            this.bunifuCards1.Controls.Add(this.label2);
            this.bunifuCards1.Controls.Add(this.groupBox1);
            this.bunifuCards1.Controls.Add(this.label1);
            this.bunifuCards1.Controls.Add(this.shapeContainer1);
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(1, 1);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(471, 170);
            this.bunifuCards1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Tomato;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(353, 127);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExtend
            // 
            this.btnExtend.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnExtend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExtend.FlatAppearance.BorderColor = System.Drawing.Color.DarkTurquoise;
            this.btnExtend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExtend.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtend.ForeColor = System.Drawing.Color.White;
            this.btnExtend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExtend.Location = new System.Drawing.Point(207, 127);
            this.btnExtend.Margin = new System.Windows.Forms.Padding(0);
            this.btnExtend.Name = "btnExtend";
            this.btnExtend.Size = new System.Drawing.Size(137, 26);
            this.btnExtend.TabIndex = 24;
            this.btnExtend.Text = "EXTEND STAY";
            this.btnExtend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExtend.UseVisualStyleBackColor = false;
            this.btnExtend.Click += new System.EventHandler(this.btnExtend_Click);
            // 
            // lblRatePreview
            // 
            this.lblRatePreview.AutoSize = true;
            this.lblRatePreview.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRatePreview.ForeColor = System.Drawing.Color.Green;
            this.lblRatePreview.Location = new System.Drawing.Point(58, 129);
            this.lblRatePreview.Name = "lblRatePreview";
            this.lblRatePreview.Size = new System.Drawing.Size(123, 19);
            this.lblRatePreview.TabIndex = 7;
            this.lblRatePreview.Text = "Php 999,999.00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(14, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "RATE:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtHour);
            this.groupBox1.Controls.Add(this.rdoPerHour);
            this.groupBox1.Controls.Add(this.rdoRate_3);
            this.groupBox1.Controls.Add(this.rdoRate_2);
            this.groupBox1.Controls.Add(this.rdoRate_1);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(439, 67);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Duration";
            // 
            // txtHour
            // 
            this.txtHour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHour.Enabled = false;
            this.txtHour.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHour.Location = new System.Drawing.Point(350, 31);
            this.txtHour.MaxLength = 3;
            this.txtHour.Name = "txtHour";
            this.txtHour.Size = new System.Drawing.Size(78, 26);
            this.txtHour.TabIndex = 36;
            this.txtHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHour.TextChanged += new System.EventHandler(this.txtHour_TextChanged);
            this.txtHour.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHour_KeyPress);
            // 
            // rdoPerHour
            // 
            this.rdoPerHour.AutoSize = true;
            this.rdoPerHour.Location = new System.Drawing.Point(263, 31);
            this.rdoPerHour.Name = "rdoPerHour";
            this.rdoPerHour.Size = new System.Drawing.Size(81, 20);
            this.rdoPerHour.TabIndex = 3;
            this.rdoPerHour.Text = "per hour";
            this.rdoPerHour.UseVisualStyleBackColor = true;
            this.rdoPerHour.CheckedChanged += new System.EventHandler(this.rdoPerHour_CheckedChanged);
            // 
            // rdoRate_3
            // 
            this.rdoRate_3.AutoSize = true;
            this.rdoRate_3.Location = new System.Drawing.Point(178, 31);
            this.rdoRate_3.Name = "rdoRate_3";
            this.rdoRate_3.Size = new System.Drawing.Size(79, 20);
            this.rdoRate_3.TabIndex = 2;
            this.rdoRate_3.Text = "22 hours";
            this.rdoRate_3.UseVisualStyleBackColor = true;
            this.rdoRate_3.CheckedChanged += new System.EventHandler(this.rdoRate_3_CheckedChanged);
            // 
            // rdoRate_2
            // 
            this.rdoRate_2.AutoSize = true;
            this.rdoRate_2.Location = new System.Drawing.Point(93, 31);
            this.rdoRate_2.Name = "rdoRate_2";
            this.rdoRate_2.Size = new System.Drawing.Size(79, 20);
            this.rdoRate_2.TabIndex = 1;
            this.rdoRate_2.Text = "10 hours";
            this.rdoRate_2.UseVisualStyleBackColor = true;
            this.rdoRate_2.CheckedChanged += new System.EventHandler(this.rdoRate_2_CheckedChanged);
            // 
            // rdoRate_1
            // 
            this.rdoRate_1.AutoSize = true;
            this.rdoRate_1.Checked = true;
            this.rdoRate_1.Location = new System.Drawing.Point(15, 31);
            this.rdoRate_1.Name = "rdoRate_1";
            this.rdoRate_1.Size = new System.Drawing.Size(72, 20);
            this.rdoRate_1.TabIndex = 0;
            this.rdoRate_1.TabStop = true;
            this.rdoRate_1.Text = "5 hours";
            this.rdoRate_1.UseVisualStyleBackColor = true;
            this.rdoRate_1.CheckedChanged += new System.EventHandler(this.rdoRate_1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Extend Stay";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(471, 170);
            this.shapeContainer1.TabIndex = 4;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderWidth = 2;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 14;
            this.lineShape1.X2 = 313;
            this.lineShape1.Y1 = 41;
            this.lineShape1.Y2 = 41;
            // 
            // frmExtendRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 170);
            this.Controls.Add(this.bunifuCards1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmExtendRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extend Stay";
            this.Load += new System.EventHandler(this.frmExtendRoom_Load);
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ns1.BunifuElipse bunifuElipse1;
        private ns1.BunifuCards bunifuCards1;
        private System.Windows.Forms.Label label1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Label lblRatePreview;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoPerHour;
        private System.Windows.Forms.RadioButton rdoRate_3;
        private System.Windows.Forms.RadioButton rdoRate_2;
        private System.Windows.Forms.RadioButton rdoRate_1;
        private System.Windows.Forms.TextBox txtHour;
        private System.Windows.Forms.Button btnExtend;
        private System.Windows.Forms.Button btnCancel;
    }
}