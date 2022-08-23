using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassProject.Models
{
    [Table("user")]
    public class User
    {
        //Properties = values of our class
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [MaxLength(250), Unique]
        public string Username { get; set; }

        [MaxLength(100)]
        public string Role { get; set; }

        [MaxLength(30), NotNull]
        public string Password { get; set; }
    }
}
