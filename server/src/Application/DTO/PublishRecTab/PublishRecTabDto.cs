using Application.Features.Common;

namespace Application.DTO.PublishRecTab
{
    public class PublishRecTabDto : PublishProfilesBase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string TestType { get; set; }
        public string Sogl { get; set; }
        public string SostType { get; set; }
        public string Advantage { get; set; }
        public short Individ { get; set; }
        public short RusPoint { get; set; }
        public short ObshPoint { get; set; }
        public short KpPoint { get; set; }
        public short SpecPoint { get; set; }
        public short ForeignLanguagePoint { get; set; }
        public short GpPoint { get; set; }
        public short HistoryPoint { get; set; }
        public short OkpPoint { get; set; }
        public short TgpPoint { get; set; }
        public short UpPoint { get; set; }
        public short SumPoints { get; set; }

        public string FullName { get; set; }
        public string Snils { get; set; }
        public bool IsPublished { get; set; }
        public string Comment { get; set; }
    }
}