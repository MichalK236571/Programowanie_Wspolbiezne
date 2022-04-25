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
using ViewModel;

namespace View
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window


    {    
        VMClass vmclass = new VMClass();
        public MainWindow()
        {
            //InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Start_Button(object sender, RoutedEventArgs e)
        {
            int amount = 10;
           // vmclass.Start(amount);
        }

        private void Stop_Button(object sender, RoutedEventArgs e)
        {
            //vmclass.Stop();
        }
    }
}