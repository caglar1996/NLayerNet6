using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.DTOs.Reponse;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    public class ProductController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _service;

        public ProductController(IMapper mapper, IService<Product> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();
            var productsDto = _mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Succes(200, productsDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Succes(200, productDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto dto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(dto));
            var productDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Succes(201, productDto));
            // 201 - kayıt olsturuldu.

        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto dto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(dto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
            // 204 - NoContent.
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _service.GetByIdAsync(id);

           await _service.RemoveAsync(product);
            var productDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Succes(200, productDto));
        }
    }
}
