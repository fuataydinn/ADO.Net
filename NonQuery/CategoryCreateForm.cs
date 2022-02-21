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
            //Degiskennin (var connection )tanımını en dısa aldık... try,catch ve finally butun scopeler erisebilsin diye
            //Finally kod calıssa da calısmasa da bu scope calısır.
            var connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=Northwind;Integrated Security=true");
            try
            {
                var command = new SqlCommand();
                command.CommandText = @$"
insert into Categories(CategoryName,Description)
values(@categoryName , @description)";

                command.Parameters.AddWithValue("@categoryName", txtCategoryName.Text.Trim());
                command.Parameters.AddWithValue("@description", txtDescription.Text.Trim());
                command.Connection = connection;

                connection.Open();
                //ExecuteNonQuery metodu int tipinde bir deger dondurur.
                //Bu deger, yürütülen Sql komutu sonucunda etkilenen satır sayısının (rows affected) degeridir.
                var rowsAffected = command.ExecuteNonQuery();

                connection.Close();
                connection.Dispose();

                MessageBox.Show($"Toplam {rowsAffected} satır kaydedildi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata meydana geldi ; \n\r" + ex.Message);
            }
            finally
            {
                connection.Dispose();
            }

            txtCategoryName.Clear();
            txtDescription.Clear();

        }
    }
}
