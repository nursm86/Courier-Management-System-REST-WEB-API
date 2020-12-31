using Courier_Management_REST_WEB_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Courier_Management_REST_WEB_API.Repositories
{
    public class CustomerRepository:Repository<Customer>
    {
        public Customer GetByUid(int id)
        {
            return this.GetAll().Where<Customer>(x => x.userId == id).FirstOrDefault();
        }

        public void UpdateU(Customer c)
        {
            Customer nc = GetByUid(c.userId);
            nc.Name = c.Name;
            nc.Contact = c.Contact;
            nc.Address = c.Address;
            nc.UpdatedDate = DateTime.Now;
            Update(nc);
        }

    }
}