using LessonMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonMVVM.ViewModels.WindowViewModels
{
    internal class GetAllViewModel
    {
        public ObservableCollection<Car> Cars { get; set; }

        public GetAllViewModel()
        {

        }

        public GetAllViewModel(ObservableCollection<Car> cars)
        {
            Cars = cars;
        }
    }
}
