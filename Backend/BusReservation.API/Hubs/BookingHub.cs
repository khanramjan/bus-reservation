using Microsoft.AspNetCore.SignalR;

namespace BusReservation.API.Hubs
{
    public class BookingHub : Hub
    {
        // Dictionary to track schedule subscriptions
        private static Dictionary<int, HashSet<string>> ScheduleConnections = new();

        public async Task SubscribeToSchedule(int scheduleId)
        {
            if (!ScheduleConnections.ContainsKey(scheduleId))
            {
                ScheduleConnections[scheduleId] = new HashSet<string>();
            }

            ScheduleConnections[scheduleId].Add(Context.ConnectionId);
            
            // Add connection to group for broadcasting
            await Groups.AddToGroupAsync(Context.ConnectionId, $"schedule-{scheduleId}");
            
            Console.WriteLine($"Client subscribed to schedule {scheduleId}. Total subscribers: {ScheduleConnections[scheduleId].Count}");
        }

        public async Task UnsubscribeFromSchedule(int scheduleId)
        {
            if (ScheduleConnections.ContainsKey(scheduleId))
            {
                ScheduleConnections[scheduleId].Remove(Context.ConnectionId);
                
                if (ScheduleConnections[scheduleId].Count == 0)
                {
                    ScheduleConnections.Remove(scheduleId);
                }
            }

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"schedule-{scheduleId}");
            Console.WriteLine($"Client unsubscribed from schedule {scheduleId}");
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            // Cleanup connections
            var scheduleIds = ScheduleConnections.Keys.ToList();
            foreach (var scheduleId in scheduleIds)
            {
                ScheduleConnections[scheduleId].Remove(Context.ConnectionId);
                if (ScheduleConnections[scheduleId].Count == 0)
                {
                    ScheduleConnections.Remove(scheduleId);
                }
            }

            await base.OnDisconnectedAsync(exception);
        }

        // This method will be called from the BookingService to notify all clients
        public static async Task NotifyBookingConfirmed(IHubContext<BookingHub> hubContext, int scheduleId, BookingNotification notification)
        {
            await hubContext.Clients.Group($"schedule-{scheduleId}").SendAsync("BookingConfirmed", notification);
        }
    }

    public class BookingNotification
    {
        public int ScheduleId { get; set; }
        public string BookingReference { get; set; } = string.Empty;
        public int AvailableSeats { get; set; }
        public List<string> BookedSeats { get; set; } = new();
        public string PassengerName { get; set; } = string.Empty;
        public DateTime BookingTime { get; set; }
    }
}
