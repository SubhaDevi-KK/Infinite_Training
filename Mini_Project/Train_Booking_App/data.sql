-- Train table
CREATE TABLE train (
    trainid INT PRIMARY KEY,
    trainname VARCHAR(100),
    source VARCHAR(100),
    destination VARCHAR(100),
    dateofjourney DATE,
    totalseats INT,
    availableseats INT
)

-- Compartment table
CREATE TABLE train_compartments (
    compartmentid INT PRIMARY KEY IDENTITY(1,1),
    trainid INT FOREIGN KEY REFERENCES train(trainid),
    compartmenttype VARCHAR(50), -- Sleeper, 1AC, 2AC, 3AC, Ladies Sleeper, Disabled Sleeper
    seatprice DECIMAL(10,2),
    availableseats INT
)

-- Booking table
CREATE TABLE booking (
    bookingid INT PRIMARY KEY IDENTITY(1000,1),
    trainid INT FOREIGN KEY REFERENCES train(trainid),
    compartmentid INT FOREIGN KEY REFERENCES train_compartments(compartmentid),
    name VARCHAR(100),
    age INT,
    phone VARCHAR(15),
    address VARCHAR(255),
    email VARCHAR(100),
    aadhar VARCHAR(20),
    numseats INT,
    totalprice DECIMAL(10,2),
    seatposition VARCHAR(50), -- Upper, Middle, Lower
    status VARCHAR(50) -- Confirmed / Waiting List / Cancelled
)

-- Cancellation table: Tracks refunds
CREATE TABLE cancellation (
    cancelid INT PRIMARY KEY IDENTITY(1,1),
    bookingid INT FOREIGN KEY REFERENCES booking(bookingid),
    refundamount DECIMAL(10,2),
    canceldate DATE
)
INSERT INTO train (trainid, trainname, source, destination, dateofjourney, totalseats, availableseats) VALUES
(101, 'Rajdhani Express', 'Delhi', 'Mumbai', '2025-08-05', 300, 140),
(102, 'Shatabdi Express', 'Delhi', 'Chandigarh', '2025-08-06', 200, 110),
(103, 'Duronto Express', 'Kolkata', 'Pune', '2025-08-06', 280, 90),
(104, 'Garib Rath', 'Bangalore', 'Hyderabad', '2025-08-06', 250, 150),
(105, 'Intercity Express', 'Lucknow', 'Delhi', '2025-08-06', 220, 115),
(106, 'Tejas Express', 'Chennai', 'Bangalore', '2025-08-08', 230, 160),
(107, 'Howrah Mail', 'Howrah', 'Chennai', '2025-08-09', 260, 120),
(108, 'Udyan Express', 'Mumbai', 'Bangalore', '2025-08-10', 240, 130),
(109, 'Kalka Shatabdi', 'Delhi', 'Kalka', '2025-08-08', 200, 90),
(110, 'Netravati Express', 'Thiruvananthapuram', 'Mumbai', '2025-08-11', 280, 140),
(111, 'Himalayan Queen', 'Delhi', 'Shimla', '2025-08-09', 180, 80),
(112, 'Goa Express', 'Delhi', 'Goa', '2025-08-10', 230, 100),
(113, 'Deccan Queen', 'Pune', 'Mumbai', '2025-08-08', 210, 115)


-- For TrainID 101: Rajdhani Express
INSERT INTO train_compartments VALUES
(101, 'Sleeper', 600.00, 50),
(101, '3AC', 1200.00, 40),
(101, '2AC', 1800.00, 30),
(101, '1AC', 2500.00, 20),
(101, 'Ladies Sleeper', 600.00, 10),
(101, 'Disabled Sleeper', 600.00, 10)

-- For TrainID 102: Shatabdi Express
INSERT INTO train_compartments VALUES
(102, 'Chair Car', 550.00, 60),
(102, 'Executive Chair Car', 1050.00, 50),
(102, 'Ladies Chair Car', 600.00, 20)

-- TrainID 103: Duronto Express
INSERT INTO train_compartments VALUES
(103, 'Sleeper', 650.00, 60),
(103, '3AC', 1150.00, 40),
(103, '2AC', 1750.00, 30),
(103, '1AC', 2400.00, 20),
(103, 'Ladies Sleeper', 650.00, 10),
(103, 'Disabled Sleeper', 650.00, 10)

