using HRAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRAPI.Data
{
    public class HRSysContext : DbContext
    {
        public HRSysContext(DbContextOptions<HRSysContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasOne(p => p.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(p => p.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasIndex(p => p.Email)
                .IsUnique();

            modelBuilder.Entity<Department>()
                .HasIndex(d => d.Name)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasOne(u => u.Employee)
                .WithOne()
                .HasForeignKey<User>(u => u.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed Departments
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Engineering" },
                new Department { Id = 2, Name = "Finance" },
                new Department { Id = 3, Name = "HR" },
                new Department { Id = 4, Name = "Marketing" },
                new Department { Id = 5, Name = "Sales" }
            );

            // Seed Employees
            modelBuilder.Entity<Employee>().HasData(
    
    new Employee { Id = 1, FirstName = "Ivan", LastName = "Petrov", Email = "ivan.petrov@gmail.com", JobTitle = "Engineering Manager", Salary = 9200m, DepartmentId = 1 },
    new Employee { Id = 2, FirstName = "Maria", LastName = "Georgieva", Email = "maria.georgieva@abv.bg", JobTitle = "Software Engineer", Salary = 6700m, DepartmentId = 1 },
    new Employee { Id = 3, FirstName = "Georgi", LastName = "Ivanov", Email = "georgi.ivanov@gmail.com", JobTitle = "QA Engineer", Salary = 3900m, DepartmentId = 1 },
    new Employee { Id = 4, FirstName = "Desislava", LastName = "Nikolova", Email = "desislava.nikolova@abv.bg", JobTitle = "DevOps Engineer", Salary = 6100m, DepartmentId = 1 },
    new Employee { Id = 5, FirstName = "Petar", LastName = "Dimitrov", Email = "petar.dimitrov@gmail.com", JobTitle = "Backend Developer", Salary = 5100m, DepartmentId = 1 },
    new Employee { Id = 6, FirstName = "Anton", LastName = "Simeonov", Email = "anton.simeonov@abv.bg", JobTitle = "Frontend Developer", Salary = 4500m, DepartmentId = 1 },
    new Employee { Id = 7, FirstName = "Radoslav", LastName = "Iliev", Email = "radoslav.iliev@gmail.com", JobTitle = "Software Engineer", Salary = 6100m, DepartmentId = 1 },
    new Employee { Id = 8, FirstName = "Yulian", LastName = "Stoyanov", Email = "yulian.stoyanov@abv.bg", JobTitle = "QA Engineer", Salary = 3700m, DepartmentId = 1 },
    new Employee { Id = 9, FirstName = "Valentina", LastName = "Hristova", Email = "valentina.hristova@gmail.com", JobTitle = "DevOps Engineer", Salary = 6200m, DepartmentId = 1 },
    new Employee { Id = 10, FirstName = "Milena", LastName = "Yordanova", Email = "milena.yordanova@abv.bg", JobTitle = "Programmer", Salary = 3500m, DepartmentId = 1 },
    new Employee { Id = 11, FirstName = "Nikola", LastName = "Mihailov", Email = "nikola.mihailov@gmail.com", JobTitle = "Support Engineer", Salary = 3000m, DepartmentId = 1 },
    new Employee { Id = 12, FirstName = "Liliya", LastName = "Koleva", Email = "liliya.koleva@abv.bg", JobTitle = "QA Specialist", Salary = 2800m, DepartmentId = 1 },
    new Employee { Id = 13, FirstName = "Todor", LastName = "Vasilev", Email = "todor.vasilev@gmail.com", JobTitle = "System Administrator", Salary = 4000m, DepartmentId = 1 },
    new Employee { Id = 14, FirstName = "Stanislav", LastName = "Petkov", Email = "stanislav.petkov@abv.bg", JobTitle = "Frontend Developer", Salary = 3300m, DepartmentId = 1 },
    new Employee { Id = 15, FirstName = "Martin", LastName = "Grozdanov", Email = "martin.grozdanov@gmail.com", JobTitle = "Software Engineer", Salary = 6700m, DepartmentId = 1 },
    new Employee { Id = 16, FirstName = "Ivaylo", LastName = "Marinov", Email = "ivaylo.marinov@abv.bg", JobTitle = "DevOps Engineer", Salary = 5700m, DepartmentId = 1 },
    new Employee { Id = 17, FirstName = "Borislav", LastName = "Pavlov", Email = "borislav.pavlov@gmail.com", JobTitle = "Backend Developer", Salary = 4100m, DepartmentId = 1 },
    new Employee { Id = 18, FirstName = "Vasil", LastName = "Stankov", Email = "vasil.stankov@abv.bg", JobTitle = "Software Engineer", Salary = 4600m, DepartmentId = 1 },
    new Employee { Id = 19, FirstName = "Polina", LastName = "Dobreva", Email = "polina.dobreva@gmail.com", JobTitle = "QA Tester", Salary = 2700m, DepartmentId = 1 },
    new Employee { Id = 20, FirstName = "Kaloyan", LastName = "Angelov", Email = "kaloyan.angelov@abv.bg", JobTitle = "Frontend Developer", Salary = 3100m, DepartmentId = 1 },
    new Employee { Id = 21, FirstName = "Kristina", LastName = "Filipova", Email = "kristina.filipova@gmail.com", JobTitle = "QA Specialist", Salary = 2900m, DepartmentId = 1 },
    new Employee { Id = 22, FirstName = "Miroslav", LastName = "Borisov", Email = "miroslav.borisov@abv.bg", JobTitle = "DevOps Engineer", Salary = 5800m, DepartmentId = 1 },
    new Employee { Id = 23, FirstName = "Teodora", LastName = "Mitkova", Email = "teodora.mitkova@gmail.com", JobTitle = "Support Engineer", Salary = 3100m, DepartmentId = 1 },
    new Employee { Id = 24, FirstName = "Zhivko", LastName = "Yordanov", Email = "zhivko.yordanov@abv.bg", JobTitle = "QA Engineer", Salary = 3900m, DepartmentId = 1 },
    new Employee { Id = 25, FirstName = "Radostin", LastName = "Tsanev", Email = "radostin.tsanev@gmail.com", JobTitle = "System Administrator", Salary = 4200m, DepartmentId = 1 },

    
    new Employee { Id = 26, FirstName = "Kalina", LastName = "Petkova", Email = "kalina.petkova@gmail.com", JobTitle = "Finance Manager", Salary = 8300m, DepartmentId = 2 },
    new Employee { Id = 27, FirstName = "Borislav", LastName = "Todorov", Email = "borislav.todorov@abv.bg", JobTitle = "Accountant", Salary = 4200m, DepartmentId = 2 },
    new Employee { Id = 28, FirstName = "Ralica", LastName = "Ganeva", Email = "ralica.ganeva@gmail.com", JobTitle = "Financial Analyst", Salary = 4100m, DepartmentId = 2 },
    new Employee { Id = 29, FirstName = "Martin", LastName = "Penev", Email = "martin.penev@abv.bg", JobTitle = "Junior Accountant", Salary = 2500m, DepartmentId = 2 },
    new Employee { Id = 30, FirstName = "Ivelina", LastName = "Mihailova", Email = "ivelina.mihailova@gmail.com", JobTitle = "Finance Specialist", Salary = 5000m, DepartmentId = 2 },
    new Employee { Id = 31, FirstName = "Stoyan", LastName = "Georgiev", Email = "stoyan.georgiev@abv.bg", JobTitle = "Payroll Specialist", Salary = 3200m, DepartmentId = 2 },
    new Employee { Id = 32, FirstName = "Milko", LastName = "Dimitrov", Email = "milko.dimitrov@gmail.com", JobTitle = "Financial Auditor", Salary = 4700m, DepartmentId = 2 },
    new Employee { Id = 33, FirstName = "Tsvetelina", LastName = "Dobreva", Email = "tsvetelina.dobreva@abv.bg", JobTitle = "Accountant", Salary = 2800m, DepartmentId = 2 },
    new Employee { Id = 34, FirstName = "Plamen", LastName = "Mladenov", Email = "plamen.mladenov@gmail.com", JobTitle = "Accountant", Salary = 3100m, DepartmentId = 2 },
    new Employee { Id = 35, FirstName = "Gergana", LastName = "Koleva", Email = "gergana.koleva@abv.bg", JobTitle = "Financial Analyst", Salary = 4200m, DepartmentId = 2 },
    new Employee { Id = 36, FirstName = "Svetoslav", LastName = "Dimitrov", Email = "svetoslav.dimitrov@gmail.com", JobTitle = "Senior Accountant", Salary = 5400m, DepartmentId = 2 },
    new Employee { Id = 37, FirstName = "Ivona", LastName = "Pavlova", Email = "ivona.pavlova@abv.bg", JobTitle = "Financial Specialist", Salary = 3500m, DepartmentId = 2 },
    new Employee { Id = 38, FirstName = "Stefan", LastName = "Kirilov", Email = "stefan.kirilov@gmail.com", JobTitle = "Auditor", Salary = 3100m, DepartmentId = 2 },

 
    new Employee { Id = 39, FirstName = "Svetla", LastName = "Petrova", Email = "svetla.petrova@gmail.com", JobTitle = "HR Admin", Salary = 7200m, DepartmentId = 3 },
    new Employee { Id = 40, FirstName = "Danail", LastName = "Popov", Email = "danail.popov@abv.bg", JobTitle = "HR Specialist", Salary = 3400m, DepartmentId = 3 },
    new Employee { Id = 41, FirstName = "Violeta", LastName = "Kirova", Email = "violeta.kirova@gmail.com", JobTitle = "Recruitment Specialist", Salary = 3500m, DepartmentId = 3 },
    new Employee { Id = 42, FirstName = "Emil", LastName = "Todorov", Email = "emil.todorov@abv.bg", JobTitle = "HR Assistant", Salary = 2200m, DepartmentId = 3 },
    new Employee { Id = 43, FirstName = "Monika", LastName = "Stancheva", Email = "monika.stancheva@gmail.com", JobTitle = "HR Coordinator", Salary = 4100m, DepartmentId = 3 },
    new Employee { Id = 44, FirstName = "Nikolay", LastName = "Lazarov", Email = "nikolay.lazarov@abv.bg", JobTitle = "Training Specialist", Salary = 3700m, DepartmentId = 3 },
    new Employee { Id = 45, FirstName = "Kristina", LastName = "Pavlova", Email = "kristina.pavlova@gmail.com", JobTitle = "HR Generalist", Salary = 3900m, DepartmentId = 3 },
    new Employee { Id = 46, FirstName = "Radostin", LastName = "Dinev", Email = "radostin.dinev@abv.bg", JobTitle = "HR Specialist", Salary = 2900m, DepartmentId = 3 },
    new Employee { Id = 47, FirstName = "Mila", LastName = "Hristova", Email = "mila.hristova@gmail.com", JobTitle = "HR Specialist", Salary = 3200m, DepartmentId = 3 },
    new Employee { Id = 48, FirstName = "Diana", LastName = "Zlateva", Email = "diana.zlateva@abv.bg", JobTitle = "HR Assistant", Salary = 2100m, DepartmentId = 3 },

  
    new Employee { Id = 49, FirstName = "Rositsa", LastName = "Angelova", Email = "rositsa.angelova@gmail.com", JobTitle = "Marketing Manager", Salary = 8500m, DepartmentId = 4 },
    new Employee { Id = 50, FirstName = "Simeon", LastName = "Kolev", Email = "simeon.kolev@abv.bg", JobTitle = "Marketing Specialist", Salary = 3500m, DepartmentId = 4 },
    new Employee { Id = 51, FirstName = "Lyudmila", LastName = "Mileva", Email = "lyudmila.mileva@gmail.com", JobTitle = "Content Writer", Salary = 2800m, DepartmentId = 4 },
    new Employee { Id = 52, FirstName = "Tihomir", LastName = "Yordanov", Email = "tihomir.yordanov@abv.bg", JobTitle = "Graphic Designer", Salary = 3200m, DepartmentId = 4 },
    new Employee { Id = 53, FirstName = "Gergana", LastName = "Valcheva", Email = "gergana.valcheva@gmail.com", JobTitle = "SEO Specialist", Salary = 3600m, DepartmentId = 4 },
    new Employee { Id = 54, FirstName = "Bogdan", LastName = "Rusev", Email = "bogdan.rusev@abv.bg", JobTitle = "Marketing Analyst", Salary = 5100m, DepartmentId = 4 },
    new Employee { Id = 55, FirstName = "Yana", LastName = "Gospodinova", Email = "yana.gospodinova@gmail.com", JobTitle = "PR Specialist", Salary = 4400m, DepartmentId = 4 },
    new Employee { Id = 56, FirstName = "Stefan", LastName = "Petkov", Email = "stefan.petkov@abv.bg", JobTitle = "Copywriter", Salary = 2400m, DepartmentId = 4 },
    new Employee { Id = 57, FirstName = "Lora", LastName = "Borisova", Email = "lora.borisova@gmail.com", JobTitle = "Social Media Specialist", Salary = 3100m, DepartmentId = 4 },
    new Employee { Id = 58, FirstName = "Viktor", LastName = "Marinov", Email = "viktor.marinov@abv.bg", JobTitle = "Marketing Coordinator", Salary = 3800m, DepartmentId = 4 },
    new Employee { Id = 59, FirstName = "Petya", LastName = "Mihova", Email = "petya.mihova@gmail.com", JobTitle = "Event Specialist", Salary = 2900m, DepartmentId = 4 },
    new Employee { Id = 60, FirstName = "Emiliya", LastName = "Hristova", Email = "emiliya.hristova@abv.bg", JobTitle = "SEO Analyst", Salary = 3700m, DepartmentId = 4 },
    new Employee { Id = 61, FirstName = "Atanas", LastName = "Todorov", Email = "atanas.todorov@gmail.com", JobTitle = "Graphic Designer", Salary = 4100m, DepartmentId = 4 },
    new Employee { Id = 62, FirstName = "Veronika", LastName = "Ilieva", Email = "veronika.ilieva@abv.bg", JobTitle = "Content Manager", Salary = 5200m, DepartmentId = 4 },
    new Employee { Id = 63, FirstName = "Slavi", LastName = "Stoyanov", Email = "slavi.stoyanov@gmail.com", JobTitle = "Copywriter", Salary = 2400m, DepartmentId = 4 },
    new Employee { Id = 64, FirstName = "Ekaterina", LastName = "Dineva", Email = "ekaterina.dineva@abv.bg", JobTitle = "PR Specialist", Salary = 3200m, DepartmentId = 4 },

    
    new Employee { Id = 65, FirstName = "Aleksandar", LastName = "Zlatev", Email = "aleksandar.zlatev@gmail.com", JobTitle = "Sales Manager", Salary = 9500m, DepartmentId = 5 },
    new Employee { Id = 66, FirstName = "Sofia", LastName = "Ilieva", Email = "sofia.ilieva@abv.bg", JobTitle = "Sales Representative", Salary = 2600m, DepartmentId = 5 },
    new Employee { Id = 67, FirstName = "Vladimir", LastName = "Kalchev", Email = "vladimir.kalchev@gmail.com", JobTitle = "Sales Assistant", Salary = 2700m, DepartmentId = 5 },
    new Employee { Id = 68, FirstName = "Daniela", LastName = "Tsoneva", Email = "daniela.tsoneva@abv.bg", JobTitle = "Account Executive", Salary = 3400m, DepartmentId = 5 },
    new Employee { Id = 69, FirstName = "Todor", LastName = "Kostov", Email = "todor.kostov@gmail.com", JobTitle = "Sales Coordinator", Salary = 6100m, DepartmentId = 5 },
    new Employee { Id = 70, FirstName = "Elitsa", LastName = "Gencheva", Email = "elitsa.gencheva@abv.bg", JobTitle = "Client Consultant", Salary = 2100m, DepartmentId = 5 },
    new Employee { Id = 71, FirstName = "Dimitar", LastName = "Ivanov", Email = "dimitar.ivanov@gmail.com", JobTitle = "Sales Specialist", Salary = 4200m, DepartmentId = 5 },
    new Employee { Id = 72, FirstName = "Kristina", LastName = "Pavlova", Email = "kristina.pavlova@abv.bg", JobTitle = "Account Manager", Salary = 7400m, DepartmentId = 5 },
    new Employee { Id = 73, FirstName = "Radostin", LastName = "Stanev", Email = "radostin.stanev@gmail.com", JobTitle = "Sales Agent", Salary = 2900m, DepartmentId = 5 },
    new Employee { Id = 74, FirstName = "Mila", LastName = "Hristova", Email = "mila.hristova@abv.bg", JobTitle = "Sales Admin", Salary = 4000m, DepartmentId = 5 },
    new Employee { Id = 75, FirstName = "Zhivko", LastName = "Yordanov", Email = "zhivko.yordanov@gmail.com", JobTitle = "Sales Engineer", Salary = 3500m, DepartmentId = 5 },
    new Employee { Id = 76, FirstName = "Ivana", LastName = "Dimitrova", Email = "ivana.dimitrova@abv.bg", JobTitle = "Sales Representative", Salary = 2700m, DepartmentId = 5 },
    new Employee { Id = 77, FirstName = "Tanya", LastName = "Nikolova", Email = "tanya.nikolova@gmail.com", JobTitle = "Key Account Manager", Salary = 8900m, DepartmentId = 5 },
    new Employee { Id = 78, FirstName = "Stefan", LastName = "Stoyanov", Email = "stefan.stoyanov@abv.bg", JobTitle = "Field Sales", Salary = 3300m, DepartmentId = 5 },
    new Employee { Id = 79, FirstName = "Vanya", LastName = "Zheleva", Email = "vanya.zheleva@gmail.com", JobTitle = "Sales Assistant", Salary = 2400m, DepartmentId = 5 },
    new Employee { Id = 80, FirstName = "Mihaela", LastName = "Kostova", Email = "mihaela.kostova@abv.bg", JobTitle = "Sales Intern", Salary = 2100m, DepartmentId = 5 },
    new Employee { Id = 81, FirstName = "Boriana", LastName = "Koleva", Email = "boriana.koleva@gmail.com", JobTitle = "Business Development Manager", Salary = 9100m, DepartmentId = 5 },
    new Employee { Id = 82, FirstName = "Veselin", LastName = "Veselinov", Email = "veselin.veselinov@abv.bg", JobTitle = "Sales Specialist", Salary = 3300m, DepartmentId = 5 },
    new Employee { Id = 83, FirstName = "Aneliya", LastName = "Petkova", Email = "aneliya.petkova@gmail.com", JobTitle = "Sales Executive", Salary = 3600m, DepartmentId = 5 },
    new Employee { Id = 84, FirstName = "Plamen", LastName = "Georgiev", Email = "plamen.georgiev@abv.bg", JobTitle = "Account Specialist", Salary = 3400m, DepartmentId = 5 },
    new Employee { Id = 85, FirstName = "Ralitsa", LastName = "Ivanova", Email = "ralitsa.ivanova@gmail.com", JobTitle = "Sales Assistant", Salary = 2200m, DepartmentId = 5 },
    new Employee { Id = 86, FirstName = "Nadezhda", LastName = "Marinova", Email = "nadezhda.marinova@abv.bg", JobTitle = "Sales Coordinator", Salary = 3700m, DepartmentId = 5 },
    new Employee { Id = 87, FirstName = "Viktor", LastName = "Iliev", Email = "viktor.iliev@gmail.com", JobTitle = "Sales Trainer", Salary = 4300m, DepartmentId = 5 },
    new Employee { Id = 88, FirstName = "Stela", LastName = "Valcheva", Email = "stela.valcheva@abv.bg", JobTitle = "Client Consultant", Salary = 2100m, DepartmentId = 5 },
    new Employee { Id = 89, FirstName = "Teodor", LastName = "Denev", Email = "teodor.denev@gmail.com", JobTitle = "Sales Engineer", Salary = 3700m, DepartmentId = 5 },
    new Employee { Id = 90, FirstName = "Silvia", LastName = "Yaneva", Email = "silvia.yaneva@abv.bg", JobTitle = "Regional Sales Manager", Salary = 9700m, DepartmentId = 5 }
);




            modelBuilder.Entity<User>().HasData(
   
    new User { Id = 1, Username = "ivan.petrov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Admin", EmployeeId = 1 },
    new User { Id = 2, Username = "maria.georgieva", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Manager", EmployeeId = 2 },
    new User { Id = 3, Username = "georgi.ivanov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Manager", EmployeeId = 3 },
    new User { Id = 4, Username = "desislava.nikolova", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 4 },
    new User { Id = 5, Username = "petar.dimitrov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 5 },
    new User { Id = 6, Username = "anton.simeonov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 6 },
    new User { Id = 7, Username = "radoslav.iliev", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 7 },
    new User { Id = 8, Username = "yulian.stoyanov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 8 },
    new User { Id = 9, Username = "valentina.hristova", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 9 },
    new User { Id = 10, Username = "milena.yordanova", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 10 },
    new User { Id = 11, Username = "nikola.mihailov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 11 },
    new User { Id = 12, Username = "liliya.koleva", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 12 },
    new User { Id = 13, Username = "todor.vasilev", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 13 },
    new User { Id = 14, Username = "stanislav.petkov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 14 },
    new User { Id = 15, Username = "martin.grozdanov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 15 },
    new User { Id = 16, Username = "ivaylo.marinov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 16 },
    new User { Id = 17, Username = "borislav.pavlov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 17 },
    new User { Id = 18, Username = "vasil.stankov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 18 },
    new User { Id = 19, Username = "polina.dobreva", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 19 },
    new User { Id = 20, Username = "kaloyan.angelov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 20 },
    new User { Id = 21, Username = "kristina.filipova", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 21 },
    new User { Id = 22, Username = "miroslav.borisov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 22 },
    new User { Id = 23, Username = "teodora.mitkova", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 23 },
    new User { Id = 24, Username = "zhivko.yordanov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 24 },
    new User { Id = 25, Username = "radostin.tsanev", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 25 },

  
    new User { Id = 26, Username = "kalina.petkova", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Admin", EmployeeId = 26 },
    new User { Id = 27, Username = "borislav.todorov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Manager", EmployeeId = 27 },
    new User { Id = 28, Username = "ralica.ganeva", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Manager", EmployeeId = 28 },
    new User { Id = 29, Username = "martin.penev", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 29 },
    new User { Id = 30, Username = "ivelina.mihailova", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 30 },
    new User { Id = 31, Username = "stoyan.georgiev", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 31 },
    new User { Id = 32, Username = "milko.dimitrov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 32 },
    new User { Id = 33, Username = "tsvetelina.dobreva", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 33 },
    new User { Id = 34, Username = "plamen.mladenov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 34 },
    new User { Id = 35, Username = "gergana.koleva", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 35 },
    new User { Id = 36, Username = "svetoslav.dimitrov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 36 },
    new User { Id = 37, Username = "ivona.pavlova", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 37 },
    new User { Id = 38, Username = "stefan.kirilov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 38 },

    new User { Id = 39, Username = "svetla.petrova", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "HR Admin", EmployeeId = 39 },
    new User { Id = 40, Username = "danail.popov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "HR Manager", EmployeeId = 40 },
    new User { Id = 41, Username = "violeta.kirova", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "HR Manager", EmployeeId = 41 },
    new User { Id = 42, Username = "emil.todorov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 42 },
    new User { Id = 43, Username = "monika.stancheva", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 43 },
    new User { Id = 44, Username = "nikolay.lazarov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 44 },
    new User { Id = 45, Username = "kristina.pavlova", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 45 },
    new User { Id = 46, Username = "radostin.dinev", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 46 },
    new User { Id = 47, Username = "mila.hristova", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 47 },
    new User { Id = 48, Username = "diana.zlateva", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 48 },

    new User { Id = 49, Username = "rositsa.angelova", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Admin", EmployeeId = 49 },
    new User { Id = 50, Username = "simeon.kolev", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Manager", EmployeeId = 50 },
    new User { Id = 51, Username = "lyudmila.mileva", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Manager", EmployeeId = 51 },
    new User { Id = 52, Username = "tihomir.yordanov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 52 },
    new User { Id = 53, Username = "gergana.valcheva", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 53 },
    new User { Id = 54, Username = "bogdan.rusev", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 54 },
    new User { Id = 55, Username = "yana.gospodinova", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 55 },
    new User { Id = 56, Username = "stefan.petkov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 56 },
    new User { Id = 57, Username = "lora.borisova", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 57 },
    new User { Id = 58, Username = "viktor.marinov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 58 },
    new User { Id = 59, Username = "petya.mihova", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 59 },
    new User { Id = 60, Username = "emiliya.hristova", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 60 },
    new User { Id = 61, Username = "atanas.todorov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 61 },
    new User { Id = 62, Username = "veronika.ilieva", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 62 },
    new User { Id = 63, Username = "slavi.stoyanov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 63 },
    new User { Id = 64, Username = "ekaterina.dineva", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 64 },

    new User { Id = 65, Username = "aleksandar.zlatev", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Admin", EmployeeId = 65 },
    new User { Id = 66, Username = "sofia.ilieva", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Manager", EmployeeId = 66 },
    new User { Id = 67, Username = "vladimir.kalchev", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Manager", EmployeeId = 67 },
    new User { Id = 68, Username = "daniela.tsoneva", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 68 },
    new User { Id = 69, Username = "todor.kostov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 69 },
    new User { Id = 70, Username = "elitsa.gencheva", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 70 },
    new User { Id = 71, Username = "dimitar.ivanov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 71 },
    new User { Id = 72, Username = "kristina.pavlova", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 72 },
    new User { Id = 73, Username = "radostin.stanev", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 73 },
    new User { Id = 74, Username = "mila.hristova", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 74 },
    new User { Id = 75, Username = "zhivko.yordanov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 75 },
    new User { Id = 76, Username = "ivana.dimitrova", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 76 },
    new User { Id = 77, Username = "tanya.nikolova", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 77 },
    new User { Id = 78, Username = "stefan.stoyanov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 78 },
    new User { Id = 79, Username = "vanya.zheleva", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 79 },
    new User { Id = 80, Username = "mihaela.kostova", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 80 },
    new User { Id = 81, Username = "boriana.koleva", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 81 },
    new User { Id = 82, Username = "veselin.veselinov", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 82 },
    new User { Id = 83, Username = "aneliya.petkova", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 83 },
    new User { Id = 84, Username = "plamen.georgiev", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 84 },
    new User { Id = 85, Username = "ralitsa.ivanova", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 85 },
    new User { Id = 86, Username = "nadezhda.marinova", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 86 },
    new User { Id = 87, Username = "viktor.iliev", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 87 },
    new User { Id = 88, Username = "stela.valcheva", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 88 },
    new User { Id = 89, Username = "teodor.denev", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Employee", EmployeeId = 89 },
    new User { Id = 90, Username = "silvia.yaneva", PasswordHash = "$2a$11$9iOPWHxUBA.46mEztpW/H.2Qteq.CFBhWmXgTfh/I0chD9jSmz5y6", Role = "Manager", EmployeeId = 90 }

            );
        }
    }
}
