using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAutomation.Business.Abstract
{
    public interface IValidator<TEntity>
    {
        bool Validation(TEntity entity);
    }
}
