using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SomeUsualShop.Infrastructure;

namespace SomeUsualShop.Models
{
    public class SessionCart : Cart
    {
        [JsonIgnore] 
        public ISession Session { get; set; }
        
        
        public static Cart GetCart(IServiceProvider serviceProvider)
        {
            ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        public override void AddItem(Product product, int count)
        {
            base.AddItem(product,count);
            Session.SetJson("Cart",this);
        }

        public override void Remove(Product product)
        {
            base.Remove(product);
            Session.SetJson("Cart",this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}