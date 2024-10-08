using AutoMapper;
using Transaction.Web.DTO;
using Transaction.Web.Models;

namespace Transaction.Web.MappingConfig
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<FileUploadModel, FileUploadDTO>().ReverseMap();
        }
    }
}
