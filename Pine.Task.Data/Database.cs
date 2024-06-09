using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pine.Task.Data.DataEntities;

namespace Pine.Task.Data
{

    public class Database
    {
        public static List<CustomerData> customerData = new List<CustomerData>
        {
            new CustomerData()
            {
                Id=1,
                Name = "John",
                Address="26A",
                City="London",
                Mobile="00001"
            },
            new CustomerData()
            {
                Id = 2,
                Name = "Smith",
                Address = "25A",
                City = "Manchester",
                Mobile = "00002"
            },
            new CustomerData()
            {
                Id = 3,
                Name = "Doe",
                Address = "24",
                City = "Liverpool",
                Mobile = "00003"
            },new CustomerData()
            {
                Id = 4,
                Name = "Ben",
                Address = "240",
                City = "Birmingham",
                Mobile = "00004"
            },new CustomerData()
            {
                Id = 5,
                Name = "David",
                Address = "21",
                City = "Bristol",
                Mobile = "00005"
            }

    };

        public bool CreateCustomer(CustomerData customer)
        {
            try
            {
                var maxId = customerData.Max(e => e.Id);
                customer.Id = maxId + 1;
                customerData.Add(customer);
                return true;
            }
            catch
            {

                return false;
            }

        }
        public bool UpdateCustomer(CustomerData customer)
        {
            try
            {
                var custom = customerData.FirstOrDefault(e => e.Id == customer.Id);
                if (custom != null)
                {
                    custom.Name = customer.Name;
                    custom.Address = customer.Address;
                    custom.City = customer.City;
                    custom.Mobile = customer.Mobile;

                }
                return true;
            }
            catch
            {

                return false;
            }


        }
        public bool DeleteCustomer(int id)
        {
            try
            {
                var deletedata = customerData.FirstOrDefault(e => e.Id == id);
                if (deletedata != null)
                {
                    customerData.Remove(deletedata);

                }
                return true;
            }
            catch
            {

                return false;
            }
          
           
        }
        public CustomerData GetCustomer(int id)
        {
            return customerData.FirstOrDefault(e => e.Id == id);
        }
        public List<CustomerData> GetAll()
        {
            return customerData;
        }
    }



}
