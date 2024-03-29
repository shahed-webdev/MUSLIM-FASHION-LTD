﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevMaker.FileStorage;
using JqueryDataTables.LoopsIT;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MuslimFashion.Data;
using MuslimFashion.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuslimFashion.Repository
{
    public class ProductRepository : Repository, IProductRepository
    {
        public ProductRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public DbResponse<int> Add(ProductAddModel model)
        {
            var product = _mapper.Map<Product>(model);
            Db.Product.Add(product);
            Db.SaveChanges();
            var productId = product.ProductId;

            return new DbResponse<int>(true, $"{model.ProductName} Added Successfully", productId);
        }

        public async Task<DbResponse> EditAsync(ProductEditModel model, IFormFile imageFile)
        {
            var product = Db.Product
                .Include(p => p.ProductSizes)
                .FirstOrDefault(p => p.ProductId == model.ProductId);

            product.SubMenuId = model.SubMenuId;
            product.ProductName = model.ProductName;
            product.Price = model.Price;
            product.OldPrice = model.OldPrice;
            product.ProductCode = model.ProductCode;
            product.Brand = model.Brand;
            product.FabricType = model.FabricType;
            product.Description = model.Description;
            product.ProductSizes = model.ProductSizes.Select(s => new ProductSize
            {
                SizeId = s
            }).ToList();

            if (imageFile != null)
            {
                var fileName = await FileStorage.UploadFileAsync(imageFile, "product-image");
                FileStorage.DeleteFile(product.ImageFileName);
                product.ImageFileName = fileName;
            }

            Db.Product.Update(product);
            await Db.SaveChangesAsync();

            return new DbResponse(true, "Product Update successfully");
        }

        public DbResponse<ProductDetailsModel> Get(int id)
        {
            var product = Db.Product.Where(r => r.ProductId == id).ProjectTo<ProductDetailsModel>(_mapper.ConfigurationProvider).FirstOrDefault();
            return new DbResponse<ProductDetailsModel>(true, $"{product.ProductName} Get Successfully", product);
        }

        public bool IsExistName(string name)
        {
            return Db.Product.Any(r => r.ProductName == name);
        }

        public bool IsExistName(string name, int updateId)
        {
            return Db.Product.Any(r => r.ProductName == name && r.ProductId != updateId);
        }

        public bool IsExistCode(string code)
        {
            return Db.Product.Any(r => r.ProductCode == code);
        }

        public bool IsExistCode(string code, int updateId)
        {
            return Db.Product.Any(r => r.ProductCode == code && r.ProductId != updateId);
        }

        public bool IsNull(int id)
        {
            return Db.Product.Any(r => r.ProductId == id);
        }

        public bool IsRelatedDataExist(int id)
        {
            return false;
        }

        public DataResult<ProductRecordView> ListByAdmin(DataRequest request)
        {
            return Db.Product
                .ProjectTo<ProductRecordView>(_mapper.ConfigurationProvider)
                .ToDataResult(request);
        }

        public DataResult<ProductRecordView> ListOfUnassignedHomeMenu(DataRequest request, int homeMenuId)
        {
            var assignedProductIds = Db.HomeProduct.Where(h => h.HomeMenuId == homeMenuId).Select(h => h.ProductId).ToList();
            return Db.Product
                .Where(p => !assignedProductIds.Contains(p.ProductId))
                .ProjectTo<ProductRecordView>(_mapper.ConfigurationProvider)
                .ToDataResult(request);
        }

        public DataResult<ProductRecordView> ListOfAssignedHomeMenu(DataRequest request, int homeMenuId)
        {
            var assignedProductIds = Db.HomeProduct.Where(h => h.HomeMenuId == homeMenuId).Select(h => h.ProductId).ToList();
            return Db.Product
                .Where(p => assignedProductIds.Contains(p.ProductId))
                .ProjectTo<ProductRecordView>(_mapper.ConfigurationProvider)
                .ToDataResult(request);
        }

        public async Task<List<ProductFindViewModel>> SearchAsync(string code)
        {

            return await Db.Product
                .Where(c => c.ProductCode.Contains(code))
                .ProjectTo<ProductFindViewModel>(_mapper.ConfigurationProvider)
                .Take(5)
                .ToListAsync()
                .ConfigureAwait(false);

        }
    }
}