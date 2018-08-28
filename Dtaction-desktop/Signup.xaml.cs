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
using System.Net.Mail;

namespace Dtaction_desktop
{
    /// <summary>
    /// Interaction logic for Signup.xaml
    /// </summary>
    public partial class Signup : Window
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void Button_SignUp_Click(object sender, RoutedEventArgs e)
        {
            string strEMail = textboxEmail.Text;

            bool isMailValid = false;

            try
            {
                var addr = new MailAddress(strEMail);
                //addr.Address == strEMail;
                isMailValid = true;
            }

            catch
            {
                isMailValid = false;
            }

            if (textboxUsername.Text.Trim(' ') != ""
                    && textboxUsername.Text.Length >= 4
                    && textboxUsername.Text.Length <= 20
                    && textboxEmail.Text.Trim(' ') != ""
                    && isMailValid
                    && textboxPassword.Password.ToString() == textboxConfirmationPassword.Password.ToString()
                    && textboxPassword.Password.ToString().Trim(' ') != ""
                    && textboxPassword.Password.ToString().Length >= 6)
            {
                User newUser = new User { Pseudo = textboxUsername.Text, Email = textboxEmail.Text, Psw = textboxPassword.Password.ToString() };
                if (!VerifBdd(newUser))
                    {
                    CurrentUser.currentUser = newUser;
                    LaListe liste = new LaListe();
                        this.Close();
                        liste.Show();
                    }
            }
            else if (textboxUsername.Text.Trim(' ') == "")
            {
                EmptyField emptyField = new EmptyField("Username is empty !");
                emptyField.ShowDialog();
            }
            else if (textboxUsername.Text.Length < 4 || textboxUsername.Text.Length > 20)
            {
                EmptyField emptyField = new EmptyField("Username need to have more than 4 characters and less than 20 characters !");
                emptyField.ShowDialog();
            }
            else if (textboxEmail.Text.Trim(' ') == "")
            {
                EmptyField emptyField = new EmptyField("Email is empty !");
                emptyField.ShowDialog();
            }
            else if (isMailValid == false)
            {
                EmptyField emptyField = new EmptyField("Email is not an email !");
                emptyField.ShowDialog();
            }
            else if (textboxPassword.Password.ToString().Trim(' ') == "")
            {
                EmptyField emptyField = new EmptyField("Password is empty !");
                emptyField.ShowDialog();
            }
            else if (textboxPassword.Password.ToString().Length < 6)
            {
                EmptyField emptyField = new EmptyField("Password need to have more than 6 characters !");
                emptyField.ShowDialog();
            }
            else if (textboxPassword.Password.ToString() != textboxConfirmationPassword.Password.ToString())
            {
                EmptyField emptyField = new EmptyField("Confirmation password need to be the same as password !");
                emptyField.ShowDialog();
            }

        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }

        public bool VerifBdd(User newUser)
        {
            var pseudo = RequestWebApi.GetUserPseudo(newUser.Pseudo);
            var email = RequestWebApi.GetUserEmail(newUser.Email);
            if (pseudo == null && email == null)
            {
                RequestWebApi.PostUser(newUser);
                return false;
            }
            else if (pseudo != null)
            {
                EmptyField emptyField = new EmptyField("Username already exist !");
                emptyField.ShowDialog();
                return true;
            }
            else if (email != null)
            {
                EmptyField emptyField = new EmptyField("Email already exist !");
                emptyField.ShowDialog();
                return true;
            }
            else return true;
        }
    }
}
