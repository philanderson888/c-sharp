USE master
GO

DROP DATABASE IF EXISTS FamilyDatabase
GO

CREATE DATABASE FamilyDatabase
GO

USE FamilyDatabase

DROP TABLE IF EXISTS DadDailyLog
GO


CREATE TABLE DadDailyLog (
    DadDailyLogId int identity PRIMARY KEY not null,
		LogDate DATETIME NULL,
	  UpOnTime BIT NULL,
		MadeGym BIT NULL
);

INSERT INTO DadDailyLog values ('2019-10-05',1,1)

select * from daddailylog