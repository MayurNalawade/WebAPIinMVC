using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class ItemListController : Controller
    {
        // GET: ItemList
        public ActionResult Index()
        {
            IEnumerable<mvcItems> itemList;
            HttpResponseMessage response = GlobalVariables.webClient.GetAsync("ItemLists/GetItemList").Result;
            itemList = response.Content.ReadAsAsync<IEnumerable<mvcItems>>().Result;
            return View(itemList);
        }

        public ActionResult AddOrEditItem(int id=0)
        {
            if (id == 0)
                return View(new mvcItems());
            else
            {
                HttpResponseMessage reponse = GlobalVariables.webClient.GetAsync("ItemLists/GetItem/"+id.ToString()).Result;
                return View(reponse.Content.ReadAsAsync<mvcItems>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEditItem(mvcItems items)
        {
            if (items.ItemID == 0)
            {
                HttpResponseMessage reponse = GlobalVariables.webClient.PostAsJsonAsync("ItemLists/PostItem", items).Result;
                TempData["SuccessMessge"] = "Saved Successfully";
            }
            else {
                HttpResponseMessage reponse = GlobalVariables.webClient.PutAsJsonAsync("ItemLists/PutItem/"+items.ItemID, items).Result;
                TempData["SuccessMessge"] = "Updated Successfully";
            }
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage reponse = GlobalVariables.webClient.DeleteAsync("ItemLists/DeleteItem/" + id.ToString()).Result;
            TempData["SuccessMessge"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}