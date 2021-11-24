using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        //BaseSpecification is used to extend more unique specifications for the queries that we need to make with the API.
        public BaseSpecification()
        {
        }

        //the BaseSpecification constructor takes on a Expression object as its parameter.
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;

        }

        //The Expression property Criteria is from ISpecification and needs to be implemented
        public Expression<Func<T, bool>> Criteria {get; }

        //The List property Includes is from ISpecification and needs to be implemented
        public List<Expression<Func<T, object>>> Includes {get; } = 
            new List<Expression<Func<T, object>>>();

        
        //AddInclude is method that passes an expression as it's parameter
        //It adds the passsed parameter to the List object Includes
        protected void AddInclude(Expression<Func<T, object>> includeExpression) 
        {
            Includes.Add(includeExpression);

        }


        public Expression<Func<T, object>> OrderBy {get; private set;}

        public Expression<Func<T, object>> OrderByDescending {get; private set;}



        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }

        //attributes and method to be used as specifications for paging.
        public int Take {get; private set;}
        public int Skip {get; private set;}

        public bool IsPagingEnabled {get; private set;}
        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
    }
}