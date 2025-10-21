# Real-Time Features - Quick Start Guide

## 🎬 Test Real-Time Seat Updates in 5 Minutes

### Step 1: Start Backend
```powershell
cd Backend\BusReservation.API
dotnet run
```
Wait for: `Application started. Press Ctrl+C to shut down.`

### Step 2: Start Frontend
```powershell
cd Frontend
npm start
```
Wait for: `Application bundle generation complete.`

### Step 3: Open Two Browser Windows
- Window 1: `http://localhost:4200`
- Window 2: `http://localhost:4200`

**Arrange side-by-side for best view**

### Step 4: Search for Buses (Both Windows)
1. Source: **Dhaka**
2. Destination: **Chittagong**
3. Date: **10/21/2025**
4. Click **Search Bus**

Both windows should show same results ✅

### Step 5: Watch Real-Time Updates!

**Window 1 (Booking Window):**
1. Click on any bus (e.g., Green Line)
2. Select any seats (e.g., click 2 seats)
3. Fill all required fields:
   - Boarding Point: Select any
   - Dropping Point: Select any
   - Mobile Number: 01712345678
   - Check Terms checkbox
4. Click **SUBMIT**

**Window 2 (Monitor Window):**
Watch the seat count **decrease in real-time**! ✨

Example:
```
Before:  Available Seats: 45 ✓
After:   Available Seats: 43 (decreased instantly!)
Banner:  ✓ Jane Smith just booked 2 seat(s)! 43 seats left
```

## 🔍 What to Observe

### ✅ Real-Time Indicators

| Indicator | What It Means |
|-----------|--------------|
| Green notification banner | Live booking detected |
| Seat count decrease | Instant update across all clients |
| Animated notification | Booking confirmed successfully |
| Auto-dismiss banner | Works as expected |

### 🔴 Issue Checklist

| Issue | Solution |
|-------|----------|
| No notification | Refresh page and try again |
| Seats don't update | Check backend is running |
| Connection failed | Verify localhost:5000 is accessible |
| Console errors | Open DevTools (F12) |

## 📊 Multiple Booking Test

### Try This Scenario:

1. **Window 1 & 2**: Both search same route
2. **Window 1**: Book 2 seats
   - Watch Window 2: Seats decrease ✓
3. **Window 2**: Book 1 seat
   - Watch Window 1: Seats decrease ✓
4. **Window 1**: Book 3 seats
   - Watch Window 2: Seats decrease ✓
   - Watch notification: Shows passenger name ✓

**Result**: Live updates working perfectly! 🎉

## 🛠️ Troubleshooting

### Notification Not Appearing?
```
1. Check browser console (F12)
2. Look for: "Booking confirmed notification received"
3. Verify SignalR connection status
```

### Seats Not Updating?
```
1. Verify both windows on same route/date
2. Refresh page (F5) to reset subscription
3. Check browser network tab:
   - Should see WebSocket connection
   - Look for "booking-hub"
```

### Backend Connection Failed?
```
1. Verify backend running: http://localhost:5000/swagger
2. Check firewall allowing localhost:5000
3. Restart backend: Ctrl+C, then dotnet run
```

## 💡 Pro Tips

1. **See Both Updated Simultaneously**: 
   - Book simultaneously from both windows to see multiple notifications

2. **Test Connection Recovery**:
   - Stop backend, then restart
   - Watch frontend automatically reconnect
   - Notifications resume working

3. **Monitor Performance**:
   - Keep DevTools → Network tab open
   - Notice WebSocket stays connected
   - See real-time updates <500ms

4. **Test Edge Cases**:
   - Try booking 6 seats (max limit)
   - Try invalid phone number
   - Try cancelling a booking

## 📝 Test Checklist

- [ ] Backend starts without errors
- [ ] Frontend loads at localhost:4200
- [ ] Can search for buses
- [ ] Notification appears on booking
- [ ] Seat count decreases in real-time
- [ ] Multiple users see same updates
- [ ] Notifications auto-dismiss
- [ ] Can refresh without losing connection
- [ ] WebSocket shown in DevTools

## 🚀 Advanced Testing

### Test Auto-Reconnection
1. Open DevTools (F12)
2. Go to Network tab
3. Find WebSocket (ws://)
4. Stop backend
5. Watch notification in console: "Attempting to reconnect"
6. Start backend
7. Watch console: "Connection re-established"
8. Try booking again - should work! ✓

### Test Concurrent Bookings
1. Three browser windows
2. All search same route
3. Each books simultaneously
4. All three should see all three bookings in real-time
5. Seat count updates correctly each time

### Performance Test
1. Open DevTools → Console
2. Type: `performance.mark('booking-start')`
3. Book a ticket
4. Type: `performance.mark('booking-end')`
5. View timing - should be <500ms

## 📞 Need Help?

**Check These Files:**
- Backend: `Backend/BusReservation.API/Hubs/BookingHub.cs`
- Frontend: `Frontend/src/app/services/real-time.service.ts`
- Search Component: `Frontend/src/app/components/search/search.component.ts`

**Read Documentation:**
- See `REALTIME_FEATURES.md` for detailed architecture
- See `README.md` for general setup

**Console Debugging:**
- Backend: Check terminal output
- Frontend: Check browser console (F12)

---

**Ready to Test?** Start with Backend → Frontend → Two Windows → Search → Book! 🚀
