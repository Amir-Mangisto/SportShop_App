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
    public class SportEquipmentController : ApiController
    {
        static string stringConnection = "Data Source=.;Initial Catalog=SportShopDB;Integrated Security=True;Pooling=False";
        ShoesContextDataContext SporteqContext = new ShoesContextDataContext(stringConnection);

        // GET: api/SportEquipment
        public IHttpActionResult Get()
        {
            try
            {
                List<SportEQ> sportEqList=SporteqContext.SportEQs.ToList();
                return Ok(sportEqList);
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

        // GET: api/SportEquipment/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                SportEQ eq=SporteqContext.SportEQs.First(eqItem=>eqItem.Id==id); 
                return Ok(eq);
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

        // POST: api/SportEquipment
        public IHttpActionResult Post([FromBody]SportEQ addEquipment)
        {
            try
            {
                SporteqContext.SportEQs.InsertOnSubmit(addEquipment);
                SporteqContext.SubmitChanges(); 
                return Ok("Equipment was Added Successfully");
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

        // PUT: api/SportEquipment/5
        public IHttpActionResult Put(int id, [FromBody]SportEQ updateEquipment)
        {
            try
            {
                SportEQ eqToUpdate = SporteqContext.SportEQs.First(eqItem => eqItem.Id == id);
                if(eqToUpdate.SportType != null)
                {
                    eqToUpdate.Id = updateEquipment.Id;
                    eqToUpdate.SportType = updateEquipment.SportType;
                    eqToUpdate.Company=updateEquipment.Company;
                    eqToUpdate.ProductName=updateEquipment.ProductName;
                    eqToUpdate.Price=updateEquipment.Price;
                    eqToUpdate.Quantity=updateEquipment.Quantity;
                    eqToUpdate.TeamId=updateEquipment.TeamId;
                    eqToUpdate.Picture=updateEquipment.Picture;
                    SporteqContext.SubmitChanges();
                    return Ok("Equipment was Updated Successfully");
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

        // DELETE: api/SportEquipment/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                SportEQ eqToDelete = SporteqContext.SportEQs.First(eqItem => eqItem.Id == id);
                SporteqContext.SportEQs.DeleteOnSubmit(eqToDelete);
                SporteqContext.SubmitChanges();
                return Ok("Equipment was Deleted Successfully");
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
