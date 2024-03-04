using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace newcsa.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    std_id = table.Column<int>(type: "int", nullable: false),
                    password = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    gender = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    y_o_p = table.Column<int>(type: "int", nullable: true),
                    branch = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    marks = table.Column<int>(type: "int", nullable: true),
                    email = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__student__0B0245BA35A63A60", x => x.std_id);
                });

            migrationBuilder.CreateTable(
                name: "meassage",
                columns: table => new
                {
                    msg_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Msg_Data = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    std_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__meassage__9CA9728D7CE642FC", x => x.msg_id);
                    table.ForeignKey(
                        name: "FK__meassage__std_id__398D8EEE",
                        column: x => x.std_id,
                        principalTable: "student",
                        principalColumn: "std_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_meassage_std_id",
                table: "meassage",
                column: "std_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "meassage");

            migrationBuilder.DropTable(
                name: "student");
        }
    }
}
