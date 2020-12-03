using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class ExamplePatternSwitch : MonoBehaviour
    {
        private sealed class Student
        {
            public string Name { get; set; }
            public string EducationalInstitution { get; set; }
            public string AcademicPerformance { get; set; }
        }

        private void Start()
        {
            Debug.Log(Select(new Student { EducationalInstitution = "Geekbrains" }));
        }

        private string Select(Student student)
        {
            return student switch
            {
                { EducationalInstitution: "Institute", AcademicPerformance: "Excelent" } => "Здравствуйте",
                { EducationalInstitution: "College" } => "Привет!",
                { EducationalInstitution: "Shool" } => "Здоров!",
                { } => "Hello World",
                _ => "Not Found"
            };
        }
    }
}
