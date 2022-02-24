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
    public partial class CategoryCreateForm : Form
    {
        public CategoryCreateForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var connection = new SqlConnection()
            {
                ConnectionString = "Data Source=.; Initial Catalog=Northwind; Integrated Security=SSPI"
            };

            try
            {
                var command = new SqlCommand();

                command.CommandText = @$"
insert into Categories (CategoryName, Description)
values (@categoryName, @description)";

                command.Parameters.AddWithValue("@categoryName", txtCategoryName.Text.Trim());
                command.Parameters.AddWithValue("@description", txtDescription.Text.Trim());

                command.Connection = connection;

                connection.Open();

                // ExecuteNonQuery metodu int tipinde bir değer döndürür
                // Bu değer, yürütülen SQL komutu sonucunda etkilenen satır sayısının (rows affected)
                // değeridir
                var rowsAffected = command.ExecuteNonQuery();

                connection.Close();

                MessageBox.Show($"Toplam {rowsAffected} satır kaydedildi");

                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata meydana geldi;\n\r" + ex.Message);
            }
            // try-catch-finally
            // finally bloğu; try-catch yapısında ister try bölümü başarıyla tamamlansın, ister
            // bir hatadan (Exception) dolayı catch bloğu yürütülsün, tüm işlemlerin sonunda
            // mutlaka ama mutlaka çalıştırılacak olan bir bölümdür
            finally
            {
                connection.Dispose();
            }

            // finally içerisindeki kod ile bu alt satırda yer alan kodlar aynı şekilde
            // çalıştırılmaz mı?

            // finally bloğu, metot try veya catch bloğunda return edilse bile mutlaka ama mutlaka
            // çalıştırılıyor. Bu sebeple özellikle hassas nesnelerin (SqlConnection gibi) Dispose
            // edilmesi mutlaka finally {} bloğu içerisinde yapılmalıdır!
            txtCategoryName.Clear();
            txtDescription.Clear();
        }
    }
}
