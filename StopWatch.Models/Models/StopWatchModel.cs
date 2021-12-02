using StopWatch.Domain.Base;

namespace StopWatch.Domain.Models
{
    public class StopWatchModel : Entity
    {
        public TimeSpan Start { get; private set; }

        public TimeSpan Stop { get; private set; }

        public bool IsActive { get; private set; }

        public StopWatchModel(Guid id, TimeSpan start, TimeSpan stop, bool isActive)
        {
            Id = id;
            Start = start;
            Stop = stop;
            IsActive = isActive;
        }

        public void UnActivate()
        {
            IsActive = false;
            Stop = DateTime.Now.TimeOfDay;
        }
    }
}
