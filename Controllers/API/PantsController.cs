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
    public class PantsController : ApiController
    {
        static string connectionString = "Data Source=.;Initial Catalog=SportShopDB;Integrated Security=True;Pooling=False";
        ShoesContextDataContext PantsContextDataContext = new ShoesContextDataContext(connectionString);

        // GET: api/Pants
        public IHttpActionResult Get()
        {
            try
            {
                List<Clothing> pants= PantsContextDataContext.Clothings.Where(pantsItem=>pantsItem.TypeOfCloths == "pants" || pantsItem.TypeOfCloths == "long pants").ToList();
                return Ok(new {PANTS = pants });
            }
            catch(SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // GET: api/Pants/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                Clothing pants=PantsContextDataContext.Clothings.First(pantsItem => pantsItem.Id == id);
                return Ok(pants);
            }
            catch(SqlException ex)
            {
                return BadRequest(ex.Message);    
            }
            catch(Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        // POST: api/Pants
        public IHttpActionResult Post([FromBody]Clothing addPants)
        {
            try
            {
                PantsContextDataContext.Clothings.InsertOnSubmit(addPants);
                PantsContextDataContext.SubmitChanges();
                return Ok("Pants was Added Successfully");
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

        // PUT: api/Pants/5
        public IHttpActionResult Put(int id, [FromBody] Clothing updatePants)
        {
            try
            {
                Clothing pantsToUpdate=PantsContextDataContext.Clothings.First(pantsItem =>pantsItem.Id == id);
                if(pantsToUpdate.TypeOfCloths != null)
                {
                    pantsToUpdate.Id = updatePants.Id;
                    pantsToUpdate.TypeOfCloths = updatePants.TypeOfCloths;
                    pantsToUpdate.Gender = updatePants.Gender;
                    pantsToUpdate.Company = updatePants.Company;
                    pantsToUpdate.Brand = updatePants.Brand;
                    pantsToUpdate.Quantity = updatePants.Quantity;
                    pantsToUpdate.Price = updatePants.Price;
                    pantsToUpdate.IsShort = updatePants.IsShort;
                    pantsToUpdate.IsDryfit = updatePants.IsDryfit;
                    pantsToUpdate.Picture = updatePants.Picture;
                    pantsToUpdate.TeamId = updatePants.TeamId;
                    PantsContextDataContext.SubmitChanges();
                    return Ok("Pants was Updated Successfully");
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

        // DELETE: api/Pants/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Clothing pantsToDelete = PantsContextDataContext.Clothings.First(pantsItem => pantsItem.Id == id);
                PantsContextDataContext.Clothings.DeleteOnSubmit(pantsToDelete);
                PantsContextDataContext.SubmitChanges();
                return Ok("Pants was Updated Successfully");
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
