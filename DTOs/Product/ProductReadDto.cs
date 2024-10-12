using System;

namespace POSWebApi.DTOs.Product{
    public class ProductReadDto{
         public Guid Id { get; set; }
        public string Name{get; set;} = string.Empty;
        public string Description{get;set;} = string.Empty;

        public decimal Price {get; set;}

        public int Stock{get; set;}
    }
}