-- About Tablosu
CREATE TABLE IF NOT EXISTS About(
    Id SERIAL PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    Description TEXT,
    ImageUrl VARCHAR(255),
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP
);

-- Skill Tablosu
CREATE TABLE IF NOT EXISTS Skills(
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Proficiency INT CHECK (Proficiency >= 0 AND Proficiency <= 100),
    DisplayOrder INT NOT NULL DEFAULT 0,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Project Tablosu
CREATE TABLE IF NOT EXISTS Projects(
    Id SERIAL PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    Description TEXT,
    ImageUrl VARCHAR(255),
    ProjectUrl VARCHAR(255),
    GithubUrl VARCHAR(255),
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    IsActive BOOLEAN DEFAULT TRUE
);

--Testimonial Tablosu
CREATE TABLE IF NOT EXISTS Testimonials(
    Id SERIAL PRIMARY KEY,
    ClientName VARCHAR(255) NOT NULL,
    ClientPosition VARCHAR(255),
    Comment TEXT,
    ClientImageUrl VARCHAR(255),
    Rating INT CHECK (Rating >= 1 AND Rating <= 5),
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    IsActive BOOLEAN DEFAULT TRUE
);

-- Contact Tablosu
CREATE TABLE IF NOT EXISTS Contacts(
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    Subject VARCHAR(255),
    Message TEXT NOT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    IsRead BOOLEAN DEFAULT FALSE
);