using AutoMapper;
using Shared.Domain.Models;
using DTOs;

namespace Mappings.SharedMappings
{
    public class SharedMappings : Profile
    {
        public SharedMappings()
        {
         
            CreateMap<RequestTypeDTO, RequestType>();

            CreateMap<DeliveryModeDTO, DeliveryMode>();

            CreateMap<DepartmentRequestPaymentChannel, DepartmentRequestPaymentChannelDTO>();

            CreateMap<DepartmentDTO, Department>();

            CreateMap<DepartmentSettingDTO, DepartmentSetting>();

            CreateMap<DepartmentDeliveryModeDTO, DepartmentDeliveryMode>().ReverseMap();

            CreateMap<DepartmentRequestTypeDTO, DepartmentRequestType>();

            CreateMap<RequestTransactionDTO, RequestTransaction>();




        }
    }
}

