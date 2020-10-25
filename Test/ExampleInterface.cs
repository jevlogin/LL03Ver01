using System;
using System.Collections;
using UnityEngine;


namespace JevLogin
{
    public class ExampleInterface : MonoBehaviour
    {
        private void Start()
        {
            User user2 = new User(new Vector3[10]);
            user2[0] = new Vector3();
            var s = user2[MyEnum.None];
            Debug.Log(s);

            foreach (var use in user2)
            {

            }

            using (User user3 = new User())
            {

            }

            return;
            User user = new User
            {
                Name = "Evgeniy",
                Health = new Health
                {
                    CurrentHealth = 6.0f,
                    MaxHealth = 100.0f
                }
            };

            User user1 = user.Clone() as User;
            user1.Health.CurrentHealth = 100.0f;
            user1.Name = "Maksim";

            Debug.Log(user);
            Debug.Log(user1);
        }

        public enum MyEnum
        {
            None = 0,
            First = 1,
            Second = 2,
            Third = 3
        }

        public class User : ICloneable, IEnumerable, IDisposable
        {
            public string Name;
            public Health Health;
            private Vector3[] _points;

            public User()
            {
            }

            public User(Vector3[] points)
            {
                _points = points;
            }

            public Vector3 this[int i]
            {
                get { return _points[i]; }
                set { _points[i] = value; }
            }

            public string this[MyEnum value]
            {
                get
                {
                    switch (value)
                    {
                        case MyEnum.None:
                            return MyEnum.None.ToString();
                        case MyEnum.First:
                            return MyEnum.First.ToString();
                        case MyEnum.Second:
                            return MyEnum.Second.ToString();
                        case MyEnum.Third:
                            return MyEnum.Third.ToString();
                        default:
                            throw new ArgumentOutOfRangeException(nameof(value));
                    }
                }
            }

            public object Clone()
            {
                return new User
                {
                    Name = Name,
                    Health = new Health
                    {
                        CurrentHealth = Health.CurrentHealth,
                        MaxHealth = Health.MaxHealth
                    }
                };
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public IEnumerator GetEnumerator()
            {
                throw new NotImplementedException();
            }

            public override string ToString()
            {
                return $"{Name}, {Health}";
            }
        }
    }

    public class Health
    {
        public float CurrentHealth;
        public float MaxHealth;

        public override string ToString()
        {
            return $"_maxHealth = {MaxHealth} _currentHealth = {CurrentHealth}";
        }
    }
}
