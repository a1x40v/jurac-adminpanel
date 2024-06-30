using Application.Features.Common;
using MediatR;

namespace Application.Features.PublishRecTab.Requests.Commands
{
    public class CreatePublishRecTabCommand : PublishProfilesBase, IRequest, IPublishRecTabCommand
    {
        public int UserId { get; set; }
        public string TestType { get; set; } // ЕГЭ, Вступительные испытания
        public bool Sogl { get; set; } // Не подано  
        public bool SostType { get; set; } // Рекомендован, Не рекомендован
        public bool Advantage { get; set; } // Не имеет 
        public short Individ { get; set; }
        public short RusPoint { get; set; }
        public short ObshPoint { get; set; }
        public short KpPoint { get; set; }
        public short SpecPoint { get; set; }
        public short ForeignLanguagePoint { get; set; }
        public short GpPoint { get; set; }
        public short HistoryPoint { get; set; }
        public short OkpPoint { get; set; } // ТГП или ОКП должны быть 0
        public short TgpPoint { get; set; } // ТГП или ОКП должны быть 0
        public short UpPoint { get; set; }
        public bool IsPublished { get; set; }
        public string Comment { get; set; }
    }
}