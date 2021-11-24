using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        //The ISpecification interface is made to be reused for all other specifications no matter the type <T>
        //These interface properties are used with the Base Specification to make specific types of queries with the API
        //Currently it has the following properties: Critieria, Includes, OrderBy and OrderByDescending
        Expression<Func<T, bool>> Criteria {get; }
        List<Expression<Func<T, object>>> Includes {get; }
        Expression<Func<T, object>> OrderBy {get;}
        Expression<Func<T, object>> OrderByDescending {get;}

        int Take {get;}
        int Skip {get;}
        bool IsPagingEnabled {get;}
        
    }
}