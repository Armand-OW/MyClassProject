using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassProject.Models
{
    public class DisplayTodo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; } = false;
        public User Userinfo { get; set; } = new User();   
    }
}
