using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class ExamplePatternSwitch : MonoBehaviour
    {
        private enum Gender
        {
            None        = 0,
            Male        = 1,
            Female      = 2,
            Indefined   = 3
        }

        private sealed class Student
        {
            public string Name { get; set; }
            public string EducationalInstitution { get; set; }
            public string AcademicPerformance { get; set; }
        }


        private void Start()
        {
            Debug.Log(Select(Gender.Female, 12));
        }

        private string Select(Gender gender, int age)
        {
            return (gender, age) switch
            {
                (Gender.Female, 14) => "Девочка",
                (Gender.Female, 18) => "Девушка",
                (Gender.Female, 30) => "Женщина",
                (Gender.Female, 70) => "Бабушка",
                _ => "Мутант"
            };
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
