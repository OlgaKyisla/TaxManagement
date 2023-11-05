using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaxManagement.DataLayer.Enums;
using TaxManagement.DataLayer.Interfaces;

namespace TaxManagement.DataLayer
{
    
    internal static class SoftDeleteQueryExtensions
    {
        public static void AddQueryFilter(this IMutableEntityType entityData, QueryFilterTypes queryFilterType)
        {
            var methodName = $"Get{queryFilterType}Filter";
            var methodToCall = typeof(SoftDeleteQueryExtensions).GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static)?.MakeGenericMethod(entityData.ClrType);
            
            var filter = methodToCall?.Invoke(null, new object[] {});

            var expression = filter as LambdaExpression;
            if (expression != null) {
                entityData.SetQueryFilter(expression);
            }
            

            if (queryFilterType == QueryFilterTypes.SoftDelete)
            {
                var softDeleteProperty = entityData.FindProperty(nameof(ISoftDelete.SoftDeleted));
                
                if (softDeleteProperty != null) {
                    entityData.AddIndex(softDeleteProperty);
                }      
            }
        }

        /*
        private static LambdaExpression GetUserIdFilter<TEntity>(IUserId userIdProvider) where TEntity : class, IUserId
        {
            Expression<Func<TEntity, bool>> filter = x => x.UserId == userIdProvider.UserId;
            return filter;
        }*/

        private static LambdaExpression GetSoftDeleteFilter<TEntity>()where TEntity : class, ISoftDelete
        {
            Expression<Func<TEntity, bool>> filter = x => !x.SoftDeleted;
            return filter;
        }
    }
}
