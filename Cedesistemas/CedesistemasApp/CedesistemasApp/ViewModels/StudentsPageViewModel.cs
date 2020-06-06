using CedesistemasApp.Models;
using CedesistemasApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CedesistemasApp.ViewModels
{
    public class StudentsPageViewModel : BaseViewModel
    {
        public ICommand GuardarCommand { get; set; }
        public ICommand LimpiarCommand { get; set; }


        private StudentModel _Student;
        public StudentModel Student
        {
            get { return _Student; }
            set
            {

                _Student = value;
                OnPropertyChanged("Student");
            }
        }

        public StudentsPageViewModel()
        {
            Student = new StudentModel();

            GuardarCommand = new Command(Guardar);
            LimpiarCommand = new Command(Limpiar);
        }

        private void Limpiar(object obj)
        {
            Student = new StudentModel();
        }

        async private void Guardar(object obj)
        {
            var repository = new StudentRepository();

            bool result = await repository.SaveStudent(this.Student);
            if (result)
                Limpiar(null);
        }
    }
}
