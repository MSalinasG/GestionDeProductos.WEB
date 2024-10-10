using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDeProductos.Data.Models
{
    [Table("Products", Schema = "Inventory")]
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

        [MaxLength(200)]
        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        [Required]
        [Display(Name = "Activo")]
        public bool EsActivo { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        public int? Cantidad { get; set; }

        [Required]
        [Display(Name = "Precio")]
        [DataType(DataType.Currency)]
        public int? PrecioEntero { get; set; }

        [Required]
        [Display(Name = "Fecha de Expiración")]
        [DataType(DataType.Date)]
        public DateTime FechaExpiracion { get; set; }
    }
}
