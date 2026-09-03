using System;

namespace API.Models.Response.CarPicture
{
    public class CarPictureResponseModel
    {
        public Guid Id { get; set; }
        public string ShortName { get; set; }
        public string Extension { get; set; }
        public byte[] Content { get; set; }
    }
}