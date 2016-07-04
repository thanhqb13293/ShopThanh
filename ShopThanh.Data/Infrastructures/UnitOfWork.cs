namespace ShopThanh.Data.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        public void Commit()
        {
            dbContext.SaveChanges();
        }

        private readonly IDbFactory dbFactory;
        private ShopThanhDbContext dbContext;

        public UnitOfWork(IDbFactory IdbFactory)
        {
            this.dbFactory = IdbFactory;
        }

        public ShopThanhDbContext DbContext()
        {
            return dbContext ?? (dbContext = dbFactory.Init());
        }
    }
}