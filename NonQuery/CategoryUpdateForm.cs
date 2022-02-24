using NonQuery.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NonQuery
{
    public partial class CategoryUpdateForm : Form
    {
        private int _categoryId;

        public CategoryUpdateForm(int categoryId)
        {
            InitializeComponent();

            _categoryId = categoryId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // HAP BİLGİ
            // Eğer IDisposable interface'ini implement etmiş sınıftan siz instance
            // alıyorsanız mutlaka o nesneyi işiniz bitince Dispose edin
            using (var connection = DbConnectionFactory.Create())
            using (var command = DbCommandFactory.Create(connection))
            {
                var category = CreateCategoryFromInputs();

                command.CommandText = @"
update Categories
set
    CategoryName = @categoryName,
    Description = @description
where CategoryID = @categoryId";

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
                    MessageBox.Show("Bir hata meydana geldi!!\n\r" + ex.Message);
                }
            }
        }

        private Category CreateCategoryFromInputs()
        {
            var category = new Category()
            {
                Id = _categoryId,
                Name = txtCategoryName.Text.Trim(),
                Description = txtDescription.Text.Trim()
            };

            return category;
        }

        private void CategoryUpdateForm_Load(object sender, EventArgs e)
        {
            // Elimde Id değeri var
            // Bu id değerine göre Kategori nesnesini veritabanından okuyup
            // form inputlarını dolduruyorum
            Category category = default;
            //var category = default(Category);

            using (var connection = DbConnectionFactory.Create())
            using (var command = DbCommandFactory.Create(connection))
            {
                command.CommandText = @"
select
    CategoryID as Id,
    CategoryName as Name,
    Description
from Categories
where CategoryID = @categoryId";
                command.Parameters.AddWithValue("@categoryId", _categoryId);

                try
                {
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            category = new Category()
                            {
                                Id = (int)reader["Id"], // Tablo kolonu değil, sorgudaki result set kolon adı önemli
                                Name = (string)reader["Name"],
                                Description = reader["Description"] != DBNull.Value
                                    ? (string)reader["Description"]
                                    : default
                            };
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata meydana geldi!\n\r" + ex.Message);
                }
            }

            if (category != null)
            {
                lblCategoryId.Text = category.Id.ToString();
                txtCategoryName.Text = category.Name;
                txtDescription.Text = category.Description;
            }
        }
    }
}
