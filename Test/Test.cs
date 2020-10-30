using System;
using System.IO;
using UnityEngine;


namespace JevLogin
{
    public sealed class Test : MonoBehaviour
    {
        private void Start()
        {
            try // Контролируемый блок
            {
                Division(5, 0);
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
               
            }
        }

        private void Division(int v1, int v2)
        {
            if (Convert.ToInt32(v2) == 0)
            {
                throw new Exception("Деление на ноль");
            }
            var x = Convert.ToInt32(v1) / Convert.ToInt32(v2);
            Debug.Log($"{v1} / {v2} = {x}");
        }
    }
}
