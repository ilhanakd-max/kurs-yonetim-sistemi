using System;

namespace KursYonetimSistemi.Models
{
    public class Holiday
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Recurring { get; set; }
        public string Description { get; set; }
    }
}
