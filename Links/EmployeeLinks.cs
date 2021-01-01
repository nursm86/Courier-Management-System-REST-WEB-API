using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Courier_Management_REST_WEB_API.Links
{
    public class EmployeeLinks
    {
        static List<Link> links = new List<Link>();
        public static List<Link> getLinks(int id = 0, int r = 0)
        {
            if (r == 1)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/" + id, Method = "GET", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/" + id, Method = "GET", Relation = "Get employee Dashboard" });

            }
            if (r == 2)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/Customer/" + id +"/profile", Method = "GET", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/Customer/" + id +"/profile", Method = "GET", Relation = "Get employee Profile" });
            }
            if (r == 3)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/Customer/" + id +"/profile", Method = "PUT", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/Customer/" + id +"/profile", Method = "PUT", Relation = "Modify Existing employee Information" });
            }
            if (r == 4)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/Customer/" + id +"/updateProfile", Method = "PUT", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/Customer/" + id + "/updateProfile", Method = "PUT", Relation = "Update Existing Employee's Information" });
            }
            if (r == 5)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/" + id + "/serviceHistory", Method = "GET", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/" + id + "/serviceHistory", Method = "GET", Relation = "Get Service history of the Employee" });
            }
            if (r == 6)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/CustomersList", Method = "GET", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/CustomersList", Method = "GET", Relation = "Get All the Customeer's List" });
            }
            if (r == 7)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/Customer/" + id, Method = "GET", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/Customer/" + id, Method = "GET", Relation = "Get a specific Customer's Information" });
            }
            if (r == 8)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/Customer/" + id + "verify", Method = "PUT", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/Customer/" + id + "verify", Method = "PUT", Relation = "Verify a specific Customer" });
            }
            if (r == 9)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/Customer/" + id + "block", Method = "PUT", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/Customer/" + id + "block", Method = "PUT", Relation = "Block A specific Customer" });
            }
            if (r == 10)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/Customer/" + id + "unblock", Method = "PUT", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/Customer/" + id + "unblock", Method = "PUT", Relation = "Unblock A specific Customer" });
            }
            if (r == 11)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/createCustomer", Method = "POST", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/createCustomer", Method = "POST", Relation = "Create a New Customer" });
            }
            if (r == 12)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/" + id + "/receivedProducts", Method = "GET", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/" + id + "/receivedProducts", Method = "GET", Relation = "Get All the Received Products" });
            }

            if (r == 13)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/Product" + id, Method = "GET", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/Product" + id, Method = "GET", Relation = "Get a Specific Product" });
            }

            if (r == 14)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/" + id + "/shipableProducts", Method = "GET", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/" + id + "/shipableProducts", Method = "GET", Relation = "Get All the shipable Products" });
            }

            if (r == 15)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/" + id + "/releaseAbleProducts", Method = "GET", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/" + id + "/releaseAbleProducts", Method = "GET", Relation = "Get All the releaseAble Products" });
            }

            if (r == 16)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/" + id + "/receiveProductFromCustomer/{pid}", Method = "PUT", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/" + id + "/receiveProductFromCustomer/{pid}", Method = "PUT", Relation = "Receive a specific Products from a customer" });
            }

            if (r == 17)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/" + id + "/receiveProductFromBranch/{pid}", Method = "PUT", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/" + id + "/receiveProductFromBranch/{pid}", Method = "PUT", Relation = "Receive a specific Products from different Branch" });
            }
            if (r == 18)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/" + id + "/shipProduct/{pid}", Method = "PUT", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/" + id + "/shipProduct/{pid}", Method = "PUT", Relation = "Ship a specific Product from a specific Branch" });
            }
            if (r == 19)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/" + id + "/releaseProduct/{pid}", Method = "PUT", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/" + id + "/releaseProduct/{pid}", Method = "PUT", Relation = "release Product from a specific Branch" });
            }
            if (r == 20)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/" + id + "/helpline", Method = "POST", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/" + id + "/helpline", Method = "POST", Relation = "Create a new Help post" });
            }

            if (r == 21)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/" + id + "/updatePassword", Method = "PUT", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/employee/" + id + "/updatePassword", Method = "PUT", Relation = "Change employees Password" });
            }
            return links;
        }
    }
}