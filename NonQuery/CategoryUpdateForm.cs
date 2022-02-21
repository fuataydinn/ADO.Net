using NonQuery.Entities;
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
    public partial class CategoryUpdateForm : Form
    {
        private int _categoryId;  //constructor ile bu id'deki degeri bana getir guncelliyim
        public CategoryUpdateForm(int categoryId)
        {
            InitializeComponent();
            _categoryId = categoryId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Eger IDisposable interface'ini implement etmiş sınıftan siz
            // instance alıyorsanız mutlaka o nesneyi işiniz nitince Dispose edin
            using(var connection = DbConnectionFactory.Create())
            using(var command=DbCommandFactory.Create(connection))
            {
                var category = CreateCategoryFromInputs();

                command.CommandText = @"update Categories
set 
    CategoryName=@categoryName,
    Description=@description
where CategoryID=@categoryId";

                command.Parameters.AddWithValue("@categoryName", category.Name);
                command.Parameters.AddWithValue("@description", category.Description);
                command.Parameters.AddWithValue("@categoryId", category.Id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Kayıt başarıyla güncellendi");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata meydana geldi!!\n\r"+ex.Message);
                }
            }          
        }

        private Category CreateCategoryFromInputs()
        {
            var category = new Category()
            {
                Id=_categoryId,
                Name = txtCategoryName.Text.Trim(),
                Description = txtDescription.Text.Trim()
            };
            return category;
        }

        private void CategoryUpdateForm_Load(object sender, EventArgs e)
        {
            //Elimde Id degeri var 
            //Bu id degerine gore Kategori nesnesini veritabanından okuyup
            //form imputlarını doldururuyorum
        }
    }
}
