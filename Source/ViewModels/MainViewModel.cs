using CommunityToolkit.Mvvm.ComponentModel;

namespace Taskeasy_Manager.Source.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial string Greeting { get; set; } = "Welcome to Avalonia!";
}
