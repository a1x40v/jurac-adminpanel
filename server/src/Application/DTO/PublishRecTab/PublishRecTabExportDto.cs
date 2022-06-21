namespace Application.DTO.PublishRecTab
{
    public class PublishRecTabDeployDto
    {
        public int UserId { get; set; }
        public string Snils { get; set; }
        public string TestType { get; set; }
        public short SumPoints { get; set; }
        public short ObshPoint { get; set; }
        public short RusPoint { get; set; }
        public short ChosenPoint { get; set; }
        public short IndividPoint { get; set; }
        public string SostType { get; set; } // Рекомендован, Не рекомендован
        public string Sogl { get; set; } // Подано, Не подано
        public string Advantage { get; set; } // Имеет, не имеет => Да, нет
    }
}