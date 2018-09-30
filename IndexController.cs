/* Names: (Team 1-3) Tiara Johnson, HaiJUng Hsu, Bailey Coleman, and Ethan Guinn
   Class: IS 403 Section 1
   Description: This program tracks the line order of customers and
                displays the total number of hamburgers each customer
                has ordered.
   Date: 9/28/2018
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructures.Controllers
{
    public class IndexController : Controller
    {
        public static Random random = new Random();

        //Generate a random name
        public static string randomName()
        {
            string[] names = new string[8] { "Dan Morain", "Emily Bell", "Carol Roche", "Ann Rose", "John Miller", "Greg Anderson", "Arthur McKinney", "Joann Fisher" };
            int randomIndex = Convert.ToInt32(random.NextDouble() * 7);
            return names[randomIndex];
        }

        //Generate a random number
        public static int randomNumberInRange()
        {
            return Convert.ToInt32(random.NextDouble() * 20);
        }

        // GET: Index
        public ActionResult Index()
        {
            //Create new queue
            Queue<string> custQueue = new Queue<string>();
            //Create new Dictionary
            Dictionary<string, int> custOrder = new Dictionary<string, int>();

            //Add 100 customers to the queue
            for (int i = 0; i < 100; i++)
            {
                custQueue.Enqueue(randomName());
            }

            //add no. of burgers for every customer
            foreach (string customer in custQueue)
            {
                if (custOrder.ContainsKey(customer))
                {
                    custOrder[customer] += randomNumberInRange();
                }
                else
                {
                    custOrder.Add(customer, randomNumberInRange());
                }
            }

            //Sort values in descending order
            var ordered = custOrder.OrderByDescending(x => x.Value);

            ViewBag.Output = "<table>";
            ViewBag.Output += "<tr>";
            ViewBag.Output += "<th>Customer</th>";
            ViewBag.Output += "<th>Burgers</th>";
            ViewBag.Output += "</tr>";

            //access dictonary to show keys and values in the table
            foreach (KeyValuePair<string, int> customer in ordered)
            {
                ViewBag.Output += "<tr> <td>" + customer.Key + "</td>";
                ViewBag.Output += "<td>" + customer.Value + "</td> </tr>";
            }
            ViewBag.Output += "</table>";

            return View();
        }
    }
}