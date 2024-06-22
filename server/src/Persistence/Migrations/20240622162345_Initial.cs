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
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.CreateTable(
                name: "abitur_educationalform",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_educational_form = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abitur_educationalform", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "abitur_educationalformasp",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_educational_form = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abitur_educationalformasp", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "abitur_educationalformmag",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_educational_form = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abitur_educationalformmag", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "abitur_educationalformspec",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_educational_form = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abitur_educationalformspec", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "auth_user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    password = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    last_login = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: true),
                    is_superuser = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    username = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    first_name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    last_name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    email = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    is_staff = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    date_joined = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auth_user", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "regabitur_choicesprofile",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regabitur_choicesprofile", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "abitur_orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_order = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    number_order = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    date_pub = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    date_order = table.Column<DateOnly>(type: "date", nullable: false),
                    file = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    educational_form_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abitur_orders", x => x.id);
                    table.ForeignKey(
                        name: "abitur_orders_educational_form_id_85a4ec2b_fk_abitur_ed",
                        column: x => x.educational_form_id,
                        principalTable: "abitur_educationalform",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "abitur_recommendedlist",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_rec_list = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    date_pub = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    date_order = table.Column<DateOnly>(type: "date", nullable: false),
                    file = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    educational_form_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abitur_recommendedlist", x => x.id);
                    table.ForeignKey(
                        name: "abitur_recommendedli_educational_form_id_c510b5d4_fk_abitur_ed",
                        column: x => x.educational_form_id,
                        principalTable: "abitur_educationalform",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "abitur_result",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_result = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    number_result = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    date_pub = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    date_result = table.Column<DateOnly>(type: "date", nullable: false),
                    file = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    educational_form_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abitur_result", x => x.id);
                    table.ForeignKey(
                        name: "abitur_result_educational_form_id_6873845e_fk_abitur_ed",
                        column: x => x.educational_form_id,
                        principalTable: "abitur_educationalform",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "abitur_ordersasp",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_order = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    number_order = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    date_pub = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    date_order = table.Column<DateOnly>(type: "date", nullable: false),
                    file = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    educational_form_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abitur_ordersasp", x => x.id);
                    table.ForeignKey(
                        name: "abitur_ordersasp_educational_form_id_9681a2a1_fk_abitur_ed",
                        column: x => x.educational_form_id,
                        principalTable: "abitur_educationalformasp",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "abitur_recommendedlistasp",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_rec_list = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    date_pub = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    date_order = table.Column<DateOnly>(type: "date", nullable: false),
                    file = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    educational_form_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abitur_recommendedlistasp", x => x.id);
                    table.ForeignKey(
                        name: "abitur_recommendedli_educational_form_id_a9089bd8_fk_abitur_ed",
                        column: x => x.educational_form_id,
                        principalTable: "abitur_educationalformasp",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "abitur_resultasp",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_result = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    number_result = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    date_pub = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    date_result = table.Column<DateOnly>(type: "date", nullable: false),
                    file = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    educational_form_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abitur_resultasp", x => x.id);
                    table.ForeignKey(
                        name: "abitur_resultasp_educational_form_id_b9f800bc_fk_abitur_ed",
                        column: x => x.educational_form_id,
                        principalTable: "abitur_educationalformasp",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "abitur_ordersmag",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_order = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    number_order = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    date_pub = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    date_order = table.Column<DateOnly>(type: "date", nullable: false),
                    file = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    educational_form_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abitur_ordersmag", x => x.id);
                    table.ForeignKey(
                        name: "abitur_ordersmag_educational_form_id_110b11ab_fk_abitur_ed",
                        column: x => x.educational_form_id,
                        principalTable: "abitur_educationalformmag",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "abitur_recommendedlistmag",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_rec_list = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    date_pub = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    date_order = table.Column<DateOnly>(type: "date", nullable: false),
                    file = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    educational_form_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abitur_recommendedlistmag", x => x.id);
                    table.ForeignKey(
                        name: "abitur_recommendedli_educational_form_id_20ab5d2e_fk_abitur_ed",
                        column: x => x.educational_form_id,
                        principalTable: "abitur_educationalformmag",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "abitur_resultmag",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_result = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    number_result = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    date_pub = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    date_result = table.Column<DateOnly>(type: "date", nullable: false),
                    file = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    educational_form_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abitur_resultmag", x => x.id);
                    table.ForeignKey(
                        name: "abitur_resultmag_educational_form_id_44f2ad0d_fk_abitur_ed",
                        column: x => x.educational_form_id,
                        principalTable: "abitur_educationalformmag",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "abitur_ordersspec",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_order = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    number_order = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    date_pub = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    date_order = table.Column<DateOnly>(type: "date", nullable: false),
                    file = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    educational_form_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abitur_ordersspec", x => x.id);
                    table.ForeignKey(
                        name: "abitur_ordersspec_educational_form_id_2c238eeb_fk_abitur_ed",
                        column: x => x.educational_form_id,
                        principalTable: "abitur_educationalformspec",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "adminpanel_emailmessage",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    subject = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    content = table.Column<string>(type: "varchar(4096)", maxLength: 4096, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    recipient_id = table.Column<int>(type: "int(11)", nullable: false),
                    recipientEmail = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    sender_id = table.Column<int>(type: "int(11)", nullable: false),
                    sent_at = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adminpanel_emailmessage", x => x.id);
                    table.ForeignKey(
                        name: "adminpanel_emailmessage_recipient_id_a8779636_fk_auth_user_id",
                        column: x => x.recipient_id,
                        principalTable: "auth_user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "adminpanel_emailmessage_sender_id_7d5eda7b_fk_auth_user_id",
                        column: x => x.sender_id,
                        principalTable: "auth_user",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "regabitur_additionalinfo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int(11)", nullable: false)
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
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "regabitur_customuser",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date_of_birth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    patronymic = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    phone_number = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    sending_status = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    complete_flag = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    agreement_flag = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    user_id = table.Column<int>(type: "int(11)", nullable: false),
                    work_flag = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    success_flag = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    address = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    comment_admin = table.Column<string>(type: "longtext", nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    date_of_doc = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    name_uz = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    passport = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    snils = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    message = table.Column<string>(type: "longtext", nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8")
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
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "regabitur_documentuser",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date_pub = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    name_doc = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    doc = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    user_id = table.Column<int>(type: "int(11)", nullable: false)
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
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "regabitur_publishrectab",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    test_type = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    date_pub = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: true),
                    sogl = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    sost_type = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    advantage = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    individ = table.Column<short>(type: "smallint(6)", nullable: false),
                    rus_point = table.Column<short>(type: "smallint(6)", nullable: false),
                    obsh_point = table.Column<short>(type: "smallint(6)", nullable: false),
                    kp_point = table.Column<short>(type: "smallint(6)", nullable: false),
                    spec_point = table.Column<short>(type: "smallint(6)", nullable: false),
                    sum_points = table.Column<short>(type: "smallint(6)", nullable: false),
                    bak_ofo_gp = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    bak_ofo_up = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    bak_zfo_gp = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    bak_zfo_up = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    bak_ozfo_gp = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    bak_ozfo_up = table.Column<bool>(type: "tinyint(1)", nullable: false),
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
                    user_id = table.Column<int>(type: "int(11)", nullable: false),
                    foreign_language_point = table.Column<short>(type: "smallint(6)", nullable: false),
                    gp_point = table.Column<short>(type: "smallint(6)", nullable: false),
                    history_point = table.Column<short>(type: "smallint(6)", nullable: false),
                    okp_point = table.Column<short>(type: "smallint(6)", nullable: false),
                    tgp_point = table.Column<short>(type: "smallint(6)", nullable: false),
                    up_point = table.Column<short>(type: "smallint(6)", nullable: false),
                    asp_ofo_gp = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    asp_ofo_ugp = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_published = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    comment = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regabitur_publishrectab", x => x.id);
                    table.ForeignKey(
                        name: "regabitur_publishrectab_user_id_9c7ed683_fk_auth_user_id",
                        column: x => x.user_id,
                        principalTable: "auth_user",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "regabitur_publishtab",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    individual_str = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    test_type = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    date_pub = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: true),
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
                    user_id = table.Column<int>(type: "int(11)", nullable: false),
                    asp_ofo_gp = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    asp_ofo_ugp = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    mag_ofo_corp = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    mag_ofo_med = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    mag_zfo_corp = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    mag_zfo_med = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    spec_zfo_sd = table.Column<bool>(type: "tinyint(1)", nullable: false)
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
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "regabitur_additionalinfo_education_profile",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    additionalinfo_id = table.Column<int>(type: "int(11)", nullable: false),
                    choicesprofile_id = table.Column<int>(type: "int(11)", nullable: false)
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
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateTable(
                name: "adminpanel_rectabmodification",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    created_at = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    author = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8_unicode_ci")
                        .Annotation("MySql:CharSet", "utf8"),
                    type = table.Column<ushort>(type: "smallint(5) unsigned", nullable: false),
                    rectab_id = table.Column<int>(type: "int(11)", nullable: true),
                    abiturient_id = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adminpanel_rectabmodification", x => x.id);
                    table.ForeignKey(
                        name: "adminpanel_rectabmod_abiturient_id_80877e36_fk_auth_user",
                        column: x => x.abiturient_id,
                        principalTable: "auth_user",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "adminpanel_rectabmod_rectab_id_48d138d3_fk_regabitur",
                        column: x => x.rectab_id,
                        principalTable: "regabitur_publishrectab",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8")
                .Annotation("Relational:Collation", "utf8_unicode_ci");

            migrationBuilder.CreateIndex(
                name: "abitur_orders_educational_form_id_85a4ec2b_fk_abitur_ed",
                table: "abitur_orders",
                column: "educational_form_id");

            migrationBuilder.CreateIndex(
                name: "abitur_ordersasp_educational_form_id_9681a2a1_fk_abitur_ed",
                table: "abitur_ordersasp",
                column: "educational_form_id");

            migrationBuilder.CreateIndex(
                name: "abitur_ordersmag_educational_form_id_110b11ab_fk_abitur_ed",
                table: "abitur_ordersmag",
                column: "educational_form_id");

            migrationBuilder.CreateIndex(
                name: "abitur_ordersspec_educational_form_id_2c238eeb_fk_abitur_ed",
                table: "abitur_ordersspec",
                column: "educational_form_id");

            migrationBuilder.CreateIndex(
                name: "abitur_recommendedli_educational_form_id_c510b5d4_fk_abitur_ed",
                table: "abitur_recommendedlist",
                column: "educational_form_id");

            migrationBuilder.CreateIndex(
                name: "abitur_recommendedli_educational_form_id_a9089bd8_fk_abitur_ed",
                table: "abitur_recommendedlistasp",
                column: "educational_form_id");

            migrationBuilder.CreateIndex(
                name: "abitur_recommendedli_educational_form_id_20ab5d2e_fk_abitur_ed",
                table: "abitur_recommendedlistmag",
                column: "educational_form_id");

            migrationBuilder.CreateIndex(
                name: "abitur_result_educational_form_id_6873845e_fk_abitur_ed",
                table: "abitur_result",
                column: "educational_form_id");

            migrationBuilder.CreateIndex(
                name: "abitur_resultasp_educational_form_id_b9f800bc_fk_abitur_ed",
                table: "abitur_resultasp",
                column: "educational_form_id");

            migrationBuilder.CreateIndex(
                name: "abitur_resultmag_educational_form_id_44f2ad0d_fk_abitur_ed",
                table: "abitur_resultmag",
                column: "educational_form_id");

            migrationBuilder.CreateIndex(
                name: "adminpanel_emailmessage_recipient_id_a8779636_fk_auth_user_id",
                table: "adminpanel_emailmessage",
                column: "recipient_id");

            migrationBuilder.CreateIndex(
                name: "adminpanel_emailmessage_sender_id_7d5eda7b_fk_auth_user_id",
                table: "adminpanel_emailmessage",
                column: "sender_id");

            migrationBuilder.CreateIndex(
                name: "abiturient_id",
                table: "adminpanel_rectabmodification",
                column: "abiturient_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "rectab_id",
                table: "adminpanel_rectabmodification",
                column: "rectab_id",
                unique: true);

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
                table: "regabitur_publishrectab",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "user_id3",
                table: "regabitur_publishtab",
                column: "user_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "abitur_orders");

            migrationBuilder.DropTable(
                name: "abitur_ordersasp");

            migrationBuilder.DropTable(
                name: "abitur_ordersmag");

            migrationBuilder.DropTable(
                name: "abitur_ordersspec");

            migrationBuilder.DropTable(
                name: "abitur_recommendedlist");

            migrationBuilder.DropTable(
                name: "abitur_recommendedlistasp");

            migrationBuilder.DropTable(
                name: "abitur_recommendedlistmag");

            migrationBuilder.DropTable(
                name: "abitur_result");

            migrationBuilder.DropTable(
                name: "abitur_resultasp");

            migrationBuilder.DropTable(
                name: "abitur_resultmag");

            migrationBuilder.DropTable(
                name: "adminpanel_emailmessage");

            migrationBuilder.DropTable(
                name: "adminpanel_rectabmodification");

            migrationBuilder.DropTable(
                name: "regabitur_additionalinfo_education_profile");

            migrationBuilder.DropTable(
                name: "regabitur_customuser");

            migrationBuilder.DropTable(
                name: "regabitur_documentuser");

            migrationBuilder.DropTable(
                name: "regabitur_publishtab");

            migrationBuilder.DropTable(
                name: "abitur_educationalformspec");

            migrationBuilder.DropTable(
                name: "abitur_educationalform");

            migrationBuilder.DropTable(
                name: "abitur_educationalformasp");

            migrationBuilder.DropTable(
                name: "abitur_educationalformmag");

            migrationBuilder.DropTable(
                name: "regabitur_publishrectab");

            migrationBuilder.DropTable(
                name: "regabitur_additionalinfo");

            migrationBuilder.DropTable(
                name: "regabitur_choicesprofile");

            migrationBuilder.DropTable(
                name: "auth_user");
        }
    }
}
