using AspMvcECommerce2.Domain.EntityController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspMvcECommerce2.Domain
{
    public class SqlServerRepository : IRepository
    {
        private AspNetMvcECommerceEntities mDb;
        public UserEC UserEC => new UserEC(mDb);
        public RoleEC RoleEC => new RoleEC(mDb);
        public CategoryEC CategoryEC => new CategoryEC(mDb);
        public ArticleEC ArticleEC => new ArticleEC(mDb);

        public SqlServerRepository()
        {
            mDb = new AspNetMvcECommerceEntities();
        }
    }
}
