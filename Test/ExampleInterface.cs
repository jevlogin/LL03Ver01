using System;
using UnityEngine;


namespace JevLogin
{
    public class ExampleInterface : MonoBehaviour
    {
        private void Start()
        {
            User user2 = new User();
            user2[0] = new Vector3();

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

        public class User : ICloneable
        {
            public string Name;
            public Health Health;
            private Vector3[] _points;

            public Vector3 this[int i]
            {
                get { return _points[i]; }
                set { _points[i] = value; }
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
