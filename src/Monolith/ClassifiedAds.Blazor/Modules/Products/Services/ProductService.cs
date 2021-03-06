﻿using ClassifiedAds.Blazor.Modules.Core.Services;
using ClassifiedAds.Blazor.Modules.Products.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ClassifiedAds.Blazor.Modules.Products.Services
{
    public class ProductService : HttpService
    {
        public ProductService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
            : base(httpClient, httpContextAccessor)
        {
        }

        public async Task<List<ProductModel>> GetProducts()
        {
            var products = await GetAsync<List<ProductModel>>("api/products");
            return products;
        }

        public async Task<ProductModel> GetProductById(Guid id)
        {
            var product = await GetAsync<ProductModel>($"api/products/{id}");
            return product;
        }

        public async Task<ProductModel> CreateProduct(ProductModel product)
        {
            var createdProduct = await PostAsync<ProductModel>("api/products", product);
            return createdProduct;
        }

        public async Task<ProductModel> UpdateProduct(Guid id, ProductModel product)
        {
            var updatedProduct = await PutAsync<ProductModel>($"api/products/{id}", product);
            return updatedProduct;
        }

        public async Task DeleteProduct(Guid id)
        {
            await DeleteAsync($"api/products/{id}");
        }

        public async Task<List<ProductAuditLogModel>> GetAuditLogs(Guid id)
        {
            var auditLogs = await GetAsync<List<ProductAuditLogModel>>($"api/products/{id}/auditlogs");
            return auditLogs;
        }
    }
}
