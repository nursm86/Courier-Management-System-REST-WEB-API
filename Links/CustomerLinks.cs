using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Courier_Management_REST_WEB_API.Links
{
    public class CustomerLinks
    {
        static List<Link> links = new List<Link>();
        public static List<Link> getLinks(int id = 0, int r = 0)
        {
            if (r == 1)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/customer/" + id, Method = "GET", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/customer" + id, Method = "GET", Relation = "Get customer Dashboard" });

            }
            if (r == 2)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/customer/" + id + "/profile", Method = "GET", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/customer/" + id + "/profile", Method = "GET", Relation = "Get customer's Profile" });
            }
            if (r == 3)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/customer/" + id + "/profile", Method = "PUT", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/customer/" + id + "/profile", Method = "PUT", Relation = "Modify Existing customer's Information" });
            }
            if (r == 4)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/customer/" + id + "/TrackProducts", Method = "GET", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/customer/" + id + "/TrackProducts", Method = "GET", Relation = "Track All the Products Sent By the Customer" });
            }
            if (r == 5)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/customer/" + id + "/serviceHistory", Method = "GET", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/customer/" + id + "/serviceHistory", Method = "GET", Relation = "Get The Service History of the Customer" });
            }
            if (r == 6)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/customer/" + id + "/newOrder", Method = "POST", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/customer/" + id + "/newOrder", Method = "POST", Relation = "Create a New Order to sent Products" });
            }
            if (r == 7)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/customer/" + id + "/password", Method = "PUT", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/customer/" + id + "/password", Method = "PUT", Relation = "Change customers Password" });
            }
            return links;
        }
    }
}