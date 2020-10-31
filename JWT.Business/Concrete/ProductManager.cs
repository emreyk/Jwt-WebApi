using Jwt.DataAccess.Interfaces;
using JWT.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Business.Concrete
{
    public class ProductManager:IProductService
    {
        private readonly IProductDal _appProductDal;
        public ProductManager(IProductDal appProductDal)
        {
            _appProductDal = appProductDal;
        }

        public async Task AddAsync(Product entity)
        {
            await _appProductDal.AddAsync(entity);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _appProductDal.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _appProductDal.GetByIdAsync(id);
        }

        public async Task RemoveAsync(Product entity)
        {
            await _appProductDal.RemoveAsync(entity);
        }

        public async Task UpdateAsync(Product entity)
        {
            await _appProductDal.RemoveAsync(entity);
        }
    }
}
