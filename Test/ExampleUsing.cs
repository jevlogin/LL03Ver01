using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class ExampleUsing : MonoBehaviour
    {
        private int WriteLinesToFile(IEnumerable<string> lines)
        {
            using var file = new System.IO.StreamWriter("writelines2.txt");
            int skippedLines = 0;
            foreach (string line in lines)
            {
                if (!line.Contains("Second"))
                {
                    file.WriteLine(line);
                }
                else
                {
                    skippedLines++;
                }
            }
            return skippedLines;
        }
    }
}
