namespace KursYonetimSistemi.Models
{
    public class Teacher
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Tc { get; set; }
        public string Branch { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public bool Active { get; set; } = true;
    }
}
