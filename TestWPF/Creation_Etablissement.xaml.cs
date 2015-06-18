using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestWPF.MyGstConduite;

namespace TestWPF
{
    /// <summary>
    /// Logique d'interaction pour Creation_Etablissement.xaml
    /// </summary>
    public partial class Creation_Etablissement : Window
    {
        private MyGstConduiteWS _managerWS = null;
        MaskedTextBox mtb_tb_r016_dateValiditeAgrement = null;
        public Creation_Etablissement(MyGstConduiteWS p_managerWS)
        {
            InitializeComponent();
            _managerWS = p_managerWS;
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
         {
            Etablissement l_etablissement = new Etablissement();

            l_etablissement.r001_nom = tb_r001_nom.Text;
            l_etablissement.r002_rue = tb_r002_rue.Text;
            l_etablissement.r003_cp = tb_r003_cp.Text;
            l_etablissement.r004_ville = tb_r004_ville.Text;
            l_etablissement.r005_mel = tb_r005_mel.Text;
            l_etablissement.r006_telephone = tb_r006_telephone.Text;
            l_etablissement.r007_fax = tb_r007_fax.Text;
            l_etablissement.r008_codeAPE = tb_r008_codeAPE.Text;
            l_etablissement.r009_numeroSIREN = tb_r009_numeroSIREN.Text;
            l_etablissement.r010_numeroIdentification = tb_r010_numeroIdentification.Text;
            l_etablissement.r011_registreCommerce = tb_r011_registreCommerce.Text;
            l_etablissement.r013_formeJuridiqueCapital = tb_r013_formeJuridiqueCapital.Text;
            l_etablissement.r015_numeroTvaIntra = tb_r015_numeroTvaIntra.Text;
            l_etablissement.r016_dateValiditeAgrement = DateTime.Parse(mtb_tb_r016_dateValiditeAgrement.Text);
            l_etablissement.r014_dureeLecon = "01:00:00";
            try
            {
                _managerWS.AjouterEtablissement(l_etablissement);
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            
           
        }

       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mtb_tb_r016_dateValiditeAgrement = new MaskedTextBox("00/00/0000");
            mtb_tb_r016_dateValiditeAgrement.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // Assign the MaskedTextBox control as the host control's child.
            WindowsMTBdateValiditeAgrement.Child = mtb_tb_r016_dateValiditeAgrement;

        }
    }
}
