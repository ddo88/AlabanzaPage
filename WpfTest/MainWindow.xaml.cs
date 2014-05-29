using AlabanzaPage.Models;
using System;
using System.Collections.Generic;
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
using WpfTest.Properties;

namespace WpfTest
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
       
       
        public MainWindow()
        {
            InitializeComponent();
            //context = new Context();
            //model   = new ViewModel();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try {

                //model.LoadCanciones();
                //DataContext     = model;                
            }
            catch (Exception ex) {
                int i = 0;
            }
            
        }
    }


    public class ViewModel
    {
        Context context;


        public ViewModel()
        { 
        context = new Context();
        }
        public void LoadCanciones(){
            _canciones = context.GetCollection<Cancion>(Settings.Default.CancionesCollection).FindAll().ToList<Cancion>();
        }
        List<Cancion> _canciones = new List<Cancion>();

        public List<Cancion> Canciones
        {
            get { return _canciones; }
            set { _canciones = value; }
        }

        public Cancion CancionSeleccionada { get; set; }
        
    }
}
