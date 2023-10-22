﻿using API.Core.DbModels;

namespace API.Core.Specifications
{
    public class ProductsWithProductTypeAndBrandSpecification : BaseSpecification<Product>
    {
        public ProductsWithProductTypeAndBrandSpecification()
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }

        public ProductsWithProductTypeAndBrandSpecification(int id) : base(x => x.Id == id)
        {

            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}
