namespace PrzegladyRemonty.Models
{
    public class WorkOrder
    {
        public int Id { get; }
        public string Created { get; }
        public int CreatedBy { get; }

        public WorkOrder(string created, int createdBy)
        {
            Created = created;
            CreatedBy = createdBy;
        }

        public WorkOrder(int id, string created, int createdBy)
        {
            Id = id;
            Created = created;
            CreatedBy = createdBy;
        }
    }
}
