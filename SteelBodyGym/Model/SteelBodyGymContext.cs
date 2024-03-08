using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SteelBodyGym.Model
{
    public partial class SteelBodyGymContext : DbContext
    {
        public SteelBodyGymContext()
        {
        }

        public SteelBodyGymContext(DbContextOptions<SteelBodyGymContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BodyMeasurementsUser> BodyMeasurementsUsers { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<County> Counties { get; set; } = null!;
        public virtual DbSet<GymMachine> GymMachines { get; set; } = null!;
        public virtual DbSet<GymRoutine> GymRoutines { get; set; } = null!;
        public virtual DbSet<IdentificationType> IdentificationTypes { get; set; } = null!;
        public virtual DbSet<MembershipRegistrationType> MembershipRegistrationTypes { get; set; } = null!;
        public virtual DbSet<PaymentType> PaymentTypes { get; set; } = null!;
        public virtual DbSet<PaymentsPerUser> PaymentsPerUsers { get; set; } = null!;
        public virtual DbSet<Province> Provinces { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RoutinesPerUser> RoutinesPerUsers { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserState> UserStates { get; set; } = null!;
        public virtual DbSet<ViewsPerRole> ViewsPerRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.

                optionsBuilder.UseSqlServer("Server=LAPTOP-QKGV96EV;Database=SteelBodyGym;Trusted_Connection=True;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BodyMeasurementsUser>(entity =>
            {
                entity.HasKey(e => e.IdMeasure)
                    .HasName("PK__BodyMeas__E9B20A9C7FC1E577");

                entity.ToTable("BodyMeasurementsUser");

                entity.Property(e => e.IdMeasure)
                    .HasColumnName("Id_Measure")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Height).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.IdUser).HasColumnName("Id_User");

                entity.Property(e => e.MeasurementDate)
                    .HasColumnType("date")
                    .HasColumnName("Measurement_Date");

                entity.Property(e => e.Waist).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Weight).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.BodyMeasurementsUsers)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__BodyMeasu__Id_Us__70DDC3D8");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.IdCities)
                    .HasName("PK__Cities__99E9A55B4648EA8A");

                entity.Property(e => e.IdCities)
                    .HasColumnName("Id_Cities")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdCounties).HasColumnName("Id_Counties");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCountiesNavigation)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.IdCounties)
                    .HasConstraintName("FK__Cities__Id_Count__01142BA1");
            });

            modelBuilder.Entity<County>(entity =>
            {
                entity.HasKey(e => e.IdCounties)
                    .HasName("PK__Counties__78D5D313E1BA6CC4");

                entity.Property(e => e.IdCounties)
                    .HasColumnName("Id_Counties")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdProvince).HasColumnName("Id_Province");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProvinceNavigation)
                    .WithMany(p => p.Counties)
                    .HasForeignKey(d => d.IdProvince)
                    .HasConstraintName("FK__Counties__Id_Pro__47DBAE45");
            });

            modelBuilder.Entity<GymMachine>(entity =>
            {
                entity.HasKey(e => e.IdMachine)
                    .HasName("PK__GymMachi__B8A2FA9106496CF7");

                entity.Property(e => e.IdMachine)
                    .HasColumnName("Id_Machine")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.MachineName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Machine_Name");
            });

            modelBuilder.Entity<GymRoutine>(entity =>
            {
                entity.HasKey(e => e.IdRoutine)
                    .HasName("PK__GymRouti__5D1EA0979406A279");

                entity.Property(e => e.IdRoutine)
                    .HasColumnName("Id_Routine")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.RoutineName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Routine_Name");
            });

            modelBuilder.Entity<IdentificationType>(entity =>
            {
                entity.Property(e => e.IdentificationTypeId)
                    .HasColumnName("Identification_Type_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MembershipRegistrationType>(entity =>
            {
                entity.HasKey(e => e.IdMembershipRegistrationTypes)
                    .HasName("PK__Membersh__5894A87C204C26A9");

                entity.Property(e => e.IdMembershipRegistrationTypes)
                    .HasColumnName("Id_Membership_Registration_Types")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.RegistrationTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Registration_Type_Name");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.HasKey(e => e.IdPaymentType)
                    .HasName("PK__PaymentT__A30A1F6074D757C2");

                entity.Property(e => e.IdPaymentType)
                    .HasColumnName("Id_Payment_Type")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaymentsPerUser>(entity =>
            {
                entity.HasKey(e => e.IdPaymentsPerUser)
                    .HasName("PK__Payments__BFA60BE79C44E3E9");

                entity.ToTable("PaymentsPerUser");

                entity.Property(e => e.IdPaymentsPerUser)
                    .HasColumnName("Id_Payments_Per_User")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.IdMembershipRegistrationTypes).HasColumnName("Id_Membership_Registration_Types");

                entity.Property(e => e.IdPaymentType).HasColumnName("Id_Payment_Type");

                entity.Property(e => e.IdUser).HasColumnName("Id_User");

                entity.Property(e => e.PaymentDay)
                    .HasColumnType("date")
                    .HasColumnName("Payment_Day");

                entity.HasOne(d => d.IdMembershipRegistrationTypesNavigation)
                    .WithMany(p => p.PaymentsPerUsers)
                    .HasForeignKey(d => d.IdMembershipRegistrationTypes)
                    .HasConstraintName("FK__PaymentsP__Id_Me__6D0D32F4");

                entity.HasOne(d => d.IdPaymentTypeNavigation)
                    .WithMany(p => p.PaymentsPerUsers)
                    .HasForeignKey(d => d.IdPaymentType)
                    .HasConstraintName("FK__PaymentsP__Id_Pa__6C190EBB");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.PaymentsPerUsers)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__PaymentsP__Id_Us__6B24EA82");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasKey(e => e.IdProvince)
                    .HasName("PK__Province__85B8CA6C6D8FCAE5");

                entity.ToTable("Province");

                entity.Property(e => e.IdProvince)
                    .HasColumnName("Id_Province")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ProvinceName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Province_Name");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Roles__55932E865DA1318D");

                entity.Property(e => e.IdRol)
                    .HasColumnName("Id_Rol")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.RolName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Rol_Name");
            });

            modelBuilder.Entity<RoutinesPerUser>(entity =>
            {
                entity.HasKey(e => e.RoutinesPerPersonId)
                    .HasName("PK__Routines__61383E679EA3AB87");

                entity.ToTable("RoutinesPerUser");

                entity.Property(e => e.RoutinesPerPersonId)
                    .HasColumnName("Routines_Per_Person_ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdMachine).HasColumnName("Id_Machine");

                entity.Property(e => e.IdRoutine)
                    .HasColumnName("Id_Routine")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdUser)
                    .HasColumnName("Id_User")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.IdMachineNavigation)
                    .WithMany(p => p.RoutinesPerUsers)
                    .HasForeignKey(d => d.IdMachine)
                    .HasConstraintName("FK__RoutinesP__Id_Ma__619B8048");

                entity.HasOne(d => d.IdRoutineNavigation)
                    .WithMany(p => p.RoutinesPerUsers)
                    .HasForeignKey(d => d.IdRoutine)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RoutinesP__Id_Ro__60A75C0F");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.RoutinesPerUsers)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RoutinesP__Id_Us__5FB337D6");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Users__D03DEDCB68B3CA73");

                entity.Property(e => e.IdUser)
                    .HasColumnName("Id_User")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("Birth_Date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IdCities).HasColumnName("Id_Cities");

                entity.Property(e => e.IdCounties).HasColumnName("Id_Counties");

                entity.Property(e => e.IdNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Id_Number");

                entity.Property(e => e.IdProvince).HasColumnName("Id_Province");

                entity.Property(e => e.IdRol).HasColumnName("Id_Rol");

                entity.Property(e => e.IdState).HasColumnName("Id_State");

                entity.Property(e => e.IdentificationTypeId).HasColumnName("Identification_Type_ID");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.HasOne(d => d.IdCitiesNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdCities)
                    .HasConstraintName("FK__Users__Id_Cities__5441852A");

                entity.HasOne(d => d.IdCountiesNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdCounties)
                    .HasConstraintName("FK__Users__Id_Counti__534D60F1");

                entity.HasOne(d => d.IdProvinceNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdProvince)
                    .HasConstraintName("FK__Users__Id_Provin__52593CB8");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__Id_Cities__4F7CD00D");

                entity.HasOne(d => d.IdStateNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdState)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__Id_State__5165187F");

                entity.HasOne(d => d.IdentificationType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdentificationTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__Identific__5070F446");
            });

            modelBuilder.Entity<UserState>(entity =>
            {
                entity.HasKey(e => e.IdState)
                    .HasName("PK__UserStat__3FDA21FBF0EDAA0B");

                entity.ToTable("UserState");

                entity.Property(e => e.IdState)
                    .HasColumnName("Id_State")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.StateName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("State_Name");
            });

            modelBuilder.Entity<ViewsPerRole>(entity =>
            {
                entity.HasKey(e => e.IdViewsPerRoles)
                    .HasName("PK__ViewsPer__DDA8FC553CBA1F9C");

                entity.Property(e => e.IdViewsPerRoles)
                    .HasColumnName("Id_ViewsPerRoles")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdRol).HasColumnName("Id_Rol");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.ViewsPerRoles)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ViewsPerR__Id_Ro__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
