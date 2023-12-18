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
    public class StudentEntriesController : System.Web.Http.ApiController
    {
        StudentEntriesServiceManager _service = new StudentEntriesServiceManager();
        //generate Student id
        [Route("api/StudentEntries/GetStudentId")]
        [HttpGet]
        public IHttpActionResult GetStudentId()
        {
            try
            {
                var code = _service.GenerateStudentId();
                return Ok(code);
            }
            catch (Exception)
            {

                return BadRequest("Not Found");
            }
        }
        // GetStudentInfo Student list a data insert and update data show kora

        [Route("api/StudentEntries/GetStudentInformation")]
        [HttpGet]
        public IHttpActionResult GetStudentInformation(int id)
        {
            try
            {
                var info = _service.GetAll()
                    .Where(c => c.Id == id);
                return Ok(info);
            }
            catch (Exception)
            {

                return BadRequest("Not Found");
            }
        }
        // Student search by name ar Student id

        [Route("api/StudentEntries/StudentSearch")]
        [HttpGet]
        public IHttpActionResult StudentSearch(string query)
        {
            try
            {
                var info = _service.GetAll()
                    .Where(c => c.StudentId.ToLower().Contains(query));
                return Ok(info);
            }
            catch (Exception)
            {

                return BadRequest("Not Found");
            }
        }
        //autocomplete Student search by id

        [Route("api/StudentEntries/StudentIdAutoComplete")]
        [HttpGet]
        public IHttpActionResult StudentIdAutoComplete(int id)
        {
            try
            {
                var info = _service.GetAll().SingleOrDefault(c => c.Id == id);
                return Ok(info);
            }
            catch (Exception)
            {
                return BadRequest("Not Found");
            }
        }
        // GET: api/StudentEntries
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

        // GET: api/StudentEntries/5 Individuals id
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

        // POST: api/StudentEntries Data Save
        public IHttpActionResult Post([FromBody] StudentEntryViewModel vm)
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

        // PUT: api/StudentEntries/5 Data Update By Individuals Id
        public IHttpActionResult Put(int id, [FromBody] StudentEntryViewModel vm)
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

        // DELETE: api/StudentEntries/5
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
