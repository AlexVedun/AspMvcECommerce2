using AspMvcECommerce2.Domain;
using AspMvcECommerce2.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace AspMvcECommerce2.WebUI.Controllers
{
    public class AuthController : ApiController
    {
        public const int userRoleId = 2;
        private IRepository mRepository;
        //public AuthController()
        //{
        //    mRepository = new SqlServerRepository();
        //}

        public AuthController(IRepository _repository)
        {
            mRepository = _repository;
        }

        // GET: api/Auth
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Auth/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("api/auth/signup")]
        public ApiResponse<User> Post([FromBody]SignupRequestForm _signupForm)
        {
            try
            {
                string newUserName = _signupForm.Login;
                var oldUser =
                    mRepository.UserEC.FindByLogin(newUserName);
                if (oldUser == null)
                {
                    Role role = mRepository.RoleEC.Find(userRoleId);
                    User user = new User()
                    {
                        login = _signupForm.Login
                        ,
                        password = _signupForm.Password
                        ,
                        Role = role
                        ,
                        role_id = role.id
                    };
                    mRepository.UserEC.Save(user);
                    return new ApiResponse<User>() { data = user , error = "" };
                }
                else
                {
                    return new ApiResponse<User>() { error = $"User {newUserName} already presents" };
                }
            }
            catch (Exception ex)
            {
                //return new ApiResponse<User>() { error = ex.Message };
                return new ApiResponse<User>() { error = ex.StackTrace };
            }
        }

        [Route("api/auth/signin")]
        public ApiResponse<User> Post([FromBody]SigninRequestForm _signupForm)
        {
            try
            {
                User user =
                    mRepository.UserEC
                    .FindByLogin(_signupForm.Login);

                if (user != null && _signupForm.Password == user.password)
                {

                    HttpContext.Current.Session["username"] =
                        _signupForm.Login;
                    return new ApiResponse<User>() { data = user };
                }
                else
                {
                    return new ApiResponse<User>() { error = $"User with name {_signupForm.Login} not found or password is incorrect" };
                }
            }
            catch (Exception ex)
            {

                return new ApiResponse<User>() { error = ex.StackTrace };
            }
        }

        [Route("api/auth/signout")]
        public ApiResponse<Object> Post()
        {
            try
            {
                HttpContext.Current.Session["username"] = null;
                return new ApiResponse<Object>() { data = "logout" };
            }
            catch (Exception ex)
            {
                return new ApiResponse<Object>() { error = ex.Message };
            }
        }

        [Route("api/auth/page")]
        public Object Get([FromUri] NavigationData _navigationData)
        {
            if (_navigationData.pagename == "admin" || _navigationData.pagename == "adminunit")
            {
                if (HttpContext.Current.Session["username"] != null)
                {

                    User user =
                        mRepository.UserEC.FindByLogin(HttpContext.Current.Session["username"].ToString());
                    if (user.Role.name == "admin")
                    {
                        var response = Request.CreateResponse(HttpStatusCode.Moved);
                        //TODO
                        response.Headers.Location =
                            new Uri(Url.Content("~/wwwroot/pages/" + _navigationData.pagename + ".htm?" + _navigationData.param));
                        return response;
                    }
                    else
                    {
                        var response = Request.CreateResponse(HttpStatusCode.Moved);
                        response.Headers.Location =
                            new Uri(Url.Content("~/wwwroot/pages/home.htm?" + _navigationData.param));
                        return response;
                    }
                }
                else
                {
                    var response = Request.CreateResponse(HttpStatusCode.Moved);
                    response.Headers.Location =
                        new Uri(Url.Content("~/wwwroot/pages/home.htm?" + _navigationData.param));
                    return response;
                }
            }
            else
            {
                var response = Request.CreateResponse(HttpStatusCode.Moved);
                response.Headers.Location =
                    new Uri(Url.Content("~/wwwroot/pages/" + _navigationData.pagename + ".htm?" + _navigationData.param));
                return response;
            }
        }

        // PUT: api/Auth/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Auth/5
        public void Delete(int id)
        {
        }
    }
}
