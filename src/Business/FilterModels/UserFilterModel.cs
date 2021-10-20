namespace Business.FilterModels
{
    public class UserFilterModel : FilterModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? NumberOfBookings { get; set; }
    }
}
