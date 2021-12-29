using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationCRUD.Models
{
    public class Visitantes
    {
        [Display(Name = "Código")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Column("Nome")]
        public string Nome { get; set; }

        [Display(Name = "Área")]
        [Column("Area")]
        public string Area { get; set; }

        [Display(Name = "Responsável")]
        [Column("Responsavel")]
        public string Responsavel { get; set; }
    }
}
