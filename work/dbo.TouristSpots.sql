CREATE TABLE [dbo].[TouristSpots] (
    [TouristSpotID] INT IDENTITY (1, 1) ,
    [Name]          VARCHAR (255) NOT NULL ,
    [Description]   TEXT NOT NULL          ,
    [Location] VARCHAR (255) NOT NULL ,
    [Category] VARCHAR (100) NOT NULL ,
    [ImageURL] VARCHAR (255) NOT NULL ,
    [PriceRange] INT NOT NULL , 
    PRIMARY KEY CLUSTERED ([TouristSpotID] ASC)
);

