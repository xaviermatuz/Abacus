using MongoDB.Bson;
using MongoDB.Driver;
using Abacus.Principal;
using System;
using System.Windows;

namespace Abacus
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //By default for a local MongoDB instance connectionString = "mongodb://localhost:27017" 
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("Abacus");
        public MainWindow()
        {
            InitializeComponent();
        }

        //Valida el serial dado
        private void Validar(object sender, RoutedEventArgs e)
        {
            try
            {
                var collection = db.GetCollection<BsonDocument>("Clientes");
                var filter = Builders<BsonDocument>.Filter.Eq("Serial", txtPassword.Text);
                var serial = collection.Find(filter).First();
                var result = serial.ToBsonDocument().GetElement(2).Value;
                //var filter = Builders<BsonDocument>.Filter.Eq("Serial", txtPassword);
                //var serial = collection.Find(filter);
                if (txtPassword.Text == result.ToString())
                {
                    VentanaPrincipal VentanaPrincipal = new VentanaPrincipal();
                    VentanaPrincipal.Show();
                    MainWindow mainWindow = this;
                    mainWindow.Close();
                }
                else if (txtPassword.Text == "")
                {
                    MessageBox.Show("El campo Serial no puede estar vacio", "Excepcion", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    Console.WriteLine($"Exception: '{txtPassword.ToString()}' is not a valid Guid!");
                }
            }
            //catch (System.Exception message)
            catch (Exception ex)
            {
                MessageBox.Show("Una excepcion a ocurrido: " + ex.Message, "Excepcion", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
