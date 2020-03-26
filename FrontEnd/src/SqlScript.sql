-- create database--
CREATE DATABASE ContactDB
--Use database
USE ContactDB
--Create table contact---
CREATE TABLE Contact(
Contact_Id INT PRIMARY KEY IDENTITY(1,1), 
First_Name VARCHAR(100), 
Last_Name VARCHAR(100), 
Email VARCHAR(100), 
Phone_Number VARCHAR(15),
IsActive BIT DEFAULT(1),
Created_Date DATETIME NULL DEFAULT(GETDATE()),
Created_By VARCHAR(100) NULL,
Modified_Date DATETIME NULL DEFAULT(GETDATE()),
Modified_By VARCHAR(100) NULL);
-----------------------------------




