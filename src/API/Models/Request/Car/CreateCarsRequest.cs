using System.Collections.Generic;

namespace API.Models.Request.Car
{
    public class CreateCarsRequest
    {
        public List<CreateCarRequest> Cars { get; set; }
    }
}