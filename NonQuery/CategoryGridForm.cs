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
            //using blogu : try-finally kullanımının pratik bir yazım seklidir
            //using blogu icerisinde instance'lanan nesneyi artık kendimiz Dispose yapmıyıcaz
            //İcinde cath blogu yok--- exeption yakalamak istiyorsak icine try-cath tanımlamalıyız
            //Using'te sadece Dispose edilenlerde kullanılabilir !! 
            using(var connection = new SqlConnection())
            {
                connection.ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Northwind;Integrated Security=true";

                var command = new SqlCommand();
                command.CommandText = "select*from Categories";
                command.Connection = connection;

                try
                {
                    var categoryList = new List<Category>();

                    connection.Open();
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            //Bu yaptıgım isleme Data Mapping adı verilir.
                            //ORM Object Relational Mapping
                            //EntityFramework
                            //nHibernate
                            //Dapper (Data Mapper, Dotnet Mapper)
                            var category = new Category()
                            {
                                Id=(int)dataReader["CategoryID"],
                                Name=(string)dataReader["CategoryName"],
                                Description=dataReader["Description"] !=DBNull.Value ? (string)dataReader["Description"]:default
                            };

                            categoryList.Add(category);
                        }
                    }
                    connection.Close();

                    grdCategories.DataSource = categoryList;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata meydana geldi ; \n\r"+ex.Message);
                }
              
            }       
            //Yukarıdaki usingte asagdaki gibi kod calısıyor
            //var connection = new SqlConnection();
            //try
            //{

            //}
            //finally
            //{

            //}
        }

        private void grdCategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //e nesnesi bana suan gerceklesen Event ile ilgili ek bilgileri gonderiyor
            //Suan metodunu yazdıgım Event "tablonun hücresine çift tıklandıgında" Event'i oldugu icin bana e nesnesinin hücresinin satır
            //index'i gonderiliyor.
            //O satır index'ini kullanarak grid'in hangi satırına tıklanmıs onu bulabilirim
            var clickedRow = grdCategories.Rows[e.RowIndex];
            var idCell = clickedRow.Cells["colCategoryId"]; //once satırı bulduk-- sonra hücreyi bulduk
            var categoryId = (int)idCell.Value;

            var updateForm = new CategoryUpdateForm(categoryId);
            updateForm.MdiParent = MdiParent;//Main form bu formun sahibi
            updateForm.Show();
        }
    }
}
