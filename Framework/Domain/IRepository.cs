using System.Linq.Expressions;
using Framework.Infrastructure;

namespace Framework.Domain;

public interface IRepository<TModel> where TModel : class
{
    DbState Add(TModel? model);
    DbState Update(TModel? model);
    DbState Delete(TModel? model);
    TResult? Find<TResult>(Expression<Func<TModel, bool>> whereExpression
        , Expression<Func<TModel, TResult>> selectExpression, Func<TResult, bool> findFunc);
    TModel? Find(Expression<Func<TModel, bool>> findExpression);

    List<TViewModel> ToViews<TViewModel>(Expression<Func<TModel, bool>> whereExpression, Expression<Func<TModel, TViewModel>> selectExpression);

    public List<TViewTModel> ToViewsWithInclude<TViewTModel, TProperty>(Expression<Func<TModel, bool>>? whereExpression
        , Expression<Func<TModel, TViewTModel>>? selectExpression,
        params Expression<Func<TModel, TProperty>>[] includesExpression);
    Task<List<TViewModel>> ToViewsAsync<TViewModel>(Expression<Func<TModel, bool>> whereExpression, Expression<Func<TModel, TViewModel>> selectExpression, CancellationToken? token = default);
    List<TModel> ToList();
    Task<List<TModel>> ToListAsync(CancellationToken? token = default);
    Task<int> SaveChanges();
}