using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LookieLooks.Api.Model
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Type { get; set; }

        public IEnumerable<string> ImagesLink { get; set; }
    }
}
