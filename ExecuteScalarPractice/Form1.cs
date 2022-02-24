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

namespace ExecuteScalarPractice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetCategoryNames_Click(object sender, EventArgs e)
        {
            var connection = new SqlConnection("Server=.; Database=Northwind; Integrated Security=true;");

            var command = new SqlCommand();
            command.Connection = connection;
            command.Connection.Open();

            command.CommandText = "select COUNT(0) from Categories";

            var rowCount = (int)command.ExecuteScalar();

            for (int i = 0; i < rowCount; i++)
            {
                command.CommandText = @$"
select
    CategoryName
from Categories
where CategoryID = {i + 1}";

                var result = command.ExecuteScalar();
                if (result != null) // Null check
                {
                    var categoryName = (string)result;
                    cmbCategories.Items.Add(categoryName);
                }

            }
            command.Connection.Close();
            connection.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
