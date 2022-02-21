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
        //Sadece 1 tane categoryForm acılsın diye asagıda field tanımladık.
        //Field'ın instance'ını aldık -- 1 kere oldu bu sayede
        private CategoryCreateForm _categoryCreateForm; //Field nesne ile yasamaya devam eder .!
        private CategoryGridForm _categoryGridForm;
        public MainForm()
        {
            InitializeComponent();
        }

        private void menuItemNewCategory_Click(object sender, EventArgs e)
        {
            if (_categoryCreateForm==null)
            {
                _categoryCreateForm = new CategoryCreateForm();
                //Property de true yaptık bu degeri. Form içinde oldu bu sefer(IsMdi)
                _categoryCreateForm.MdiParent = this;
                _categoryCreateForm.Show();

                //Kapatma durumunda event'ı yakala ve asagıdaki metodunda temizle field icini-- if sartını tekrar saglamak ıcın.
                _categoryCreateForm.FormClosed += _categoryCreateForm_FormClosed; 
            }
          
        }
        private void _categoryCreateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _categoryCreateForm.MdiParent = null; //ana tasıyıcıya artık bu senın cocugun degıl dedık
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

                _categoryGridForm.FormClosed += _categoryGridForm_FormClosed;
            }
        }
        private void _categoryGridForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _categoryGridForm.MdiParent = null;
            _categoryGridForm.Dispose();
            _categoryGridForm = null;
        }
    }
}
