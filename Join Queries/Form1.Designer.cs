﻿
namespace Join_Queries
{
    partial class Form1
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
            this.PrinttextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // PrinttextBox
            // 
            this.PrinttextBox.Location = new System.Drawing.Point(41, 47);
            this.PrinttextBox.Multiline = true;
            this.PrinttextBox.Name = "PrinttextBox";
            this.PrinttextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PrinttextBox.Size = new System.Drawing.Size(719, 358);
            this.PrinttextBox.TabIndex = 0;
            this.PrinttextBox.TextChanged += new System.EventHandler(this.PrinttextBox_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PrinttextBox);
            this.Name = "Form1";
            this.Text = "Display Titles and Authors Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PrinttextBox;
    }
}

