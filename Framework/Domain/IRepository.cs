using System.Linq.Expressions;
using Framework.Infrastructure;

namespace Framework.Domain;

public interface IRepository<TModel> where TModel : class
{
    DbState Add(TModel? model);
    DbState Update(TModel? model);
    DbState Delete(TModel? model);
    Task<bool> AnyEntity(Expression<Func<TModel, bool>> anyExpression, CancellationToken cancellationToken = default);

    TResult? Find<TResult>(Expression<Func<TModel, bool>> whereExpression
        , Expression<Func<TModel, TResult>> selectExpression, Func<TResult, bool>? findFunc);

    Task<TResult?> FindAsync<TResult>(Expression<Func<TModel, bool>> whereExpression
        , Expression<Func<TModel, TResult>> selectExpression, Expression<Func<TResult?, bool>> findFunc);
    TModel? Find(Expression<Func<TModel, bool>> findExpression);
    Task<TModel?> FindAsync(Expression<Func<TModel, bool>> findExpression);

    List<TViewModel> ToViews<TViewModel>(Expression<Func<TModel, bool>> whereExpression, Expression<Func<TModel, TViewModel>> selectExpression);

    public Task<List<TViewTModel>> ToViewsWithInclude<TViewTModel>(Expression<Func<TModel, bool>>? whereExpression, Expression<Func<TModel, TViewTModel>>? selectExpression, CancellationToken cancellationToken,
        params Expression<Func<TModel, object>>[] includesExpression);
    Task<List<TViewModel>> ToViewsAsync<TViewModel>(Expression<Func<TModel, bool>> whereExpression, Expression<Func<TModel, TViewModel>> selectExpression, CancellationToken? token = default);
    List<TModel> ToList();
    Task<List<TModel>> ToListAsync(CancellationToken? token = default);
    Task<bool> SaveChanges();
}