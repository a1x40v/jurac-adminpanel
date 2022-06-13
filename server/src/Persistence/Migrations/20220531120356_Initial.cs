using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "auth_user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    password = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_login = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    is_superuser = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    username = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    first_name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_staff = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    date_joined = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auth_user", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "regabitur_choicesprofile",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regabitur_choicesprofile", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "regabitur_additionalinfo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regabitur_additionalinfo", x => x.id);
                    table.ForeignKey(
                        name: "regabitur_additionalinfo_user_id_479b7d54_fk_auth_user_id",
                        column: x => x.user_id,
                        principalTable: "auth_user",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "regabitur_customuser",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date_of_birth = table.Column<DateTime>(type: "date", nullable: false),
                    patronymic = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone_number = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sending_status = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    complete_flag = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    agreement_flag = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    work_flag = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    success_flag = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    address = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    comment_admin = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date_of_doc = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name_uz = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    passport = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    snils = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    message = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regabitur_customuser", x => x.id);
                    table.ForeignKey(
                        name: "regabitur_customuser_user_id_9940f6c5_fk_auth_user_id",
                        column: x => x.user_id,
                        principalTable: "auth_user",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "regabitur_documentuser",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date_pub = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    name_doc = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    doc = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regabitur_documentuser", x => x.id);
                    table.ForeignKey(
                        name: "regabitur_documentuser_user_id_2349932c_fk_auth_user_id",
                        column: x => x.user_id,
                        principalTable: "auth_user",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "regabitur_publishtab",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    individual_str = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    test_type = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date_pub = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    bak_ofo_up = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    bak_ofo_gp = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    bak_zfo_up = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    bak_zfo_gp = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    bak_ozfo_up = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    bak_ozfo_gp = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    spec_ofo_sd = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    mag_ofo_po = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    mag_zfo_po = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    mag_ofo_tp = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    mag_zfo_tp = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    asp_ofo_tip = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    asp_zfo_tip = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    asp_ofo_up = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    asp_zfo_up = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    asp_ofo_ks = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    asp_zfo_ks = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regabitur_publishtab", x => x.id);
                    table.ForeignKey(
                        name: "regabitur_publishtab_user_id_3906f876_fk_auth_user_id",
                        column: x => x.user_id,
                        principalTable: "auth_user",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "regabitur_additionalinfo_education_profile",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    additionalinfo_id = table.Column<int>(type: "int", nullable: false),
                    choicesprofile_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regabitur_additionalinfo_education_profile", x => x.id);
                    table.ForeignKey(
                        name: "regabitur_additional_additionalinfo_id_600cd786_fk_regabitur",
                        column: x => x.additionalinfo_id,
                        principalTable: "regabitur_additionalinfo",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "regabitur_additional_choicesprofile_id_c3becd9c_fk_regabitur",
                        column: x => x.choicesprofile_id,
                        principalTable: "regabitur_choicesprofile",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "username",
                table: "auth_user",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "user_id",
                table: "regabitur_additionalinfo",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "regabitur_additional_choicesprofile_id_c3becd9c_fk_regabitur",
                table: "regabitur_additionalinfo_education_profile",
                column: "choicesprofile_id");

            migrationBuilder.CreateIndex(
                name: "regabitur_additionalinfo_additionalinfo_id_choice_a9d99a17_uniq",
                table: "regabitur_additionalinfo_education_profile",
                columns: new[] { "additionalinfo_id", "choicesprofile_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "user_id1",
                table: "regabitur_customuser",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "regabitur_documentuser_user_id_2349932c_fk_auth_user_id",
                table: "regabitur_documentuser",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "user_id2",
                table: "regabitur_publishtab",
                column: "user_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "regabitur_additionalinfo_education_profile");

            migrationBuilder.DropTable(
                name: "regabitur_customuser");

            migrationBuilder.DropTable(
                name: "regabitur_documentuser");

            migrationBuilder.DropTable(
                name: "regabitur_publishtab");

            migrationBuilder.DropTable(
                name: "regabitur_additionalinfo");

            migrationBuilder.DropTable(
                name: "regabitur_choicesprofile");

            migrationBuilder.DropTable(
                name: "auth_user");
        }
    }
}
