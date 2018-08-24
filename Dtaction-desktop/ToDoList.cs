using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtaction_desktop
{
    public class ToDoList
    {
        public int IdUser { get; set; }
        public int IdList { get; set; }
        public string Title { get; set; }
        public int PositionList { get; set; }
        public List<Task> Tasks = new List<Task>();
    }
}
