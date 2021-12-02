using StopWatch.Application.ViewModels;
using StopWatch.Domain.Models;
using StopWatch.Infra.Data.Repositories;

namespace StopWatch.Application.Services
{
    public class StopWatchService
    {
        StopWatchData _data = new StopWatchData();

        public async Task<IEnumerable<StopWatchViewModel>> GetAll()
        {
            return (await _data.GetAll()).Select(o => StopWatchAdapter.Adapt(o));
        }

        public async Task<StopWatchViewModel> StartNew()
        {
            bool canStartNew = await _data.GetStopWatchCount() < 5;

            if (!canStartNew)
                throw new Exception("There are already 5 stop watches in action.");

            StopWatchModel model = new StopWatchModel(Guid.NewGuid(), DateTime.Now.TimeOfDay, TimeSpan.Zero, true);
            await _data.Insert(model);
            return StopWatchAdapter.Adapt(model);
        }

        public async Task<StopWatchViewModel> Stop(Guid id)
        {
            StopWatchModel stopWatch = await _data.GetById(id);
            if (!stopWatch.IsActive)
                throw new Exception("This stopwatch had already been stopped!");

            stopWatch.UnActivate();

            await _data.Update(stopWatch);

            return StopWatchAdapter.Adapt(stopWatch);
        }

        public async Task Delete(Guid id)
        {
            await _data.Delete(id);
        }
    }
}
