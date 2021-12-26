namespace Common.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public IEnumerable<ServiceTask> Tasks { get; set; }
    }
}