-- TrainID 104: Garib Rath 
INSERT INTO train_compartments VALUES
(104, 'Sleeper', 500.00, 60),
(104, '3AC', 850.00, 90),
(104, 'Ladies 3AC', 850.00, 20),
(104, 'Disabled Sleeper', 500.00, 10)

-- TrainID 105: Intercity Express
INSERT INTO train_compartments VALUES
(105, 'Sleeper', 400.00, 50),
(105, '3AC', 700.00, 40),
(105, '2AC', 1200.00, 30),
(105, 'Ladies Sleeper', 400.00, 10),
(105, 'Disabled Sleeper', 400.00, 10)

-- TrainID 106: Tejas Express 
INSERT INTO train_compartments VALUES
(106, 'Executive Class', 2100.00, 60),
(106, 'AC Chair Car', 1400.00, 100),
(106, 'Ladies AC Chair Car', 1450.00, 30),
(106, 'Disabled Chair Car', 1400.00, 10)

-- TrainID 107: Howrah Mail
INSERT INTO train_compartments VALUES
(107, 'Sleeper', 550.00, 60),
(107, '3AC', 1100.00, 40),
(107, '2AC', 1600.00, 30),
(107, 'Ladies Sleeper', 550.00, 10),
(107, 'Disabled Sleeper', 550.00, 10)

-- TrainID 108: Udyan Express
INSERT INTO train_compartments VALUES
(108, 'Sleeper', 600.00, 60),
(108, '3AC', 1200.00, 40),
(108, '2AC', 1800.00, 30),
(108, '1AC', 2500.00, 20),
(108, 'Ladies Sleeper', 600.00, 10),
(108, 'Disabled Sleeper', 600.00, 10)

-- TrainID 109: Kalka Shatabdi
INSERT INTO train_compartments VALUES
(109, 'Chair Car', 500.00, 60),
(109, 'Executive Chair Car', 1000.00, 40),
(109, 'Ladies Chair Car', 550.00, 10),
(109, 'Disabled Chair Car', 500.00, 10)

-- TrainID 110: Netravati Express
INSERT INTO train_compartments VALUES
(110, 'Sleeper', 620.00, 60),
(110, '3AC', 1250.00, 40),
(110, '2AC', 1850.00, 30),
(110, 'Ladies Sleeper', 620.00, 10),
(110, 'Disabled Sleeper', 620.00, 10)

-- TrainID 111: Himalayan Queen
INSERT INTO train_compartments VALUES
(111, 'Sleeper', 550.00, 40),
(111, '3AC', 950.00, 30),
(111, 'Ladies Sleeper', 550.00, 10),
(111, 'Disabled Sleeper', 550.00, 10)

-- TrainID 112: Goa Express
INSERT INTO train_compartments VALUES
(112, 'Sleeper', 600.00, 50),
(112, '3AC', 1100.00, 40),
(112, '2AC', 1600.00, 30),
(112, 'Ladies Sleeper', 600.00, 10),
(112, 'Disabled Sleeper', 600.00, 10)

-- TrainID 113: Deccan Queen
INSERT INTO train_compartments VALUES
(113, 'Chair Car', 650.00, 60),
(113, 'Executive Chair Car', 1150.00, 40),
(113, 'Ladies Chair Car', 650.00, 10),
(113, 'Disabled Chair Car', 650.00, 10)
ALTER TABLE booking ADD isdeleted BIT NOT NULL DEFAULT 0
ALTER TABLE train ADD isdeleted BIT DEFAULT 0
SELECT trainid, trainname, isdeleted FROM train


select * from booking
select * from train
UPDATE train SET isdeleted = 0;

CREATE TABLE customer_login (
    username VARCHAR(100) PRIMARY KEY,
    password VARCHAR(100)
)

SELECT bookingid, name, email, status FROM booking
ALTER TABLE train DROP COLUMN dateofjourney
ALTER TABLE booking ADD journey_date DATE
ALTER TABLE train DROP COLUMN totalseats






