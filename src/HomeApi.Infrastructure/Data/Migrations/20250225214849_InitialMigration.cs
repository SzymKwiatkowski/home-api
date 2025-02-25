using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HomeApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "home_app");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "home_app",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "home_app",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: true),
                    security_stamp = table.Column<string>(type: "text", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockout_end = table.Column<long>(type: "bigint", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    access_failed_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "currencies",
                schema: "home_app",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    code = table.Column<string>(type: "text", nullable: false),
                    symbol = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    created = table.Column<long>(type: "bigint", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified = table.Column<long>(type: "bigint", nullable: false),
                    last_modified_by = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_currencies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "event_kinds",
                schema: "home_app",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    default_severity = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    created = table.Column<long>(type: "bigint", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified = table.Column<long>(type: "bigint", nullable: false),
                    last_modified_by = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_event_kinds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "income_kinds",
                schema: "home_app",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    default_severity = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    created = table.Column<long>(type: "bigint", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified = table.Column<long>(type: "bigint", nullable: false),
                    last_modified_by = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_income_kinds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "payment_kinds",
                schema: "home_app",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    default_severity = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    created = table.Column<long>(type: "bigint", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified = table.Column<long>(type: "bigint", nullable: false),
                    last_modified_by = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_payment_kinds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "summaries",
                schema: "home_app",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    overall_amount = table.Column<decimal>(type: "numeric", nullable: false),
                    duration_end = table.Column<long>(type: "bigint", nullable: true),
                    duration_start = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<long>(type: "bigint", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified = table.Column<long>(type: "bigint", nullable: false),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    is_periodic = table.Column<bool>(type: "boolean", nullable: false),
                    period_definition = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    severity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_summaries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "home_app",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<string>(type: "text", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_role_claims_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "home_app",
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "home_app",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_user_claims_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "home_app",
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "home_app",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    provider_key = table.Column<string>(type: "text", nullable: false),
                    provider_display_name = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_logins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_asp_net_user_logins_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "home_app",
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "home_app",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "text", nullable: false),
                    role_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "home_app",
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "home_app",
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "home_app",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "text", nullable: false),
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_asp_net_user_tokens_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "home_app",
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "events",
                schema: "home_app",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    event_kind_id = table.Column<int>(type: "integer", nullable: false),
                    duration_end = table.Column<long>(type: "bigint", nullable: true),
                    duration_start = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<long>(type: "bigint", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified = table.Column<long>(type: "bigint", nullable: false),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    is_periodic = table.Column<bool>(type: "boolean", nullable: false),
                    period_definition = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    severity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_events", x => x.id);
                    table.ForeignKey(
                        name: "fk_events_event_kinds_event_kind_id",
                        column: x => x.event_kind_id,
                        principalSchema: "home_app",
                        principalTable: "event_kinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "incomes",
                schema: "home_app",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    income_kind_id = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    duration_end = table.Column<long>(type: "bigint", nullable: true),
                    duration_start = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<long>(type: "bigint", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified = table.Column<long>(type: "bigint", nullable: false),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    is_periodic = table.Column<bool>(type: "boolean", nullable: false),
                    period_definition = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    severity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_incomes", x => x.id);
                    table.ForeignKey(
                        name: "fk_incomes_income_kinds_income_kind_id",
                        column: x => x.income_kind_id,
                        principalSchema: "home_app",
                        principalTable: "income_kinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                schema: "home_app",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    payment_kind_id = table.Column<int>(type: "integer", nullable: false),
                    duration_end = table.Column<long>(type: "bigint", nullable: true),
                    duration_start = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<long>(type: "bigint", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified = table.Column<long>(type: "bigint", nullable: false),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    is_periodic = table.Column<bool>(type: "boolean", nullable: false),
                    period_definition = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    severity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_payments", x => x.id);
                    table.ForeignKey(
                        name: "fk_payments_payment_kinds_payment_kind_id",
                        column: x => x.payment_kind_id,
                        principalSchema: "home_app",
                        principalTable: "payment_kinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "owners_events",
                schema: "home_app",
                columns: table => new
                {
                    event_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_owners_events", x => new { x.event_id, x.user_id });
                    table.ForeignKey(
                        name: "fk_owners_events_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "home_app",
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_owners_events_events_event_id",
                        column: x => x.event_id,
                        principalSchema: "home_app",
                        principalTable: "events",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "owners_incomes",
                schema: "home_app",
                columns: table => new
                {
                    income_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_owners_incomes", x => new { x.income_id, x.user_id });
                    table.ForeignKey(
                        name: "fk_owners_incomes_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "home_app",
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_owners_incomes_incomes_income_id",
                        column: x => x.income_id,
                        principalSchema: "home_app",
                        principalTable: "incomes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "summaries_incomes",
                schema: "home_app",
                columns: table => new
                {
                    summary_id = table.Column<Guid>(type: "uuid", nullable: false),
                    income_id = table.Column<Guid>(type: "uuid", nullable: false),
                    _incomes_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_summaries_incomes", x => new { x.summary_id, x.income_id });
                    table.ForeignKey(
                        name: "fk_summaries_incomes_incomes__incomes_id",
                        column: x => x._incomes_id,
                        principalSchema: "home_app",
                        principalTable: "incomes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_summaries_incomes_incomes_income_id",
                        column: x => x.income_id,
                        principalSchema: "home_app",
                        principalTable: "incomes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_summaries_incomes_summaries_summary_id",
                        column: x => x.summary_id,
                        principalSchema: "home_app",
                        principalTable: "summaries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "owners_payments",
                schema: "home_app",
                columns: table => new
                {
                    payment_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_owners_payments", x => new { x.payment_id, x.user_id });
                    table.ForeignKey(
                        name: "fk_owners_payments_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "home_app",
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_owners_payments_payments_payment_id",
                        column: x => x.payment_id,
                        principalSchema: "home_app",
                        principalTable: "payments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "summaries_payments",
                schema: "home_app",
                columns: table => new
                {
                    summary_id = table.Column<Guid>(type: "uuid", nullable: false),
                    payment_id = table.Column<Guid>(type: "uuid", nullable: false),
                    _payments_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_summaries_payments", x => new { x.summary_id, x.payment_id });
                    table.ForeignKey(
                        name: "fk_summaries_payments_payments__payments_id",
                        column: x => x._payments_id,
                        principalSchema: "home_app",
                        principalTable: "payments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_summaries_payments_payments_payment_id",
                        column: x => x.payment_id,
                        principalSchema: "home_app",
                        principalTable: "payments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_summaries_payments_summaries_summary_id",
                        column: x => x.summary_id,
                        principalSchema: "home_app",
                        principalTable: "summaries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_role_claims_role_id",
                schema: "home_app",
                table: "AspNetRoleClaims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "home_app",
                table: "AspNetRoles",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_claims_user_id",
                schema: "home_app",
                table: "AspNetUserClaims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_logins_user_id",
                schema: "home_app",
                table: "AspNetUserLogins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_roles_role_id",
                schema: "home_app",
                table: "AspNetUserRoles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "home_app",
                table: "AspNetUsers",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "home_app",
                table: "AspNetUsers",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_currencies_id",
                schema: "home_app",
                table: "currencies",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_event_kinds_id",
                schema: "home_app",
                table: "event_kinds",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_events_event_kind_id",
                schema: "home_app",
                table: "events",
                column: "event_kind_id");

            migrationBuilder.CreateIndex(
                name: "ix_events_id",
                schema: "home_app",
                table: "events",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_income_kinds_id",
                schema: "home_app",
                table: "income_kinds",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_incomes_id",
                schema: "home_app",
                table: "incomes",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_incomes_income_kind_id",
                schema: "home_app",
                table: "incomes",
                column: "income_kind_id");

            migrationBuilder.CreateIndex(
                name: "ix_owners_events_user_id",
                schema: "home_app",
                table: "owners_events",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_owners_incomes_user_id",
                schema: "home_app",
                table: "owners_incomes",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_owners_payments_user_id",
                schema: "home_app",
                table: "owners_payments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_payment_kinds_id",
                schema: "home_app",
                table: "payment_kinds",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_payments_id",
                schema: "home_app",
                table: "payments",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_payments_payment_kind_id",
                schema: "home_app",
                table: "payments",
                column: "payment_kind_id");

            migrationBuilder.CreateIndex(
                name: "ix_summaries_id",
                schema: "home_app",
                table: "summaries",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_summaries_incomes__incomes_id",
                schema: "home_app",
                table: "summaries_incomes",
                column: "_incomes_id");

            migrationBuilder.CreateIndex(
                name: "ix_summaries_incomes_income_id",
                schema: "home_app",
                table: "summaries_incomes",
                column: "income_id");

            migrationBuilder.CreateIndex(
                name: "ix_summaries_payments__payments_id",
                schema: "home_app",
                table: "summaries_payments",
                column: "_payments_id");

            migrationBuilder.CreateIndex(
                name: "ix_summaries_payments_payment_id",
                schema: "home_app",
                table: "summaries_payments",
                column: "payment_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "home_app");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "home_app");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "home_app");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "home_app");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "home_app");

            migrationBuilder.DropTable(
                name: "currencies",
                schema: "home_app");

            migrationBuilder.DropTable(
                name: "owners_events",
                schema: "home_app");

            migrationBuilder.DropTable(
                name: "owners_incomes",
                schema: "home_app");

            migrationBuilder.DropTable(
                name: "owners_payments",
                schema: "home_app");

            migrationBuilder.DropTable(
                name: "summaries_incomes",
                schema: "home_app");

            migrationBuilder.DropTable(
                name: "summaries_payments",
                schema: "home_app");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "home_app");

            migrationBuilder.DropTable(
                name: "events",
                schema: "home_app");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "home_app");

            migrationBuilder.DropTable(
                name: "incomes",
                schema: "home_app");

            migrationBuilder.DropTable(
                name: "payments",
                schema: "home_app");

            migrationBuilder.DropTable(
                name: "summaries",
                schema: "home_app");

            migrationBuilder.DropTable(
                name: "event_kinds",
                schema: "home_app");

            migrationBuilder.DropTable(
                name: "income_kinds",
                schema: "home_app");

            migrationBuilder.DropTable(
                name: "payment_kinds",
                schema: "home_app");
        }
    }
}
