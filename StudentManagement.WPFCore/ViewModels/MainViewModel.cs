using StudentManagement.Domain;
using StudentManagement.WPFCore.DataProvider;
using StudentManagement.WPFCore.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace StudentManagement.WPFCore.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Ctor
        private readonly IStudentDataProvider _studentDataProvider;
        public MainViewModel(IStudentDataProvider studentDataProvider)
        {
            _studentDataProvider = studentDataProvider;
            GetAllStudents();
            SaveCommand = new RelayCommand(ExecuteSaveCommand, CanExecuteSaveCommand);
        }

      



        /// <summary>
        /// Get All students through IStudentDataProvider
        /// </summary>
        private void GetAllStudents()
        {
            AllStudents = new ObservableCollection<Student>( _studentDataProvider.GetAllStudents());
        }
        #endregion
        #region Properties
        private string _StudentFirstName;

        public string StudentFirstName
        {
            get => _StudentFirstName;
            set
            {
                _StudentFirstName = value;
                OnPropertyChanged(nameof(StudentFirstName));
            }
        }
        private string _StudentLastName;

        public string StudentLastName
        {
            get => _StudentLastName;
            set
            {
                _StudentLastName = value;
                OnPropertyChanged(nameof(StudentLastName));
            }
        }

        private DateTime _StudentDOB = DateTime.Now;

        public DateTime StudentDOB
        {
            get => _StudentDOB;
            set
            {
                _StudentDOB = value;
                OnPropertyChanged(nameof(StudentDOB));
            }
        }
        private string _StudentAddress;

        public string StudentAddress
        {
            get => _StudentAddress;
            set
            {
                _StudentAddress = value;
                OnPropertyChanged(nameof(StudentAddress));
            }
        }
        private ObservableCollection<Student> _AllStudents;

        public ObservableCollection<Student> AllStudents
        {
            get => _AllStudents;
            set
            {
                _AllStudents = value;
                OnPropertyChanged(nameof(AllStudents));
            }
        }
        public ICommand  SaveCommand { get;private  set; }
       

        #endregion
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
        #region Public Methods
        public bool CanExecuteSaveCommand(object arg)
        {
            if (String.IsNullOrEmpty(StudentFirstName))
            {
                return false;
            }
            else if(StudentFirstName.Length >50)
            {
                return false;
            }
            else if (string.IsNullOrEmpty(StudentLastName))
            {
                return false;
            }
            else if (StudentLastName.Length > 50)
            {
                return false;
            }
            else if (StudentDOB == DateTime.MinValue)
            {
                return false;
            }
            else if(StudentDOB >= DateTime.Today)
            {
                return false;
            }
            else if(string.IsNullOrEmpty(StudentAddress))
            {
                return false;
            }
            else if (StudentAddress.Length >300)
            {
                return false;
            }
            else
            return true;


        }
        private void ExecuteSaveCommand(object obj)
        {
            Student student = new Student();
            student.StudentFirstName = StudentFirstName;
            student.StudentLastName = StudentLastName;
            student.StudentDOB = StudentDOB;
            student.StudentAddress = StudentAddress;
            Guid id =_studentDataProvider.SaveStudentData(student);
            if(id!= Guid.Empty)
            {
                student.StudentId = id;
            }
            AllStudents.Add(student);
            ClearAllFields();
        }

        public void ClearAllFields()
        {
            StudentFirstName = string.Empty;
            StudentLastName = string.Empty;
            StudentDOB = DateTime.Now;
            StudentAddress = string.Empty;
        }
        #endregion
    }
}
