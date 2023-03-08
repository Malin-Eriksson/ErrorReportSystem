using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ErrorReportSystem.MVVM.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableObject currentViewModel = new AddUnitViewModel();


    [RelayCommand]
    private void GoToAddUnit() => CurrentViewModel = new AddUnitViewModel();

    public MainViewModel()
    {
        CurrentViewModel = new AddUnitViewModel();
    }
}
