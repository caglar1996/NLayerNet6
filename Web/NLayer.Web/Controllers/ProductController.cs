using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.DTOs.Reponse;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _service;

        public ProductController(IMapper mapper, IService<Product> service)
        {
            _mapper = mapper;
            _service = service;
        }

        //[HttpGet]
        //public async Task<IActionResult> All()
        //{
        //    var products = await _service.GetAllAsync();
        //    var productDtos = _mapper.Map<List<ProductDto>>(products);
        //    return Ok(CustomResponseDto<List<ProductDto>>.Succes(200, productDtos));

        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var product = await _service.GetByIdAsync(id);
        //    var productDto = _mapper.Map<ProductDto>(product);
        //    return CreateActionResult<ProductDto>(CustomResponseDto<ProductDto>.Succes(200, productDto));

        //}
    }
}
