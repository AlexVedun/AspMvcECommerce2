using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspMvcECommerce2.Domain.EntityController
{
    public class CategoryEC : AbstractEC<Category>
    {
        public CategoryEC(AspNetMvcECommerceEntities _db) : base(_db)
        {
        }
        public IEnumerable<Category> Categories { get { return mDb.Categories; } }
    }
}
