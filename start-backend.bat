@echo off
echo ========================================
echo  Bus Reservation System - Backend
echo ========================================
echo.
cd Backend\BusReservation.API
echo Starting .NET API Server...
echo API will be available at: http://localhost:5000
echo Swagger UI: http://localhost:5000/swagger
echo.
echo Press Ctrl+C to stop the server
echo.
dotnet run
