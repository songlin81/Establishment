
1. Install EF via Tools > NuGet Package Manager > Manage Nuget Packages for Solutions







2. SQL
	select * from Employees
	select * from EmployeeReviews
	--insert into Employees (FirstName, LastName) VALUES('FN','LN')
	--insert into EmployeeReviews VALUES('reviewer 01','review1',1)

3. Migration
	PM> Enable-Migrations -ContextTypeName EmployeeDb
	Checking if the context targets an existing database...
	Detected database created with a database initializer. Scaffolded migration '201708110954191_InitialCreate' corresponding to 
	existing database. To use an automatic migration instead, delete the Migrations folder and re-run Enable-Migrations 
	specifying the -EnableAutomaticMigrations parameter.
	Code First Migrations enabled for project WPFWithEF.

4.
	In the constructor of the Configuration class, AutomaticMigrationsEnabled is set as false. 
	This denotes that migrations are not run automatically. This is helpful if the project is completed 
	and we are final with our class design and structures. We will set it as true as we need to do the changes.
	The other thing about this class is the Seed method which is used to add the initial data to database.

5.	
	PM> Update-Database -verbose
	Using StartUp project 'WPFWithEF'.
	Using NuGet project 'WPFWithEF'.
	Running Seed method.

