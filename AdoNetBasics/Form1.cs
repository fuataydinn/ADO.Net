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
        private void Form1_Load_1(object sender, EventArgs e)
        {
            //ADO(.NET ÖNCESİ)
            //Active Data objects 
            //Ado .Net(.NET SONRASI)
        }

        private void btnReadCategory_Click(object sender, EventArgs e)
        {
            //MsSql veritabanına bağlantı kurmak için bu sınıfı kullanırım.
            SqlConnection connection = new SqlConnection();

            //connection.ConnectionString = "";
            //ConnectionString=>bağlantı cümlesi/adresi
            //Sunucu,Veri tabanı,Kullanıcı adı ve şifre bilgilerini ConnectionString ile bildiririz.(Genel İfade )

            //Integrated Security=true=>Windows authentication bağlantı oluğunu ifade ediyor.
            //Normalde biz user ve password diyerek giriş yaparken bunların yerine Integrated Security=true kullandık.
            //connection.ConnectionString="Server=DESKTOP-MTRU3O2;Database=Northwind;User Id=Kullanıcı Adı;Password="Sifre"

            //Soldakiler Standart Okuma

            //Server <=> Data Source
            //Database<=>Initial Catalog
            //Integrated Security<=>Trusted_Connection
            //User Id <=> Uid
            //Password<=> Pwd

            //Port=>1433(Eğer standart porttan farklı bir noktasına bağlanmamız gerektiyse,ip adresinin yanına virgülle port numarasını yazcaz.)
            //connection.ConnectionString = "Server=123.23.32.45,1453;Database=Northwind;User Id=Kullanıcı Adı;Password=Şifre";

            //. local sunucu olduğunu söyler.

            connection.ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Northwind;Integrated Security=true";

            //Ctrl+Shift+v kopyalama geçmişini getirir.

            //Sql sorgu veya komutlarını(Select,insert,update,delete ve niceleri) SqlCommand nesnesi ile çalıştırırız(execute)

            //QUERY
            //ExecuteScalar()=>tek değer döndürecek sorguyu(query) yürüt.
            //ExecuteReader()=>tabular veri döndürecek sorguyu(query) yürüt.

            //COMMAND
            //ExecuteNonQuery()=>sorgu dışındaki komutları(command) yürüt(insert,update,delete)
            //Bu sorgudan kaç tane kayıt etkilendiyse bunun sonucunu int olarak bize döndürür.

            //CRUD

            //Create   insert
            //Read     select
            //Update   update
            //Delete   delete

            //---------------------------------------------
            //QUERY(Veriyi Okuma)         COMMAND(Veriyi Manipüle Etme,Manuplation)

            //Read(Select)                 //Create(insert)
            //Update(Update)
            //Delete(delete)

            SqlCommand command = new SqlCommand();
            command.Connection = connection;//Benim kodumu git şu adresden yönet dedik.
                                            //Bu komut ne iş yapacağını da bilmeli
            command.CommandText = $@"
Select CategoryName 
from Categories 
where CategoryID={numCategoryID.Value}";//Dinamik Şekilde Veri Tabanından değerimizi getirdik.
                                        //Normalde üç dört gibi değerler yazıyorduk.

            connection.Open();//Connection ı açtık

            //Scalar =>tekil değer
            //Sql sorgusunun tek değer gönderdiği durumlarda ExecuteScalar metodu kullanılır.
            //Hangi değer döneceği belli olmadığı için object içine alınarak geri dönüş sağlanıyor.
            string categoryName = (string)command.ExecuteScalar();
            //ExecuteScalar yazdığımız kodu tetikler ve çalışmasını sağlar. CommandText propertysi ile bir haberleşme içinde.

            connection.Close();//Connection ı kapattık. Open kalırsa ram şişer. C# bunu yönetmiyor. Normalde Managed Code bir dil olmasına rağmen.

            connection.Dispose();//İşin connection ile tamamen bittiğinde nesneyi Dispose et.

            //Dispose=>Nesnenin memory'den (Ram'den) temizlenmesi greektiğini açıkça sisteme (sistem=>dotnet runtime) bildirmek . Bu null duruma düşürmüyor ama ,farklı.

            MessageBox.Show(categoryName);
        }
    }
}
