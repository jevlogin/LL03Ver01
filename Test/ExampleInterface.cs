using System;
using UnityEngine;


namespace JevLogin
{
    public class ExampleInterface : MonoBehaviour
    {
        private void Start()
        {
            User user = new User
            {
                Name = "Evgeniy",
                Health = new Health
                {
                    CurrentHealth = 10.0f,
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

            public object Clone()
            {
                return MemberwiseClone();
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
