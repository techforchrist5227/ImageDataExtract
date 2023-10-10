using MetadataExtractor.Formats.Exif;
using MetadataExtractor;
using static ImageDataExtract.Models.ImageData;
using ImageDataExtract.Models;



namespace ImageDataExtract
{
    //IImageDataService interface 
    public interface IImageDataService
    {
        ImageData ExtractMetadataFromImage(Stream imageStream);
    }

    public class ImageMetaDataService_2 : IImageDataService
    {
        //Mock data class , for interface learning purposes
        public ImageData ExtractMetadataFromImage(Stream imageStream)
        {
            return new ImageData { GpsLatitude = 5, GpsLongitude = 10 };
        }
    }


    public class ImageMetaDataService: IImageDataService

    {
       
        public ImageData ExtractMetadataFromImage(Stream imageStream)
        {

            
            var metadata = ImageMetadataReader.ReadMetadata(imageStream);

            var gpsDirectory = metadata.OfType<GpsDirectory>().FirstOrDefault();
            var dateDirectory = metadata.OfType<ExifSubIfdDirectory>().FirstOrDefault();
            var imageMetadata = new ImageData();

            

            if (gpsDirectory != null)
            {
                imageMetadata.GpsLatitude = gpsDirectory.GetGeoLocation().Latitude;
                imageMetadata.GpsLongitude = gpsDirectory.GetGeoLocation().Longitude;
            }

            if (dateDirectory != null)
            {
                imageMetadata.DateTaken = dateDirectory.GetDateTime(ExifDirectoryBase.TagDateTimeOriginal);
            }

            return imageMetadata;
        }
    }

    

}

