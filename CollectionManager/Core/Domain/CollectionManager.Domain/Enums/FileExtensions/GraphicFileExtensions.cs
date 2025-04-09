using System.ComponentModel.DataAnnotations;

namespace CollectionManager.Domain.Enums.FileExtensions
{
    /// <summary>
    /// Supported graphic file extensions.
    /// </summary>
    public enum GraphicFileExtensions
    {
        [Display(Name = "jpg")]
        Jpg,

        [Display(Name = "jpeg")]
        Jpeg,

        [Display(Name = "png")]
        Png,

        [Display(Name = "bmp")]
        Bmp
    }
}