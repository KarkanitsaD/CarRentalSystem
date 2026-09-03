using System;
using System.Collections.Generic;

namespace Business.Models
{
    public class RoleModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<UserModel> Users { get; set; }
    }
}