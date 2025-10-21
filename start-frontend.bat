@echo off
echo ========================================
echo  Bus Reservation System - Frontend
echo ========================================
echo.
cd Frontend
echo Installing dependencies (first time only)...
call npm install
echo.
echo Starting Angular Development Server...
echo App will be available at: http://localhost:4200
echo.
echo Press Ctrl+C to stop the server
echo.
call npm start
