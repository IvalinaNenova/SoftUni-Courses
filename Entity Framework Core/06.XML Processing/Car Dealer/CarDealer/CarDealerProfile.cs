using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Supplier
            this.CreateMap<ImportSupplierDto, Supplier>();
            this.CreateMap<Supplier, ExportLocalSuppliersDto>()
                .ForMember(dest => dest.PartsCount, opt => opt.MapFrom(src => src.Parts.Count));
            //Part
            this.CreateMap<ImportPartDto, Part>()
                .ForMember(d => d.SupplierId,
                    opt => opt.MapFrom(s => s.SupplierId.Value));
            this.CreateMap<Part, ExportCarPartsDto>();
            //Car
            this.CreateMap<ImportCarDto, Car>()
                .ForSourceMember(s => s.Parts, 
                    opt => opt.DoNotValidate());
            this.CreateMap<Car, ExportCarDto>();
            this.CreateMap<Car, ExportBMWCarsDto>();
            this.CreateMap<Car, ExportCarWithPartsDto>()
                .ForMember(d => d.Parts,
                    opt => opt.MapFrom(s => s.PartsCars
                        .Select(pc => pc.Part)
                        .OrderByDescending(p => p.Price)
                        .ToArray()));

            //Customer
            this.CreateMap<ImportCustomerDto, Customer>();
            this.CreateMap<Customer, ExportTotalSalesByCustomerDto>()
                .ForMember(dest => dest.BoughtCars, opt => opt.MapFrom(src => src.Sales.Count));

            //Sale
            this.CreateMap<ImportSaleDto, Sale>();
        }
    }
}
