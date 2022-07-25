using Application.DTO.Documentuser;
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