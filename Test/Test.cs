using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace JevLogin
{
    public sealed class Test : MonoBehaviour
    {
        public class EmailAddress
        {
            public string Name { get; }
            public string Address { get; }
            public EmailAddress(string n, string a)
            {
                Name = n;
                Address = a;
            }

        }
        private void Start()
        {
            EmailAddress[] addrs = {
                new EmailAddress("Herb", "Herb@HerbSchildt.com"),
                new EmailAddress("Tom", "Tom@HerbSchildt.com"),
                new EmailAddress("Sara", "Sara@HerbSchildt.com")
            };
            // Create a query that selects e-mail addresses
            var eAddrs = from entry in addrs
                         select entry.Address;
            Debug.Log("The e-mail addresses are");
            // Execute the query and display the results
            foreach (string s in eAddrs)
            {
                Debug.Log("  " + s);
            }
        }

    }
}
