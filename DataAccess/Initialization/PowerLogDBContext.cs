using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using PowerMonitoring.Data;
using PowerMonitoring.Data.Poco;
using PowerMonitoring.DataAccess.Mapping;

namespace PowerMonitoring.DataAccess.Initialization
{
    public class PowerLogDbContext : DbContext
    {
        private const string ConnectionString = @"Data Source=jure-pc\sqlexpress;Initial Catalog=CodeFirstDb;persist security info=True; Integrated Security=SSPI;;Application Name=EntityFramework";

        //todo - comment http://stackoverflow.com/questions/14985854/ef-code-first-creating-database-login-failed-for-user/14987845#14987845
        //for reverse code first
        //static PowerLogDbContext()
        //{
        //    Database.SetInitializer<PowerLogDbContext>(null);
        //}

        //public PowerLogDbContext()
        //    : base("name=PowerLogDbContext")
        //{
        //}        

        public PowerLogDbContext()
            : base(ConnectionString)
        {
        }

        public PowerLogDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public PowerLogDbContext(string nameOrConnectionString, DbCompiledModel model)
            : base(nameOrConnectionString, model)
        {
        }

        public PowerLogDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        public PowerLogDbContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlarmConfigurationMapping());
            modelBuilder.Configurations.Add(new AlamLevelConfigurationMapping());
            modelBuilder.Configurations.Add(new AlarmLogMapping());
            modelBuilder.Configurations.Add(new AlarmMapping());
            modelBuilder.Configurations.Add(new DoubleLogMapping());
            modelBuilder.Configurations.Add(new SingleHistogramMapping());
            modelBuilder.Configurations.Add(new SingleLogMapping());
            modelBuilder.Configurations.Add(new VariableMapping());
        }

        public DbSet<AlarmConfiguration> AlarmConfigurations { get; set; }
        public DbSet<AlarmLog> AlarmLogs { get; set; }
        public DbSet<Alarm> Alarms { get; set; }
        public DbSet<DoubleLog> DoubleLogs { get; set; }
        public DbSet<SingleHistogram> SingleHistograms { get; set; }
        public DbSet<SingleLog> SingleLogs { get; set; }
        public DbSet<Variable> Variables { get; set; }
    }
}
