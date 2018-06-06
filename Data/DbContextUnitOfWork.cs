using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Data
{
    [SuppressMessage("Microsoft.Design", "CA1001",
        Justification = "Class is not responsible for lifetime of injected objects")]
    public class DbContextUnitOfWork : IUnitOfWork
    {
        [SuppressMessage("Microsoft.Usage", "CA2213",
            Justification = "Class is not responsible for lifetime of object because object is injected")]
        private readonly DbContext _context;
        private bool _cancelSaving;

        public DbContextUnitOfWork(StoreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void SaveChanges()
        {
            if (_cancelSaving)
            {
                return;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                ProcessEntityValidationException(ex);
            }
        }

        public void CancelSaving()
        {
            _cancelSaving = true;
        }

        private void ProcessEntityValidationException(DbEntityValidationException ex)
        {
            var errorMessages = ex.EntityValidationErrors
                .SelectMany(x => x.ValidationErrors)
                .Select(x => x.ErrorMessage);

            var fullErrorMessage = string.Join("; ", errorMessages);

            var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
            throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
        }
    }
}