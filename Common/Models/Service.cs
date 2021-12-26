namespace Common.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ServiceTask> Tasks { get; set; }
    }
}
