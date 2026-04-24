using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HomeApi.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class CompromisedMigratoins : Migration
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
                    is_default = table.Column<bool>(type: "boolean", nullable: false),
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
                name: "entry_entity_kinds",
                schema: "home_app",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    entry_kind = table.Column<int>(type: "integer", nullable: false),
                    emoji = table.Column<string>(type: "text", nullable: false),
                    color = table.Column<string>(type: "text", nullable: false),
                    created = table.Column<long>(type: "bigint", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified = table.Column<long>(type: "bigint", nullable: false),
                    last_modified_by = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_entry_entity_kinds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "periodic_entries",
                schema: "home_app",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    occured_at_on_utc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    period_definition = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    entry_entity_kind_id = table.Column<short>(type: "smallint", nullable: false),
                    entry_kind = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    amount = table.Column<decimal>(type: "numeric", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    duration_end = table.Column<long>(type: "bigint", nullable: true),
                    duration_start = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<long>(type: "bigint", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified = table.Column<long>(type: "bigint", nullable: false),
                    last_modified_by = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_periodic_entries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "summaries",
                schema: "home_app",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    overall_amount = table.Column<decimal>(type: "numeric", nullable: true),
                    duration_end = table.Column<long>(type: "bigint", nullable: true),
                    duration_start = table.Column<long>(type: "bigint", nullable: false),
                    created = table.Column<long>(type: "bigint", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified = table.Column<long>(type: "bigint", nullable: false),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    occured_at_on_utc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
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
                name: "entries",
                schema: "home_app",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: true),
                    entry_entity_kind_id = table.Column<short>(type: "smallint", nullable: false),
                    entry_kind = table.Column<int>(type: "integer", nullable: false),
                    is_completed = table.Column<bool>(type: "boolean", nullable: false),
                    created = table.Column<long>(type: "bigint", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    last_modified = table.Column<long>(type: "bigint", nullable: false),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    occured_at_on_utc = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_entries", x => x.id);
                    table.ForeignKey(
                        name: "fk_entries_entry_entity_kinds_entry_entity_kind_id",
                        column: x => x.entry_entity_kind_id,
                        principalSchema: "home_app",
                        principalTable: "entry_entity_kinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "periodic_entries_users",
                schema: "home_app",
                columns: table => new
                {
                    periodic_entry_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_periodic_entries_users", x => new { x.periodic_entry_id, x.user_id });
                    table.ForeignKey(
                        name: "fk_periodic_entries_users_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "home_app",
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_periodic_entries_users_periodic_entries_periodic_entry_id",
                        column: x => x.periodic_entry_id,
                        principalSchema: "home_app",
                        principalTable: "periodic_entries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "entries_users",
                schema: "home_app",
                columns: table => new
                {
                    entry_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_entries_users", x => new { x.entry_id, x.user_id });
                    table.ForeignKey(
                        name: "fk_entries_users_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "home_app",
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_entries_users_entries_entry_id",
                        column: x => x.entry_id,
                        principalSchema: "home_app",
                        principalTable: "entries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "summaries_entries",
                schema: "home_app",
                columns: table => new
                {
                    summary_id = table.Column<Guid>(type: "uuid", nullable: false),
                    entry_id = table.Column<Guid>(type: "uuid", nullable: false),
                    _entries_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_summaries_entries", x => new { x.summary_id, x.entry_id });
                    table.ForeignKey(
                        name: "fk_summaries_entries_entries__entries_id",
                        column: x => x._entries_id,
                        principalSchema: "home_app",
                        principalTable: "entries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_summaries_entries_entries_entry_id",
                        column: x => x.entry_id,
                        principalSchema: "home_app",
                        principalTable: "entries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_summaries_entries_summaries_summary_id",
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
                name: "ix_entries_entry_entity_kind_id",
                schema: "home_app",
                table: "entries",
                column: "entry_entity_kind_id");

            migrationBuilder.CreateIndex(
                name: "ix_entries_id",
                schema: "home_app",
                table: "entries",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_entries_users_user_id",
                schema: "home_app",
                table: "entries_users",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_entry_entity_kinds_id",
                schema: "home_app",
                table: "entry_entity_kinds",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_periodic_entries_id",
                schema: "home_app",
                table: "periodic_entries",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_periodic_entries_users_user_id",
                schema: "home_app",
                table: "periodic_entries_users",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_summaries_id",
                schema: "home_app",
                table: "summaries",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_summaries_entries__entries_id",
                schema: "home_app",
                table: "summaries_entries",
                column: "_entries_id");

            migrationBuilder.CreateIndex(
                name: "ix_summaries_entries_entry_id",
                schema: "home_app",
                table: "summaries_entries",
                column: "entry_id");
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
                name: "entries_users",
                schema: "home_app");

            migrationBuilder.DropTable(
                name: "periodic_entries_users",
                schema: "home_app");

            migrationBuilder.DropTable(
                name: "summaries_entries",
                schema: "home_app");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "home_app");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "home_app");

            migrationBuilder.DropTable(
                name: "periodic_entries",
                schema: "home_app");

            migrationBuilder.DropTable(
                name: "entries",
                schema: "home_app");

            migrationBuilder.DropTable(
                name: "summaries",
                schema: "home_app");

            migrationBuilder.DropTable(
                name: "entry_entity_kinds",
                schema: "home_app");
        }
    }
}
