using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtaction_desktop
{
    public class ToDoList
    {
        public static int IdToDo { get; set; }
        public static string Title { get; set; }
        public static List<Task> Tasks = new List<Task>();
    }
}
