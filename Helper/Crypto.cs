using UnityEngine;


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

        public static string CryptoJEVLOGIN(string text)
        {
            var result = string.Empty;
            int tempRandom = 0;

            foreach (var simbol in text)
            {
                var i = GetIntFromCharacter(simbol);
                tempRandom = Random.Range(1, 9);
                i += tempRandom;
                result += tempRandom + i;
            }

            return result;
        }

        private static int GetIntFromCharacter(char simbol)
        {
            int ascii = 0;

            if (simbol == 'А')
            {
                ascii = 1;
            }
            else if (simbol == 'Б')
            {
                ascii = 2;
            }
            else if (simbol == 'В')
            {
                ascii = 3;
            }
            else if (simbol == 'Г')
            {
                ascii = 4;
            }
            else if (simbol == 'Д')
            {
                ascii = 5;
            }
            else if (simbol == 'Е')
            {
                ascii = 6;
            }
            else if (simbol == 'Ё')
            {
                ascii = 7;
            }
            else if (simbol == 'Ж')
            {
                ascii = 8;
            }
            else if (simbol == 'З')
            {
                ascii = 9;
            }
            else if (simbol == 'И')
            {
                ascii = 10;
            }
            else if (simbol == 'Й')
            {
                ascii = 11;
            }
            else if (simbol == 'К')
            {
                ascii = 12;
            }
            else if (simbol == 'Л')
            {
                ascii = 13;
            }
            else if (simbol == 'М')
            {
                ascii = 14;
            }
            else if (simbol == 'Н')
            {
                ascii = 15;
            }
            else if (simbol == 'О')
            {
                ascii = 16;
            }
            else if (simbol == 'П')
            {
                ascii = 17;
            }
            else if (simbol == 'Р')
            {
                ascii = 18;
            }
            else if (simbol == 'С')
            {
                ascii = 19;
            }
            else if (simbol == 'Т')
            {
                ascii = 20;
            }
            else if (simbol == 'У')
            {
                ascii = 21;
            }
            else if (simbol == 'Ф')
            {
                ascii = 22;
            }
            else if (simbol == 'Х')
            {
                ascii = 23;
            }
            else if (simbol == 'Ц')
            {
                ascii = 24;
            }
            else if (simbol == 'Ч')
            {
                ascii = 25;
            }
            else if (simbol == 'Ш')
            {
                ascii = 26;
            }
            else if (simbol == 'Щ')
            {
                ascii = 27;
            }
            else if (simbol == 'Ъ')
            {
                ascii = 28;
            }
            else if (simbol == 'Ы')
            {
                ascii = 29;
            }
            else if (simbol == 'Ь')
            {
                ascii = 30;
            }
            else if (simbol == 'Э')
            {
                ascii = 31;
            }
            else if (simbol == 'Ю')
            {
                ascii = 32;
            }
            else if (simbol == 'Я')
            {
                ascii = 33;
            }
            else if (simbol == ' ')
            {
                ascii = 44;
            }
            else if (simbol == '.')
            {
                ascii = 55;
            }
            else if (simbol == ',')
            {
                ascii = 66;
            }
            else if (simbol == '!')
            {
                ascii = 77;
            }
            else if (simbol == '?')
            {
                ascii = 88;
            }
            else if (simbol == '0')
            {
                ascii = 1000;
            }
            else if (simbol == '1')
            {
                ascii = 1001;
            }
            else if (simbol == '2')
            {
                ascii = 1002;
            }
            else if (simbol == '3')
            {
                ascii = 1003;
            }
            else if (simbol == '4')
            {
                ascii = 1004;
            }
            else if (simbol == '5')
            {
                ascii = 1005;
            }
            else if (simbol == '6')
            {
                ascii = 1006;
            }
            else if (simbol == '7')
            {
                ascii = 1007;
            }
            else if (simbol == '8')
            {
                ascii = 1008;
            }
            else if (simbol == '9')
            {
                ascii = 1009;
            }
            else if (simbol == '+')
            {
                ascii = 1010;
            }
            else if (simbol == '-')
            {
                ascii = 1011;
            }
            else if (simbol == '*')
            {
                ascii = 1012;
            }
            else if (simbol == '/')
            {
                ascii = 1013;
            }
            else if (simbol == '%')
            {
                ascii = 1014;
            }
            else if (simbol == ':')
            {
                ascii = 1015;
            }
            else if (simbol == ';')
            {
                ascii = 1016;
            }
            return ascii;
        }
    }
}
