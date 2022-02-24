using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NonQuery
{
    public partial class MainForm : Form
    {
        private CategoryCreateForm _categoryCreateForm;
        private CategoryGridForm _categoryGridForm;
        private ProductGridForm _productGridForm;
        public MainForm()
        {
            InitializeComponent();
        }

        private void menuItemNewCategory_Click(object sender, EventArgs e)
        {
            if (_categoryCreateForm == null)
            {
                _categoryCreateForm = new CategoryCreateForm();
                _categoryCreateForm.MdiParent = this; // 0x1234
                _categoryCreateForm.Show();

                _categoryCreateForm.FormClosed += _categoryCreateForm_FormClosed;
            }
        }

        private void _categoryCreateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _categoryCreateForm.MdiParent = null;
            _categoryCreateForm.Dispose();
            _categoryCreateForm = null;
        }

        private void menuItemAllCategories_Click(object sender, EventArgs e)
        {
            if (_categoryGridForm == null)
            {
                _categoryGridForm = new CategoryGridForm();
                _categoryGridForm.MdiParent = this;
                _categoryGridForm.Show();
                _categoryGridForm.Top = 0;
                _categoryGridForm.Left = 0;

                _categoryGridForm.FormClosed += _categoryGridForm_FormClosed;
            }
        }

        private void _categoryGridForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _categoryGridForm.MdiParent = null;
            _categoryGridForm.Dispose();
            _categoryGridForm = null;
        }

        private void menuItemAllProducts_Click(object sender, EventArgs e)
        {
            if (_productGridForm == null)
            {
                _productGridForm = new ProductGridForm()
                {
                    MdiParent = this,
                    Text = "Tüm ürünler",
                    Left = 0,
                    Top = 0
                };

                _productGridForm.FormClosed += _productGridForm_FormClosed;
                _productGridForm.Show();
            }
        }

        private void _productGridForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _productGridForm.Dispose();
            _productGridForm = null;
        }

        private void menuItemNewProduct_Click(object sender, EventArgs e)
        {
            var productCreateForm = new ProductCreateForm();
            productCreateForm.MdiParent = this;
            productCreateForm.Show();
        }
    }
}
