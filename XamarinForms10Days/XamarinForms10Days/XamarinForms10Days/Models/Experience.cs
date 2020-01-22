using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinForms10Days.Models
{
    class Experience
    {
        [PrimaryKey, AutoIncrement] // added using SQLite;
        public int Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
