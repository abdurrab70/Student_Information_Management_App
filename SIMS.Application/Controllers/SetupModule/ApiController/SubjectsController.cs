using System;
using System.Web.Http;
using SIMS.Core.ViewModel.SetupModule;
using SIMS.ServiceManager.ServiceManager.SetupModule;

namespace SIMS.Application.Controllers.SetupModule.ApiController
{
    public class SubjectsController : System.Web.Http.ApiController
    {
        // Constructor create for inherite service manager data
        private SubjectServiceManager _subjectService = new SubjectServiceManager();

        // GET: api/Subjects
        public IHttpActionResult Get()
        {
            try
            {
                var entities = _subjectService.GetAll();
                return Ok(entities);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Subjects/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var entity = _subjectService.Get(id);
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Subjects
        public IHttpActionResult Post([FromBody]SubjectViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = _subjectService.Add(vm);
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

        // PUT: api/Subjects/5
        public IHttpActionResult Put(int id, [FromBody]SubjectViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = _subjectService.Update(id, vm);
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

        // DELETE: api/Subjects/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var entity = _subjectService.Remove(id);
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
