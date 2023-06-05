using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TodoItemApp.Models
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar(100)")]
        public string? Title { get; set; }

        // DateTime을 string으로 변환
        public string TodoDate { get; set; }

        // boolin을 int로 변환
        public int IsComplete { get; set; }

    }
}
