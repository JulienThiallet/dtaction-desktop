using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for LaListe.xaml
    /// </summary>
    public partial class LaListe : Window
    {
        private ObservableCollection<Task> ListItems = new ObservableCollection<Task>();

        public LaListe()
        {
            InitializeComponent();
            listBox1.ItemsSource = this.ListItems;
        }

        private void add_Click(object sender, RoutedEventArgs e)

        {
            Task newTask = new Task {Content = textBox1.Text };
            ListItems.Add(newTask);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)

        {
                ListItems.RemoveAt(listBox1.SelectedIndex);
        }

        private void up_click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = listBox1.SelectedIndex;

            if (selectedIndex > 0)
            {
                var itemToMoveUp = this.ListItems[selectedIndex];
                ListItems.RemoveAt(selectedIndex);
                this.ListItems.Insert(selectedIndex - 1, itemToMoveUp);
                this.listBox1.SelectedIndex = selectedIndex - 1;
            }
        }

        private void down_click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = this.listBox1.SelectedIndex;

            if (selectedIndex + 1 < this.ListItems.Count)
            {
                var itemToMoveDown = this.ListItems[selectedIndex];
                this.ListItems.RemoveAt(selectedIndex);
                this.ListItems.Insert(selectedIndex + 1, itemToMoveDown);
                this.listBox1.SelectedIndex = selectedIndex + 1;
            }
        }

        private void edit_click(object sender, RoutedEventArgs e)
        {
            Task selectedItem = this.listBox1.SelectedItem as Task;

            editTask Task = new editTask(selectedItem);
            Task.ShowDialog();


        }
    }
}
