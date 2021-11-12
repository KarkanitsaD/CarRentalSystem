using System;

namespace Business.Models
{
    public class CarPictureModel
    {   
        public Guid Id { get; set; }
        public string ShortName { get; set; }
        public string Extension { get; set; }
        public byte[] Content { get; set; }
    }
}