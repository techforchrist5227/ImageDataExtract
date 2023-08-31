using System.ComponentModel.DataAnnotations;

namespace ImageDataExtract.Models
{
    public class ImageData
    {
        [Key]
        public int Id { get; set; }
        public double? GpsLatitude { get; set; }
        public double? GpsLongitude { get; set; }
        public DateTime? DateTaken { get; set; }

    }
}