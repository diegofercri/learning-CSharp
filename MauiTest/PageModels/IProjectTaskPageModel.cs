using CommunityToolkit.Mvvm.Input;
using MauiTest.Models;

namespace MauiTest.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}