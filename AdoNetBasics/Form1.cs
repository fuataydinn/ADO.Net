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

namespace AdoNetBasics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnReadCategory_Click(object sender, EventArgs e)
        {
            // MsSql veritabanına bağlantı kurmak için bu sınıfı kullanırım
            SqlConnection connection = new SqlConnection();

            // ConnectionString => Bağlantı cümlesi/adresi
            // Sunucu, Veritabanı, Kullanıcı adı ve şifre bilgilerini ConnectionString ile bildiririz
            // Integrated Security=true demek, ben veritabanına Windows Authentication ile bağlanacağım
            // anlamına geliyor

            //connection.ConnectionString = "Server=.; Database=Northwind; User Id=KullanıcıAdı; Password=Şifren";

            // Data Source <=> Server
            // Initial Catalog <=> Database
            // Integrated Security <=> Trusted_Connection
            // User Id <=> Uid
            // Password <=> Pwd
            // Port => 1433 (Eğer standart porttan farklı bir port noktasına bağlanmanız gerektiyse)
            //connection.ConnectionString = "Data Source=123.23.32.45,1453; Initial Catalog=Northwind; User Id=KullanıcıAdı; Password=Şifren";

            connection.ConnectionString = "Server=.; Database=Northwind; Integrated Security=true;";

            // Sql sorgu veya komutlarını (select, insert, update, delete ve niceleri)
            // SqlCommand nesnesi ile çalıştırırız (execute)

            // QUERY
            // ExecuteScalar() => tek değer döndürecek sorguyu (query) yürüt
            // ExecuteReader() => tabular veri döndürecek sorguyu (query) yürüt

            // COMMAND
            // ExecuteNonQuery() => sorgu dışındaki komutları (command) yürüt (insert, update, delete)

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = $@"
select CategoryName 
from Categories
where CategoryID = {numCategoryId.Value}";

            connection.Open(); // Bağlantıyı aç

            // Scalar => Tekil değer
            // Sql sorgusunun tek değer gönderdiği durumlarda ExecuteScalar metodu kullanılır
            string categoryName = (string)command.ExecuteScalar();

            connection.Close(); // Bağlantıyı kapat

            connection.Dispose(); // İşin connection ile tamamen bittiğinde nesneyi Dispose et
            // Dispose => Nesnenin memory'den (RAM'den) temizlenmesi gerektiğini açıkça sisteme
            // (sistem => dotnet runtime) bildirmek

            MessageBox.Show(categoryName);
        }
    }
}
