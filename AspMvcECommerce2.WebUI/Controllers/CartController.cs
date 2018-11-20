using AspMvcECommerce2.Domain;
using AspMvcECommerce2.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AspMvcECommerce2.WebUI.Controllers
{
    public class CartController : ApiController
    {
        private IRepository mRepository;
        public CartController(IRepository _repository)
        {
            mRepository = _repository;
        }

        [Route("api/articles/cart")]
        public Object Get()
        {
            try
            {
                if (HttpContext.Current.Session["username"] != null)
                {
                    if (HttpContext.Current.Session["cart"] == null)
                    {
                        HttpContext.Current.Session["cart"] = new Cart() { CartItems = new List<CartItem>() };
                    }

                    List<CartItemDetails> cartItemDetails =
                        (HttpContext.Current.Session["cart"] as Cart).CartItems
                        .Select(cartItem => {
                            Article article = mRepository.ArticleEC.Find(cartItem.ArticleId);

                            return new CartItemDetails()
                            {
                                ArticleId = cartItem.ArticleId
                                ,
                                ArticleName = article.title
                                ,
                                Count = cartItem.Count
                                ,
                                Summ = cartItem.Count * article.price
                            };
                        })
                        .ToList();

                    return new ApiResponse<List<CartItemDetails>>()
                    {
                        data = cartItemDetails
                        ,
                        error = ""
                    };
                }
                else
                {
                    return new ApiResponse<Object>() { error = "Sign in first" };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<Object>() { error = ex.Message + " : " + ex.StackTrace };
                //return new ApiResponse() { data = null, error = ex.Message + " : " + ex.StackTrace };
            }
        }

        [Route("api/articles/cart/{artid}")]
        public Object Post([FromUri] string artid, [FromBody] CartAction cartAction)
        {
            try
            {
                int artidInt = Int32.Parse(artid);
                if (HttpContext.Current.Session["username"] != null)
                {
                    if (HttpContext.Current.Session["cart"] == null)
                    {
                        HttpContext.Current.Session["cart"] =
                            new Cart() { CartItems = new List<CartItem>() };
                    }

                    Cart cart = (Cart)HttpContext.Current.Session["cart"];
                    CartItem currentCartItem =
                        cart.CartItems.Find(cartItem => cartItem.ArticleId == artidInt);
                    if (currentCartItem == null)
                    {
                        cart.CartItems.Add(new CartItem() { ArticleId = artidInt, Count = 0 });
                        currentCartItem =
                            cart.CartItems.Find(cartItem => cartItem.ArticleId == artidInt);
                    }
                    if (cartAction.actionTypeValue == CartAction.ActionType.neg)
                    {
                        currentCartItem.Count--;
                        if (currentCartItem.Count <= 0)
                        {
                            cart.CartItems.Remove(currentCartItem);
                        }
                    }
                    else if (cartAction.actionTypeValue == CartAction.ActionType.rem)
                    {
                        cart.CartItems.Remove(currentCartItem);
                    }
                    else if (cartAction.actionTypeValue == CartAction.ActionType.add)
                    {
                        currentCartItem.Count++;
                    }


                    HttpContext.Current.Session["cart"] = cart;

                    return new ApiResponse<List<Cart>>()
                    {
                        data = new List<Cart>() { HttpContext.Current.Session["cart"] as Cart }
                        ,
                        error = ""
                    };
                }
                else
                {
                    return new ApiResponse<Object>() { error = "Sign in first" };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<Object>() { error = ex.Message + " : " + ex.StackTrace };
            }
        }
    }
}