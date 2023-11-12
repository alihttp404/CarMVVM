using LessonMVVM.Commands;
using LessonMVVM.Models;
using LessonMVVM.Services;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace LessonMVVM.ViewModels.WindowViewModels;

public class AddCarViewModel : NotificationService
{
    private Car? currCar;
    public Car? CurrCar { get => currCar; set { currCar = value; OnPropertyChanged(); } }

    public ObservableCollection<Car> Cars { get; set; }

    public ICommand? SaveCommand{ get; set; }
    public ICommand? CancelCommand{ get; set; }

    public AddCarViewModel() { }

    public AddCarViewModel(ObservableCollection<Car> cars)
    {
        Cars = cars;
        CurrCar = new Car();

        SaveCommand = new RelayCommand(Save, CanSave);
        CancelCommand = new RelayCommand(CancelWindow);
    }

    public void CancelWindow(object? parameter)
    {
        var window = parameter as Window;
        if (window != null) window.Close();
    }

    public void Save(object? parameter)
    {
        Cars.Add(CurrCar!);
        CurrCar = new Car();
        File.WriteAllText("..\\..\\..\\DataBase\\Cars.json", JsonConvert.SerializeObject(Cars));
    }

    public bool CanSave(object? parameter)
    {
        return !string.IsNullOrEmpty(CurrCar!.Make) &&
               !string.IsNullOrEmpty(CurrCar!.Model);
    }
}
