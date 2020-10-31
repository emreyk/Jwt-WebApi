using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jwt.DataAccess.Interfaces;
using JWT.Business.StringInfos;
using JWT.Entities.Concrate;
using JWT.Entities.Dtos.ProductDtos;
using JWT.UI.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _mapper = mapper;
            _productService = productService;
        }


        [HttpGet]
        [Authorize]
        [Authorize(Roles = RoleInfo.Admin + "," + RoleInfo.Member)]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpPost]
        [Authorize(Roles = RoleInfo.Admin)]
        [ValidModel]
        public async Task<IActionResult> Add(ProductAddDto productAddDto)
        {
            await _productService.AddAsync(_mapper.Map<Product>(productAddDto));
            return Created("", productAddDto);

        }
    }
}
