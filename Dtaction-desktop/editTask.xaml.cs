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
        private Task selectedtask { get; set; }

        public editTask(Task selectedTask)
        {
            InitializeComponent();
            textBox1.Text = selectedTask.Content;
            selectedtask = selectedTask;
        }

        public void button_cancel_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void button_valider_click(object sender, RoutedEventArgs e)
        {
            selectedtask.Content = textBox1.Text;
            this.Close();
        }
    }
}
