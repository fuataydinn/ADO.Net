
namespace ExecuteScalarPractice
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetCategoryNames = new System.Windows.Forms.Button();
            this.cmbCategories = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetCategoryNames
            // 
            this.btnGetCategoryNames.Location = new System.Drawing.Point(30, 35);
            this.btnGetCategoryNames.Name = "btnGetCategoryNames";
            this.btnGetCategoryNames.Size = new System.Drawing.Size(153, 29);
            this.btnGetCategoryNames.TabIndex = 0;
            this.btnGetCategoryNames.Text = "Kategorileri getir";
            this.btnGetCategoryNames.UseVisualStyleBackColor = true;
            this.btnGetCategoryNames.Click += new System.EventHandler(this.btnGetCategoryNames_Click);
            // 
            // cmbCategories
            // 
            this.cmbCategories.FormattingEnabled = true;
            this.cmbCategories.Location = new System.Drawing.Point(219, 36);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Size = new System.Drawing.Size(211, 28);
            this.cmbCategories.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(679, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbCategories);
            this.Controls.Add(this.btnGetCategoryNames);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetCategoryNames;
        private System.Windows.Forms.ComboBox cmbCategories;
        private System.Windows.Forms.Button button1;
    }
}

