using AspMvcECommerce2.Domain.EntityController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspMvcECommerce2.Domain
{
    public interface IRepository
    {
        UserEC UserEC { get; }
        RoleEC RoleEC { get; }
        CategoryEC CategoryEC { get; }
        ArticleEC ArticleEC { get; }
    }
}
