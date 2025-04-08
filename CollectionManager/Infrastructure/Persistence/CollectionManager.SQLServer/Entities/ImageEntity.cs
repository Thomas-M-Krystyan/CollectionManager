using CollectionManager.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollectionManager.SQLServer.Entities
{
    /// <inheritdoc cref="ImageFile"/>
    [Table("Images")]
    public sealed record ImageEntity
    {
        /// <inheritdoc cref="ImageFile.Id"/>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "int", Order = 0)]
        public int Id { get; set; }

        /// <inheritdoc cref="ImageFile.Name"/>
        [Required]
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)", Order = 1)]
        public string Name { get; set; } = string.Empty;

        /// <inheritdoc cref="ImageFile.Extension"/>
        [Required]
        [Column(TypeName = "smallint", Order = 2)]
        public short Extension { get; set; }

        /// <inheritdoc cref="ImageFile.Bytes"/>
        [Required]
        [Column(TypeName = "varbinary(max)", Order = 3)]
        public byte[] Bytes { get; set; } = [];
    }
}