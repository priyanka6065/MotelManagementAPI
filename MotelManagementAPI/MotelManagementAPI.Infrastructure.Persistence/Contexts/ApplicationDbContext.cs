using MotelManagementAPI.Application.Interfaces;
using MotelManagementAPI.Domain.Common;
using MotelManagementAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MotelManagementAPI.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        private readonly IAuthenticatedUserService _authenticatedUser;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
            _authenticatedUser = authenticatedUser;
        }
        
        public virtual DbSet<Product> Products { get; set; }
        //public virtual DbSet<Role> Role { get; set; }
        //public virtual DbSet<RoleClaims> RoleClaims { get; set; }
        public virtual DbSet<RoomDetail> RoomDetails { get; set; }
        //public virtual DbSet<User> User { get; set; }
        //public virtual DbSet<UserClaims> UserClaims { get; set; }
        //public virtual DbSet<UserLogins> UserLogins { get; set; }
        //public virtual DbSet<UserRoles> UserRoles { get; set; }
        //public virtual DbSet<UserTokens> UserTokens { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<CustomerInfo> CustomerInfos { get; set; }

        public virtual DbSet<OccupiedRoomDetails> OccupiedRoomDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-VE987TB;Initial Catalog=MotelManagement;Integrated Security=True");
            }
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.NowUtc;
                        entry.Entity.CreatedBy = _authenticatedUser.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.NowUtc;
                        entry.Entity.LastModifiedBy = _authenticatedUser.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //All Decimals will have 18,6 Range
            foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,6)");
            }
            base.OnModelCreating(builder);
        }
    }
}
