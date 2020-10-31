using JWT.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Entities.Dtos.ProductDtos
{
    public class ProductAddDto : IDto
    {
        public string Name { get; set; }
    }
}
