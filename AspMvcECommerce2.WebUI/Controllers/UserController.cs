using AspMvcECommerce2.Domain;
using AspMvcECommerce2.WebUI.Models;
using AspMvcECommerce2.Domain.EntityController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspMvcECommerce2.WebUI.Controllers
{
    public class UserController : ApiController
    {
        private IRepository repository;
        public UserController() {
            repository = new SqlServerRepository();
        }
        // GET: api/User
        [Route("api/users/get-all")]
        public ApiResponse <List<User>> Get()
        {
            ApiResponse<List<User>> usersResponse = new ApiResponse<List<User>>();
            List<User> users = null;
            try
            {
                users = repository.UserEC.Users.ToList();
                usersResponse.data = users;
            }
            catch (Exception ex)
            {
                usersResponse.error = ex.Message;
            }
            return usersResponse;
        }
        //public IEnumerable<Object> Get()
        //{
        //    //repository.UserEC.Users.ToList();
        //    //return new List<User>() { new User()};
        //    return repository.UserEC.Users.Select(u => new { id = u.id, name = u.login  }).ToList();
        //}

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
