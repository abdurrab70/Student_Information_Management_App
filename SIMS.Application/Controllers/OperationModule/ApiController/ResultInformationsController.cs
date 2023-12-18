using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SIMS.Core.ViewModel.OperationModule;
using SIMS.ServiceManager.ServiceManager.OperationModule;

namespace SIMS.Application.Controllers.OperationModule.ApiController
{
    public class ResultInformationsController : System.Web.Http.ApiController
    {
        private ResultInformationService _service = new ResultInformationService();

        [Route("api/ResultInformations/GetStudentInformations")]
        [HttpGet]
        public IHttpActionResult GetStudentInformations(int id)
        {
            try
            {
                var info = _service.GetAll()
                    .Where(c => c.StudentEntryId == id);
                return Ok(info);
            }
            catch (Exception)
            {

                return BadRequest("Not Found");
            }
        }

        // GET: api/ResultInformations
        public IHttpActionResult Get()
        {
            try
            {
                var entities = _service.GetAll();
                return Ok(entities);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/ResultInformations/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var entity = _service.Get(id);
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/ResultInformations
        public IHttpActionResult Post([FromBody] ResultInformationViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = _service.Add(vm);
                    return Ok(entity);
                }
                else
                {
                    return BadRequest("Required Field Must Not be Empty!");
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/ResultInformations/5
        public IHttpActionResult Put(int id, [FromBody] ResultInformationViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = _service.Update(id, vm);
                    return Ok(entity);
                }
                else
                {
                    return BadRequest("Required Field Must Not be Empty!");
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/ResultInformations/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var entity = _service.Remove(id);
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
