using AspMvcECommerce2.Domain;
using AspMvcECommerce2.WebUI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspMvcECommerce2.WebUI.Controllers
{
    public class CategoryController : ApiController
    {
        private IRepository repository;
        /*public CategoryController()
        {
            repository = new SqlServerRepository();
        }*/
        public CategoryController() : this(_repository)
        {
        }
        public CategoryController(IRepository _repository)
        {
            repository = _repository;
        }
        // GET: api/Category
        [Route("api/categories/get-all")]
        //public IEnumerable<TestModel> Get()
        public ApiResponse<List<Category>> Get()
        {
            //return new string[] { "value1", "value2" };
            /*IEnumerable<TestModel> testModels = new List<TestModel>() {
                new TestModel{id = 1, name = "n1"}
                , new TestModel{id = 2, name = "n2"}
            };*/
            //return testModels;
            ApiResponse<List<Category>> categoriesResponse =
                new ApiResponse<List<Category>>();
            List<Category> categories = null;
            try
            {
                categories =
                    repository.CategoryEC.Categories.ToList();
                /*categories =
                    new List<Category>() {
                        new Category() { id = 1, name = "n1" }
                    };*/
                categoriesResponse.data = categories;
            }
            catch (Exception ex)
            {
                categoriesResponse.error = ex.Message;
            }

            return categoriesResponse;
        }

        // GET: api/Category/5
        /*[Route("api/categories/{_id}")]
        public TestModel Get(int _id)
        {
            //return "value = " + id;
            return new TestModel { id = _id, name = "n" + _id };
        }*/

        // POST: api/Category
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Category/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Category/5
        public void Delete(int id)
        {
        }
    }
}
