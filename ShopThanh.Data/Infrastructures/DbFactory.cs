namespace ShopThanh.Data.Infrastructures
{
    public class DbFactory : Disposable, IDbFactory
    {
        private ShopThanhDbContext dbContext;

        public ShopThanhDbContext Init()
        {
            return dbContext ?? (dbContext = new ShopThanhDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}