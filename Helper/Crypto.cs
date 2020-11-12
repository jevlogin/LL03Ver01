﻿using UnityEngine;


namespace JevLogin
{
    public static class Crypto
    {
        public static string CryptoXOR(string text, int key = 42)
        {
            var result = string.Empty;
            foreach (var simbol in text)
            {
                result += (char)(simbol ^ key);
            }
            return result;
        }
    }
}
