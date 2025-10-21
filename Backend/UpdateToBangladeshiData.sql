-- Script to Update Database with Bangladeshi Data
-- Run this script in SQL Server Management Studio or Azure Data Studio

USE BusReservationDb;
GO

-- Update Buses to Bangladeshi Operators
UPDATE Buses 
SET BusNumber = 'DH-11-5678', 
    BusName = 'Green Line Paribahan', 
    BasePrice = 1200.00 
WHERE BusId = 1;

UPDATE Buses 
SET BusNumber = 'CH-15-9012', 
    BusName = 'Shyamoli Paribahan', 
    BasePrice = 800.00 
WHERE BusId = 2;

UPDATE Buses 
SET BusNumber = 'DH-12-3456', 
    BusName = 'Hanif Enterprise', 
    BasePrice = 1000.00 
WHERE BusId = 3;

UPDATE Buses 
SET BusNumber = 'RJ-10-7890', 
    BusName = 'Ena Transport', 
    BasePrice = 1400.00 
WHERE BusId = 4;

-- Update Routes to Bangladeshi Districts
UPDATE Routes 
SET Source = 'Dhaka', 
    Destination = 'Rajshahi', 
    Distance = 256.00, 
    EstimatedDuration = '06:00:00' 
WHERE RouteId = 1;

UPDATE Routes 
SET Source = 'Dhaka', 
    Destination = 'Chittagong', 
    Distance = 264.00, 
    EstimatedDuration = '07:00:00' 
WHERE RouteId = 2;

UPDATE Routes 
SET Source = 'Dhaka', 
    Destination = 'Cox''s Bazar', 
    Distance = 400.00, 
    EstimatedDuration = '10:00:00' 
WHERE RouteId = 3;

UPDATE Routes 
SET Source = 'Dhaka', 
    Destination = 'Sylhet', 
    Distance = 245.00, 
    EstimatedDuration = '06:00:00' 
WHERE RouteId = 4;

-- Update Schedule Prices
UPDATE Schedules SET Price = 1250.00 WHERE ScheduleId = 1;
UPDATE Schedules SET Price = 850.00 WHERE ScheduleId = 2;
UPDATE Schedules SET Price = 1100.00 WHERE ScheduleId = 3;
UPDATE Schedules SET Price = 1450.00 WHERE ScheduleId = 4;

-- Verify Updates
SELECT * FROM Buses;
SELECT * FROM Routes;
SELECT * FROM Schedules;

PRINT 'Database updated successfully with Bangladeshi data!';
GO
