using System;

namespace Business.Models
{
    public class CarPictureModel
    {
        public CarPictureModel(string base64Content, string shortName, string extension)
        {
            ShortName = shortName;
            Extension = extension;
            Content = Convert.FromBase64String(base64Content);
        }

        public CarPictureModel()
        {
        }

        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public CarModel Car { get; set; }
        public string ShortName { get; set; }
        public string Extension { get; set; }
        public byte[] Content { get; set; }
    }
}