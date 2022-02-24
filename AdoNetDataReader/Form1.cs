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
        private const string ColId = "CategoryId";
        private const string ColName = "CategoryName";
        private const string ColDescription = "Description";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var connection = new SqlConnection(
                "Data Source=.; Initial Catalog=Northwind; Integrated Security=true;");

            var command = new SqlCommand(
                "select * from Categories", connection);

            connection.Open();

            SqlDataReader dataReader = command.ExecuteReader();

            var categoryList = new List<Category>();

            while (dataReader.Read())
            {
                var category = new Category()
                {
                    // Null check işlemini satır içinde TERNARY kullanarak bu şekilde yapabilirim
                    Id = dataReader[ColId] != DBNull.Value ? (int)dataReader[ColId] : default,
                    Name = dataReader[ColName] != DBNull.Value ? (string)dataReader[ColName] : default,
                    Description = dataReader[ColDescription] != DBNull.Value ? (string)dataReader[ColDescription] : default
                };

                categoryList.Add(category);
            }

            dataReader.Close();

            connection.Close();
            connection.Dispose();
        }
    }
}
