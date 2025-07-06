using AutoMapper;
using MongoDB.Driver;
using Multishop.Catalog.Dtos.ProductDetailDtos;
using Multishop.Catalog.Entities;
using Multishop.Catalog.Settings;

namespace Multishop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {        
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductDetail> _ProductDetailCollection;

        public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _ProductDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;

        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createCategoryDto)
        {
            var values = _mapper.Map<ProductDetail>(createCategoryDto);
            await _ProductDetailCollection.InsertOneAsync(values);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _ProductDetailCollection.DeleteOneAsync(x => x.ProductDetailID == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var values = await _ProductDetailCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(values);
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var value = await _ProductDetailCollection.Find<ProductDetail>(x => x.ProductDetailID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(value);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateCategoryDto)
        {
            var values = _mapper.Map<ProductDetail>(updateCategoryDto);
            await _ProductDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailID == updateCategoryDto.ProductDetailID, values);
        }
        
}
