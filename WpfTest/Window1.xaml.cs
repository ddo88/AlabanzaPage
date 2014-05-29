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
using System.Windows.Shapes;
using WpfTest.Properties;

namespace WpfTest
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    /// 

    public partial class Window1 : Window
    {
        //readonly Context context = new Context();
        ViewModel model;
        bool sw = false;
        public Window1()
        {
            InitializeComponent();
            //
            model = new ViewModel();
            //Task.Factory.StartNew(() => { model.LoadCanciones(); });
            this.Loaded += Window_Loaded;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                model.LoadCanciones();
                DataContext = model;
            }
            catch (Exception ex)
            {
                int i = 0;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!sw)
            {
                Canciones.ItemTemplate = (DataTemplate)Resources["Complex"];
                sw = true;
            }
            else
            {
                Canciones.ItemTemplate = (DataTemplate)Resources["Simple"];
                sw = false;
            }
            
        }
    }
}
