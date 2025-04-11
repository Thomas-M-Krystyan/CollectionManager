using CollectionManager.Domain.Enums.FileExtensions;
using CollectionManager.Domain.Models.Base;

namespace CollectionManager.Domain.Models
{
    /// <summary>
    /// <inheritdoc cref="FileBase{TExtension}"/>
    /// <para>
    ///   Represents a graphic content.
    /// </para>
    /// </summary>
    public record ImageFile : FileBase<Graphics>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageFile"/> class.
        /// </summary>
        public ImageFile() : base()
        {
        }
    }
}