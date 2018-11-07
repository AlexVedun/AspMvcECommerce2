using AspMvcECommerce2.Domain;
using AspMvcECommerce2.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace AspMvcECommerce2.WebUI.Controllers
{
    public class ArticleController : ApiController
    {
        private IRepository mRepository;
        public ArticleController(IRepository _repository)
        {
            mRepository = _repository;
        }

        [Route("api/articles/get-all")]
        public Object Get()
        {
            if (HttpContext.Current.Session["username"] != null)
            {

                User user =
                    mRepository.UserEC.FindByLogin(HttpContext.Current.Session["username"].ToString());
                if (user.Role.name == "admin")
                {
                    return new ApiResponse<Object>() { data = mRepository.ArticleEC.Articles.ToList(), error = "" };
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

        [Route("api/articles/add")]
        //public Object Get([FromUri] ArticleForm _articleForm)
        public Object Post(ArticleForm _articleForm)
        {
            try
            {
                if (HttpContext.Current.Session["username"] != null)
                {
                    User user =
                        mRepository.UserEC.FindByLogin(HttpContext.Current.Session["username"].ToString());
                    if (user.Role.name == "admin")
                    {
                        Category category =
                            mRepository.CategoryEC.Find(_articleForm.Categoryid);
                        Article article = new Article()
                        {
                            title = Uri.UnescapeDataString(_articleForm.Title)
                            ,
                            category_id = _articleForm.Categoryid
                            ,
                            description = Uri.UnescapeDataString(_articleForm.Description)
                            ,
                            price = _articleForm.Price
                            ,
                            quantity = _articleForm.Quantity
                            ,
                            Category = category
                            ,
                            image_base64 = _articleForm.ImageBase64
                        };
                        mRepository.ArticleEC.Save(article);
                        return new ApiResponse<Object>() { data = new List<ArticleForm>() { _articleForm }, error = "" };
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
            catch (DbEntityValidationException e)
            {
                string errorString = "";
                foreach (var eve in e.EntityValidationErrors)
                {
                    errorString += String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    /*Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);*/
                    foreach (var ve in eve.ValidationErrors)
                    {
                        errorString += String.Format("- Property: \"{0}\", Error: \"{1}\"",
                        ve.PropertyName, ve.ErrorMessage);
                        /*Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);*/
                    }
                }
                throw;
            }
            catch (Exception ex)
            {

                return new ApiResponse<Object>() { data = null, error = ex.Message + " : " + ex.StackTrace };
            }
        }

        [Route("api/articles/delete")]
        public Object Get(int artid)
        {
            try
            {
                if (HttpContext.Current.Session["username"] != null)
                {
                    User user =
                        mRepository.UserEC.FindByLogin(HttpContext.Current.Session["username"].ToString());
                    if (user.Role.name == "admin")
                    {
                        Article article = mRepository.ArticleEC.Find(artid);
                        mRepository.ArticleEC.Remove(article);
                        return new ApiResponse<Object>() { data = new List<Article>() { article }, error = "" };
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
    }
}
