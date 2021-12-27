namespace Common.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public ServiceTask Task { get; set; }
    }
}
