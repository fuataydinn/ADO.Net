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
    public partial class ProductGridForm : Form
    {
        public ProductGridForm()
        {
            InitializeComponent();

            grdProducts.AutoGenerateColumns = false;
        }

        private void ProductGridForm_Load(object sender, EventArgs e)
        {
            var productList = new List<Product>();

            using (var sqlConnection = DbConnectionFactory.Create())
            using (var sqlCommand = DbCommandFactory.Create(sqlConnection))
            {
                sqlCommand.CommandText = "select * from Products";

                sqlConnection.Open();

                using (var dbReader = sqlCommand.ExecuteReader())
                {
                    while (dbReader.Read())
                    {
                        productList.Add(new Product()
                        {
                            Id = (int)dbReader["ProductID"],
                            Name = (string)dbReader["ProductName"],
                            CategoryId = dbReader["CategoryID"] != DBNull.Value ? (int)dbReader["CategoryID"] : default,
                            SupplierId = dbReader["SupplierID"] != DBNull.Value ? (int)dbReader["SupplierID"] : default,
                            QuantityPerUnit = dbReader["QuantityPerUnit"] != DBNull.Value ? (string)dbReader["QuantityPerUnit"] : default,
                            UnitPrice = dbReader["UnitPrice"] != DBNull.Value ? (decimal)dbReader["UnitPrice"] : default,
                            UnitsInStock = dbReader["UnitsInStock"] != DBNull.Value ? (short)dbReader["UnitsInStock"] : default,
                            UnitsOnOrder = dbReader["UnitsOnOrder"] != DBNull.Value ? (short)dbReader["UnitsOnOrder"] : default,
                            ReorderLevel = dbReader["ReorderLevel"] != DBNull.Value ? (short)dbReader["ReorderLevel"] : default,
                            Discontinued = dbReader["Discontinued"] != DBNull.Value ? (bool)dbReader["Discontinued"] : default
                        });
                    }
                }

                sqlConnection.Close();
            }

            grdProducts.DataSource = productList;
        }
    }
}
