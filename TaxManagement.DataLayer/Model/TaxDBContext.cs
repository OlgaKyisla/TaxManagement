using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaxManagement.DataLayer.Configurations;
using TaxManagement.DataLayer.Enums;
using TaxManagement.DataLayer.Interfaces;

namespace TaxManagement.DataLayer.Model
{
    public class TaxDBContext : DbContext
    {
        public Guid UserId { get; private set; }

        private readonly string _username;
        private readonly bool _userIsAdmin;

        public TaxDBContext(DbContextOptions<TaxDBContext> options, string username, bool userIsAdmin) : base(options)
        {
            _username = username;
            _userIsAdmin = userIsAdmin;
        }

        public DbSet<TaxDeclaration> Declarations { get; set; }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Constants.ShemaName);

            //But a time-saving method called ApplyConfigurationsFromAssembly can find all
            //your configuration classes that inherit IEntityTypeConfiguration<T> and run them all for you. 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //modelBuilder.ApplyConfiguration(new TaxDeclarationConfig());
            //modelBuilder.ApplyConfiguration(new UserConfig());

            var taxDeclarationEntity = modelBuilder.Entity<TaxDeclaration>().HasQueryFilter(x => x.User.UserName.Equals(_username) || _userIsAdmin);


            foreach (var entityType in modelBuilder.Model.GetEntityTypes()){

                //other property code removed for clarity
                if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
                {
                    entityType.AddQueryFilter(QueryFilterTypes.SoftDelete);
                }
            }

          
           
           

        }


    }
}
