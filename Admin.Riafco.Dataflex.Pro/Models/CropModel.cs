using System.ComponentModel.DataAnnotations;

namespace Admin.Riafco.Dataflex.Pro.Models
{
    /// <summary>
    /// The CropModel class.
    /// </summary>
    public class CropModel
    {
        /// <summary>
        /// Gets or sets ObjectId
        /// </summary>
        public int ObjectId { get; set; }

        /// <summary>
        /// Gets or sets ImageSrc.
        /// </summary>
        [Required(ErrorMessage = "Obligatoire.", AllowEmptyStrings = false)]
        public string ImageSrc { get; set; }

        /// <summary>
        /// Gets or sets PointX.
        /// </summary>
        [Required(ErrorMessage = "Obligatoire.", AllowEmptyStrings = false)]
        public string PointX { get; set; }

        /// <summary>
        /// Gets or sets PointY.
        /// </summary>
        [Required(ErrorMessage = "Obligatoire.", AllowEmptyStrings = false)]
        public string PointY { get; set; }

        /// <summary>
        /// Gets or sets ImageWidth.
        /// </summary>
        [Required(ErrorMessage = "Obligatoire.", AllowEmptyStrings = false)]
        public string ImageWidth { get; set; }

        /// <summary>
        /// Gets or sets ImageHeight.
        /// </summary>
        [Required(ErrorMessage = "Obligatoire.", AllowEmptyStrings = false)]
        public string ImageHeight { get; set; }
    }
}