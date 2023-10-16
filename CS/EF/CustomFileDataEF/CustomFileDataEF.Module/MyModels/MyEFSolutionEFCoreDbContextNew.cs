using System;
using System.Collections.Generic;
using DevExpress.ExpressApp.Design;
using Microsoft.EntityFrameworkCore;

namespace CustomFileDataEF.Module.BusinessObjects;
[TypesInfoInitializer(typeof(CustomFileDataEFContextInitializer))]
public partial class CustomFileDataEFEFCoreDbContext : DbContext {
    public CustomFileDataEFEFCoreDbContext(DbContextOptions<CustomFileDataEFEFCoreDbContext> options)
        : base(options) {
    }

    public virtual DbSet<BusinessObject> BusinessObjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        OnModelCreatingPartial(modelBuilder);
        modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues);
        modelBuilder.UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
