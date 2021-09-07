using AutoMapper;
using MaintenanceServiceCRUD.API.DTOs;
using MaintenanceServiceCRUD.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaintenanceServiceCRUD.API.Mapper
{
    public class MappingProfile: Profile
    {

        public MappingProfile()
        {
            CreateMap<TruckMaintenanceServiceInsertDto, TruckMaintenanceService>();
            CreateMap <TruckMaintenanceService, TruckMaintenanceServiceInsertDto>();
            CreateMap<TruckMaintenanceService, TruckMaintenanceServiceDto>()
                .ForMember(dest => dest.Dispatcher,
                           opt => opt.MapFrom(e => $"{e.DispatcherNavigation.FirstName} {e.DispatcherNavigation.LastName}"))
                .ForMember(dest => dest.Driver,
                           opt => opt.MapFrom(e => $"{e.DriverNavigation.FirstName} {e.DriverNavigation.LastName}"))
                .ForMember(dest => dest.Mechanical,
                           opt => opt.MapFrom(e => $"{e.MechanicalNavigation.FirstName} {e.MechanicalNavigation.LastName}"))
                .ForMember(dest => dest.Truck,
                           opt => opt.MapFrom(e => e.IdTruckNavigation.Number))
                .ForMember(dest => dest.Type,
                           opt => opt.MapFrom(e => e.IdTypeTruckMaintenanceServiceNavigation.TypeDescription));
            CreateMap<Truck,VehicleQueryDto> ();
            CreateMap<Employee,EmployeeQueryDto> ();
            CreateMap<TypeTruckMaintenanceService, TypeTruckMaintenanceServicesQueryDto>();
        }
    }
}
