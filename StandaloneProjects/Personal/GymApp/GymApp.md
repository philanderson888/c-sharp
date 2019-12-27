# Gym App

Here is a gym app

We are going to build it in .Net Core with ASP MVC

Let's create the tables first

```sql
use ASP_04_MVC
drop database Gym
go
create database Gym
go
use Gym
go
CREATE TABLE Exercises(
   ExerciseID INT NOT NULL IDENTITY PRIMARY KEY,
   ExerciseName NVARCHAR(50) NULL,
   CategoryID INT NULL FOREIGN KEY REFERENCES Categories(CategoryID)
);
CREATE TABLE Categories(
	CategoryID INT NOT NULL IDENTITY PRIMARY KEY,
	CategoryName NVARCHAR(50) NOT NULL
);
CREATE TABLE WorkoutCycles
(
	WorkoutCycleID INT NOT NULL IDENTITY PRIMARY KEY,  
	StartDate Date NULL,
	EndDate Date NULL
);


INSERT INTO Categories (Category) values ('Family');
INSERT INTO Categories (Category) values ('Work');

INSERT INTO Users (UserName) values ('Dad');

insert into RegularTasks (CategoryID,Description,Done,UserID)
values(1,'Family',1,1);

```