﻿using DomainLayer.Contracts;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Specifications
{
    public abstract class BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public BaseSpecifications(Expression<Func<TEntity, bool>> CriteriaExprssion)
        {
            Criteria = CriteriaExprssion;
        }
        public Expression<Func<TEntity, bool>>? Criteria { get; private set; }

        public List<Expression<Func<TEntity, object>>> IncludeExpression { get; } = [];

        public Expression<Func<TEntity, object>>? OrderBy { get; private set; }
        protected void AddOrderBy(Expression<Func<TEntity, object>> orderByAsc)
        {
            OrderBy = orderByAsc;
        }

        public Expression<Func<TEntity, object>>? OrderByDescending { get; private set; }
        protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDesc)
        {
            OrderByDescending = orderByDesc;
        }

        protected void AddInclude(Expression<Func<TEntity,object>>includeExpression)
        {
            IncludeExpression.Add(includeExpression);
        }
    }
}
