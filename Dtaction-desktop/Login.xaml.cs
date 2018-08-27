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

namespace Dtaction_desktop
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {           
            var test = RequestWebApi.GetUser(TBUsername.Text, PBPsw.Password.ToString());
            if (test != null)
            {
                LaListe liste = new LaListe();
                liste.Show();
                this.Close();
            }
            else
            {
                EmptyField emptyField = new EmptyField("Username or Password is not valid !");
                emptyField.ShowDialog();
            }
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }
    }
}
