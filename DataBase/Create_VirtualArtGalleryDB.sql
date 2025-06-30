-- Artist Table
CREATE TABLE Artist (
    ArtistID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Biography NVARCHAR(MAX),
    BirthDate DATE,
    Nationality NVARCHAR(50),
    Website NVARCHAR(200),
    ContactInfo NVARCHAR(100)
);

-- Artwork Table
CREATE TABLE Artwork (
    ArtworkID INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(100),
    Description NVARCHAR(MAX),
    CreationDate DATE,
    Medium NVARCHAR(50),
    ImageURL NVARCHAR(200),
    ArtistID INT FOREIGN KEY REFERENCES Artist(ArtistID)
);

-- User Table
CREATE TABLE [User] (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50),
    [Password] NVARCHAR(50),
    Email NVARCHAR(100),
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    DOB DATE,
    ProfilePicture NVARCHAR(200)
);

-- Gallery Table
CREATE TABLE Gallery (
    GalleryID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Description NVARCHAR(MAX),
    Location NVARCHAR(100),
    CuratorID INT FOREIGN KEY REFERENCES Artist(ArtistID),
    OpeningHours NVARCHAR(100)
);

-- User Favorite Artwork
CREATE TABLE User_Favorite_Artwork (
    UserID INT FOREIGN KEY REFERENCES [User](UserID),
    ArtworkID INT FOREIGN KEY REFERENCES Artwork(ArtworkID),
    PRIMARY KEY(UserID, ArtworkID)
);

-- Artwork Gallery
CREATE TABLE Artwork_Gallery (
    ArtworkID INT FOREIGN KEY REFERENCES Artwork(ArtworkID),
    GalleryID INT FOREIGN KEY REFERENCES Gallery(GalleryID),
    PRIMARY KEY(ArtworkID, GalleryID)
);
SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Gallery';



ALTER TABLE Gallery
DROP CONSTRAINT FK__Gallery__Curator__442B18F2;

ALTER TABLE Gallery
DROP COLUMN CuratorID;


ALTER TABLE Gallery
ADD ArtistID INT;

ALTER TABLE Gallery
ADD CONSTRAINT FK_Gallery_Artist FOREIGN KEY (ArtistID) REFERENCES Artist(ArtistID);



SELECT * FROM Gallery;

DROP TABLE IF EXISTS Gallery;

SELECT f.name AS ForeignKey, OBJECT_NAME(f.parent_object_id) AS TableName
FROM sys.foreign_keys AS f
INNER JOIN sys.foreign_key_columns AS fc
    ON f.OBJECT_ID = fc.constraint_object_id
WHERE OBJECT_NAME(f.referenced_object_id) = 'Gallery';

ALTER TABLE Artwork_Gallery
DROP CONSTRAINT FK__Artwork_G__Galle__5812160E;  -- Replace with your actual FK name

DROP TABLE IF EXISTS Gallery;
CREATE TABLE Gallery (
    GalleryID INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(100),
    [Description] NVARCHAR(300),
    [Location] NVARCHAR(100),
    ArtistID INT,
    FOREIGN KEY (ArtistID) REFERENCES Artist(ArtistID),
    OpeningHours NVARCHAR(100)
);
DROP TABLE IF EXISTS Artist;

SELECT f.name AS ForeignKey, OBJECT_NAME(f.parent_object_id) AS TableName
FROM sys.foreign_keys AS f
INNER JOIN sys.foreign_key_columns AS fc
    ON f.OBJECT_ID = fc.constraint_object_id
WHERE OBJECT_NAME(f.referenced_object_id) = 'Artist';

-- Drop FK from Artwork to Artist
ALTER TABLE Artwork
DROP CONSTRAINT FK__Artwork__ArtistI__4BAC3F29;  -- Replace with actual FK name

-- Drop FK from Gallery to Artist
ALTER TABLE Gallery
DROP CONSTRAINT FK__Gallery__ArtistI__6FE99F9F; 
-- Replace with actual FK name
DROP TABLE IF EXISTS Artist;

CREATE TABLE Artist (
    ArtistID INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(100),
    Biography NVARCHAR(500),
    BirthDate DATE,
    Nationality NVARCHAR(50),
    Website NVARCHAR(100),
    ContactInfo NVARCHAR(100) 
);

INSERT INTO Artist ([Name], Biography, BirthDate, Nationality, Website, ContactInfo)
VALUES 
('Liam Carter', 'Known for contemporary sculpture.', '1980-07-21', 'American', 'www.liamcarterart.com', 'liam@example.com');

