using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Core.Models;
using Transaction.Infrastructor.Entities;

namespace Transaction.Core.MappingConfig
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<TransactionData, TransactionModel>().ReverseMap();
            CreateMap<ResponseModel, Transaction.Infrastructor.Models.ResponseModel>().ReverseMap();
        }
    }
}
