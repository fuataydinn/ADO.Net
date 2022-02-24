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
    public partial class ProductCreateForm : Form
    {
        public ProductCreateForm()
        {
            InitializeComponent();
        }

        private void ProductCreateForm_Load(object sender, EventArgs e)
        {
            FillCategoriesComboBox();
            FillSuppliersComboBox();
        }

        private void FillSuppliersComboBox()
        {
            var supplierList = new List<Supplier>();

            using (var connection = DbConnectionFactory.Create())
            using (var command = DbCommandFactory.Create(connection))
            {
                command.CommandText = "select * from Suppliers";

                try
                {
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        // Bu kontrol de yapılabilir
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                supplierList.Add(new Supplier()
                                {
                                    Id = (int)reader["SupplierID"],
                                    Name = (string)reader["CompanyName"],
                                    ContactName = reader["ContactName"] != DBNull.Value ? (string)reader["ContactName"] : default,
                                    //
                                    //
                                    //
                                });
                            }
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tedarikçi kayıtları getirilken bir hata meydana geldi");
                }
            }

            cmbSupplier.DataSource = supplierList;
            cmbSupplier.DisplayMember = "Name";
            cmbSupplier.ValueMember = "Id";
        }

        private void FillCategoriesComboBox()
        {
            var categoryList = new List<Category>();

            using (var connection = DbConnectionFactory.Create())
            using (var command = DbCommandFactory.Create(connection))
            {
                command.CommandText = "select * from Categories";

                try
                {
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var category = new Category()
                            {
                                Id = (int)reader["CategoryID"],
                                Name = (string)reader["CategoryName"],
                                Description = reader["Description"] != DBNull.Value ? (string)reader["Description"] : default
                            };

                            categoryList.Add(category);
                        }
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kategori kayıtları getirilirken bir hata meydana geldi");
                }
            }

            cmbCategory.DataSource = categoryList;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "Id";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var product = GetProductFromInputs();

            using (var connection = DbConnectionFactory.Create())
            using (var command = DbCommandFactory.Create(connection))
            {

                command.CommandText = @"insert into Products
values (@productName, @supplierId, @categoryId, @quantityPerUnit, 
@unitPrice, @unitsInStock, @unitsOnOrder, @reorderLevel, @discontinued)";

                command.Parameters.AddWithValue("@productName", product.Name);

                // Parameters.AddWithValue metodu, value parametresine gönderdiğiniz değerin tipine göre
                // DbType/SqlDbType property'sini otomatik tayin eder

                // Ancak, null geçilebilir bir short, int, long gibi Nullable Value Type için durum
                // biraz farklı cereyan ediyor. Eğer null geçilebilir bir int kolonuna doğrudan null
                // değeri gönderirseniz, Parameters koleksiyonu bu parametrenin DbType/SqlDbType property
                // değerini kendiliğinden String tipinde algılıyor.
                //
                // Bu durumu düzeltmek için DbType/SqlDbType özelliğini manuel set etmek gerekir
                var catIdParam = command.Parameters.AddWithValue(
                    "@categoryId", 
                    product.CategoryId.HasValue ? product.CategoryId.Value : DBNull.Value);
                catIdParam.SqlDbType = SqlDbType.Int;

                var supplierIdParam = command.Parameters.Add("@supplierId", SqlDbType.Int);
                supplierIdParam.Value = product.SupplierId.HasValue 
                    ? product.SupplierId.Value 
                    : DBNull.Value;

                // Extension method olarak yazabiliriz
                //command.Parameters.Add("@supplierId", SqlDbType.Int, product.SupplierId);

                //var supplierIdParam2 = new SqlParameter();
                //supplierIdParam2.ParameterName = "@supplierId";
                //supplierIdParam2.SqlDbType = SqlDbType.Int;
                //supplierIdParam2.Value = product.SupplierId;

                //command.Parameters.Add(supplierIdParam2);

                command.Parameters.AddWithValue("@quantityPerUnit", product.QuantityPerUnit);
                command.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
                command.Parameters.AddWithValue("@unitsInStock", product.UnitsInStock);
                command.Parameters.AddWithValue("@unitsOnOrder", product.UnitsOnOrder);
                command.Parameters.AddWithValue("@reorderLevel", product.ReorderLevel);
                command.Parameters.AddWithValue("@discontinued", product.Discontinued);

                try
                {
                    connection.Open();

                    command.ExecuteNonQuery();

                    connection.Close();

                    ClearForm();
                    MessageBox.Show("Kayıt başarıyla gerçekleşti");
                }
                catch (InvalidCastException castException)
                {
                    MessageBox.Show("Veri dönüştürme hatası");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Sql hatası");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bilinmeyen hata\n\r" + ex.Message);
                }
            }
        }

        private void ClearForm()
        {
            txtProductName.Clear();
            cmbCategory.SelectedItem = null;
            //
            //
        }

        private Product GetProductFromInputs()
        {
            var product = new Product();
            product.Name = txtProductName.Text.Trim();

            if (cmbSupplier.SelectedItem != null)
                product.SupplierId = (int)cmbSupplier.SelectedValue;

            if (cmbCategory.SelectedItem != null)
                product.CategoryId = (int)cmbCategory.SelectedValue;

            product.QuantityPerUnit = txtQuantityPerUnit.Text.Trim();
            product.UnitPrice = numUnitPrice.Value;

            if (!string.IsNullOrWhiteSpace(txtUnitsInStock.Text))
            {
                product.UnitsInStock = short.Parse(txtUnitsInStock.Text.Trim());
            }

            if (!string.IsNullOrWhiteSpace(txtUnitsOnOrder.Text))
            {
                product.UnitsOnOrder = short.Parse(txtUnitsOnOrder.Text.Trim());
            }

            if (!string.IsNullOrWhiteSpace(txtReorderLevel.Text))
            {
                product.ReorderLevel = short.Parse(txtReorderLevel.Text.Trim());
            }

            product.Discontinued = chkDiscontinued.Checked;

            return product;
        }
    }
}
