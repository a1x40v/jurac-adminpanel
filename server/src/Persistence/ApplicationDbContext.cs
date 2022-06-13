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

        public virtual DbSet<AuthUser> AuthUsers { get; set; }
        public virtual DbSet<RegabiturAdditionalinfo> RegabiturAdditionalinfos { get; set; }
        public virtual DbSet<RegabiturAdditionalinfoEducationProfile> RegabiturAdditionalinfoEducationProfiles { get; set; }
        public virtual DbSet<RegabiturChoicesprofile> RegabiturChoicesprofiles { get; set; }
        public virtual DbSet<RegabiturCustomuser> RegabiturCustomusers { get; set; }
        public virtual DbSet<RegabiturDocumentuser> RegabiturDocumentusers { get; set; }
        public virtual DbSet<RegabiturPublishtab> RegabiturPublishtabs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthUser>(entity =>
            {
                entity.ToTable("auth_user");

                entity.HasIndex(e => e.Username, "username")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateJoined)
                    .HasColumnType("datetime(6)")
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
                    .HasColumnType("datetime(6)")
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

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

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

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdditionalinfoId).HasColumnName("additionalinfo_id");

                entity.Property(e => e.ChoicesprofileId).HasColumnName("choicesprofile_id");

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

                entity.Property(e => e.Id).HasColumnName("id");

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

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasColumnName("address");

                entity.Property(e => e.AgreementFlag).HasColumnName("agreement_flag");

                entity.Property(e => e.CommentAdmin)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasColumnName("comment_admin");

                entity.Property(e => e.CompleteFlag).HasColumnName("complete_flag");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.DateOfDoc)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("date_of_doc");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnType("longtext")
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

                entity.Property(e => e.UserId).HasColumnName("user_id");

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

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DatePub)
                    .HasColumnType("datetime(6)")
                    .HasColumnName("date_pub");

                entity.Property(e => e.Doc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("doc");

                entity.Property(e => e.NameDoc)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("name_doc");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RegabiturDocumentusers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("regabitur_documentuser_user_id_2349932c_fk_auth_user_id");
            });

            modelBuilder.Entity<RegabiturPublishtab>(entity =>
            {
                entity.ToTable("regabitur_publishtab");

                entity.HasIndex(e => e.UserId, "user_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AspOfoKs).HasColumnName("asp_ofo_ks");

                entity.Property(e => e.AspOfoTip).HasColumnName("asp_ofo_tip");

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
                    .HasColumnType("datetime(6)")
                    .HasColumnName("date_pub");

                entity.Property(e => e.IndividualStr)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("individual_str");

                entity.Property(e => e.MagOfoPo).HasColumnName("mag_ofo_po");

                entity.Property(e => e.MagOfoTp).HasColumnName("mag_ofo_tp");

                entity.Property(e => e.MagZfoPo).HasColumnName("mag_zfo_po");

                entity.Property(e => e.MagZfoTp).HasColumnName("mag_zfo_tp");

                entity.Property(e => e.SpecOfoSd).HasColumnName("spec_ofo_sd");

                entity.Property(e => e.TestType)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("test_type");

                entity.Property(e => e.UserId).HasColumnName("user_id");

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
