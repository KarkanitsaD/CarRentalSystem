namespace Data.Entities
{
    public abstract class PictureEntity: Entity
    {
        public string ShortName { get; set; }
        public string Extension { get; set; }
        public byte[] Content { get; set; }
    }
}