using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassProject.Models
{
    [Table("todo")]
    public class Todo
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }

        public bool IsCompleted { get; set; } = false;

        [NotNull]
        public int UserId { get; set; }

        public string Username { get; set; }
    }
}
