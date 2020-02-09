using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercise.Dtos;
using Exercise.Models;
using Exercise.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Exercise.Controllers
{
    [ApiController]
    [Route("")]
    public class WeatherForecastController : ControllerBase
    {


        private readonly ILogger<WeatherForecastController> _logger;




        [HttpGet("customers")]/*//returns all of the customers*/
        public List<Customer> Customers()
        {

            MyServices services = new MyServices();
            return services.GetCustomers(3);

        }


        [HttpGet("customers/{id}")]/*// returns the customer with a specific key */

        public ReturnData<Customer> CustomerId([FromRoute] int id)
        {
            MyServices services = new MyServices();
            return services.GetCustomerId(id);


        }

        [HttpPost("customer")]//creates a customer

        public Customer CreateNewCustomer([FromBody] CustomerDto customerDto)
        {

            MyServices services = new MyServices();
            return services.CreateCustomer(customerDto);

        }




        //ORDERS

        [HttpPost("order")]//creates an order
        public Order CreateNewOrder([FromBody] OrderDto orderDto)
        {

            MyServices services = new MyServices();
            return services.CreateOrder(orderDto);

        }


        [HttpGet("orders")]/*//returns all of the orders*/
        public List<Order> Orders()
        {

            MyServices services = new MyServices();
            return services.GetOrders(12);

        }


        [HttpGet("customer/{id}/orders")]
        public ReturnData<List<Order>> GetOrdersByCustomerId([FromRoute] int id)
        {
            MyServices services = new MyServices();
            return services.GetOrdersByCustomerId(id);
        }


        [HttpGet("customer/{id}/order/{orderid}")]// gets a specific orders of a customer
        public ReturnData<Order> GetOrderByCustomerIdAndByOrderId([FromRoute] int id
            , [FromRoute] int orderid)
        {
            MyServices services = new MyServices();
            return services.GetOrderByCustomerIdAndByOrderId(id, orderid);



        }




        [HttpPut("customer/{id}")] /*updates a specific customer*/

        public ReturnData<Customer> UpdateCustomer([FromRoute] int id
            , [FromBody] CustomerDto customerDto)
        {
            MyServices services = new MyServices();
            return services.UpDateCustomer(customerDto, id);


        }

        [HttpGet("customerByName/{name}")]
        public ReturnData<List<Customer>> GetCustomerByName([FromRoute] string name)
        {

            MyServices services = new MyServices();
            return services.GetCustomerByName(name);


        }



        //PRODUCTS



        [HttpPost("product")]//creats product
        public ReturnData<Product> CreateProduct([FromBody] ProductDtos productDtos)
        {
            MyServices services = new MyServices();
            return services.CreateProduct(productDtos);

        }

        [HttpGet("products")]//gets the list of the first 3 products
        public ReturnData<List<Product>> GetProduct()
        {
            MyServices services = new MyServices();
            return services.GetProducts(3);

        }

        [HttpGet("product/{id}")]//get product by id
        public ReturnData<Product> GetProductById([FromRoute] int id)
        {
            MyServices services = new MyServices();
            return services.GetProductById(id);

        }

        [HttpGet("productByName/{name}")]
        public ReturnData<List<Product>> GetProductByName([FromRoute] string name)
        {

            MyServices services = new MyServices();
            return services.GetProductByName(name);
        }

        [HttpPost("customer/{id}/order")]
        public ReturnData<List<Product>> CreatListOfProductsByOrder([FromRoute] int id
            ,[FromBody] List<ProductDtos> productDtos)
        {

            MyServices services = new MyServices();
            return services.CreateListOfProductsByOrder(id, productDtos);


        }



    }
}
