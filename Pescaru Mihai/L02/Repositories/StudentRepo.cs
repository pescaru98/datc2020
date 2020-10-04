using L02.Entities;
using System;
using System.Collections.Generic;  
namespace L02.Repositories{
    public static class StudentRepo{
        public static Student student1 = new Student(1,"Mihai");
        public static Student student2 = new Student(2,"Dan");

        public static List<Student> students;

        public static IEnumerable<Student> GetStudents(){
            students = new List<Student>();
            students.Add(student1);
            students.Add(student2);
            return students.ToArray();
        }

        // public static Student getStudentOfId(int id){
        //     return students.Find();
        // }

    }
}