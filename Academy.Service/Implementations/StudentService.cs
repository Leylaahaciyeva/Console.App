using System;
using Academy.Core.Enums;
using Academy.Core.Models;
using Academy.Core.Repositories;
using Academy.Data.Repositories;
using Academy.Service.Interfaces;

namespace Academy.Service.Implementations
{
    public class StudentService : IStudentService
    {
        IStudentRepository _istudentRepository = new StudentRepository();
        private object _studentRepository;

        public async Task<string> CreateAsync(string fullname, string group, int average, Education education)
        {
            if (string.IsNullOrWhiteSpace(fullname))
                return "FullName can not be empty";

            if (string.IsNullOrWhiteSpace(group))
                return "Group can not be empty";

            if (average < 0 && average > 100)
                return "Average should be between 0 and 100";

            Student student = new Student(fullname,group,average,education);
            student.CreatedAt = DateTime.UtcNow.AddHours(4);
            await  _istudentRepository.AddAsync(student);

            return "Succssfully created";

        }

        public async Task GetAllAsync()
        {
            List<Student> students =await _istudentRepository.GetAllAsync();

            foreach (Student student in students)
            {
                Console.WriteLine($"Id:{student.Id} FullName:{student.FullName} Group:{student.Group} Average:{student.Average} Education:{student.Education} CreatedAt:{student.CreatedAt} UpdatedAt:{student.UpdatedAt}");
            }
        }

        public async Task<string> GetAsync(string id)
        {
            Student student = await _istudentRepository.GetAsync(x=>x.Id==id);

            if (student == null)
                return "Student not found";
            Console.WriteLine($"Id:{student.Id} FullName:{student.FullName} Group:{student.Group} Average:{student.Average} Education:{student.Education} CreatedAt:{student.CreatedAt} UpdatedAt:{student.UpdatedAt}");
            return "Success";
        }

        public async Task<string> RemoveAsync(string id)
        {
            Student student = await _istudentRepository.GetAsync(x => x.Id == id);

            if (student == null)
                return "Student not found";
            await _istudentRepository.RemoveAsync(student);

            return "Removed successfully";
        }

        public async Task<string> UpdateAsync(string id,string fullname, string group, int average, Education education)
        {
            Student student = await _istudentRepository.GetAsync(x => x.Id == id);

            if (student == null)
                return "Student not found";

            if (string.IsNullOrWhiteSpace(fullname))
                return "FullName can not be empty";

            if (string.IsNullOrWhiteSpace(group))
                return "Group can not be empty";

            if (average < 0 && average > 100)
                return "Average should be between 0 and 100";


            student.FullName = fullname;
            student.Group = group;
            student.Average = average;
            student.Education = education;
            student.UpdatedAt = DateTime.UtcNow.AddHours(4);
            return "Updated successfully";
        }
    }
}

