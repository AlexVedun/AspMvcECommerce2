using AspMvcECommerce2.Domain;
using AspMvcECommerce2.WebUI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace AspMvcECommerce2.WebUI.Controllers
{
    public class CategoryController : ApiController
    {
        private IRepository mRepository;
        public CategoryController(IRepository _repository)
        {
            mRepository = _repository;
        }

        // GET: api/Category
        [Route("api/categories/get-all")]
        //public IEnumerable<TestModel> Get()
        public ApiResponse<List<Category>> Get()
        {
            
            ApiResponse<List<Category>> categoriesResponse =
                new ApiResponse<List<Category>>();
            List<Category> categories = null;
            try
            {
                categories =
                    mRepository.CategoryEC.Categories.ToList();
                
                categoriesResponse.data = categories;
            }
            catch (Exception ex)
            {
                categoriesResponse.error = ex.Message;
            }

            return categoriesResponse;
        }

        [Route("api/categories/add")]
        public Object Get(int catid, string catname)
        {
            try
            {
                if (HttpContext.Current.Session["username"] != null)
                {
                    User user =
                        mRepository.UserEC.FindByLogin(HttpContext.Current.Session["username"].ToString());
                    if (user.Role.name == "admin")
                    {
                        Category category = catid > 0 ? mRepository.CategoryEC.Find(catid) : new Category();
                        category.name = catname;
                        //Category category = new Category() { name = catname, Articles = new List<Article>() };
                        mRepository.CategoryEC.Save(category);
                        return new ApiResponse<Object>() { data = new List<Category>() { category }, error = "" };
                    }
                    else
                    {
                        var response = Request.CreateResponse(HttpStatusCode.Moved);
                        response.Headers.Location =
                            new Uri(Url.Content("~/wwwroot/pages/home.htm"));
                        return response;
                    }
                }
                else
                {
                    var response = Request.CreateResponse(HttpStatusCode.Moved);
                    response.Headers.Location =
                        new Uri(Url.Content("~/wwwroot/pages/home.htm"));
                    return response;
                }
            }
            catch (Exception ex)
            {

                return new ApiResponse<Object>() { data = null, error = ex.Message + " : " + ex.StackTrace };
            }
        }

        [Route("api/categories/delete")]
        public Object Get(int catid)
        {
            try
            {
                if (HttpContext.Current.Session["username"] != null)
                {
                    User user =
                        mRepository.UserEC.FindByLogin(HttpContext.Current.Session["username"].ToString());
                    if (user.Role.name == "admin")
                    {
                        Category category = mRepository.CategoryEC.Find(catid);
                        mRepository.CategoryEC.Remove(category);
                        return new ApiResponse<Object>() { data = new List<Category>() { category }, error = "" };
                    }
                    else
                    {
                        var response = Request.CreateResponse(HttpStatusCode.Moved);
                        response.Headers.Location =
                            new Uri(Url.Content("~/wwwroot/pages/home.htm"));
                        return response;
                    }
                }
                else
                {
                    var response = Request.CreateResponse(HttpStatusCode.Moved);
                    response.Headers.Location =
                        new Uri(Url.Content("~/wwwroot/pages/home.htm"));
                    return response;
                }
            }
            catch (Exception ex)
            {

                return new ApiResponse<Object>() { data = null, error = ex.Message + " : " + ex.StackTrace };
            }
        }

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
