namespace Common.Models
{
    public class ServiceTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}
