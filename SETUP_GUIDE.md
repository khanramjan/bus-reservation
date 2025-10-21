# Quick Setup Guide

## Backend Setup (Already Complete! ✅)

The backend has been successfully built and the database has been created with seed data.

### To Run Backend:
```powershell
cd Backend\BusReservation.API
dotnet run
```

The API will be available at: `http://localhost:5000`
Swagger UI: `http://localhost:5000/swagger`

---

## Frontend Setup

### Step 1: Install Node Modules
```powershell
cd Frontend
npm install
```

### Step 2: Start Development Server
```powershell
npm start
```

The app will open at: `http://localhost:4200`

---

## Important Notes

✅ **Database**: Already created and seeded with sample data
✅ **API**: Configured to run on `http://localhost:5000`
✅ **Frontend**: Configured to connect to the API
✅ **CORS**: Already enabled for `http://localhost:4200`

---

## Troubleshooting

### If Backend Won't Start:
1. Make sure SQL Server LocalDB is installed
2. Check if port 5000 is available
3. Try: `dotnet clean` then `dotnet build`

### If Frontend Won't Start:
1. Delete `node_modules` folder
2. Delete `package-lock.json`
3. Run `npm install` again
4. Run `npm start`

### If CORS Errors Occur:
- Make sure backend is running first
- Check that backend is on `http://localhost:5000`
- Check that frontend is on `http://localhost:4200`

---

## Sample Data Included

### Routes:
- Bangalore → Mumbai
- Delhi → Jaipur
- Chennai → Bangalore
- Hyderabad → Pune

### Buses:
- National Travels (AC Sleeper)
- Royal Coaches (Non-AC Seater)
- Intercity Express (AC Seater)
- Greenline Travels (AC Sleeper)

All buses have schedules for tomorrow's date with available seats!
