create database Kernal_travel_Guide;


use Kernal_travel_Guide;

CREATE TABLE TouristSpots (
    TouristSpotID INT identity(1,1) PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Description TEXT,
    Location VARCHAR(255),
    Category VARCHAR(100),
    ImageURL VARCHAR(255)
);

-- Create the database


-- Use the created database

-- Create TouristSpots table


-- Create TravelInfo table
CREATE TABLE TravelInfo (
    TravelInfoID INT IDENTITY(1,1) PRIMARY KEY,
    ModeOfTransport NVARCHAR(100),
    Description TEXT,
    Availability NVARCHAR(255),
    PriceRange NVARCHAR(50)
);
GO

-- Create Hotels table
CREATE TABLE Hotels (
    HotelID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Location NVARCHAR(255),
    Description TEXT,
    PriceRange NVARCHAR(50),
    Rating FLOAT,
    ImageURL NVARCHAR(255)
);
GO

-- Create Restaurants table
CREATE TABLE Restaurants (
    RestaurantID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Location NVARCHAR(255),
    CuisineType NVARCHAR(100),
    Description TEXT,
    Rating FLOAT,
    ImageURL NVARCHAR(255)
);
GO

-- Create Resorts table
CREATE TABLE Resorts (
    ResortID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Location NVARCHAR(255),
    Description TEXT,
    PriceRange NVARCHAR(50),
    Rating FLOAT,
    ImageURL NVARCHAR(255)
);
GO

-- Create Users table
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255),
    Email NVARCHAR(255) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    Phone NVARCHAR(20)
);
GO

-- Create admin table
CREATE TABLE Admin (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(255),
    Email NVARCHAR(255) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL,
  
);
GO
-- Create Feedback table
CREATE TABLE Feedback (
    FeedbackID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT,
    Date DATETIME DEFAULT GETDATE(),
    Message TEXT,
    Rating INT,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
GO



-- Create Reservation table
CREATE TABLE Reservations (
    ReservationID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,
    TouristSpotID INT NULL,
    HotelID INT NULL,
    RestaurantID INT NULL,
    ResortID INT NULL,
    TravelInfoID INT NULL,
    ReservationDate DATETIME DEFAULT GETDATE(),
    NumberOfPeople INT,
    SpecialRequests TEXT,
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (TouristSpotID) REFERENCES TouristSpots(TouristSpotID),
    FOREIGN KEY (HotelID) REFERENCES Hotels(HotelID),
    FOREIGN KEY (RestaurantID) REFERENCES Restaurants(RestaurantID),
    FOREIGN KEY (ResortID) REFERENCES Resorts(ResortID),
    FOREIGN KEY (TravelInfoID) REFERENCES TravelInfo(TravelInfoID)
);
GO