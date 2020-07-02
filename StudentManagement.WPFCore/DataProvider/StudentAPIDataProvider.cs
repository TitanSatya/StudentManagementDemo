using Newtonsoft.Json;

using RestSharp;
using RestSharp.Serialization.Json;

using StudentManagement.Domain;

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace StudentManagement.WPFCore.DataProvider
{
    public class StudentAPIDataProvider : IStudentDataProvider
    {
        string baseURL = "https://localhost:44398/api/student";
        public bool DeleteStudentData(Guid studentId)
        {
            bool result = default(bool);
            var client = new RestClient($"{baseURL}/id={studentId}");
            var request = new RestRequest(Method.DELETE);
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<bool>(response.Content);
            }
            return result;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            List<Student> students = null;
            var client = new RestClient(baseURL);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    students = JsonConvert.DeserializeObject<List<Student>>(response.Content);
                }
            }
            return students;
        }

        public Student GetStudent(Guid studentId)
        {
            Student student = null;

            var client = new RestClient($"{baseURL}/id={studentId}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if(response.IsSuccessful)
            {
                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    student = JsonConvert.DeserializeObject<Student>(response.Content);
                }
            }
            return student;
        }

        public Guid SaveStudentData(Student student)
        {
            var client = new RestClient(baseURL);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var body = JsonConvert.SerializeObject(student);
            if (!string.IsNullOrEmpty(body))
            {
                request.AddParameter("undefined", body, ParameterType.RequestBody);
            }
            IRestResponse response = client.Execute(request);
            Guid studentId = Guid.Empty;
           if(response.IsSuccessful)
            {
                Guid.TryParse(response.Content, out studentId);
            }
            return studentId;
        }
    }
}
