using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CampusApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name:"Course",
                columns: table => new {
                    CourseID = table.Column<int>(nullable:false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable:false),
                    Credits = table.Column<int>(nullable:false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Course", x => x.CourseID);
                }
            );

            migrationBuilder.CreateTable(
                name:"Department",
                columns: table => new {
                    DepartmentID = table.Column<int>(nullable:false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable:false, maxLength:50)
                },
                constraints: table=>{
                    table.PrimaryKey("PK_Department", x=> x.DepartmentID);
                }
            );

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new{
                    StudentID = table.Column<int>(nullable:false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable:false,maxLength:50),
                    DepartmentID = table.Column<int>(nullable:false),
                },
                constraints: table => {
                    table.PrimaryKey("PK_Student", x => x.StudentID);
                    table.ForeignKey(
                        name:"FK_Student_Department",
                        column: x=>x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name : "Enrollment",
                columns : table => new {
                    EnrollmentID = table.Column<int>(nullable:false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseID = table.Column<int>(nullable:false),
                    StudentID = table.Column<int>(nullable:false),
                    Status = table.Column<string>(nullable:false)
                },
                constraints:table => {
                    table.PrimaryKey("PK_Enrollment", x => x.EnrollmentID);
                    table.ForeignKey(
                        name:"FK_Enrollment_Student",
                        column: x=>x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name:"FK_Enrollment_Course",
                        column: x=>x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name:"FK_Student_Department", table:"Student");
            migrationBuilder.DropForeignKey(name:"FK_Enrollment_Student", table:"Enrollment");
            migrationBuilder.DropForeignKey(name:"FK_Enrollment_Course", table:"Enrollment");
            migrationBuilder.DropTable("Enrollment");
            migrationBuilder.DropTable("Student");
            migrationBuilder.DropTable("Course");
            migrationBuilder.DropTable("Department");       
        }
    }
}
