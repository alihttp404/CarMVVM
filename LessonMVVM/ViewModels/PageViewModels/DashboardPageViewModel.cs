using LessonMVVM.Commands;
using LessonMVVM.Models;
using LessonMVVM.Services;
using LessonMVVM.ViewModels.WindowViewModels;
using LessonMVVM.Views.Windows;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LessonMVVM.ViewModels.PageViewModels;

public class DashboardPageViewModel : NotificationService
{
    public ObservableCollection<Car> Cars { get; set; }

    public ICommand? AddViewCommand { get; set; }
    public ICommand? EditViewCommand { get; set; }
    public ICommand? RemoveCommand { get; set; }
    public ICommand? GetAllCommand { get; set; }

    public DashboardPageViewModel()
    {
        string jsonText = File.ReadAllText("..\\..\\..\\DataBase\\Cars.json");
        Cars = JsonConvert.DeserializeObject<ObservableCollection<Car>>(jsonText);
        
        AddViewCommand = new RelayCommand(AddCarView);
        EditViewCommand = new RelayCommand(EditCarView, IsComboBoxNotEmpty);
        RemoveCommand = new RelayCommand(Remove, IsComboBoxNotEmpty);
        GetAllCommand = new RelayCommand(GetAll);
    }

    public void AddCarView(object? parameter)
    {
        var addView = new AddCarView();
        addView.DataContext = new AddCarViewModel(Cars);
        addView.ShowDialog();
    }

    public void EditCarView(object? parameter) 
    {
        int index = Convert.ToInt32(parameter);
        var editView = new EditCarView();
        editView.DataContext = new EditCarViewModel(Cars, index);
        editView.ShowDialog();
    }

    public void Remove(object? parameter)
    {
        int index = Convert.ToInt32(parameter);
        Cars.Remove(Cars[index]).ToString();
        string json = JsonConvert.SerializeObject(Cars);
        File.WriteAllText("..\\..\\..\\DataBase\\Cars.json", json);
    }

    public void GetAll(object? parameter)
    {
        var addView = new GetAllView();
        addView.DataContext = new GetAllViewModel(Cars);
        addView.ShowDialog();
    }

    public static bool IsComboBoxNotEmpty(object? parameter)
    {
        int index = Convert.ToInt32(parameter);
        return (index != -1);
    }
}
