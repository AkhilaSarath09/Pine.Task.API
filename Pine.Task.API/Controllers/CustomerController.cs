using Pine.Task.BL;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

using System.Runtime.InteropServices.WindowsRuntime;
using AutoMapper;

using Pine.Task.BL.BLEntities;


namespace Pine.Task.API.Controllers
{
    public class CustomerController : ApiController
    {
       CustomerBL customerBL = new CustomerBL();
        [HttpGet]
        public Customer getCustomer(int id)
        {
            return customerBL.GetCustomer(id);

        }
        [HttpGet]
        public List<Customer> getAllCustomer()
        {
            return customerBL.GetCustomerList();

        }
        [HttpPost]
        public bool CreateCustomer(Customer customer)
        {
            return customerBL.CreateCustomer(customer);
        }
        [HttpPost]
        public bool UpdateCustomer(Customer customer) { 
        
            return customerBL.UpdateCustomer(customer);
        }
        [HttpPost]
        public bool DeleteCustomer(int id)
        {
            return customerBL.DeleteCustomer(id);
        }
    }
}
