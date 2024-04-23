
using System;

namespace algo_project_CSHARP
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        
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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.CalculateConvexHullButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.typeOfConvexHullSolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jarvisMarchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grahamScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grahamscanbutton = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.stackPictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stackPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // CalculateConvexHullButton
            // 
            this.CalculateConvexHullButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CalculateConvexHullButton.Image = ((System.Drawing.Image)(resources.GetObject("CalculateConvexHullButton.Image")));
            this.CalculateConvexHullButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CalculateConvexHullButton.Location = new System.Drawing.Point(901, 513);
            this.CalculateConvexHullButton.Margin = new System.Windows.Forms.Padding(4);
            this.CalculateConvexHullButton.Name = "CalculateConvexHullButton";
            this.CalculateConvexHullButton.Size = new System.Drawing.Size(163, 42);
            this.CalculateConvexHullButton.TabIndex = 1;
            this.CalculateConvexHullButton.Text = "Generate JarvisMarch";
            this.CalculateConvexHullButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CalculateConvexHullButton.UseVisualStyleBackColor = true;
            this.CalculateConvexHullButton.Click += new System.EventHandler(this.CalculateConvexHullButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(4, 36);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1057, 470);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.typeOfConvexHullSolutionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1064, 34);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // typeOfConvexHullSolutionToolStripMenuItem
            // 
            this.typeOfConvexHullSolutionToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.typeOfConvexHullSolutionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jarvisMarchToolStripMenuItem,
            this.grahamScanToolStripMenuItem});
            this.typeOfConvexHullSolutionToolStripMenuItem.Font = new System.Drawing.Font("Trebuchet MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeOfConvexHullSolutionToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.typeOfConvexHullSolutionToolStripMenuItem.Name = "typeOfConvexHullSolutionToolStripMenuItem";
            this.typeOfConvexHullSolutionToolStripMenuItem.Size = new System.Drawing.Size(296, 30);
            this.typeOfConvexHullSolutionToolStripMenuItem.Text = "Type of Convex Hull Solution";
            this.typeOfConvexHullSolutionToolStripMenuItem.Click += new System.EventHandler(this.typeOfConvexHullSolutionToolStripMenuItem_Click);
            // 
            // jarvisMarchToolStripMenuItem
            // 
            this.jarvisMarchToolStripMenuItem.Name = "jarvisMarchToolStripMenuItem";
            this.jarvisMarchToolStripMenuItem.Size = new System.Drawing.Size(222, 30);
            this.jarvisMarchToolStripMenuItem.Text = "Jarvis March";
            this.jarvisMarchToolStripMenuItem.Click += new System.EventHandler(this.jarvisMarchToolStripMenuItem_Click);
            // 
            // grahamScanToolStripMenuItem
            // 
            this.grahamScanToolStripMenuItem.Name = "grahamScanToolStripMenuItem";
            this.grahamScanToolStripMenuItem.Size = new System.Drawing.Size(222, 30);
            this.grahamScanToolStripMenuItem.Text = "Graham Scan";
            this.grahamScanToolStripMenuItem.Click += new System.EventHandler(this.grahamScanToolStripMenuItem_Click);
            //
            // grahamscanbutton
            // 
            this.grahamscanbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grahamscanbutton.Image = ((System.Drawing.Image)(resources.GetObject("grahamscanbutton.Image")));
            this.grahamscanbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.grahamscanbutton.Location = new System.Drawing.Point(901, 511);
            this.grahamscanbutton.Margin = new System.Windows.Forms.Padding(4);
            this.grahamscanbutton.Name = "grahamscanbutton";
            this.grahamscanbutton.Size = new System.Drawing.Size(163, 42);
            this.grahamscanbutton.TabIndex = 5;
            this.grahamscanbutton.Text = "Generate GrahamScan";
            this.grahamscanbutton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.grahamscanbutton.UseVisualStyleBackColor = true;
            this.grahamscanbutton.Click += new System.EventHandler(this.grahamscanbutton_Click);
            // 
            // Reset
            // 
            this.Reset.AllowDrop = true;
            this.Reset.AutoSize = true;
            this.Reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reset.Image = ((System.Drawing.Image)(resources.GetObject("Reset.Image")));
            this.Reset.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Reset.Location = new System.Drawing.Point(657, 512);
            this.Reset.Margin = new System.Windows.Forms.Padding(4);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(151, 41);
            this.Reset.TabIndex = 6;
            this.Reset.Text = "Reset Points";
            this.Reset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // stackPictureBox
            // 
            this.stackPictureBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.stackPictureBox.Location = new System.Drawing.Point(657, 41);
            this.stackPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.stackPictureBox.Name = "stackPictureBox";
            this.stackPictureBox.Size = new System.Drawing.Size(405, 463);
            this.stackPictureBox.TabIndex = 7;
            this.stackPictureBox.TabStop = false;
            this.stackPictureBox.Click += new System.EventHandler(this.stackPictureBox_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox2.Location = new System.Drawing.Point(4, 37);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1057, 466);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
            this.pictureBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 554);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.stackPictureBox);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.grahamscanbutton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.CalculateConvexHullButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stackPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void stackPictureBox_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.Button CalculateConvexHullButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem typeOfConvexHullSolutionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jarvisMarchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grahamScanToolStripMenuItem;
        private System.Windows.Forms.Button grahamscanbutton;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.PictureBox stackPictureBox;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

