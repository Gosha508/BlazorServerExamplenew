namespace DB.Interface.BasicInterface
{
    public interface IAsyncRepository<T> : IAsyncReadRepository<T>, IAsyncWriteRepository<T>, IUpdateRepository<T>, IAsyncRemoveRepository where T : class
    {
    }
}
