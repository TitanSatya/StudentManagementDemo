using Moq;
using StudentManagement.Domain;
using StudentManagement.WPFCore;
using StudentManagement.WPFCore.DataProvider;
using StudentManagement.WPFCore.ViewModels;
using System;
using System.Collections.ObjectModel;
using Xunit;

namespace StudentManagement.WPFCore.Tests
{
    public class MainViewModelTests_Should
    {
        ObservableCollection<Student> allstudents = new ObservableCollection<Student>()
            {
            new Student()
            {
                StudentId = Guid.Parse("3fe0eb48-3b46-496e-b883-84b68ff3b149"),
                StudentFirstName = "Satya",
                StudentLastName ="Biswal",
                StudentAddress = "Some Test Address",
                StudentDOB = new DateTime(1983,04,05)
            },
            new Student()
            {
                StudentId = Guid.Parse("52c723f0-7cb3-46a3-8e8e-4060411cd5b0"),
                StudentFirstName = "Albert",
                StudentLastName ="Einstein",
                StudentAddress = "Some Test Address",
                StudentDOB = new DateTime(1990,08,21)
            },
            new Student()
            {
                StudentId = Guid.Parse("d0a2b968-f4ae-4f35-9da5-fa85f8194abf"),
                 StudentFirstName = "Lord",
                StudentLastName ="Kelvin",
                StudentAddress = "Some Test Address",
                StudentDOB = new DateTime(1985,08,21)
            }
        };
        Mock<IStudentDataProvider> studentDataProvider;
        MainViewModel vm;
        public MainViewModelTests_Should()
        {
            studentDataProvider = new Mock<IStudentDataProvider>();
            //Mock for GetAllStudents
            studentDataProvider.Setup(x => x.GetAllStudents())
                               .Returns(allstudents);
            //Mock for Get Single Student
            studentDataProvider.Setup(x => x.GetStudent(Guid.Parse("52c723f0-7cb3-46a3-8e8e-4060411cd5b0")))
                               .Returns(new Student()
                               {
                                   StudentId = Guid.Parse("52c723f0-7cb3-46a3-8e8e-4060411cd5b0"),
                                   StudentFirstName = "Albert",
                                   StudentLastName = "Einstein",
                                   StudentAddress = "Some Test Address",
                                   StudentDOB = new DateTime(1990, 08, 21)
                               });
            //Mock For Save Method
            studentDataProvider.Setup(x => x.SaveStudentData(new Student()
            {

                StudentFirstName = "Albert",
                StudentLastName = "Einstein",
                StudentAddress = "Some Test Address",
                StudentDOB = new DateTime(1990, 08, 21)
            })).Returns(Guid.Parse("22bd6c43-cc96-4811-9e88-43fd4d2789ee"));
            //Mock For Delete Method
            studentDataProvider.Setup(x => x.DeleteStudentData(Guid.Parse("52c723f0-7cb3-46a3-8e8e-4060411cd5b0")))
                               .Returns(true);
            vm = new MainViewModel(studentDataProvider.Object);
           
            }
        [Fact]
        public void Return_All_Students()
        {
            vm.GetAllStudents(); //Act
            Assert.Equal(3, vm.AllStudents.Count);
        }
        [Fact]
        public void Return_Single_Student()
        {
            vm.StudentId = Guid.Parse("52c723f0-7cb3-46a3-8e8e-4060411cd5b0");
            vm.GetStudent();
            Assert.Equal("Albert", vm.SelectedStudent.StudentFirstName);
            Assert.Equal("Einstein", vm.SelectedStudent.StudentLastName);
            Assert.NotNull(vm.SelectedStudent);
        }
        [Fact]
        public void Add_new_Student_On_Save()
        {
            vm.GetAllStudents();
            var oldStudentsCount = vm.AllStudents.Count;
            Assert.Equal(3, oldStudentsCount);
            vm.StudentFirstName = "FirstName";
            vm.StudentLastName = "LastName";
            vm.StudentDOB = new DateTime(1900, 01, 01);
            vm.StudentAddress = "Address";
            vm.ExecuteSaveCommand(null);
            var newStudentsCount = vm.AllStudents.Count;
            Assert.Equal(4, newStudentsCount);

        }
        [Fact]
        void Remove_Student_from_allStudents_On_Delete()
        {
            vm.GetAllStudents();
            var oldStudentsCount = vm.AllStudents.Count;
            Assert.Equal(3, oldStudentsCount);
            vm.SelectedStudent = new Student()
            {
                StudentId = Guid.Parse("52c723f0-7cb3-46a3-8e8e-4060411cd5b0"),
                StudentFirstName = "Albert",
                StudentLastName = "Einstein",
                StudentAddress = "Some Test Address",
                StudentDOB = new DateTime(1990, 08, 21)
            };
            Assert.NotNull(vm.SelectedStudent);
            vm.ExecuteDeleteCommand(null);

            var newStudentsCount = vm.AllStudents.Count;
            Assert.Equal(2, newStudentsCount);
        }
    }
}
