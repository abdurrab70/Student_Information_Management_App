using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SIMS.Core.Model.OperationModule;
using SIMS.Core.ViewModel.OperationModule;
using SIMS.Core.ViewModel.SetupModule;
using SIMS.ServiceManager.ServiceManager.OperationModule;

namespace SIMS.Application.Controllers.OperationModule.ApiController
{
    public class StudentResultsController : System.Web.Http.ApiController
    {
        // GET: api/StudentResults
        private StudentResultServiceManager _service = new StudentResultServiceManager();

        public IHttpActionResult Get()
        {
            try
            {
                var entities = _service.GetAll();
                return Ok(content: entities);
            }
            catch (Exception e)
            {
                return BadRequest(message: e.Message);
            }
        }

        // GET: api/StudentResults/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var entity = _service.Get(id: id);
                return Ok(content: entity);
            }
            catch (Exception e)
            {
                return BadRequest(message: e.Message);
            }
        }

        // POST: api/StudentResults
        public IHttpActionResult Post([FromBody]MarksViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = _service.Add(vm);
                    return Ok(content: entity);
                }
                else
                {
                    return BadRequest(message: "Now Entry The Student field!");
                }

            }
            catch (Exception e)
            {
                return BadRequest(message: e.Message);
            }
        }

        // PUT: api/StudentResults/5
        public IHttpActionResult Put(int id, [FromBody]MarksViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = _service.Update(id, vm);
                    return Ok(content: entity);
                }
                else
                {
                    return BadRequest(message: " ");
                }

            }
            catch (Exception e)
            {
                return BadRequest(message: e.Message);
            }
        }

        // DELETE: api/StudentResults/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var entity = _service.Remove(id: id);
                return Ok(content: entity);
            }
            catch (Exception e)
            {
                return BadRequest(message: e.Message);
            }
        }
    }
}
