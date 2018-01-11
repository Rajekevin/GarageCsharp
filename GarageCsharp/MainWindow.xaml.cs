using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GarageCsharp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ajouter_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cnx = new SqlConnection(
              @"Data Source=<nomduserveur>; Initial Catalog=<nomdelatable>;  integrated security=True"
              );
              cnx.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Voiture VALUES (@marque)";
            cmd.Connection = cnx;

            int result = cmd.ExecuteNonQuery();
            SqlCommand command = cnx.CreateCommand();
            SqlDataReader dateReader = command.ExecuteReader();
            while (dateReader.Read())
            {
                string marque = (string)dateReader["marque"];
                listView.Items.Add(marque);
               
            }

            cnx.Close();
        }


        private void btnImport_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == true)
            {
                imgVoiture.Source = new BitmapImage(new Uri(ofd.FileName));
                imgVoiture.Stretch = Stretch.Fill;
            }

        }

    }
}
