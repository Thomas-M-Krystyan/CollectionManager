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
        [Column(Order = 0)]
        public required ulong Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(Order = 1)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(Order = 2)]
        public required string Authors { get; set; }

        [Required]
        [Column(Order = 3)]
        public required byte Genre { get; set; }

        [Required]
        [Column(Order = 4)]
        public required byte Age { get; set; }

        [Required]
        [Column(Order = 5)]
        public required DateOnly Published { get; set; }

        [Required]
        [Column(Order = 6)]
        public required bool IsOwned { get; set; }

        [Required]
        [MaxLength(500)]
        [Column(Order = 7)]
        public required string Notes { get; set; }

        // ---------------------
        // Navigation properties
        // ---------------------

        [Required]
        [Column(Order = 8)]
        public required ulong ImageId { get; set; }

        [Required]
        [ForeignKey(nameof(ImageId))]
        [Column(Order = 9)]
        public required ImageEntity Image { get; set; }
    }
}