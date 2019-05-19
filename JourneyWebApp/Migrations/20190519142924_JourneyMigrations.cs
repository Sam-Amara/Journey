using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JourneyWebApp.Migrations
{
    public partial class JourneyMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CityName = table.Column<string>(maxLength: 40, nullable: false),
                    Country = table.Column<string>(maxLength: 40, nullable: false),
                    CityState = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TravelerPhoto",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PhotoName = table.Column<string>(maxLength: 200, nullable: true),
                    Thumbnail = table.Column<byte[]>(nullable: true),
                    FilePath = table.Column<string>(maxLength: 1000, nullable: false),
                    Loc = table.Column<string>(maxLength: 100, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelerPhoto", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TripName = table.Column<string>(maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Descript = table.Column<string>(maxLength: 2000, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripCities",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Note = table.Column<string>(maxLength: 2000, nullable: true),
                    CityID = table.Column<int>(nullable: false),
                    TripID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripCities", x => x.ID);
                    table.ForeignKey(
                        name: "FK__TripCitie__CityI__6383C8BA",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__TripCitie__TripI__6477ECF3",
                        column: x => x.TripID,
                        principalTable: "Trip",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TripDetails",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Accomodation = table.Column<string>(maxLength: 200, nullable: false),
                    AccomodationDetails = table.Column<string>(maxLength: 1000, nullable: true),
                    InboundTransportation = table.Column<string>(maxLength: 20, nullable: false),
                    InboundTransportationDetails = table.Column<string>(maxLength: 1000, nullable: true),
                    OutboundTransportation = table.Column<string>(maxLength: 20, nullable: false),
                    OutboundTransportationDetails = table.Column<string>(maxLength: 1000, nullable: true),
                    TripCitiesID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK__TripDetai__TripC__6754599E",
                        column: x => x.TripCitiesID,
                        principalTable: "TripCities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TripActivities",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Activity = table.Column<string>(maxLength: 200, nullable: false),
                    ActivityDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ActivityType = table.Column<string>(maxLength: 20, nullable: true),
                    Cost = table.Column<decimal>(type: "money", nullable: true),
                    Currency = table.Column<string>(maxLength: 10, nullable: true),
                    Note = table.Column<string>(maxLength: 2000, nullable: true),
                    TripDetailsID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripActivities", x => x.ID);
                    table.ForeignKey(
                        name: "FK__TripActiv__TripD__6A30C649",
                        column: x => x.TripDetailsID,
                        principalTable: "TripDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "Traveler",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 40, nullable: true),
                    LastName = table.Column<string>(maxLength: 40, nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    DOB = table.Column<DateTime>(type: "date", nullable: true),
                    Gender = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    Email2 = table.Column<string>(maxLength: 40, nullable: true),
                    AboutMe = table.Column<string>(maxLength: 2000, nullable: true),
                    Occupation = table.Column<string>(maxLength: 100, nullable: true),
                    Hobbies = table.Column<string>(maxLength: 1000, nullable: true),
                    SocialMedia = table.Column<string>(maxLength: 1000, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserID = table.Column<string>(maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traveler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    TravelerId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Traveler_TravelerId",
                        column: x => x.TravelerId,
                        principalTable: "Traveler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TravelerAlbum",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlbumName = table.Column<string>(maxLength: 200, nullable: false),
                    Thumbnail = table.Column<byte[]>(nullable: true),
                    Descript = table.Column<string>(maxLength: 2000, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    TripID = table.Column<long>(nullable: true),
                    TravelerID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelerAlbum", x => x.ID);
                    table.ForeignKey(
                        name: "FK__TravelerA__Trave__10566F31",
                        column: x => x.TravelerID,
                        principalTable: "Traveler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__TravelerA__TripI__0F624AF8",
                        column: x => x.TripID,
                        principalTable: "Trip",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TravelerRelationships",
                columns: table => new
                {
                    TravelerID1 = table.Column<long>(nullable: false),
                    TravelerID2 = table.Column<long>(nullable: false),
                    Relationship = table.Column<string>(maxLength: 40, nullable: false),
                    isFollower = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    isEmergencyContact = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelerRelationships", x => new { x.TravelerID1, x.TravelerID2 });
                    table.ForeignKey(
                        name: "FK__TravelerR__Trave__7B5B524B",
                        column: x => x.TravelerID1,
                        principalTable: "Traveler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__TravelerR__Trave__7C4F7684",
                        column: x => x.TravelerID2,
                        principalTable: "Traveler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TravelersCities",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TravelerAddress = table.Column<string>(maxLength: 200, nullable: true),
                    isCurrent = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    hasLived = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    hasVisited = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    wantVisit = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    TravelerID = table.Column<long>(nullable: false),
                    CityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelersCities", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Travelers__CityI__08B54D69",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Travelers__Trave__09A971A2",
                        column: x => x.TravelerID,
                        principalTable: "Traveler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TravelersTrips",
                columns: table => new
                {
                    TripID = table.Column<long>(nullable: false),
                    TravelerID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelersTrips", x => new { x.TripID, x.TravelerID });
                    table.ForeignKey(
                        name: "FK__Travelers__Trave__01142BA1",
                        column: x => x.TravelerID,
                        principalTable: "Traveler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Travelers__TripI__00200768",
                        column: x => x.TripID,
                        principalTable: "Trip",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlbumPhoto",
                columns: table => new
                {
                    AlbumID = table.Column<long>(nullable: false),
                    PhotoID = table.Column<long>(nullable: false),
                    SequenceNumber = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumPhoto", x => new { x.AlbumID, x.PhotoID });
                    table.ForeignKey(
                        name: "FK__AlbumPhot__Album__14270015",
                        column: x => x.AlbumID,
                        principalTable: "TravelerAlbum",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__AlbumPhot__Photo__151B244E",
                        column: x => x.PhotoID,
                        principalTable: "TravelerPhoto",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlbumPhoto_PhotoID",
                table: "AlbumPhoto",
                column: "PhotoID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TravelerId",
                table: "AspNetUsers",
                column: "TravelerId");

            migrationBuilder.CreateIndex(
                name: "IX_Traveler_UserID",
                table: "Traveler",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TravelerAlbum_TravelerID",
                table: "TravelerAlbum",
                column: "TravelerID");

            migrationBuilder.CreateIndex(
                name: "IX_TravelerAlbum_TripID",
                table: "TravelerAlbum",
                column: "TripID");

            migrationBuilder.CreateIndex(
                name: "UQ__Traveler__48D910BDC44C4D2D",
                table: "TravelerPhoto",
                column: "FilePath",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TravelerRelationships_TravelerID2",
                table: "TravelerRelationships",
                column: "TravelerID2");

            migrationBuilder.CreateIndex(
                name: "IX_TravelersCities_CityID",
                table: "TravelersCities",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_TravelersCities_TravelerID",
                table: "TravelersCities",
                column: "TravelerID");

            migrationBuilder.CreateIndex(
                name: "IX_TravelersTrips_TravelerID",
                table: "TravelersTrips",
                column: "TravelerID");

            migrationBuilder.CreateIndex(
                name: "IX_TripActivities_TripDetailsID",
                table: "TripActivities",
                column: "TripDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_TripCities_CityID",
                table: "TripCities",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_TripCities_TripID",
                table: "TripCities",
                column: "TripID");

            migrationBuilder.CreateIndex(
                name: "IX_TripDetails_TripCitiesID",
                table: "TripDetails",
                column: "TripCitiesID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Traveler_AspNetUsers_UserID",
                table: "Traveler",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Traveler_AspNetUsers_UserID",
                table: "Traveler");

            migrationBuilder.DropTable(
                name: "AlbumPhoto");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "TravelerRelationships");

            migrationBuilder.DropTable(
                name: "TravelersCities");

            migrationBuilder.DropTable(
                name: "TravelersTrips");

            migrationBuilder.DropTable(
                name: "TripActivities");

            migrationBuilder.DropTable(
                name: "TravelerAlbum");

            migrationBuilder.DropTable(
                name: "TravelerPhoto");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "TripDetails");

            migrationBuilder.DropTable(
                name: "TripCities");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Trip");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Traveler");
        }
    }
}
