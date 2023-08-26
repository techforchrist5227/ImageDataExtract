using MetadataExtractor.Formats.Exif;
using MetadataExtractor;
using static ImageDataExtract.ImageData;




namespace ImageDataExtract
{
    public class ImageMetaDataService

    {
        public ImageData ExtractMetadataFromImage(Stream imageStream)
        {
            
            var metadata = ImageMetadataReader.ReadMetadata(imageStream);

            var gpsDirectory = metadata.OfType<GpsDirectory>().FirstOrDefault();
            var dateDirectory = metadata.OfType<ExifSubIfdDirectory>().FirstOrDefault();
            var imageMetadata = new ImageMetaData();



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

