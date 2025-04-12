using CollectionManager.SQLServer.Context;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollectionManager.SQLServer.Entities.Collectibles
{
    [PrimaryKey(nameof(Id))]
    [Table(nameof(CollectionManagerDbContext.Comics))]
    public sealed class ComicEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required ulong Id { get; set; }

        [Required]
        [MaxLength(20)]
        public required string Series { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Title { get; set; }

        [Required]
        public required byte Volume { get; set; }

        [Required]
        [MaxLength(7)]  // Example: "1-5"
        public required string Issues { get; set; }

        [Required]
        public required DateOnly Published { get; set; }

        [Required]
        public required bool IsOwned { get; set; }

        [Required]
        [MaxLength(500)]
        public required string Notes { get; set; }
    }
}