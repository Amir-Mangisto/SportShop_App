using SportShop_App.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SportShop_App.Controllers.API
{
    public class ShoesController : ApiController
    {
        static string stringConnection = "Data Source=.;Initial Catalog=SportShopDB;Integrated Security=True;Pooling=False";
        ShoesContextDataContext ShoesContext = new ShoesContextDataContext(stringConnection);
        // GET: api/Shoes
        public IHttpActionResult Get()
        {
            try
            {
                List<Shoe> shoesList = ShoesContext.Shoes.ToList();
                return Ok(shoesList);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return Ok(err.Message);
            }
        }

        // GET: api/Shoes/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Shoe shoe=ShoesContext.Shoes.First(shoeItem => shoeItem.Id == id);
                return Ok(shoe);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return Ok(err.Message);
            }
        }

        // POST: api/Shoes
        public IHttpActionResult Post([FromBody] Shoe addShoe)
        {
            try
            {
                ShoesContext.Shoes.InsertOnSubmit(addShoe);
                ShoesContext.SubmitChanges();
                return Ok("Shoe was Added Successfully");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return Ok(err.Message);
            }
        }

        // PUT: api/Shoes/5
        public IHttpActionResult Put(int id, [FromBody] Shoe updateShoe)
        {
            try
            {
                Shoe shoeToUpdate = ShoesContext.Shoes.First(shoeItem => shoeItem.Id == id);
                if(shoeToUpdate.ShoeType != null)
                {
                    shoeToUpdate.Id=updateShoe.Id;
                    shoeToUpdate.ShoeType = updateShoe.ShoeType;
                    shoeToUpdate.Company=updateShoe.Company;
                    shoeToUpdate.Brand=updateShoe.Brand;
                    shoeToUpdate.Price=updateShoe.Price;
                    shoeToUpdate.Quantity=updateShoe.Quantity;
                    shoeToUpdate.OnSale=updateShoe.OnSale;
                    shoeToUpdate.Picture=updateShoe.Picture;
                    ShoesContext.SubmitChanges();
                    return Ok("Shoe was Updated Successfully");
                }
                else { return NotFound(); }
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return Ok(err.Message);
            }
        }

        // DELETE: api/Shoes/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Shoe shoeToDelete = ShoesContext.Shoes.First(shoeItem => shoeItem.Id == id);
                ShoesContext.Shoes.DeleteOnSubmit(shoeToDelete);
                ShoesContext.SubmitChanges();
                return Ok("Shoe was Deleted Successfully");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return Ok(err.Message);
            }
        }
    }
}
