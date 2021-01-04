using Courier_Management_REST_WEB_API.Models;
using Courier_Management_REST_WEB_API.Report;
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

        public CustomerReportData Report(int id)
        {
            UserRepository userRepo = new UserRepository();
            ProductRepository proRepo = new ProductRepository();
            CustomerReportData crd = new CustomerReportData();

            crd.Name = this.GetByUid(id).Name;
            crd.TotalFinishedDelivery = proRepo.GetAll().Where<Product>(x => x.Customer_id == id && x.Product_State == 4).Count();
            crd.TotalPendingDelivery = proRepo.GetAll().Where<Product>(x => x.Customer_id == id && x.Product_State != 4).Count();
            List<Product> pro = proRepo.GetAll().Where<Product>(x => x.Customer_id == id).ToList();
            int e=0,m=0,a=0,p=0,pk=0;
            double count = 0;
            foreach (var item in pro)
            {
                count += item.Delivery_charge;
                if(item.ProductCategory == 0)
                {
                    e++;
                }
                else if(item.ProductCategory == 1)
                {
                    m++;
                }
                else if (item.ProductCategory == 2)
                {
                    a++;
                }
                else if (item.ProductCategory == 3)
                {
                    p++;
                }
                else if (item.ProductCategory == 4)
                {
                    pk++;
                }
            }
            crd.TotalElectronisSent = e;
            crd.TotalMobilesSent = m;
            crd.TotalAccessoriesSent = a;
            crd.TotalPapersSent = p;
            crd.TotalPackagesSent = pk;
            crd.totalSpentMoney = count;
            return crd;
        }

        public void UpdateU(Customer c)
        {
            Customer nc = GetByUid(c.userId);
            nc.Name = c.Name;
            nc.Contact = c.Contact;
            nc.Address = c.Address;
            nc.SequrityQue = c.SequrityQue;
            nc.UpdatedDate = DateTime.Now;
            Update(nc);
        }

    }
}