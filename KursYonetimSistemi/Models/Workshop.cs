namespace KursYonetimSistemi.Models
{
    public class Workshop
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public string Equipment { get; set; }
        public string Color { get; set; }
        public bool Active { get; set; } = true;
    }
}
