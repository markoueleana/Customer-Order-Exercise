using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercise.Models;

namespace Exercise.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime RegistrationDate { get; set; }
        public decimal Balance { get; set; }
    }
    public class OrderDto
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime Date { get; set; }
        public List<OrderProductDtos> OrderProduct { get; set; }
    }

    public class OrderProductDtos
    {
        public int Id { get; set; }
        public int ProductId { get; }
        public Product Product { get; set; }
        public int OrderQuantity { get; set; }
    }


    public class ProductDtos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }



    }


}
