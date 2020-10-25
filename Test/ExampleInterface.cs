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

            public object Clone()
            {
                //return MemberwiseClone();
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
