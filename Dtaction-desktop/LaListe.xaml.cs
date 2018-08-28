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
        private ToDoList Listprivate = new ToDoList();
        private ObservableCollection<Task> ListItems = new ObservableCollection<Task>();

        public LaListe()
        {
            InitializeComponent();
            var todolist = RequestWebApi.GetToDoList(CurrentUser.currentUser.Id).FirstOrDefault();
            textboxtitlelist.Text = todolist.Title;
            Listprivate.Id = todolist.Id;
            var tasks = RequestWebApi.GetTasks(todolist.Id).ToList();

            //Add list to observable collection
            foreach (var item in tasks)
                ListItems.Add(item);

            listBox1.ItemsSource = ListItems;
        }
        
        private void add_Click(object sender, RoutedEventArgs e)

        {
            string messagetest = textBox1.Text.Trim(' '); 
            if (messagetest != "")
            {
                Task newTask = new Task { Content = textBox1.Text, IdList = Listprivate.Id, Position = ListItems.Count };
                ListItems.Add(newTask);
                textBox1.Text = "";
            }
            else
            {
                EmptyField error = new EmptyField("Empty field !");
                error.ShowDialog();
                textBox1.Text = "";
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)

        {
            if (listBox1.SelectedItem != null)
            {
                ListItems.RemoveAt(listBox1.SelectedIndex);
            }
            else
            {
                NoItemSelected error = new NoItemSelected();
                error.ShowDialog();
            }
        }

        private void up_click(object sender, RoutedEventArgs e)
        {
            if (listBox1.SelectedItem != null)
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
            else
            {
                NoItemSelected error = new NoItemSelected();
                error.ShowDialog();
            }
        }

        private void down_click(object sender, RoutedEventArgs e)
        {
            if (listBox1.SelectedItem != null)
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
            else
            {
                NoItemSelected error = new NoItemSelected();
                error.ShowDialog();
            }
        }

        private void edit_click(object sender, RoutedEventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Task selectedItem = this.listBox1.SelectedItem as Task;
                editTask Task = new editTask(selectedItem);
                Task.ShowDialog();
                listBox1.Items.Refresh();
            }
            else
            {
                NoItemSelected error = new NoItemSelected();
                error.ShowDialog();
            }
        }
    }
}
