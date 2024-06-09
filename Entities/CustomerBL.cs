using AutoMapper;
using Pine.Task.BL.BLEntities;
using Pine.Task.Data;
using Pine.Task.Data.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pine.Task.BL
{
    public class CustomerBL
    {
        Database Repository = new Database();
        public Customer GetCustomer(int id)
        {
            var customer = Repository.GetCustomer(id);
            return MapData<CustomerData, Customer, Customer>(customer);
        }
        public bool DeleteCustomer(int id)
        {
            return Repository.DeleteCustomer(id);
        }
        public List<Customer> GetCustomerList()
        {
            var customers = Repository.GetAll();
            return MapData<CustomerData, Customer, List<Customer>>(customers);
           
        }
        public bool CreateCustomer(Customer customer)
        {
            var customerData = MapData<Customer,CustomerData,CustomerData>(customer);
            return Repository.CreateCustomer(customerData);
        }
        public bool UpdateCustomer(Customer customer)
        {
            var customerData = MapData<Customer, CustomerData, CustomerData>(customer);
            return Repository.UpdateCustomer(customerData);
        }
        T3 MapData<T1, T2, T3>(object data)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<T1, T2>());
            var mapper = new Mapper(config);
            return mapper.Map<T3>(data);
        }

    }
}
