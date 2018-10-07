using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspMvcECommerce2.Domain.EntityController
{
    public class RoleEC : AbstractEC<Role>
    {
        public RoleEC(AspNetMvcECommerceEntities _db) : base(_db)
        {
        }
    }
}
