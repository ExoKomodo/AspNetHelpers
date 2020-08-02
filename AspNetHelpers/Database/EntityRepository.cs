using System.Linq;
using System.Threading.Tasks;
using AspNetHelpers.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetHelpers.Database
{
    public abstract class EntityRepository<TId, TModel>
        where TModel : Model<TId>
    {
        #region Public

        #region Constructors
        protected EntityRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Member Methods
        public TModel Create(TModel model) => CreateAsync(model).Result;
        public TModel Delete(TId id) => DeleteAsync(id).Result;
        public TModel Get(TId id) => GetAsync(id).Result;
        public IQueryable<TModel> GetAll() => GetAllAsync().Result;
        public TModel Update(TId id, TModel model) => UpdateAsync(id, model).Result;
        #endregion

        #endregion

        #region Protected

        #region Fields
        protected readonly DbContext _dbContext;
        #endregion

        #region Member Methods
        protected async Task<TModel> CreateAsync(TModel model)
        {
            var createdModel = GetModelContext().Add(model).Entity;
            await Save();
            return createdModel;
        }

        protected async Task<TModel> DeleteAsync(TId id)
        {
            
            var modelToDelete = GetModelContext().FindAsync(id).Result;
            GetModelContext().Remove(modelToDelete);
            await Save();
            return modelToDelete;
        }

        protected ValueTask<TModel> GetAsync(TId id)
        {
            return GetModelContext().FindAsync(id);
        }

        protected Task<IQueryable<TModel>> GetAllAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                return GetModelContext().AsQueryable();
            });
        }

        protected DbSet<TModel> GetModelContext() => _dbContext.Set<TModel>();

        protected Task Save() => _dbContext.SaveChangesAsync();
        
        protected async Task<TModel> UpdateAsync(TId id, TModel model)
        {
            var updatedModel = GetModelContext().Update(model).Entity;
            await Save();
            return updatedModel;
        }
        #endregion

        #endregion
    }
}
