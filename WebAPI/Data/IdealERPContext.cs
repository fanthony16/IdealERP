using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebAPI.Data
{
    public partial class IdealERPContext : DbContext
    {
        public IdealERPContext()
        {
        }

        public IdealERPContext(DbContextOptions<IdealERPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblApplicationRegistration> TblApplicationRegistrations { get; set; }
        public virtual DbSet<TblAuditLog> TblAuditLogs { get; set; }
        public virtual DbSet<TblCompany> TblCompanies { get; set; }
        public virtual DbSet<TblCountry> TblCountries { get; set; }
        public virtual DbSet<TblCurrency> TblCurrencies { get; set; }
        public virtual DbSet<TblOrganisation> TblOrganisations { get; set; }
        public virtual DbSet<TblPermission> TblPermissions { get; set; }
        public virtual DbSet<TblPlan> TblPlans { get; set; }
        public virtual DbSet<TblRole> TblRoles { get; set; }
        public virtual DbSet<TblRolePermission> TblRolePermissions { get; set; }
        public virtual DbSet<TblSubscription> TblSubscriptions { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }
        public virtual DbSet<TblUserOrganization> TblUserOrganizations { get; set; }
        public virtual DbSet<VwUser> VwUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("****");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblApplicationRegistration>(entity =>
            {
                entity.ToTable("tblApplicationRegistration");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApplicationName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DteCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dteCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SecretHash)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblAuditLog>(entity =>
            {
                entity.ToTable("tblAudit_Log");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("action");

                entity.Property(e => e.ActorUserId).HasColumnName("actor_user_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.EntityId).HasColumnName("entity_id");

                entity.Property(e => e.EntityType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("entity_type");

                entity.Property(e => e.IpAddress)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ip_address");

                entity.Property(e => e.OrganizationId).HasColumnName("organization_id");

                entity.HasOne(d => d.ActorUser)
                    .WithMany(p => p.TblAuditLogs)
                    .HasForeignKey(d => d.ActorUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAudit_Log_tblUsers");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.TblAuditLogs)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAudit_Log_tblOrganisation");
            });

            modelBuilder.Entity<TblCompany>(entity =>
            {
                entity.ToTable("tblCompany");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Address2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address2");

                entity.Property(e => e.BankAccPostingGroup)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("bank_acc_posting_group");

                entity.Property(e => e.BankAccountNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("bank_account_no");

                entity.Property(e => e.BankBranchNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("bank_branch_no");

                entity.Property(e => e.BankName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("bank_name");

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.ContactName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("contact_name");

                entity.Property(e => e.Country)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("country")
                    .IsFixedLength(true);

                entity.Property(e => e.County)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("county");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FaxNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fax_no");

                entity.Property(e => e.GiroNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("giro_no");

                entity.Property(e => e.Iban)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("iban");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.OrganisationId).HasColumnName("organisation_id");

                entity.Property(e => e.PaymentRoutingNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("payment_routing_no");

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone_no");

                entity.Property(e => e.PictureUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("picture_url");

                entity.Property(e => e.PostCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("post_code");

                entity.Property(e => e.ShipToAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ship_to_address");

                entity.Property(e => e.ShipToAddress2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ship_to_address2");

                entity.Property(e => e.ShipToCity)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ship_to_city");

                entity.Property(e => e.ShipToContact)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ship_to_contact");

                entity.Property(e => e.ShipToCountry)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("ship_to_country")
                    .IsFixedLength(true);

                entity.Property(e => e.ShipToCounty)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ship_to_county");

                entity.Property(e => e.ShipToLocation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ship_to_location");

                entity.Property(e => e.ShipToName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ship_to_name");

                entity.Property(e => e.ShipToPostCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ship_to_post_code");

                entity.Property(e => e.SwiftCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("swift_code");

                entity.Property(e => e.VatRegNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("vat_reg_no");

                entity.Property(e => e.Website)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("website");

                entity.HasOne(d => d.Organisation)
                    .WithMany(p => p.TblCompanies)
                    .HasForeignKey(d => d.OrganisationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCompany_tblOrganisations");
            });

            modelBuilder.Entity<TblCountry>(entity =>
            {
                entity.ToTable("tblCountry");

                entity.HasIndex(e => e.CountryCode, "IX_tblCountry")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("country_code")
                    .IsFixedLength(true);

                entity.Property(e => e.CountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("country_name");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblCurrency>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tblCurrency");

                entity.Property(e => e.Code)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("code")
                    .IsFixedLength(true);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");
            });

            modelBuilder.Entity<TblOrganisation>(entity =>
            {
                entity.ToTable("tblOrganisations");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AcceptTerms).HasColumnName("accept_terms");

                entity.Property(e => e.BusinessEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("business_email");

                entity.Property(e => e.CompanySize).HasColumnName("company_size");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("country")
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("currency")
                    .IsFixedLength(true);

                entity.Property(e => e.Industry)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("industry");

                entity.Property(e => e.LegalName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("legal_name");

                entity.Property(e => e.RegistrationStage)
                    .HasColumnName("registration_stage")
                    .HasDefaultValueSql("((3))")
                    .HasComment("3= trial, 2= suspended, 1= active");

                entity.Property(e => e.Timezone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("timezone");

                entity.Property(e => e.TradeName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("trade_name");

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.TblOrganisations)
                    .HasPrincipalKey(p => p.CountryCode)
                    .HasForeignKey(d => d.Country)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblOrganisations_tblCountry");

                entity.HasOne(d => d.CurrencyNavigation)
                    .WithMany(p => p.TblOrganisations)
                    .HasForeignKey(d => d.Currency)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblOrganisations_tblCurrency");
            });

            modelBuilder.Entity<TblPermission>(entity =>
            {
                entity.ToTable("tblPermission");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<TblPlan>(entity =>
            {
                entity.ToTable("tblPlan");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("currency")
                    .IsFixedLength(true);

                entity.Property(e => e.MaxUsers).HasColumnName("max_users");

                entity.Property(e => e.ModulesEnabled)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("modules_enabled");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("price");

                entity.HasOne(d => d.CurrencyNavigation)
                    .WithMany(p => p.TblPlans)
                    .HasForeignKey(d => d.Currency)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPlan_tblCurrency");
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.ToTable("tblRoles");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Scope)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("scope")
                    .HasComment("1 = organization, module = 2");
            });

            modelBuilder.Entity<TblRolePermission>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblRole_Permission");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");
            });

            modelBuilder.Entity<TblSubscription>(entity =>
            {
                entity.ToTable("tblSubscription");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.BillingCycle)
                    .HasColumnName("billing_cycle")
                    .HasDefaultValueSql("((1))")
                    .HasComment("1= Monthly, 2 = Quarterly, 3= Half Yearly, 4= Yearly");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.OrganizationId).HasColumnName("organization_id");

                entity.Property(e => e.PlanId).HasColumnName("plan_id");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("1=active, 2= trial, 3= cancelled");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.TblSubscriptions)
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSubscription_tblPlan");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.ToTable("tblUsers");

                entity.HasIndex(e => e.Email, "IX_tblUsers")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.EmailVerified).HasColumnName("email_verified");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastLoginAt)
                    .HasColumnType("datetime")
                    .HasColumnName("last_login_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password_hash");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((3))")
                    .HasComment("3= Pending, 2= suspended, 1= active");
            });

            modelBuilder.Entity<TblUserOrganization>(entity =>
            {
                entity.ToTable("tblUser_Organization");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.JoinedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("joined_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrganizationId).HasColumnName("organization_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((3))")
                    .HasComment("3=invited, 2=removed, 1=active");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.TblUserOrganizations)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUser_Organization_tblOrganization");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblUserOrganizations)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_tblUser_Organization_tblRoles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblUserOrganizations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUser_Organization_tblUsers");
            });

            modelBuilder.Entity<VwUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_users");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.EmailVerified).HasColumnName("email_verified");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LastLoginAt)
                    .HasColumnType("datetime")
                    .HasColumnName("last_login_at");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.OrganizationId).HasColumnName("organization_id");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password_hash");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("phone_number");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
