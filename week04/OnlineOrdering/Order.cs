using System;
using System.Collections.Generic;

namespace OnlineOrdering
{
    public class Order
    {
        private List<Product> _products;
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        public List<Product> Products
        {
            get { return _products; }
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public double GetTotalCost()
        {
            double total = 0;
            foreach (Product product in _products)
            {
                total += product.GetTotalCost();
            }
            
            double shippingCost = _customer.IsInUSA() ? 5 : 35;
            total += shippingCost;
            return total;
        }

        public string GetPackingLabel()
        {
            string label = "Packing Label:\n";
            foreach (Product product in _products)
            {
                label += $"Product Name: {product.Name}, Product ID: {product.ProductId}\n";
            }
            return label;
        }

        public string GetShippingLabel()
        {
            string label = "Shipping Label:\n";
            label += $"Customer: {_customer.Name}\n";
            label += "Address:\n" + _customer.Address.GetFullAddress() + "\n";
            return label;
        }
    }
}
