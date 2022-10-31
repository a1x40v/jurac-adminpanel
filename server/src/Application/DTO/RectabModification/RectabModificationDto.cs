namespace Application.DTO.RectabModification
{
    public class RectabModificationDto
    {
        public int Id { get; set; }
        public int AbiturientId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Author { get; set; }
        public ushort Type { get; set; }
        public string StudentName { get; set; }
    }
}