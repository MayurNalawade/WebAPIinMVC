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
        // Fetch all list of inventory items
        public ActionResult Index()
        {
            IEnumerable<mvcItems> itemList;
            //call API to get Item lists
            HttpResponseMessage response = GlobalVariables.webClient.GetAsync("ItemLists/GetItemList").Result;
            itemList = response.Content.ReadAsAsync<IEnumerable<mvcItems>>().Result;
            return View(itemList);
        }

        //To add/edit item by passing item ID
        public ActionResult AddOrEditItem(int id=0)
        {
            if (id == 0)
                return View(new mvcItems());
            else
            {
                //call API by passing Item id
                HttpResponseMessage reponse = GlobalVariables.webClient.GetAsync("ItemLists/GetItem/"+id.ToString()).Result;
                return View(reponse.Content.ReadAsAsync<mvcItems>().Result);
            }
        }

        //Post method to Save or update Items
        [HttpPost]
        public ActionResult AddOrEditItem(mvcItems items)
        {
            //if item is not available the add else update by calling API
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

        //Call to delete Item from list
        public ActionResult Delete(int id)
        {
            //Call API and pass Id of item to delete item
            HttpResponseMessage reponse = GlobalVariables.webClient.DeleteAsync("ItemLists/DeleteItem/" + id.ToString()).Result;
            TempData["SuccessMessge"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}