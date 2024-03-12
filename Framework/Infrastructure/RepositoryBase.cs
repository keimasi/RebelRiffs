using System.Linq.Expressions;
using Framework.Application;
using Framework.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

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

    public TModel? Find(Expression<Func<TModel, bool>> findExpression)
    {
        return _Context.Set<TModel>().Find(findExpression);
    }

    public List<TViewTModel> ToViews<TViewTModel>(Expression<Func<TModel, bool>>? whereExpression
        , Expression<Func<TModel, TViewTModel>>? selectExpression)
    {
        IQueryable<TModel> query = To(whereExpression);

        if (selectExpression is null)
            return new List<TViewTModel>(0);
        return query.Select(selectExpression).ToList();
    }


    public List<TViewTModel> ToViewsWithInclude<TViewTModel, TProperty>(Expression<Func<TModel, bool>>? whereExpression
        , Expression<Func<TModel, TViewTModel>>? selectExpression, params Expression<Func<TModel, TProperty>>[] includesExpression)
    {
        IQueryable<TModel> query = _Context.Set<TModel>().AsQueryable();

        foreach (var include in includesExpression)
        {
            query = query.Include(include);
        }
        return query.Where(whereExpression).Select(selectExpression).ToList();
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

    public async Task<int> SaveChanges()
    {
        return await _Context.SaveChangesAsync();
    }

    public TResult? Find<TResult>(Expression<Func<TModel, bool>> whereExpression
        , Expression<Func<TModel, TResult>> selectExpression, Func<TResult, bool> findFunc)
    {
        return _Context.Set<TModel>().Where(whereExpression).Select(selectExpression).FirstOrDefault(findFunc);
    }


    private IQueryable<TModel> To(Expression<Func<TModel, bool>>? whereExpression)
    {
        IQueryable<TModel> query = _Context.Set<TModel>();

        if (whereExpression is not null)
            query = _Context.Set<TModel>().Where(whereExpression);
        return query;
    }
}