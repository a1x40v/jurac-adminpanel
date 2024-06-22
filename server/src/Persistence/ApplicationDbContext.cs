using Domain;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Persistence
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AbiturEducationalform> AbiturEducationalforms { get; set; }
        public virtual DbSet<AbiturEducationalformasp> AbiturEducationalformasps { get; set; }
        public virtual DbSet<AbiturEducationalformmag> AbiturEducationalformmags { get; set; }
        public virtual DbSet<AbiturEducationalformspec> AbiturEducationalformspecs { get; set; }
        public virtual DbSet<AbiturOrder> AbiturOrders { get; set; }
        public virtual DbSet<AbiturOrdersasp> AbiturOrdersasps { get; set; }
        public virtual DbSet<AbiturOrdersmag> AbiturOrdersmags { get; set; }
        public virtual DbSet<AbiturOrdersspec> AbiturOrdersspecs { get; set; }
        public virtual DbSet<AbiturRecommendedlist> AbiturRecommendedlists { get; set; }
        public virtual DbSet<AbiturRecommendedlistasp> AbiturRecommendedlistasps { get; set; }
        public virtual DbSet<AbiturRecommendedlistmag> AbiturRecommendedlistmags { get; set; }
        public virtual DbSet<AbiturResult> AbiturResults { get; set; }
        public virtual DbSet<AbiturResultasp> AbiturResultasps { get; set; }
        public virtual DbSet<AbiturResultmag> AbiturResultmags { get; set; }
        public virtual DbSet<AdminpanelEmailmessage> AdminpanelEmailmessages { get; set; }
        public virtual DbSet<AdminpanelRectabmodification> AdminpanelRectabmodifications { get; set; }
        public virtual DbSet<AuthUser> AuthUsers { get; set; }
        public virtual DbSet<RegabiturAdditionalinfo> RegabiturAdditionalinfos { get; set; }
        public virtual DbSet<RegabiturAdditionalinfoEducationProfile> RegabiturAdditionalinfoEducationProfiles { get; set; }
        public virtual DbSet<RegabiturChoicesprofile> RegabiturChoicesprofiles { get; set; }
        public virtual DbSet<RegabiturCustomuser> RegabiturCustomusers { get; set; }
        public virtual DbSet<RegabiturDocumentuser> RegabiturDocumentusers { get; set; }
        public virtual DbSet<RegabiturPublishrectab> RegabiturPublishrectabs { get; set; }
        public virtual DbSet<RegabiturPublishtab> RegabiturPublishtabs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=141.8.192.132;user=a0173508_abiturient;password=aMw6QXyr;database=a0173508_abiturient", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.37-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_unicode_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<AbiturEducationalform>(entity =>
            {
                entity.ToTable("abitur_educationalform");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.NameEducationalForm)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name_educational_form");
            });

            modelBuilder.Entity<AbiturEducationalformasp>(entity =>
            {
                entity.ToTable("abitur_educationalformasp");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.NameEducationalForm)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name_educational_form");
            });

            modelBuilder.Entity<AbiturEducationalformmag>(entity =>
            {
                entity.ToTable("abitur_educationalformmag");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.NameEducationalForm)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name_educational_form");
            });

            modelBuilder.Entity<AbiturEducationalformspec>(entity =>
            {
                entity.ToTable("abitur_educationalformspec");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.NameEducationalForm)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("name_educational_form");
            });

            modelBuilder.Entity<AbiturOrder>(entity =>
            {
                entity.ToTable("abitur_orders");

                entity.HasIndex(e => e.EducationalFormId, "abitur_orders_educational_form_id_85a4ec2b_fk_abitur_ed");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DateOrder).HasColumnName("date_order");

                entity.Property(e => e.DatePub)
                    .HasMaxLength(6)
                    .HasColumnName("date_pub");

                entity.Property(e => e.EducationalFormId)
                    .HasColumnType("int(11)")
                    .HasColumnName("educational_form_id");

                entity.Property(e => e.File)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("file");

                entity.Property(e => e.NameOrder)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name_order");

                entity.Property(e => e.NumberOrder)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("number_order");

                entity.HasOne(d => d.EducationalForm)
                    .WithMany(p => p.AbiturOrders)
                    .HasForeignKey(d => d.EducationalFormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("abitur_orders_educational_form_id_85a4ec2b_fk_abitur_ed");
            });

            modelBuilder.Entity<AbiturOrdersasp>(entity =>
            {
                entity.ToTable("abitur_ordersasp");

                entity.HasIndex(e => e.EducationalFormId, "abitur_ordersasp_educational_form_id_9681a2a1_fk_abitur_ed");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DateOrder).HasColumnName("date_order");

                entity.Property(e => e.DatePub)
                    .HasMaxLength(6)
                    .HasColumnName("date_pub");

                entity.Property(e => e.EducationalFormId)
                    .HasColumnType("int(11)")
                    .HasColumnName("educational_form_id");

                entity.Property(e => e.File)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("file");

                entity.Property(e => e.NameOrder)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name_order");

                entity.Property(e => e.NumberOrder)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("number_order");

                entity.HasOne(d => d.EducationalForm)
                    .WithMany(p => p.AbiturOrdersasps)
                    .HasForeignKey(d => d.EducationalFormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("abitur_ordersasp_educational_form_id_9681a2a1_fk_abitur_ed");
            });

            modelBuilder.Entity<AbiturOrdersmag>(entity =>
            {
                entity.ToTable("abitur_ordersmag");

                entity.HasIndex(e => e.EducationalFormId, "abitur_ordersmag_educational_form_id_110b11ab_fk_abitur_ed");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DateOrder).HasColumnName("date_order");

                entity.Property(e => e.DatePub)
                    .HasMaxLength(6)
                    .HasColumnName("date_pub");

                entity.Property(e => e.EducationalFormId)
                    .HasColumnType("int(11)")
                    .HasColumnName("educational_form_id");

                entity.Property(e => e.File)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("file");

                entity.Property(e => e.NameOrder)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name_order");

                entity.Property(e => e.NumberOrder)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("number_order");

                entity.HasOne(d => d.EducationalForm)
                    .WithMany(p => p.AbiturOrdersmags)
                    .HasForeignKey(d => d.EducationalFormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("abitur_ordersmag_educational_form_id_110b11ab_fk_abitur_ed");
            });

            modelBuilder.Entity<AbiturOrdersspec>(entity =>
            {
                entity.ToTable("abitur_ordersspec");

                entity.HasIndex(e => e.EducationalFormId, "abitur_ordersspec_educational_form_id_2c238eeb_fk_abitur_ed");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DateOrder).HasColumnName("date_order");

                entity.Property(e => e.DatePub)
                    .HasMaxLength(6)
                    .HasColumnName("date_pub");

                entity.Property(e => e.EducationalFormId)
                    .HasColumnType("int(11)")
                    .HasColumnName("educational_form_id");

                entity.Property(e => e.File)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("file");

                entity.Property(e => e.NameOrder)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name_order");

                entity.Property(e => e.NumberOrder)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("number_order");

                entity.HasOne(d => d.EducationalForm)
                    .WithMany(p => p.AbiturOrdersspecs)
                    .HasForeignKey(d => d.EducationalFormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("abitur_ordersspec_educational_form_id_2c238eeb_fk_abitur_ed");
            });

            modelBuilder.Entity<AbiturRecommendedlist>(entity =>
            {
                entity.ToTable("abitur_recommendedlist");

                entity.HasIndex(e => e.EducationalFormId, "abitur_recommendedli_educational_form_id_c510b5d4_fk_abitur_ed");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DateOrder).HasColumnName("date_order");

                entity.Property(e => e.DatePub)
                    .HasMaxLength(6)
                    .HasColumnName("date_pub");

                entity.Property(e => e.EducationalFormId)
                    .HasColumnType("int(11)")
                    .HasColumnName("educational_form_id");

                entity.Property(e => e.File)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("file");

                entity.Property(e => e.NameRecList)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name_rec_list");

                entity.HasOne(d => d.EducationalForm)
                    .WithMany(p => p.AbiturRecommendedlists)
                    .HasForeignKey(d => d.EducationalFormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("abitur_recommendedli_educational_form_id_c510b5d4_fk_abitur_ed");
            });

            modelBuilder.Entity<AbiturRecommendedlistasp>(entity =>
            {
                entity.ToTable("abitur_recommendedlistasp");

                entity.HasIndex(e => e.EducationalFormId, "abitur_recommendedli_educational_form_id_a9089bd8_fk_abitur_ed");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DateOrder).HasColumnName("date_order");

                entity.Property(e => e.DatePub)
                    .HasMaxLength(6)
                    .HasColumnName("date_pub");

                entity.Property(e => e.EducationalFormId)
                    .HasColumnType("int(11)")
                    .HasColumnName("educational_form_id");

                entity.Property(e => e.File)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("file");

                entity.Property(e => e.NameRecList)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name_rec_list");

                entity.HasOne(d => d.EducationalForm)
                    .WithMany(p => p.AbiturRecommendedlistasps)
                    .HasForeignKey(d => d.EducationalFormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("abitur_recommendedli_educational_form_id_a9089bd8_fk_abitur_ed");
            });

            modelBuilder.Entity<AbiturRecommendedlistmag>(entity =>
            {
                entity.ToTable("abitur_recommendedlistmag");

                entity.HasIndex(e => e.EducationalFormId, "abitur_recommendedli_educational_form_id_20ab5d2e_fk_abitur_ed");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DateOrder).HasColumnName("date_order");

                entity.Property(e => e.DatePub)
                    .HasMaxLength(6)
                    .HasColumnName("date_pub");

                entity.Property(e => e.EducationalFormId)
                    .HasColumnType("int(11)")
                    .HasColumnName("educational_form_id");

                entity.Property(e => e.File)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("file");

                entity.Property(e => e.NameRecList)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name_rec_list");

                entity.HasOne(d => d.EducationalForm)
                    .WithMany(p => p.AbiturRecommendedlistmags)
                    .HasForeignKey(d => d.EducationalFormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("abitur_recommendedli_educational_form_id_20ab5d2e_fk_abitur_ed");
            });

            modelBuilder.Entity<AbiturResult>(entity =>
            {
                entity.ToTable("abitur_result");

                entity.HasIndex(e => e.EducationalFormId, "abitur_result_educational_form_id_6873845e_fk_abitur_ed");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DatePub)
                    .HasMaxLength(6)
                    .HasColumnName("date_pub");

                entity.Property(e => e.DateResult).HasColumnName("date_result");

                entity.Property(e => e.EducationalFormId)
                    .HasColumnType("int(11)")
                    .HasColumnName("educational_form_id");

                entity.Property(e => e.File)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("file");

                entity.Property(e => e.NameResult)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name_result");

                entity.Property(e => e.NumberResult)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("number_result");

                entity.HasOne(d => d.EducationalForm)
                    .WithMany(p => p.AbiturResults)
                    .HasForeignKey(d => d.EducationalFormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("abitur_result_educational_form_id_6873845e_fk_abitur_ed");
            });

            modelBuilder.Entity<AbiturResultasp>(entity =>
            {
                entity.ToTable("abitur_resultasp");

                entity.HasIndex(e => e.EducationalFormId, "abitur_resultasp_educational_form_id_b9f800bc_fk_abitur_ed");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DatePub)
                    .HasMaxLength(6)
                    .HasColumnName("date_pub");

                entity.Property(e => e.DateResult).HasColumnName("date_result");

                entity.Property(e => e.EducationalFormId)
                    .HasColumnType("int(11)")
                    .HasColumnName("educational_form_id");

                entity.Property(e => e.File)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("file");

                entity.Property(e => e.NameResult)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name_result");

                entity.Property(e => e.NumberResult)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("number_result");

                entity.HasOne(d => d.EducationalForm)
                    .WithMany(p => p.AbiturResultasps)
                    .HasForeignKey(d => d.EducationalFormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("abitur_resultasp_educational_form_id_b9f800bc_fk_abitur_ed");
            });

            modelBuilder.Entity<AbiturResultmag>(entity =>
            {
                entity.ToTable("abitur_resultmag");

                entity.HasIndex(e => e.EducationalFormId, "abitur_resultmag_educational_form_id_44f2ad0d_fk_abitur_ed");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DatePub)
                    .HasMaxLength(6)
                    .HasColumnName("date_pub");

                entity.Property(e => e.DateResult).HasColumnName("date_result");

                entity.Property(e => e.EducationalFormId)
                    .HasColumnType("int(11)")
                    .HasColumnName("educational_form_id");

                entity.Property(e => e.File)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("file");

                entity.Property(e => e.NameResult)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name_result");

                entity.Property(e => e.NumberResult)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("number_result");

                entity.HasOne(d => d.EducationalForm)
                    .WithMany(p => p.AbiturResultmags)
                    .HasForeignKey(d => d.EducationalFormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("abitur_resultmag_educational_form_id_44f2ad0d_fk_abitur_ed");
            });

            modelBuilder.Entity<AdminpanelEmailmessage>(entity =>
            {
                entity.ToTable("adminpanel_emailmessage");

                entity.HasIndex(e => e.RecipientId, "adminpanel_emailmessage_recipient_id_a8779636_fk_auth_user_id");

                entity.HasIndex(e => e.SenderId, "adminpanel_emailmessage_sender_id_7d5eda7b_fk_auth_user_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(4096)
                    .HasColumnName("content");

                entity.Property(e => e.RecipientEmail)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("recipientEmail");

                entity.Property(e => e.RecipientId)
                    .HasColumnType("int(11)")
                    .HasColumnName("recipient_id");

                entity.Property(e => e.SenderId)
                    .HasColumnType("int(11)")
                    .HasColumnName("sender_id");

                entity.Property(e => e.SentAt)
                    .HasMaxLength(6)
                    .HasColumnName("sent_at");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("subject");

                entity.HasOne(d => d.Recipient)
                    .WithMany(p => p.AdminpanelEmailmessageRecipients)
                    .HasForeignKey(d => d.RecipientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("adminpanel_emailmessage_recipient_id_a8779636_fk_auth_user_id");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.AdminpanelEmailmessageSenders)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("adminpanel_emailmessage_sender_id_7d5eda7b_fk_auth_user_id");
            });

            modelBuilder.Entity<AdminpanelRectabmodification>(entity =>
            {
                entity.ToTable("adminpanel_rectabmodification");

                entity.HasIndex(e => e.AbiturientId, "abiturient_id")
                    .IsUnique();

                entity.HasIndex(e => e.RectabId, "rectab_id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.AbiturientId)
                    .HasColumnType("int(11)")
                    .HasColumnName("abiturient_id");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("author");

                entity.Property(e => e.CreatedAt)
                    .HasMaxLength(6)
                    .HasColumnName("created_at");

                entity.Property(e => e.RectabId)
                    .HasColumnType("int(11)")
                    .HasColumnName("rectab_id");

                entity.Property(e => e.Type)
                    .HasColumnType("smallint(5) unsigned")
                    .HasColumnName("type");

                entity.HasOne(d => d.Abiturient)
                    .WithOne(p => p.AdminpanelRectabmodification)
                    .HasForeignKey<AdminpanelRectabmodification>(d => d.AbiturientId)
                    .HasConstraintName("adminpanel_rectabmod_abiturient_id_80877e36_fk_auth_user");

                entity.HasOne(d => d.Rectab)
                    .WithOne(p => p.AdminpanelRectabmodification)
                    .HasForeignKey<AdminpanelRectabmodification>(d => d.RectabId)
                    .HasConstraintName("adminpanel_rectabmod_rectab_id_48d138d3_fk_regabitur");
            });

            modelBuilder.Entity<AuthUser>(entity =>
            {
                entity.ToTable("auth_user");

                entity.HasIndex(e => e.Username, "username")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DateJoined)
                    .HasMaxLength(6)
                    .HasColumnName("date_joined");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(254)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("first_name");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsStaff).HasColumnName("is_staff");

                entity.Property(e => e.IsSuperuser).HasColumnName("is_superuser");

                entity.Property(e => e.LastLogin)
                    .HasMaxLength(6)
                    .HasColumnName("last_login");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<RegabiturAdditionalinfo>(entity =>
            {
                entity.ToTable("regabitur_additionalinfo");

                entity.HasIndex(e => e.UserId, "user_id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.RegabiturAdditionalinfo)
                    .HasForeignKey<RegabiturAdditionalinfo>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("regabitur_additionalinfo_user_id_479b7d54_fk_auth_user_id");
            });

            modelBuilder.Entity<RegabiturAdditionalinfoEducationProfile>(entity =>
            {
                entity.ToTable("regabitur_additionalinfo_education_profile");

                entity.HasIndex(e => e.ChoicesprofileId, "regabitur_additional_choicesprofile_id_c3becd9c_fk_regabitur");

                entity.HasIndex(e => new { e.AdditionalinfoId, e.ChoicesprofileId }, "regabitur_additionalinfo_additionalinfo_id_choice_a9d99a17_uniq")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.AdditionalinfoId)
                    .HasColumnType("int(11)")
                    .HasColumnName("additionalinfo_id");

                entity.Property(e => e.ChoicesprofileId)
                    .HasColumnType("int(11)")
                    .HasColumnName("choicesprofile_id");

                entity.HasOne(d => d.Additionalinfo)
                    .WithMany(p => p.RegabiturAdditionalinfoEducationProfiles)
                    .HasForeignKey(d => d.AdditionalinfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("regabitur_additional_additionalinfo_id_600cd786_fk_regabitur");

                entity.HasOne(d => d.Choicesprofile)
                    .WithMany(p => p.RegabiturAdditionalinfoEducationProfiles)
                    .HasForeignKey(d => d.ChoicesprofileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("regabitur_additional_choicesprofile_id_c3becd9c_fk_regabitur");
            });

            modelBuilder.Entity<RegabiturChoicesprofile>(entity =>
            {
                entity.ToTable("regabitur_choicesprofile");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<RegabiturCustomuser>(entity =>
            {
                entity.ToTable("regabitur_customuser");

                entity.HasIndex(e => e.UserId, "user_id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasColumnName("address");

                entity.Property(e => e.AgreementFlag).HasColumnName("agreement_flag");

                entity.Property(e => e.CommentAdmin)
                    .IsRequired()
                    .HasColumnName("comment_admin");

                entity.Property(e => e.CompleteFlag).HasColumnName("complete_flag");

                entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");

                entity.Property(e => e.DateOfDoc)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("date_of_doc");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnName("message");

                entity.Property(e => e.NameUz)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name_uz");

                entity.Property(e => e.Passport)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("passport");

                entity.Property(e => e.Patronymic)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("patronymic");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("phone_number");

                entity.Property(e => e.SendingStatus)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("sending_status");

                entity.Property(e => e.Snils)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("snils");

                entity.Property(e => e.SuccessFlag).HasColumnName("success_flag");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");

                entity.Property(e => e.WorkFlag).HasColumnName("work_flag");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.RegabiturCustomuser)
                    .HasForeignKey<RegabiturCustomuser>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("regabitur_customuser_user_id_9940f6c5_fk_auth_user_id");
            });

            modelBuilder.Entity<RegabiturDocumentuser>(entity =>
            {
                entity.ToTable("regabitur_documentuser");

                entity.HasIndex(e => e.UserId, "regabitur_documentuser_user_id_2349932c_fk_auth_user_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DatePub)
                    .HasMaxLength(6)
                    .HasColumnName("date_pub");

                entity.Property(e => e.Doc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("doc");

                entity.Property(e => e.NameDoc)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name_doc");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RegabiturDocumentusers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("regabitur_documentuser_user_id_2349932c_fk_auth_user_id");
            });

            modelBuilder.Entity<RegabiturPublishrectab>(entity =>
            {
                entity.ToTable("regabitur_publishrectab");

                entity.HasIndex(e => e.UserId, "user_id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Advantage)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("advantage");

                entity.Property(e => e.AspOfoGp).HasColumnName("asp_ofo_gp");

                entity.Property(e => e.AspOfoKs).HasColumnName("asp_ofo_ks");

                entity.Property(e => e.AspOfoTip).HasColumnName("asp_ofo_tip");

                entity.Property(e => e.AspOfoUgp).HasColumnName("asp_ofo_ugp");

                entity.Property(e => e.AspOfoUp).HasColumnName("asp_ofo_up");

                entity.Property(e => e.AspZfoKs).HasColumnName("asp_zfo_ks");

                entity.Property(e => e.AspZfoTip).HasColumnName("asp_zfo_tip");

                entity.Property(e => e.AspZfoUp).HasColumnName("asp_zfo_up");

                entity.Property(e => e.BakOfoGp).HasColumnName("bak_ofo_gp");

                entity.Property(e => e.BakOfoUp).HasColumnName("bak_ofo_up");

                entity.Property(e => e.BakOzfoGp).HasColumnName("bak_ozfo_gp");

                entity.Property(e => e.BakOzfoUp).HasColumnName("bak_ozfo_up");

                entity.Property(e => e.BakZfoGp).HasColumnName("bak_zfo_gp");

                entity.Property(e => e.BakZfoUp).HasColumnName("bak_zfo_up");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("comment");

                entity.Property(e => e.DatePub)
                    .HasMaxLength(6)
                    .HasColumnName("date_pub");

                entity.Property(e => e.ForeignLanguagePoint)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("foreign_language_point");

                entity.Property(e => e.GpPoint)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("gp_point");

                entity.Property(e => e.HistoryPoint)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("history_point");

                entity.Property(e => e.Individ)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("individ");

                entity.Property(e => e.IsPublished).HasColumnName("is_published");

                entity.Property(e => e.KpPoint)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("kp_point");

                entity.Property(e => e.MagOfoPo).HasColumnName("mag_ofo_po");

                entity.Property(e => e.MagOfoTp).HasColumnName("mag_ofo_tp");

                entity.Property(e => e.MagZfoPo).HasColumnName("mag_zfo_po");

                entity.Property(e => e.MagZfoTp).HasColumnName("mag_zfo_tp");

                entity.Property(e => e.ObshPoint)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("obsh_point");

                entity.Property(e => e.OkpPoint)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("okp_point");

                entity.Property(e => e.RusPoint)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("rus_point");

                entity.Property(e => e.Sogl)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("sogl");

                entity.Property(e => e.SostType)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("sost_type");

                entity.Property(e => e.SpecOfoSd).HasColumnName("spec_ofo_sd");

                entity.Property(e => e.SpecPoint)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("spec_point");

                entity.Property(e => e.SumPoints)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("sum_points");

                entity.Property(e => e.TestType)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("test_type");

                entity.Property(e => e.TgpPoint)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("tgp_point");

                entity.Property(e => e.UpPoint)
                    .HasColumnType("smallint(6)")
                    .HasColumnName("up_point");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.RegabiturPublishrectab)
                    .HasForeignKey<RegabiturPublishrectab>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("regabitur_publishrectab_user_id_9c7ed683_fk_auth_user_id");
            });

            modelBuilder.Entity<RegabiturPublishtab>(entity =>
            {
                entity.ToTable("regabitur_publishtab");

                entity.HasIndex(e => e.UserId, "user_id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.AspOfoGp).HasColumnName("asp_ofo_gp");

                entity.Property(e => e.AspOfoKs).HasColumnName("asp_ofo_ks");

                entity.Property(e => e.AspOfoTip).HasColumnName("asp_ofo_tip");

                entity.Property(e => e.AspOfoUgp).HasColumnName("asp_ofo_ugp");

                entity.Property(e => e.AspOfoUp).HasColumnName("asp_ofo_up");

                entity.Property(e => e.AspZfoKs).HasColumnName("asp_zfo_ks");

                entity.Property(e => e.AspZfoTip).HasColumnName("asp_zfo_tip");

                entity.Property(e => e.AspZfoUp).HasColumnName("asp_zfo_up");

                entity.Property(e => e.BakOfoGp).HasColumnName("bak_ofo_gp");

                entity.Property(e => e.BakOfoUp).HasColumnName("bak_ofo_up");

                entity.Property(e => e.BakOzfoGp).HasColumnName("bak_ozfo_gp");

                entity.Property(e => e.BakOzfoUp).HasColumnName("bak_ozfo_up");

                entity.Property(e => e.BakZfoGp).HasColumnName("bak_zfo_gp");

                entity.Property(e => e.BakZfoUp).HasColumnName("bak_zfo_up");

                entity.Property(e => e.DatePub)
                    .HasMaxLength(6)
                    .HasColumnName("date_pub");

                entity.Property(e => e.IndividualStr)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("individual_str");

                entity.Property(e => e.MagOfoCorp).HasColumnName("mag_ofo_corp");

                entity.Property(e => e.MagOfoMed).HasColumnName("mag_ofo_med");

                entity.Property(e => e.MagOfoPo).HasColumnName("mag_ofo_po");

                entity.Property(e => e.MagOfoTp).HasColumnName("mag_ofo_tp");

                entity.Property(e => e.MagZfoCorp).HasColumnName("mag_zfo_corp");

                entity.Property(e => e.MagZfoMed).HasColumnName("mag_zfo_med");

                entity.Property(e => e.MagZfoPo).HasColumnName("mag_zfo_po");

                entity.Property(e => e.MagZfoTp).HasColumnName("mag_zfo_tp");

                entity.Property(e => e.SpecOfoSd).HasColumnName("spec_ofo_sd");

                entity.Property(e => e.SpecZfoSd).HasColumnName("spec_zfo_sd");

                entity.Property(e => e.TestType)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("test_type");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.RegabiturPublishtab)
                    .HasForeignKey<RegabiturPublishtab>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("regabitur_publishtab_user_id_3906f876_fk_auth_user_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
