using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trello.Models

{
    [Table("Usuarios")]
    public class UsersInfo
    {

        [Column("Nome")]
        [Display(Name = "Nome")]
        [Required]
        public string Name { get; set; } = String.Empty;

        
        [Column("Id")]
        [Display(Name = "Id")]
        [Key]
        public int ID { get; set; }
    }
}
