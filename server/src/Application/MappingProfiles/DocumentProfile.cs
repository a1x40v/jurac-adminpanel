using Application.DTO.Document;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<RegabiturDocumentuser, DocumentDto>();
        }
    }
}