using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ErrorReportSystem.MVVM.Models;
using ErrorReportSystem.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ErrorReportSystem.MVVM.ViewModels;

public partial class AddResidentViewModel : ObservableObject
{
    public AddResidentViewModel()
    {
        LoadResidentsAsync();
    }


    public async Task LoadResidentsAsync()
    {
        await ResidentService.GetAllResidentsAsync();
    }




    [ObservableProperty]
    private string pageTitle = "Add Resident";

    [ObservableProperty]
    private ObservableCollection<ResidentModel> residents = ResidentService.Residents();


    [ObservableProperty]
    private ResidentModel resident = new ResidentModel();

    [ObservableProperty]
    private ResidentModel selectedResident = null!;

/*    [RelayCommand]
    public async Task Add()
    {
        await ResidentService.SaveResidentAsync(Resident);
        foreach (var item in ResidentService.Residents())
            Residents.Add(item);

        Resident = new ResidentModel();
    }*/

}
