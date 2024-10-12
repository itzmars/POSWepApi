using AutoMapper;
using POSWebApi.DTOs.Product;
using POSWebApi.Models;

namespace POSWebApi.Profiles{
    public class ProductsProfile : Profile{

        public ProductsProfile() {
           // Domain Model to Read DTO
            CreateMap<Product, ProductReadDto>();

            // Create DTO to Domain Model
            CreateMap<ProductCreateDto, Product>();

            // Update DTO to Domain Model
            CreateMap<ProductUpdateDto, Product>();

        }

    }
}