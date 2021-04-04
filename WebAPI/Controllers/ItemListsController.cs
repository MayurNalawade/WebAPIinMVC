using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ItemListsController : ApiController
    {
        private DBModelNew db = new DBModelNew();

        // GET ItemList of created itens
        public IQueryable<ItemList> GetItemList()
        {
            return db.ItemLists;
        }

        // GET ItemList of created itens by ID
        [ResponseType(typeof(ItemList))]
        public IHttpActionResult GetItem(int? id)
        {
            ItemList item = db.ItemLists.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // Update ItemList of created itens
        public IHttpActionResult PutItem(int id,ItemList item)
        {
             
            if (id != item.ItemID)
            {
                return BadRequest();
            }
            db.Entry(item).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch {
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // ADD new Item to ItemList 
        public IHttpActionResult PostItem(ItemList itemList)
        {
            
            db.ItemLists.Add(itemList);
            db.SaveChanges();

            return CreatedAtRoute("GetItemList",new { id = itemList.ItemID},itemList);
        }

        // Delete Item from ItemList 
        [ResponseType(typeof(ItemList))]
        public IHttpActionResult DeleteItem(int id)
        {
            ItemList item = db.ItemLists.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            db.ItemLists.Remove(item);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }


    }
}
