using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollectionManager.SQLServer.Entities
{
    [PrimaryKey(nameof(Id))]
    [Table("Images")]
    public sealed record ImageEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public required ulong Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Column(Order = 1)]
        public required string Name { get; set; }

        [Required]
        [Column(Order = 2)]
        public required byte Extension { get; set; }

        [Required]
        [Column(TypeName = "varbinary(max)", Order = 3)]
        public required byte[] Bytes { get; set; }
    }
}