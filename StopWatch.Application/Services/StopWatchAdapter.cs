using StopWatch.Application.ViewModels;
using StopWatch.Domain.Models;

namespace StopWatch.Application.Services
{
    public static class StopWatchAdapter
    {
        public static StopWatchViewModel Adapt(StopWatchModel model)
        {
            return new StopWatchViewModel
            {
                Id = model.Id,
                Start = model.Start,
                Stop = model.Stop,
                IsActive = model.IsActive,
            };
        }

        public static StopWatchModel Adapt(StopWatchViewModel viewModel)
        {
            return new StopWatchModel(viewModel.Id, viewModel.Start, viewModel.Stop, viewModel.IsActive);
        }
    }
}
