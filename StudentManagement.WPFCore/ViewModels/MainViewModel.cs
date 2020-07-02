using StudentManagement.Domain;
using StudentManagement.WPFCore.DataProvider;
using StudentManagement.WPFCore.Helpers;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
[assembly: InternalsVisibleTo("StudentManagement.WPFCore.Tests")]
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
            DeleteCommand = new RelayCommand(ExecuteDeleteCommand, CanExecuteDeleteCommand);
           
        }

        /// <summary>
        /// Get All students through IStudentDataProvider
        /// </summary>
        internal void GetAllStudents() => AllStudents = new ObservableCollection<Student>(_studentDataProvider.GetAllStudents());
        internal void GetStudent()
        {
            SelectedStudent = _studentDataProvider.GetStudent(StudentId);
        }
        #endregion
        #region Properties
        private Guid _StudentId;

        public Guid StudentId
        {
            get => _StudentId;
            set
            {
                _StudentId = value;
                OnPropertyChanged(nameof(StudentId));
            }
        }

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
        public ICommand SaveCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        private Student _SelectedStudent;

        public Student SelectedStudent
        {
            get => _SelectedStudent;
            set
            {
                _SelectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
            }
        }
       

        #endregion
        #region Public Methods
        public bool CanExecuteSaveCommand(object arg)
        {
            if (string.IsNullOrEmpty(StudentFirstName))
            {
                return false;
            }
            else if (StudentFirstName.Length > 50)
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
            else if (StudentDOB >= DateTime.Today)
            {
                return false;
            }
            else if (string.IsNullOrEmpty(StudentAddress))
            {
                return false;
            }
            else if (StudentAddress.Length > 300)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        internal void ExecuteSaveCommand(object obj)
        {
            Student student = new Student
            {
                StudentFirstName = StudentFirstName,
                StudentLastName = StudentLastName,
                StudentDOB = StudentDOB,
                StudentAddress = StudentAddress
            };
            Guid id = _studentDataProvider.SaveStudentData(student);
            if (id != Guid.Empty)
            {
                student.StudentId = id;
            }
            AllStudents.Add(student);
            ClearAllFields();
        }

        internal void ClearAllFields()
        {
            StudentFirstName = string.Empty;
            StudentLastName = string.Empty;
            StudentDOB = DateTime.Now;
            StudentAddress = string.Empty;
        }
        internal bool CanExecuteDeleteCommand(object arg)
        {
            return (SelectedStudent != null);
        }

        internal void ExecuteDeleteCommand(object obj)
        {
           //var result= MessageBox.Show($"Do you really want to delete {SelectedStudent.StudentFirstName} {SelectedStudent.StudentLastName} ?",
           //                 "Delete Student",
           //                 MessageBoxButton.YesNo);
            //if (result == MessageBoxResult.Yes)
            //{
                _studentDataProvider.DeleteStudentData(SelectedStudent.StudentId);
                AllStudents.Remove(AllStudents.ToList().First(x => x.StudentId == SelectedStudent.StudentId));
                SelectedStudent = null;
            //}
        }
        #endregion
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
