USE master
GO

DROP DATABASE IF EXISTS FamilyDatabase02
GO

CREATE DATABASE FamilyDatabase02
GO

USE FamilyDatabase02

DROP TABLE IF EXISTS DailyLogs
GO


CREATE TABLE DailyLogs (
    DailyLogId int identity PRIMARY KEY not null,
	LogDate DATETIME NULL,
	UpOnTime BIT NULL,
	StayedUp BIT NULL,
	MadeGym BIT NULL,
	PrayWithFamily BIT NULL,
	PrayWithZoe BIT NULL,
	ChristaPrayPhoto BIT NULL,
	PhilipPrayPhoto BIT NULL,
	ChristaDeskPhoto BIT NULL
);

INSERT INTO DailyLogs values ('2019-10-05',1,1,1,1,1,1,1,1)

select * from DailyLogs