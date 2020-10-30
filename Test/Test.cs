using System;
using System.IO;
using UnityEngine;


namespace JevLogin
{
    public sealed class Test : MonoBehaviour
    {
        private void Start()
        {
            StreamWriter streamWriter = null;

            try // Контролируемый блок
            {
                var path = Path.Combine(@"C:\", "temp", "text.txt");
                streamWriter = new StreamWriter(path);
                int a;
                do
                {
                    a = Convert.ToInt32(1);
                    streamWriter.WriteLine(a);
                } while (a != 0);
            }
            catch (FormatException) // Один или несколько блоков обработки исключений

            {
                Debug.Log($"Ошибка ввода данных");
            }
            catch (FileNotFoundException)
            {
                // Обработка исключения, возникшего при отсутствии файла
            }
            catch (IOException)
            {
                Debug.Log($"Ошибка ввода/вывода");
            }
            catch(Exception exc)
            {
                // Остальные исключения
                Debug.Log($"Неизвестная ошибка");
                Debug.Log($"Информация об ошибке" + exc.Message);
            }
            finally // Блок завершения

            {
                // Использование блока finally гарантирует, что набор операторов будет выполняться всегда, независимо от того, возникло исключение любого типа или нет)
                streamWriter?.Close();
            }
        }
    }
}
