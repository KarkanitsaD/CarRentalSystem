using System;

namespace Data.Entities
{
    public class CarPictureEntity: PictureEntity
    {
        public Guid CarId { get; set; }
        public CarEntity Car { get; set; }
    }
}