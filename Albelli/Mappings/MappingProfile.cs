using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;

namespace API.Mappings
{
    public class MappingProfile:Profile
    {
		public MappingProfile()
		{
			CreateMap<Product, API.Models.Product>();
			CreateMap<API.Models.Product, Product>()
				.ForMember(dest => dest.Validations, opt => opt.Ignore())
				.ForMember(dest => dest.Created, opt => opt.Ignore())
				.ForMember(dest => dest.Updated, opt => opt.Ignore())
				.ForMember(dest => dest.Order, opt => opt.Ignore());

			CreateMap<Customer, API.Models.Customer>();
			CreateMap<API.Models.Customer, Customer>()
				.ForMember(dest => dest.Validations, opt => opt.Ignore())
				.ForMember(dest => dest.Created, opt => opt.Ignore())
				.ForMember(dest => dest.Updated, opt => opt.Ignore())
				.ForMember(dest => dest.Name, opt => opt.MapFrom(m => string.Format("{0} {1}", m.FirstName, m.LastName)));

			CreateMap<Order, API.Models.Order>();
			CreateMap<API.Models.Order, Order>()
				.ForMember(dest => dest.Validations, opt => opt.Ignore())
				.ForMember(dest => dest.Created, opt => opt.Ignore())
				.ForMember(dest => dest.Updated, opt => opt.Ignore())
				.ForMember(dest => dest.Customer, opt => opt.MapFrom(m => m.Customer))
				.ForMember(dest => dest.Products, opt => opt.MapFrom(m => m.Products));


			

			//.ForMember(dest => dest.Name, opt => opt.MapFrom(m => string.Format("{0} {1}", m.FirstName, m.LastName)));


			//				cfg.CreateMap<API.Models.Customer, Domain.Entities.Customer>()
			//				.ForMember(dest => dest.Created, opt => opt.Ignore())
			//				.ForMember(dest => dest.Updated, opt => opt.Ignore())
			//				.ForMember(dest => dest.Validations, opt => opt.Ignore())
			//				.ForMember(dest => dest.Name, opt => opt.MapFrom(m=> m.FirstName));

			//				cfg.CreateMap<API.Models.Order, Domain.Entities.Order>()
			//				.ForMember(dest => dest.Created, opt => opt.Ignore())
			//				.ForMember(dest => dest.Updated, opt => opt.Ignore())
			//				.ForMember(dest => dest.Customer, opt => opt.Ignore())
			//				.ForMember(dest => dest.Products, opt => opt.Ignore())
			//				.ForMember(dest => dest.Validations, opt => opt.Ignore());

			//				cfg.CreateMap<API.Models.Product, Domain.Entities.Product>()
			//					.ForMember(dest => dest.Id, opt => opt.Ignore())
			//				.ForMember(dest => dest.Created, opt => opt.Ignore())
			//								.ForMember(dest => dest.Updated, opt => opt.Ignore())
			//								.ForMember(dest => dest.Order, opt => opt.Ignore())
			//								.ForMember(dest => dest.Validations, opt => opt.Ignore());


		}
	}
}
