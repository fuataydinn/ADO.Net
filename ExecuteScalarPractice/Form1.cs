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
        private int counter=0;
        //Butona bastığımız an combobox datasourcuna bu değerler gidecek.
        private void btnGetCategoryName_Click(object sender, EventArgs e)
        {
            if (counter>=1)
            {
                cmbCategories.Items.Clear();
            }
            SqlConnection connection = new SqlConnection();

            connection.ConnectionString = "Server=.;Database=NorthwindEnglish;Integrated Security=true";

            SqlCommand command = new SqlCommand();

            command.Connection = connection;

            connection.Open();//Bir open açtığında birden fazla kod çalıştırılabilir

            //* gibi bir şeylerin yerine geçen ifadelere WildCard (Vahşi Kart) deniliyor. Genel bir ifade.
            command.CommandText =  "Select Count(*) From Categories";

            //Count  da olsa bir değer döndüreceği için bir değer döndürecek
            int categoryCount=(int)command.ExecuteScalar();//Döngüyü dinamik hale getiriyor

            for (int i = 1; i < categoryCount; i++)
            {
                command.CommandText = $@"
Select CategoryName 
From Categories where CategoryID={i}
";
                var result = command.ExecuteScalar();//Sonuç null dönebilir diye ilk önce kontrol edecek. Mesela beş numraya gitti ama o numarada kategori yoksa null olarak işaretlencek.
              
                if (result!=null)//Null Check
                {
                    cmbCategories.Items.Add(result);
                } 
            }
            counter=counter+1;
            connection.Close();
            connection.Dispose();
        }
    }
}
