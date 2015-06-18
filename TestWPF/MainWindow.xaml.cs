using System;
using System.Collections.Generic;
using System.Configuration;
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
using TestWPF.MyGstConduite;

namespace TestWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MyGstConduiteWS _managerWS = null;
        public MainWindow()
        {
            InitializeComponent();
            _managerWS = new MyGstConduiteWS();
            _managerWS.Url = ConfigurationManager.AppSettings["MyGstConduite"];
            RemplirComboBox();
        }

        private void RemplirComboBox()
        {
            cb_Etablissement.ItemsSource = _managerWS.RecupererEtablissement();
            cb_Etablissement.SelectedValuePath = "id_Etablissement";
            cb_Etablissement.DisplayMemberPath = "r001_nom";
            
        }

        private void btn_valider_Click(object sender, RoutedEventArgs e)
        {
            Creation_Etablissement m = new Creation_Etablissement(_managerWS);
            m.Show();
        }
    }
}
