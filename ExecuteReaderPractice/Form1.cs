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

namespace ExecuteReaderPractice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            List<Supplier> categoryList = new List<Supplier>();

            //Daha öncden bu nuget yüklendiği için referansını localden getirerek yükleyecek.
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;Trusted_Connection=true");

            SqlCommand command = new SqlCommand("Select*From Suppliers", connection);

            connection.Open();

            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read()) //dataReader her seferinde Read ile bir satıra denk gelirse orası için çalışıyor.
            {
                //const string colId="CategoryID";
                var supplier = new Supplier()
                {
                    //Adonet te bu şekilde değerin boşmu değil mi bilgisini görebilirim.
                    SupplierID = dataReader["SupplierId"] != DBNull.Value ? (int)dataReader["SupplierID"] : default,

                    CompanyName = dataReader["CompanyName"] != DBNull.Value ? (string)dataReader["CompanyName"] : default,

                    ContactName = dataReader["ContactName"] != DBNull.Value ? (string)dataReader["ContactName"] : default,

                    ContactTitle = dataReader["ContactTitle"] != DBNull.Value ? (string)dataReader["ContactTitle"] : default,

                    Address = dataReader["Address"] != DBNull.Value ? (string)dataReader["Address"] : default,

                    City = dataReader["City"] != DBNull.Value ? (string)dataReader["City"] : default,

                    Region = dataReader["Region"] != DBNull.Value ? (string)dataReader["Region"] : default,

                    PostalCode = dataReader["PostalCode"] != DBNull.Value ? (string)dataReader["PostalCode"] : default,

                    Country = dataReader["Country"] != DBNull.Value ? (string)dataReader["Country"] : default,

                    Phone = dataReader["Phone"] != DBNull.Value ? (string)dataReader["Phone"] : default,

                   Fax = dataReader["Fax"] != DBNull.Value ? (string)dataReader["Fax"] : default,

                    HomePage = dataReader["HomePage"] != DBNull.Value ? (string)dataReader["HomePage"] : default,
                };

                categoryList.Add(supplier);

                //Böyle yapınca durmadan üstüne yazacağı için bizim bir liste oluşturmamız gerekecek.
                //var categoryId=(int)dataReader["CategoryID"];
                //var categoryName = (string)dataReader["CategoryName"];
            }

      
            dataGridView1.DataSource = categoryList;

            dataReader.Close();//Burada dönen Readin kapatılması gerekli

            connection.Close();
            connection.Dispose();

        }
    }
}
