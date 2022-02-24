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
    public partial class CategoryGridForm : Form
    {
        public CategoryGridForm()
        {
            InitializeComponent();
        }

        private void CategoryGridForm_Load(object sender, EventArgs e)
        {
            // using bloğu; try-finally kullanımının pratik bir yazım şeklidir
            // using parantezleri () içerisinde oluşturduğunuz instance, scope (süslü parantez)
            // tamamlandığında gizli bir finally bloğu içerisinde Dispose edilecektir

            // Biz using bloğu içerisinde instance'lanan nesneyi artık kendimiz Dispose yapmayacağız

            // using bloğunda yalnızca Dispose edilebilir (IDisposable interface'ini implement etmiş)
            // sınıfların instance'ı kullanılabilir
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = "Server = .; Database = Northwind; Integrated Security = true;";

                var command = new SqlCommand();
                command.CommandText = "select * from Categories";
                command.Connection = connection;

                try
                {
                    var categoryList = new List<Category>();

                    connection.Open();
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            // Bu yaptığım işleme Data Mapping adı veriliyor
                            var category = new Category()
                            {
                                Id = (int)dataReader["CategoryID"],
                                Name = (string)dataReader["CategoryName"],
                                Description = dataReader["Description"] != DBNull.Value
                                    ? (string)dataReader["Description"]
                                    : default
                            };

                            categoryList.Add(category);
                        }
                    }
                    connection.Close();

                    grdCategories.DataSource = categoryList;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata meydana geldi;\n\r" + ex.Message);
                }
            }


            // Proje derlendiğinde yukarıdaki using bloğu aşağıdakine benzer bir koda dönüştürülür

            //var connection = new SqlConnection();
            //try
            //{
            //    // işlemler
            //}
            //finally
            //{
            //    connection.Dispose();
            //}
        }

        private void grdCategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // e nesnesi bana şu an gerçekleşen Event ile ilgili ek bilgileri gönderiyor
            // Şu an metodunu yazdığım Event "tablonun hücresine çift tıklandığı an" event'i olduğu için
            // bana e nesnesinden hücrenin satır index'i gönderiliyor

            // O satır index'ini kullanarak grid'in hangi satırına tıklanmış onu bulabilirim
            var clickedRow = grdCategories.Rows[e.RowIndex];
            var idCell = clickedRow.Cells["colCategoryId"];
            var categoryId = (int)idCell.Value;

            var updateForm = new CategoryUpdateForm(categoryId);
            updateForm.MdiParent = MdiParent;
            updateForm.Show();
            
        }
    }
}
