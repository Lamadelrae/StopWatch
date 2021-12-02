namespace StopWatch.Application.ViewModels
{
    public class StopWatchViewModel
    {
        public Guid Id { get; set; }

        public TimeSpan Start { get; set; }

        public TimeSpan Stop { get; set; }

        public TimeSpan TotalTime
        {
            get
            {
                if (Stop != TimeSpan.Zero)
                    return Stop - Start;
                else
                    return TimeSpan.Zero;
            }
        }

        public TimeSpan CountNow
        {
            get
            {
                if (!IsActive)
                    return TotalTime;

                return DateTime.Now.TimeOfDay - Start;
            }
        }

        public bool IsActive { get; set; }
    }
}
