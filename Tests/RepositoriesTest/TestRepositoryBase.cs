using data;

namespace Tests
{
    public abstract class TestRepositoryBase : IDisposable
    {
        protected readonly Context Context;
        public TestRepositoryBase()
        {
            Context = ContextFactory.Create();
        }
        public void Dispose()
        {
            ContextFactory.Destroy(Context);
        }
    }
}
