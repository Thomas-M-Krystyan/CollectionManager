using System.ComponentModel.DataAnnotations;

namespace CollectionManager.Domain.Enums
{
    /// <summary>
    /// A list of supported graphic file extensions.
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