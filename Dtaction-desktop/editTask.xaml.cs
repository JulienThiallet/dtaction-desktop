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
    /// Interaction logic for editTask.xaml
    /// </summary>
    public partial class editTask : Window
    {
        public editTask(Task selectedTask)
        {
            InitializeComponent();
            textBox1.Text = selectedTask.Content;
        }

        public void button_cancel_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
