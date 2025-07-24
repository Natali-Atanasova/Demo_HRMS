using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HRAPI.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Engineering" },
                    { 2, "Finance" },
                    { 3, "HR" },
                    { 4, "Marketing" },
                    { 5, "Sales" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "Email", "FirstName", "JobTitle", "LastName", "Salary" },
                values: new object[,]
                {
                    { 1, 1, "ivan.petrov@gmail.com", "Ivan", "Engineering Manager", "Petrov", 9200m },
                    { 2, 1, "maria.georgieva@abv.bg", "Maria", "Software Engineer", "Georgieva", 6700m },
                    { 3, 1, "georgi.ivanov@gmail.com", "Georgi", "QA Engineer", "Ivanov", 3900m },
                    { 4, 1, "desislava.nikolova@abv.bg", "Desislava", "DevOps Engineer", "Nikolova", 6100m },
                    { 5, 1, "petar.dimitrov@gmail.com", "Petar", "Backend Developer", "Dimitrov", 5100m },
                    { 6, 1, "anton.simeonov@abv.bg", "Anton", "Frontend Developer", "Simeonov", 4500m },
                    { 7, 1, "radoslav.iliev@gmail.com", "Radoslav", "Software Engineer", "Iliev", 6100m },
                    { 8, 1, "yulian.stoyanov@abv.bg", "Yulian", "QA Engineer", "Stoyanov", 3700m },
                    { 9, 1, "valentina.hristova@gmail.com", "Valentina", "DevOps Engineer", "Hristova", 6200m },
                    { 10, 1, "milena.yordanova@abv.bg", "Milena", "Programmer", "Yordanova", 3500m },
                    { 11, 1, "nikola.mihailov@gmail.com", "Nikola", "Support Engineer", "Mihailov", 3000m },
                    { 12, 1, "liliya.koleva@abv.bg", "Liliya", "QA Specialist", "Koleva", 2800m },
                    { 13, 1, "todor.vasilev@gmail.com", "Todor", "System Administrator", "Vasilev", 4000m },
                    { 14, 1, "stanislav.petkov@abv.bg", "Stanislav", "Frontend Developer", "Petkov", 3300m },
                    { 15, 1, "martin.grozdanov@gmail.com", "Martin", "Software Engineer", "Grozdanov", 6700m },
                    { 16, 1, "ivaylo.marinov@abv.bg", "Ivaylo", "DevOps Engineer", "Marinov", 5700m },
                    { 17, 1, "borislav.pavlov@gmail.com", "Borislav", "Backend Developer", "Pavlov", 4100m },
                    { 18, 1, "vasil.stankov@abv.bg", "Vasil", "Software Engineer", "Stankov", 4600m },
                    { 19, 1, "polina.dobreva@gmail.com", "Polina", "QA Tester", "Dobreva", 2700m },
                    { 20, 1, "kaloyan.angelov@abv.bg", "Kaloyan", "Frontend Developer", "Angelov", 3100m },
                    { 21, 1, "kristina.filipova@gmail.com", "Kristina", "QA Specialist", "Filipova", 2900m },
                    { 22, 1, "miroslav.borisov@abv.bg", "Miroslav", "DevOps Engineer", "Borisov", 5800m },
                    { 23, 1, "teodora.mitkova@gmail.com", "Teodora", "Support Engineer", "Mitkova", 3100m },
                    { 24, 1, "zhivko.yordanov@abv.bg", "Zhivko", "QA Engineer", "Yordanov", 3900m },
                    { 25, 1, "radostin.tsanev@gmail.com", "Radostin", "System Administrator", "Tsanev", 4200m },
                    { 26, 2, "kalina.petkova@gmail.com", "Kalina", "Finance Manager", "Petkova", 8300m },
                    { 27, 2, "borislav.todorov@abv.bg", "Borislav", "Accountant", "Todorov", 4200m },
                    { 28, 2, "ralica.ganeva@gmail.com", "Ralica", "Financial Analyst", "Ganeva", 4100m },
                    { 29, 2, "martin.penev@abv.bg", "Martin", "Junior Accountant", "Penev", 2500m },
                    { 30, 2, "ivelina.mihailova@gmail.com", "Ivelina", "Finance Specialist", "Mihailova", 5000m },
                    { 31, 2, "stoyan.georgiev@abv.bg", "Stoyan", "Payroll Specialist", "Georgiev", 3200m },
                    { 32, 2, "milko.dimitrov@gmail.com", "Milko", "Financial Auditor", "Dimitrov", 4700m },
                    { 33, 2, "tsvetelina.dobreva@abv.bg", "Tsvetelina", "Accountant", "Dobreva", 2800m },
                    { 34, 2, "plamen.mladenov@gmail.com", "Plamen", "Accountant", "Mladenov", 3100m },
                    { 35, 2, "gergana.koleva@abv.bg", "Gergana", "Financial Analyst", "Koleva", 4200m },
                    { 36, 2, "svetoslav.dimitrov@gmail.com", "Svetoslav", "Senior Accountant", "Dimitrov", 5400m },
                    { 37, 2, "ivona.pavlova@abv.bg", "Ivona", "Financial Specialist", "Pavlova", 3500m },
                    { 38, 2, "stefan.kirilov@gmail.com", "Stefan", "Auditor", "Kirilov", 3100m },
                    { 39, 3, "svetla.petrova@gmail.com", "Svetla", "HR Manager", "Petrova", 7200m },
                    { 40, 3, "danail.popov@abv.bg", "Danail", "HR Specialist", "Popov", 3400m },
                    { 41, 3, "violeta.kirova@gmail.com", "Violeta", "Recruitment Specialist", "Kirova", 3500m },
                    { 42, 3, "emil.todorov@abv.bg", "Emil", "HR Assistant", "Todorov", 2200m },
                    { 43, 3, "monika.stancheva@gmail.com", "Monika", "HR Coordinator", "Stancheva", 4100m },
                    { 44, 3, "nikolay.lazarov@abv.bg", "Nikolay", "Training Specialist", "Lazarov", 3700m },
                    { 45, 3, "kristina.pavlova@gmail.com", "Kristina", "HR Generalist", "Pavlova", 3900m },
                    { 46, 3, "radostin.dinev@abv.bg", "Radostin", "HR Specialist", "Dinev", 2900m },
                    { 47, 3, "mila.hristova@gmail.com", "Mila", "HR Specialist", "Hristova", 3200m },
                    { 48, 3, "diana.zlateva@abv.bg", "Diana", "HR Assistant", "Zlateva", 2100m },
                    { 49, 4, "rositsa.angelova@gmail.com", "Rositsa", "Marketing Manager", "Angelova", 8500m },
                    { 50, 4, "simeon.kolev@abv.bg", "Simeon", "Marketing Specialist", "Kolev", 3500m },
                    { 51, 4, "lyudmila.mileva@gmail.com", "Lyudmila", "Content Writer", "Mileva", 2800m },
                    { 52, 4, "tihomir.yordanov@abv.bg", "Tihomir", "Graphic Designer", "Yordanov", 3200m },
                    { 53, 4, "gergana.valcheva@gmail.com", "Gergana", "SEO Specialist", "Valcheva", 3600m },
                    { 54, 4, "bogdan.rusev@abv.bg", "Bogdan", "Marketing Analyst", "Rusev", 5100m },
                    { 55, 4, "yana.gospodinova@gmail.com", "Yana", "PR Specialist", "Gospodinova", 4400m },
                    { 56, 4, "stefan.petkov@abv.bg", "Stefan", "Copywriter", "Petkov", 2400m },
                    { 57, 4, "lora.borisova@gmail.com", "Lora", "Social Media Specialist", "Borisova", 3100m },
                    { 58, 4, "viktor.marinov@abv.bg", "Viktor", "Marketing Coordinator", "Marinov", 3800m },
                    { 59, 4, "petya.mihova@gmail.com", "Petya", "Event Specialist", "Mihova", 2900m },
                    { 60, 4, "emiliya.hristova@abv.bg", "Emiliya", "SEO Analyst", "Hristova", 3700m },
                    { 61, 4, "atanas.todorov@gmail.com", "Atanas", "Graphic Designer", "Todorov", 4100m },
                    { 62, 4, "veronika.ilieva@abv.bg", "Veronika", "Content Manager", "Ilieva", 5200m },
                    { 63, 4, "slavi.stoyanov@gmail.com", "Slavi", "Copywriter", "Stoyanov", 2400m },
                    { 64, 4, "ekaterina.dineva@abv.bg", "Ekaterina", "PR Specialist", "Dineva", 3200m },
                    { 65, 5, "aleksandar.zlatev@gmail.com", "Aleksandar", "Sales Manager", "Zlatev", 9500m },
                    { 66, 5, "sofia.ilieva@abv.bg", "Sofia", "Sales Representative", "Ilieva", 2600m },
                    { 67, 5, "vladimir.kalchev@gmail.com", "Vladimir", "Sales Assistant", "Kalchev", 2700m },
                    { 68, 5, "daniela.tsoneva@abv.bg", "Daniela", "Account Executive", "Tsoneva", 3400m },
                    { 69, 5, "todor.kostov@gmail.com", "Todor", "Sales Coordinator", "Kostov", 6100m },
                    { 70, 5, "elitsa.gencheva@abv.bg", "Elitsa", "Client Consultant", "Gencheva", 2100m },
                    { 71, 5, "dimitar.ivanov@gmail.com", "Dimitar", "Sales Specialist", "Ivanov", 4200m },
                    { 72, 5, "kristina.pavlova@abv.bg", "Kristina", "Account Manager", "Pavlova", 7400m },
                    { 73, 5, "radostin.stanev@gmail.com", "Radostin", "Sales Agent", "Stanev", 2900m },
                    { 74, 5, "mila.hristova@abv.bg", "Mila", "Sales Admin", "Hristova", 4000m },
                    { 75, 5, "zhivko.yordanov@gmail.com", "Zhivko", "Sales Engineer", "Yordanov", 3500m },
                    { 76, 5, "ivana.dimitrova@abv.bg", "Ivana", "Sales Representative", "Dimitrova", 2700m },
                    { 77, 5, "tanya.nikolova@gmail.com", "Tanya", "Key Account Manager", "Nikolova", 8900m },
                    { 78, 5, "stefan.stoyanov@abv.bg", "Stefan", "Field Sales", "Stoyanov", 3300m },
                    { 79, 5, "vanya.zheleva@gmail.com", "Vanya", "Sales Assistant", "Zheleva", 2400m },
                    { 80, 5, "mihaela.kostova@abv.bg", "Mihaela", "Sales Intern", "Kostova", 2100m },
                    { 81, 5, "boriana.koleva@gmail.com", "Boriana", "Business Development Manager", "Koleva", 9100m },
                    { 82, 5, "veselin.veselinov@abv.bg", "Veselin", "Sales Specialist", "Veselinov", 3300m },
                    { 83, 5, "aneliya.petkova@gmail.com", "Aneliya", "Sales Executive", "Petkova", 3600m },
                    { 84, 5, "plamen.georgiev@abv.bg", "Plamen", "Account Specialist", "Georgiev", 3400m },
                    { 85, 5, "ralitsa.ivanova@gmail.com", "Ralitsa", "Sales Assistant", "Ivanova", 2200m },
                    { 86, 5, "nadezhda.marinova@abv.bg", "Nadezhda", "Sales Coordinator", "Marinova", 3700m },
                    { 87, 5, "viktor.iliev@gmail.com", "Viktor", "Sales Trainer", "Iliev", 4300m },
                    { 88, 5, "stela.valcheva@abv.bg", "Stela", "Client Consultant", "Valcheva", 2100m },
                    { 89, 5, "teodor.denev@gmail.com", "Teodor", "Sales Engineer", "Denev", 3700m },
                    { 90, 5, "silvia.yaneva@abv.bg", "Silvia", "Regional Sales Manager", "Yaneva", 9700m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmployeeId", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { 1, 1, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Admin", "ivan.petrov" },
                    { 2, 2, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Manager", "maria.georgieva" },
                    { 3, 3, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Manager", "georgi.ivanov" },
                    { 4, 4, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "desislava.nikolova" },
                    { 5, 5, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "petar.dimitrov" },
                    { 6, 6, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "anton.simeonov" },
                    { 7, 7, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "radoslav.iliev" },
                    { 8, 8, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "yulian.stoyanov" },
                    { 9, 9, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "valentina.hristova" },
                    { 10, 10, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "milena.yordanova" },
                    { 11, 11, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "nikola.mihailov" },
                    { 12, 12, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "liliya.koleva" },
                    { 13, 13, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "todor.vasilev" },
                    { 14, 14, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "stanislav.petkov" },
                    { 15, 15, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "martin.grozdanov" },
                    { 16, 16, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "ivaylo.marinov" },
                    { 17, 17, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "borislav.pavlov" },
                    { 18, 18, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "vasil.stankov" },
                    { 19, 19, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "polina.dobreva" },
                    { 20, 20, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "kaloyan.angelov" },
                    { 21, 21, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "kristina.filipova" },
                    { 22, 22, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "miroslav.borisov" },
                    { 23, 23, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "teodora.mitkova" },
                    { 24, 24, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "zhivko.yordanov" },
                    { 25, 25, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "radostin.tsanev" },
                    { 26, 26, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Admin", "kalina.petkova" },
                    { 27, 27, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Manager", "borislav.todorov" },
                    { 28, 28, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Manager", "ralica.ganeva" },
                    { 29, 29, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "martin.penev" },
                    { 30, 30, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "ivelina.mihailova" },
                    { 31, 31, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "stoyan.georgiev" },
                    { 32, 32, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "milko.dimitrov" },
                    { 33, 33, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "tsvetelina.dobreva" },
                    { 34, 34, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "plamen.mladenov" },
                    { 35, 35, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "gergana.koleva" },
                    { 36, 36, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "svetoslav.dimitrov" },
                    { 37, 37, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "ivona.pavlova" },
                    { 38, 38, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "stefan.kirilov" },
                    { 39, 39, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "HR Admin", "svetla.petrova" },
                    { 40, 40, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "HR Manager", "danail.popov" },
                    { 41, 41, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "HR Manager", "violeta.kirova" },
                    { 42, 42, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "emil.todorov" },
                    { 43, 43, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "monika.stancheva" },
                    { 44, 44, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "nikolay.lazarov" },
                    { 45, 45, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "kristina.pavlova" },
                    { 46, 46, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "radostin.dinev" },
                    { 47, 47, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "mila.hristova" },
                    { 48, 48, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "diana.zlateva" },
                    { 49, 49, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Admin", "rositsa.angelova" },
                    { 50, 50, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Manager", "simeon.kolev" },
                    { 51, 51, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Manager", "lyudmila.mileva" },
                    { 52, 52, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "tihomir.yordanov" },
                    { 53, 53, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "gergana.valcheva" },
                    { 54, 54, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "bogdan.rusev" },
                    { 55, 55, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "yana.gospodinova" },
                    { 56, 56, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "stefan.petkov" },
                    { 57, 57, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "lora.borisova" },
                    { 58, 58, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "viktor.marinov" },
                    { 59, 59, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "petya.mihova" },
                    { 60, 60, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "emiliya.hristova" },
                    { 61, 61, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "atanas.todorov" },
                    { 62, 62, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "veronika.ilieva" },
                    { 63, 63, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "slavi.stoyanov" },
                    { 64, 64, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "ekaterina.dineva" },
                    { 65, 65, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Admin", "aleksandar.zlatev" },
                    { 66, 66, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Manager", "sofia.ilieva" },
                    { 67, 67, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Manager", "vladimir.kalchev" },
                    { 68, 68, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "daniela.tsoneva" },
                    { 69, 69, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "todor.kostov" },
                    { 70, 70, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "elitsa.gencheva" },
                    { 71, 71, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "dimitar.ivanov" },
                    { 72, 72, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "kristina.pavlova" },
                    { 73, 73, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "radostin.stanev" },
                    { 74, 74, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "mila.hristova" },
                    { 75, 75, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "zhivko.yordanov" },
                    { 76, 76, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "ivana.dimitrova" },
                    { 77, 77, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "tanya.nikolova" },
                    { 78, 78, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "stefan.stoyanov" },
                    { 79, 79, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "vanya.zheleva" },
                    { 80, 80, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "mihaela.kostova" },
                    { 81, 81, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "boriana.koleva" },
                    { 82, 82, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "veselin.veselinov" },
                    { 83, 83, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "aneliya.petkova" },
                    { 84, 84, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "plamen.georgiev" },
                    { 85, 85, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "ralitsa.ivanova" },
                    { 86, 86, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "nadezhda.marinova" },
                    { 87, 87, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "viktor.iliev" },
                    { 88, 88, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "stela.valcheva" },
                    { 89, 89, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Employee", "teodor.denev" },
                    { 90, 90, "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", "Manager", "silvia.yaneva" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Name",
                table: "Departments",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                table: "Employees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmployeeId",
                table: "Users",
                column: "EmployeeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
