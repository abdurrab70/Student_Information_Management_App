using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SIMS.Core.ViewModel.SetupModule;
using SIMS.ServiceManager.ServiceManager.SetupModule;

namespace SIMS.Application.Controllers.SetupModule.ApiController
{
    public class DepartmentsController : System.Web.Http.ApiController
    {
        private DepartmentServiceManager _department = new DepartmentServiceManager();

        // GET: api/Departments
        public IHttpActionResult Get()
        {
            try
            {
                var entities = _department.GetAll();
                return Ok(content: entities);
            }
            catch (Exception e)
            {
                return BadRequest(message: e.Message);
            }
        }

        // GET: api/Departments/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var entity = _department.Get( id);
                return Ok(content: entity);
            }
            catch (Exception e)
            {
                return BadRequest(message: e.Message);
            }
        }

        // POST: api/Departments
        public IHttpActionResult Post([FromBody]DepartmentViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = _department.Add( vm);
                    return Ok(content: entity);
                }
                else
                {
                    return BadRequest(message: "Required Field Must Not be Empty!");
                }

            }
            catch (Exception e)
            {
                return BadRequest(message: e.Message);
            }
        }

        // PUT: api/Departments/5
        public IHttpActionResult Put(int id, [FromBody]DepartmentViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = _department.Update( id, vm);
                    return Ok(content: entity);
                }
                else
                {
                    return BadRequest(message: "Required Field Must Not be Empty!");
                }

            }
            catch (Exception e)
            {
                return BadRequest(message: e.Message);
            }
        }

        // DELETE: api/Departments/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var entity = _department.Remove( id);
                return Ok(content: entity);
            }
            catch (Exception e)
            {
                return BadRequest(message: e.Message);
            }
        }
    }
}
