using AutoMapper;
using AutoMapper.QueryableExtensions;
using JqueryDataTables.LoopsIT;
using MuslimFashion.Data;
using MuslimFashion.ViewModel;
using System.Linq;

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

        public DbResponse<ProductDetailsModel> Get(int id)
        {
            var product = Db.Product.Where(r => r.ProductId == id)
                .ProjectTo<ProductDetailsModel>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
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
    }
}