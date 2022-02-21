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

namespace AdoNetDataReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private const string colId = "CategoryID";
        private const string colCategoryName = "CategoryName";
        private const string colDescription = "Description";
        private void Form1_Load(object sender, EventArgs e)
        {
            List<Category> categoryList = new List<Category>();

            //Daha öncden bu nuget yüklendiği için referansını localden getirerek yükleyecek.
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;Trusted_Connection=true");

            SqlCommand command = new SqlCommand("Select*From Categories", connection);


            connection.Open();


            SqlDataReader dataReader = command.ExecuteReader();
            Category category;
            while (dataReader.Read()) //dataReader her seferinde Read ile bir satıra denk gelirse orası için çalışıyor.
            {
                category = new Category()
                {
                    //Adonet te bu şekilde değerin boşmu değil mi bilgisini görebilirim..
                    Id = dataReader[colId] != DBNull.Value ? (int)dataReader[colId] : default,
                    Name = dataReader[colCategoryName] != DBNull.Value ? (string)dataReader[colCategoryName] : default,
                    Description = dataReader[colDescription] != DBNull.Value ? (string)dataReader[colDescription] : default,
                    //Const değerler kullanılmadğı zaman şu şekilde tanım yapabiliriz:Name = (string)dataReader["CategoryName"],
                };

                categoryList.Add(category);

                //Böyle yapınca durmadan üstüne yazacağı için bizim bir liste oluşturmamız gerekecek.
                //var categoryId=(int)dataReader["CategoryID"];
                //var categoryName = (string)dataReader["CategoryName"];
            }

            dataGridView1.DataSource = categoryList;

            dataReader.Close();//Burada dönen Read in kapatılması gerekli

            connection.Close();

            connection.Dispose();

        }


    }
}
