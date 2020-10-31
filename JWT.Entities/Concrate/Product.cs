using JWT.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Entities.Concrate
{
    public class Product : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
