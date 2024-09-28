using AutoMapper;
using Transaction.Core.Models;
using Transaction.Infrastructor.Entities;

namespace Transaction.Core.MappingConfig
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<TD_Transaction, TransactionModel>().ReverseMap();
        }
    }
}
