using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trello_Duda.Models
{
    [Table("Sprints")]
    public class SprintsInfo
    {
        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Name { get; set; } = String.Empty;

        [Column("Id")]
        [Display(Name = "Id")]
        public int ID { get; set; }
    }
}
