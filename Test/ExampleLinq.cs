﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JevLogin
{
    public sealed class ExampleLinq
    {
        private sealed class User
        {
            public string FirstName { get; }
            public string LastName { get; }
            public int Age { get; set; }

            public User(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }
        }

        private readonly User[] _users;
        private readonly int[] _numbers;

        public ExampleLinq()
        {
            _users = new[]
            {
                new User("Roman", "Muratov") {Age = 18},
                new User("Ivan", "Petrov") {Age = 22},
                new User("Ilya", "Afanasyev") {Age = 18},
                new User("Igor", "Ivanov") {Age = 25},
                new User("Lera", "Muratova") {Age = 17},
                new User("Sveta", "Petrova") {Age = 27},
                new User("Lena", "Ivanova") {Age = 33},
                new User("Lera", "Muratova") {Age = 17},
                new User("Sveta", "Petrova") {Age = 27},
                new User("Lena", "Ivanova") {Age = 33}
            };
            _numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        }

        public void Filtration()
        {
            IEnumerable<int> evens = from i in _numbers
                                     where i % 2 == 0 && i > 10
                                     select i;

            IEnumerable<int> evens1 = _numbers.Where(i => i % 2 == 0 && i > 10);

            foreach (var i in evens)
            {
                Debug.Log(i);
            }
        }

        public void SelectComplexObjects()
        {
            var selectedUsers = from user in _users
                                where user.Age > 28
                                select user;

            var selectedUsers1 = _users.Where(u => u.Age > 28).ToList();

            foreach (var user in selectedUsers)
            {
                Debug.Log($"{user.FirstName} - {user.Age}");
            }
        }

        public void Projection()
        {
            var names = _users.Select(u => u.FirstName);

            foreach (string user in names)
            {
                Debug.Log(user);
            }
        }


        public void ExampleLet()
        {
            var people = from u in _users
                         let age = u.Age <= 18 ? u.Age + (18 - u.Age) : u.Age
                         select new User(u.FirstName, u.LastName)
                         {
                             Age = age
                         };

            foreach (var user in people)
            {
                Debug.Log($"{user.FirstName} - {user.Age}");
            }
        }

        public void Sorting()
        {
            var sortedUsers = from u in _users
                              orderby u.Age //ascending (сортировка по возрастанию) и descending (сортировка по убыванию)
                              select u;

            var result = _users.OrderBy(u => u.FirstName).ThenBy(u => u.Age).ThenBy(u => u.FirstName.Length); //ThenByDescending() (для сортировки по убыванию)


            foreach (User u in sortedUsers)
            {
                Debug.Log($"{u.FirstName} - {u.Age}");
            }
        }

        public void WorkingWithSets()
        {
            string[] peopleFromAstrakhan = { "Igor", "Roman", "Ivan" };
            string[] peopleFromMoscow = { "Ilya", "Vitalik", "Denis" };

            // разность множеств
            //  В данном случае из массива soft убираются все элементы, которые есть в массиве hard. Результатом операции будут два элемента:
            var result = peopleFromAstrakhan.Except(peopleFromMoscow);

            // пересечение множеств
            //  Для получения пересечения последовательностей, то есть общих для обоих наборов элементов, применяется метод Intersect:
            var result1 = peopleFromAstrakhan.Intersect(peopleFromMoscow);

            // объединение множеств
            //  Для объединения двух последовательностей используется метод Union. Его результатом является новый набор, 
            //  в котором имеются элементы, как из первой, так и из второй последовательности. 
            //  Повторяющиеся элементы добавляются в результат только один раз
            var result2 = peopleFromAstrakhan.Union(peopleFromMoscow);

            // удаление дубликатов
            var result3 = peopleFromAstrakhan.Concat(peopleFromMoscow).Distinct();
        }

        public void ExampleAverage()
        {
            int min1 = _numbers.Min();
            int min2 = _users.Min(n => n.Age); // минимальный возраст

            int max1 = _numbers.Max();
            int max2 = _users.Max(n => n.Age); // максимальный возраст

            double avr1 = _numbers.Average();
            double avr2 = _users.Average(n => n.Age); //средний возраст
        }

        public void ExampleSkipAndTake()
        {
            var result = _numbers.Take(3); // три первых элемента
            var result1 = _numbers.Skip(3); // все элементы, кроме первых трех

            foreach (var t in _users.TakeWhile(x => x.FirstName.StartsWith("I")))
            {
                Debug.Log(t);
            }

            foreach (var t in _users.SkipWhile(x => x.FirstName.StartsWith("I")))
            {
                Debug.Log(t);
            }

            //Метод TakeWhile выбирает цепочку элементов, начиная с первого элемента, пока они удовлетворяют определенному условию. Например:

            string[] teams = { "Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона" };
            foreach (var t in teams.TakeWhile(x => x.StartsWith("Б")))
                Console.WriteLine(t);
            //Согласно условию мы выбираем те команды, которые начинаются с буквы Б. В массиве есть три таких команды. Однако в цикле будут выведены только две первых:
        }

        public void ExampleGrouping()
        {
            var groups = from user in _users
                         group user by user.LastName;

            foreach (IGrouping<string, User> g in groups)
            {
                Debug.Log(g.Key);
                foreach (var t in g)
                {
                    Debug.Log(t.FirstName);
                }
            }

            var groups1 = _users.GroupBy(p => p.LastName)
                        .Select(g => new { LastName = g.Key, Count = g.Count() });

            var groups2 = _users.GroupBy(p => p.LastName)
                        .Select(g => new
                        {
                            LastName = g.Key,
                            Count = g.Count(),
                            Name = g.Select(p => p)
                        });

            foreach (var g in groups2)
            {
                Debug.Log(g.LastName);
                Debug.Log(g.Count);
                foreach (var t in g.Name)
                {
                    Debug.Log(t.FirstName);
                }
            }
        }
    }
}