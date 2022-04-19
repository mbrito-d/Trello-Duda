using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trello.Models

{

    [Table("Cartoes")]
    public class Cards
    {

        [Column("Titulo")]
        [Display(Name = "Titulo")]
        public string Title { get; set; } = String.Empty;

        [Column("Tempo")]
        [Display(Name = "Tempo")]
        public int Time { get; set; }

        [Column("Descricao")]
        [Display(Name = "Descrição")]
        public string Description { get; set; } = String.Empty;

        [Column("Id")]
        [Display(Name = "Id")]
        public int ID { get; set; }

        [Column("Status")]
        [Display(Name = "Status")]
        public StatusType Status { get; set; }

        public enum StatusType
        {
            [Display(Name = "A fazer")]
            Fazer,
            [Display(Name = "Em andamento")]
            Andamento,
            [Display(Name = "Concluído")]
            Finalizado
        }

    }
}
