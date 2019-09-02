using System.Data.Entity;
using System.Threading.Tasks;

namespace ModeloProjeto.Infraestrutura.ORM
{
    public class ModeloProjetoDbContext : DbContext
    {
        private readonly string connectionString;

        public ModeloProjetoDbContext(string connectionString) : base(connectionString)
        {
            this.connectionString = connectionString;
            Configuration.LazyLoadingEnabled = false;
        }
        static ModeloProjetoDbContext()
        {
            //manter, pois faz uma referência estática ao System.Data.Entity.SqlServer
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }


        //public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new UsuarioEntityConfig());
        }

        public async override Task<int> SaveChangesAsync()
        {
            ChangeTracker.DetectChanges();

            return await base.SaveChangesAsync();
        }

    }
}
