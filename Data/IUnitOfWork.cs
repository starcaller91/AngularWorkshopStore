namespace Data
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        void CancelSaving();
    }
}