using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPI.Data
{
    public partial class TblApplicationRegistration
    {
        public int Id { get; set; }
        public Guid ApplicationId { get; set; }
        public string SecretHash { get; set; }
        public string ApplicationName { get; set; }
        public bool IsActive { get; set; }
        public DateTime DteCreated { get; set; }
    }
}
