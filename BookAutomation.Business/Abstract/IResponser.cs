using System.Collections.Generic;

namespace BookAutomation.Business.Abstract
{
    public interface IResponser<TEntity, TRO>
    {
        TRO ToResponseObject(TEntity entity);
        List<TRO> ToResponseObject(List<TEntity> entity);
    }
}
