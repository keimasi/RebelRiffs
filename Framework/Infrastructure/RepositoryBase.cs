using System.Linq.Expressions;
using Framework.Application;
using Framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace Framework.Infrastructure;

public class RepositoryBase<TModel> : IRepository<TModel> where TModel : class
{
    readonly DbContext _Context;

    public RepositoryBase(DbContext context)
    {
        _Context = context;
    }

    public DbState Add(TModel? model)
    {
        return _Context.Set<TModel>().Add(model).ConvertEntityEntryToDbState();
    }

    public DbState Update(TModel? model)
    {
        return _Context.Set<TModel>().Update(model).ConvertEntityEntryToDbState();
    }

    public DbState Delete(TModel? model)
    {
        return _Context.Set<TModel>().Remove(model).ConvertEntityEntryToDbState();
    }

    public Task<bool> AnyEntity(Expression<Func<TModel, bool>> anyExpression, CancellationToken cancellationToken = default)
    {
        return _Context.Set<TModel>().AnyAsync(anyExpression, cancellationToken);
    }
    public TModel? Find(Expression<Func<TModel, bool>> findExpression)
    {
        return _Context.Set<TModel>().FirstOrDefault(findExpression);
    }
    public async Task<TModel?> FindAsync(Expression<Func<TModel, bool>> findExpression)
    {
        return await _Context.Set<TModel>().FirstOrDefaultAsync(findExpression);
    }

    public List<TViewTModel> ToViews<TViewTModel>(Expression<Func<TModel, bool>>? whereExpression
        , Expression<Func<TModel, TViewTModel>>? selectExpression)
    {
        IQueryable<TModel> query = To(whereExpression);

        if (selectExpression is null)
            return new List<TViewTModel>(0);
        return query.Select(selectExpression).ToList();
    }


    public async Task<List<TViewTModel>> ToViewsWithInclude<TViewTModel,TProperty>(Expression<Func<TModel, bool>>? whereExpression, Expression<Func<TModel, TViewTModel>>? selectExpression, CancellationToken cancellationToken, params Expression<Func<TModel, object>>[] includesExpression)
    {
        IQueryable<TModel> query = _Context.Set<TModel>().AsQueryable();

        foreach (var include in includesExpression)
        {
            query = query.Include(include);
        }
        if (whereExpression is not null)
            query = query.Where(whereExpression);
        return await query.Select(selectExpression).ToListAsync(cancellationToken);
    }


    public List<TModel> ToList()
    {
        return _Context.Set<TModel>().ToList();
    }

    public async Task<List<TViewTModel>> ToViewsAsync<TViewTModel>(Expression<Func<TModel, bool>> whereExpression,
        Expression<Func<TModel, TViewTModel>>? selectExpression, CancellationToken? token = default)
    {
        IQueryable<TModel> query = To(whereExpression);
        if (selectExpression is null)
            return new List<TViewTModel>(0);

        return await query.Select(selectExpression).ToListAsync();
    }

    public async Task<List<TModel>> ToListAsync(CancellationToken? token = default)
    {
        return await _Context.Set<TModel>().ToListAsync();
    }

    public async Task<bool> SaveChanges()
    {
        return await _Context.SaveChangesAsync() != 0 ? true : false;
    }

    public TResult? Find<TResult>(Expression<Func<TModel, bool>> whereExpression
        , Expression<Func<TModel, TResult>> selectExpression, Func<TResult, bool>? findFunc)
    {
        var query = _Context.Set<TModel>().Where(whereExpression)
            .Select(selectExpression);
        if (findFunc is null)
            return query.FirstOrDefault();

        return query.FirstOrDefault(findFunc);
    }



    private IQueryable<TModel> To(Expression<Func<TModel, bool>>? whereExpression)
    {
        IQueryable<TModel> query = _Context.Set<TModel>();

        if (whereExpression is not null)
            query = _Context.Set<TModel>().Where(whereExpression);
        return query;
    }
}