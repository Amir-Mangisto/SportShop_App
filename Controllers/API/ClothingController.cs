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
    public class ClothingController : ApiController
    {
       public  static string connectionString = "Data Source=.;Initial Catalog=SportShopDB;Integrated Security=True;Pooling=False";
       public  ShoesContextDataContext ClothingContextDataContext = new ShoesContextDataContext(connectionString);

        // GET: api/Clothing
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(new { MESS = ClothingContextDataContext.Clothings.ToList() });
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // GET: api/Clothing/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Clothing cloth=ClothingContextDataContext.Clothings.First(clothItem=>clothItem.Id == id);
                return Ok(cloth);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }

        }

        // POST: api/Clothing
        public IHttpActionResult Post([FromBody] Clothing addCloth)
        {
            try
            {
                ClothingContextDataContext.Clothings.InsertOnSubmit(addCloth);
                ClothingContextDataContext.SubmitChanges();
                return Ok("Cloth was Added Successfully");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // PUT: api/Clothing/5
        public IHttpActionResult Put(int id, [FromBody] Clothing updateCloth)
        {
            try
            {
                Clothing clothToUpdate = ClothingContextDataContext.Clothings.First(clothItem => clothItem.Id == id);
                if (clothToUpdate.TypeOfCloths != null)
                {
                    clothToUpdate.Id = updateCloth.Id;
                    clothToUpdate.TypeOfCloths = updateCloth.TypeOfCloths;
                    clothToUpdate.Gender = updateCloth.Gender;
                    clothToUpdate.Company=updateCloth.Company;
                    clothToUpdate.Brand = updateCloth.Brand;
                    clothToUpdate.Quantity = updateCloth.Quantity;
                    clothToUpdate.Price = updateCloth.Price;
                    clothToUpdate.IsShort= updateCloth.IsShort;
                    clothToUpdate.IsDryfit= updateCloth.IsDryfit;
                    clothToUpdate.Picture = updateCloth.Picture;
                    clothToUpdate.TeamId = updateCloth.TeamId;
                    ClothingContextDataContext.SubmitChanges();
                    return Ok("Cloth was Update Successfully");
                }
                else { return NotFound(); }
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // DELETE: api/Clothing/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Clothing clothToDelete = ClothingContextDataContext.Clothings.First(clothItem => clothItem.Id == id);
                ClothingContextDataContext.Clothings.DeleteOnSubmit(clothToDelete);
                ClothingContextDataContext.SubmitChanges();
                return Ok("Cloth was Deleted Successfully");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
