using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Courier_Management_REST_WEB_API.Links
{
    public class AdminLinks
    {
        static List<Link> links = new List<Link>();
        public static List<Link> getLinks(int id=0, int r=0)
        {
            if(r == 1)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/admin/"+id, Method = "GET", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/admin/"+id, Method = "GET", Relation = "Get Admin Dashboard" });

            }
            if(r == 2)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/admin/" + id + "/profile", Method = "GET", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/admin/" + id + "/profile", Method = "GET", Relation = "Get Admin Profile" });
            }
            if (r == 3)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/admin/" + id + "/profile", Method = "PUT", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/admin/" + id + "/profile", Method = "PUT", Relation = "Modify Existing Admin Information" });
            }
            if (r == 4)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/admin/branchlist", Method = "GET", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/admin/branchlist", Method = "GET", Relation = "Get All the Branch" });
            }
            if (r == 5)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/admin/branch/" + id, Method = "GET", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/admin/branch/" + id, Method = "GET", Relation = "Get a Specific Branch's Informaiton" });
            }
            if (r == 6)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/admin/addbranch", Method = "POST", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/admin/addbranch", Method = "POST", Relation = "Create a New Branch" });
            }
            if (r == 7)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/admin/allEmployee", Method = "GET", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/admin/allEmployee", Method = "GET", Relation = "Get All Employee" });
            }
            if (r == 8)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/admin/Employee/" + id, Method = "GET", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/admin/Employee/" + id, Method = "GET", Relation = "Get Specific Employee's Information" });
            }
            if (r == 9)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/admin/Employee/" + id, Method = "PUT", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/admin/Employee/" + id, Method = "PUT", Relation = "Update a specific Employee's Information" });
            }
            if (r == 10)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/admin/addEmployee", Method = "POST", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/admin/addEmployee", Method = "POST", Relation = "Create a New Employee" });
            }
            if (r == 11)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/admin/employeeProblems", Method = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/admin/employeeProblems", Method = "GET", Relation = "Get All the Employee Problems" });
            }
            if(r == 12)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/admin/solveProblem/" + id, Method = "DELETE", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/admin/solveProblem/" + id, Method = "DELETE", Relation = "Delete a specific Problem" });
            }
            if(r == 13)
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/admin/" + id + "/password", Method = "PUT", Relation = "Self" });
            }
            else
            {
                links.Add(new Link() { Url = "http://localhost:55484/api/admin/" + id + "/password", Method = "PUT", Relation = "Change Admins Password" });
            }

            return links;
        }
    }
}