
namespace AdoNetBasics
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
            this.btnReadCategory = new System.Windows.Forms.Button();
            this.numCategoryId = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numCategoryId)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReadCategory
            // 
            this.btnReadCategory.Location = new System.Drawing.Point(195, 81);
            this.btnReadCategory.Name = "btnReadCategory";
            this.btnReadCategory.Size = new System.Drawing.Size(138, 49);
            this.btnReadCategory.TabIndex = 0;
            this.btnReadCategory.Text = "Kategoriyi getir";
            this.btnReadCategory.UseVisualStyleBackColor = true;
            this.btnReadCategory.Click += new System.EventHandler(this.btnReadCategory_Click);
            // 
            // numCategoryId
            // 
            this.numCategoryId.Location = new System.Drawing.Point(148, 39);
            this.numCategoryId.Name = "numCategoryId";
            this.numCategoryId.Size = new System.Drawing.Size(185, 27);
            this.numCategoryId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kategori ID";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numCategoryId);
            this.Controls.Add(this.btnReadCategory);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numCategoryId)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReadCategory;
        private System.Windows.Forms.NumericUpDown numCategoryId;
        private System.Windows.Forms.Label label1;
    }
}

