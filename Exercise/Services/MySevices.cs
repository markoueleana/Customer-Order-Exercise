using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercise.Dtos;
using Exercise.Models;

namespace Exercise.Services
{
    public class MyServices
    {

        public Customer Customer { set; get; }
        public Customer CreateCustomer(CustomerDto customerDto)
        {
            Customer c = new Customer()
            {
                Name = customerDto.Name,
                Address = customerDto.Address + "GR"


            };

            using ExerciseDbContent exercise = new ExerciseDbContent();
            exercise.Customers.Add(c);
            exercise.SaveChanges();

            return c;

        }
        public Order CreateOrder(OrderDto orderDto)
        {

            Order order = new Order()
            {

                Customer = orderDto.Customer,
                CustomerId = orderDto.CustomerId,
                Date = orderDto.Date,



            };

            using ExerciseDbContent exercise = new ExerciseDbContent();
            exercise.Orders.Add(order);
            exercise.SaveChanges();

            return order;

        }

        public List<Customer> GetCustomers(int howmany)
        {


            List<Customer> customers;
            using ExerciseDbContent exercise = new ExerciseDbContent();
            customers = exercise.Customers
                .Take(howmany)
                .ToList();
            return customers;
        }

        public ReturnData<Customer> GetCustomerId(int id)
        {

            using ExerciseDbContent exercise = new ExerciseDbContent();
            Customer customer = exercise.Customers.Find(id);
            return new ReturnData<Customer>
            {

                Data = customer,
                Error = (customer == null) ? 1 : 0,
                Description = (customer == null) ? "No such student" : "ok"

            };
        }

        public void Read(int id)
        {
            using ExerciseDbContent db = new ExerciseDbContent();
            Customer = db.Customers.Find(id);
        }

        public ReturnData<Customer> UpDateCustomer(CustomerDto customerDto, int id)
        {
            using ExerciseDbContent exercise = new ExerciseDbContent();

            Customer customer = exercise.Customers.Find(id);

            if (customer == null)
            {
                return new ReturnData<Customer>
                {
                    Error = 1,
                    Description = $"NO such customer{customer.Id}"
                };
            }



            if (customerDto.Name != null)
            {
                customer.Name = customerDto.Name;
            }
            if (customerDto.Address != null)
            {
                customer.Address = customerDto.Address;
            }

            exercise.SaveChanges();

            return new ReturnData<Customer>
            {
                Data = customer,
                Error = 0,
                Description = $"Customer {customer.Id} updated"
            };

        }

        public ReturnData<List<Customer>> GetCustomerByName(string cname)
        {
            using ExerciseDbContent exercise = new ExerciseDbContent();
            List<Customer> customers =
                exercise.Customers.Where(c => c.Name.StartsWith(cname)).ToList();

            return new ReturnData<List<Customer>>
            {
                Data = customers,
                Error = (customers == null) ? 1 : 0,
                Description = (customers == null) ? "no such customer" : "ok"

            };

        }
        public void Delete(int id)
        {
            using ExerciseDbContent db = new ExerciseDbContent();
            Customer = db.Customers.Find(id);
            if (Customer != null)
            {
                db.Customers.Remove(Customer);
            }

            db.SaveChanges();
        }


        public List<Order> GetOrders(int howmany)
        {


            List<Order> orders;
            using ExerciseDbContent exercise = new ExerciseDbContent();
            orders = exercise.Orders
                .Take(howmany)
                .ToList();
            return orders;
        }


        public ReturnData<List<Order>> GetOrdersByCustomerId(int id)
        {

            using ExerciseDbContent exercise = new ExerciseDbContent();

            List<Order> orders = exercise.Orders.Where(o => o.CustomerId == id).ToList();



            return new ReturnData<List<Order>>
            {
                Data = orders,
                Error = (orders == null) ? 0 : 1,
                Description = (orders == null) ? "No such order" : "ok"

            };

        }


