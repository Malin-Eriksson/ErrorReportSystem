using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ErrorReportSystem.MVVM.Models;
using ErrorReportSystem.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ErrorReportSystem.MVVM.ViewModels;

public partial class AddResidentViewModel : ObservableObject
{

    [ObservableProperty]
    private string pageTitle = "Add Resident";

    [ObservableProperty]
    private ResidentModel resident = new ResidentModel();

    

    public AddResidentViewModel()
    {
        LoadResidentsAsync();
    }


    [ObservableProperty]
    private ObservableCollection<ResidentModel> residentList;


    public void LoadResidentsAsync()
    {
        IEnumerable<ResidentModel> _residents = Task.Run(async () => await ResidentService.GetAllResidentsAsync()).Result;
        ResidentList = new ObservableCollection<ResidentModel>(_residents);
    }

    [RelayCommand]
    public async Task Add()
    {
        await ResidentService.SaveResidentAsync(Resident);
        foreach (var item in ResidentService.Residents())
            ResidentList.Add(item);

        Resident = new ResidentModel();
    }


    [ObservableProperty]
    private ResidentModel selectedResident = null!;


    [RelayCommand]
    public async Task DeleteResident()
    {
        await ResidentService.DeleteResidentAsync(SelectedResident.Id);
    }


    /*    [RelayCommand]
        public async Task Add()
        {
            await ResidentService.SaveResidentAsync(Resident);
            foreach (var item in ResidentService.Residents())
                Residents.Add(item);

            Resident = new ResidentModel();
        }*/

}
