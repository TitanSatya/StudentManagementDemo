using StudentManagement.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace StudentManagement.WPFCore.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {

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

        private DateTime _StudentDOB;

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

        public int MyProperty
        {
            get { return _AllStudents; }
            set { _AllStudents = value; }
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
