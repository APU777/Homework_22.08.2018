CREATE DATABASE Phone_Book
ON PRIMARY
(
	NAME = PhoneBook_DATA,
	FILENAME = 'C:\Users\User\Desktop\Homework_22.08.2018\Phone_Book.mdf',
	Size = 8,
	MaxSize = 128,
	FILEGROWTH = 2
);

GO

USE Phone_Book

CREATE TABLE Subscribers
(
	ID_SUBSCRIBER INT IDENTITY PRIMARY KEY,
	LastName VARCHAR(50) NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	SurName VARCHAR(50) NOT NULL,
	Sex BIT,
	DateOfBirth DATE
);

CREATE TABLE Address_Subscribers
(
	ID_ADDRESS INT IDENTITY PRIMARY KEY,
	Country VARCHAR(50) NOT NULL,
	City VARCHAR(50),
	Address_ VARCHAR(50),
	ID_SUBSCRIBER INT REFERENCES Subscribers(ID_SUBSCRIBER) 
);
CREATE TABLE Phone_Number
(
	ID_PhoneNumber INT IDENTITY PRIMARY KEY,
	PhoneNumber VARCHAR(50) NOT NULL,
	ID_SUBSCRIBER INT REFERENCES Subscribers(ID_SUBSCRIBER),
	ID_ADDRESS INT REFERENCES Address_Subscribers(ID_ADDRESS) 
);