using System.Linq.Expressions;
using Framework.Application;
using Framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace Framework.Infrastructure;

public class RepositoryBase<TModel> : IRepository<TModel> where TModel : class
{
    readonly DbContext _context;

    public RepositoryBase(DbContext context)
    {
        _context = context;
    }

    public DbState AddEntity(TModel? model)
    {
        return _context.Set<TModel>().Add(model).ConvertEntityEntryToDbState();
    }

    public DbState UpdateEntity(TModel? model)
    {
        return _context.Set<TModel>().Update(model).ConvertEntityEntryToDbState();
    }

    public DbState DeleteEntity(TModel? model)
    {
        return _context.Set<TModel>().Remove(model).ConvertEntityEntryToDbState();
    }

    public Task<bool> AnyEntityAsync(Expression<Func<TModel, bool>> anyExpression, CancellationToken cancellationToken = default)
    {
        return _context.Set<TModel>().AnyAsync(anyExpression, cancellationToken);
    }
    public TModel? Find(Expression<Func<TModel, bool>> findExpression)
    {
        return _context.Set<TModel>().FirstOrDefault(findExpression);
    }
    public async Task<TModel?> FindAsync(Expression<Func<TModel, bool>> findExpression)
    {
        return await _context.Set<TModel>().FirstOrDefaultAsync(findExpression);
    }

    public List<TViewTModel> ToViews<TViewTModel>(Expression<Func<TModel, bool>>? whereExpression
        , Expression<Func<TModel, TViewTModel>>? selectExpression)
    {
        IQueryable<TModel> query = To(whereExpression);

        if (selectExpression is null)
            return new List<TViewTModel>(0);
        return query.Select(selectExpression).ToList();
    }


    public async Task<List<TViewTModel>> ToViewsWithInclude<TViewTModel>(Expression<Func<TModel, bool>>? whereExpression, Expression<Func<TModel, TViewTModel>>? selectExpression, CancellationToken cancellationToken, params Expression<Func<TModel, object>>[] includesExpression)
    {
        IQueryable<TModel> query = _context.Set<TModel>().AsQueryable();

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
        return _context.Set<TModel>().ToList();
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
        return await _context.Set<TModel>().ToListAsync();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() != 0 ? true : false;
    }

    public TResult? Find<TResult>(Expression<Func<TModel, bool>> whereExpression
        , Expression<Func<TModel, TResult>> selectExpression, Func<TResult, bool>? findFunc)
    {
        var query = _context.Set<TModel>().Where(whereExpression)
            .Select(selectExpression);
        if (findFunc is null)
            return query.FirstOrDefault();

        return query.FirstOrDefault(findFunc);
    }


    public async Task<TResult?> FindAsync<TResult>(Expression<Func<TModel, bool>> whereExpression
        , Expression<Func<TModel, TResult>> selectExpression,Expression<Func<TResult?, bool>> findFunc)
    {
        IQueryable<TResult?> query = _context.Set<TModel>().Where(whereExpression)
            .Select(selectExpression);
        if (findFunc is null)
            return query.FirstOrDefault();

        return await query.FirstOrDefaultAsync(findFunc);
    }


    private IQueryable<TModel> To(Expression<Func<TModel, bool>>? whereExpression)
    {
        IQueryable<TModel> query = _context.Set<TModel>();

        if (whereExpression is not null)
            query = _context.Set<TModel>().Where(whereExpression);
        return query;
    }
}