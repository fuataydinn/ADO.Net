
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
            this.btnGetCategoryName = new System.Windows.Forms.Button();
            this.cmbCategories = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnGetCategoryName
            // 
            this.btnGetCategoryName.Location = new System.Drawing.Point(132, 119);
            this.btnGetCategoryName.Name = "btnGetCategoryName";
            this.btnGetCategoryName.Size = new System.Drawing.Size(121, 26);
            this.btnGetCategoryName.TabIndex = 0;
            this.btnGetCategoryName.Text = "Kategorileri Ekle";
            this.btnGetCategoryName.UseVisualStyleBackColor = true;
            this.btnGetCategoryName.Click += new System.EventHandler(this.btnGetCategoryName_Click);
            // 
            // cmbCategories
            // 
            this.cmbCategories.FormattingEnabled = true;
            this.cmbCategories.Location = new System.Drawing.Point(132, 79);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Size = new System.Drawing.Size(121, 23);
            this.cmbCategories.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbCategories);
            this.Controls.Add(this.btnGetCategoryName);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetCategoryName;
        private System.Windows.Forms.ComboBox cmbCategories;
    }
}

