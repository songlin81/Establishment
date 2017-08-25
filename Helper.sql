[1] Rename db instance

	ALTER DATABASE playzone SET SINGLE_USER WITH ROLLBACK IMMEDIATE 
	sp_renamedb 'playzone', 'playzone_new'
	ALTER DATABASE playzone_new SET MULTI_USER


[2] To get the last identity value inserted in any table

	IF OBJECT_ID ('dbo.new_employees', 'U') IS NOT NULL  
	   DROP TABLE new_employees;  
	GO  
	CREATE TABLE new_employees  
	(  
	 id_num int IDENTITY(1,1),  
	 fname varchar (20),  
	 minit char(1),  
	 lname varchar(30)  
	);  
	INSERT new_employees (fname, minit, lname) VALUES ('Karin', 'F', 'Josephs');  
	INSERT new_employees (fname, minit, lname) VALUES ('Pirkko', 'O', 'Koskitalo');  
	SELECT @@identity	--return 2


[3] To return a non-null from more than one column 
	
	SELECT COALESCE(hourly_wage, salary, commission) AS 'Total Salary' FROM wages


[4] Implicit Transaction & Explicit Transaction

	Implicit Transaction is the auto commit. There is no beginning or ending of the transaction;
	Explicit Transaction has the beginning, ending and rollback of transactions with the command 
	In the explicit transaction, if an error occurs in between we can rollback to the beginning of the transaction, which cannot be done in implicit transaction.


[5] row_number()

	select [name],gender,fenshu, row_number() over(order by fenshu desc) as num from dbo.PeopleInfo

	select [name],gender,fenshu, row_number() over(partition by Gender order by fenshu desc) as num from dbo.PeopleInfo

	with temp as
	(
	select [name],gender,fenshu, row_number() over(partition by Gender order by fenshu desc) as num from dbo.PeopleInfo
	)
	select * from temp where num = 1


[6] Cross apply & outer apply

	select * from dbo.Customers as C
	 cross apply
		(select top 2 *
		 from dbo.Orders as O
		 where C.customerid=O.customerid
		 order by orderid desc) as CA
	
	select * from dbo.Customers as C
	 outer apply
		(select top 2 *
		 from dbo.Orders as O
		 where C.customerid=O.customerid
		 order by orderid desc) as CA


[7] ad-hoc, in-memory table
	SELECT * FROM (
		VALUES(1),(2),(3)
	) t(a)


[8] loop execution
	INSERT INTO TestData(CreatedDate) SELECT GetDate()
	GO 10


[9] CTE

	WITH
	  t1(v1, v2) AS (SELECT 1, 2),
	  t2(w1, w2) AS (
		SELECT v1 * 2, v2 * 2
		FROM t1
	  )
	SELECT * FROM t1, t2
	
	v1   v2   w1   w2
	-----------------
	 1    2    2    4

	WITH t(v) AS (
	  SELECT 1     -- Seed Row
	  UNION ALL
	  SELECT v + 1 -- Recursion
	  FROM t
	)
	SELECT v FROM t
	OPTION (MAXRECURSION 4)


[10] Selecting Domain from Email Address

	SELECT RIGHT(Email, LEN(Email) - CHARINDEX('@', email)) Domain ,
	COUNT(Email) EmailCount
	FROM   dbo.email
	WHERE  LEN(Email) > 0
	GROUP BY RIGHT(Email, LEN(Email) - CHARINDEX('@', email))
	ORDER BY EmailCount DESC

 
[11] column to row

	Table is:
	+----+------+
	| Id | Name |
	+----+------+    
	| 1  | aaa  |
	| 1  | bbb  |
	| 1  | ccc  |
	| 1  | ddd  |
	| 1  | eee  |
	+----+------+
	Required output:
	+----+---------------------+
	| Id |        abc          |
	+----+---------------------+ 
	|  1 | aaa,bbb,ccc,ddd,eee |
	+----+---------------------+
	SELECT ID, 
		abc = STUFF(
					 (SELECT ',' + name FROM temp1 FOR XML PATH ('')), 1, 1, ''
				   ) 
	FROM temp1 GROUP BY id