        public ReturnData<Order> GetOrderByCustomerIdAndByOrderId(int customerid, int orderid)
        {
            using ExerciseDbContent exercise = new ExerciseDbContent();

            List<Order> orders = exercise.Orders.Where(o => o.CustomerId == customerid
            && o.Id == orderid).ToList();

            if (orders.Count() == 1)
            {
                return new ReturnData<Order>
                {
                    Data = orders.First(),
                    Error = (orders.First() == null) ? 1 : 0,
                    Description = (orders.First() == null) ? "No such order" : "ok"

                };
            }
            return new ReturnData<Order>
            {
                Error = 1,
                Description = "No such order"

            };
        }

        public ReturnData<Product> CreateProduct(ProductDtos productDtos)
        {
            Product product = new Product
            {
                Id = productDtos.Id,
                Name = productDtos.Name,
                Price = productDtos.Price
            };
            using ExerciseDbContent exercise = new ExerciseDbContent();
            exercise.Products.Add(product);
            exercise.SaveChanges();
            return new ReturnData<Product>
            {
                Data = product,
                Error = (product == null) ? 0 : 1,
                Description = (product == null) ? "emply product" : "ok"
            };

        }
        public ReturnData<List<Product>> GetProducts(int howmany)
        {
            List<Product> products;
            using ExerciseDbContent exercise = new ExerciseDbContent();
            products = exercise.Products.Take(howmany).ToList();
            return new ReturnData<List<Product>>
            {
                Data = products,
                Error = (products == null) ? 1 : 0,
                Description = (products == null) ? "empty list of products" : "ok"


            };

        }

        public ReturnData<Product> GetProductById(int id)
        {
            List<Product> product = new List<Product>();
            using ExerciseDbContent exercise = new ExerciseDbContent();
            product = exercise.Products.Where(p => p.Id.Equals(id)).ToList();

            if (product.Count != 0)
            {
                return new ReturnData<Product>
                {
                    Data = product.First(),
                    Error = (product.First() == null) ? 1 : 0,
                    Description = (product.First() == null) ? "No such product id" : "ok"

                };
            }
            else
            {
                return new ReturnData<Product>
                {

                    Data = null,
                    Error = 1,
                    Description = "No such product id"

                };
            }
        }

        public ReturnData<List<Product>> GetProductByName(string name)
        {

            using ExerciseDbContent exercise = new ExerciseDbContent();
            List<Product> products = new List<Product>();
            products = exercise.Products.Where(p => p.Name.Contains(name)).ToList();
            if (products != null)
            {

                return new ReturnData<List<Product>>
                {
                    Data = products,
                    Error = (products == null) ? 1 : 0,
                    Description = (products == null) ? "No such product" : "ok"
                };

            }
            else {

                return new ReturnData<List<Product>>
                {

                    Data = null,
                    Error = 1,
                    Description = "No such product"
                };

            }


        }


        public ReturnData<List<Product>> CreateListOfProductsByOrder(int id, List<ProductDtos> productDtos)
        {
            using ExerciseDbContent db = new ExerciseDbContent();
            Customer = db.Customers.Find(id);
            List<Order> orders = new List<Order>();
            List<OrderProduct> orderProducts = new List<OrderProduct>();

            List<Product> products = new List<Product>();
            products.AddRange(db.Products);

            
            foreach (Product product in products)
            {
                foreach (ProductDtos productDto in productDtos)
                {
                    if (product.Name == productDto.Name)
                    {
                        product.Name = productDto.Name;
                        product.Id = productDto.Id;
                    }
                    else
                    {

                     products.Remove(product);
                    }

                }
                        
             }
            foreach (Product product in products)
            {
                OrderProduct orderProduct = new OrderProduct
                {

                    Product = product

                };
                orderProducts.Add(orderProduct);
            }
            foreach (OrderProduct orderProduct1 in orderProducts)
            {
                Order order = new Order
                {
                    OrderProduct = orderProducts

                };
                Customer.Orders.Add(order);


            }
            
           
            return new ReturnData<List<Product>>
            {
                Data= products,
                Error=(products==null)?1:0,
                Description=(products==null)?"no creation was made":"ok"

            };









        }

    }

    
}

         