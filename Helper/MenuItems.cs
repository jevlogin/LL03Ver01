using UnityEditor;


namespace JevLogin
{
    public sealed class MenuItems
    {
        [MenuItem("GeekBrains/Пункт Меню №0")]
        private static void MenuOption()
        {

        }

        [MenuItem("GeekBrains/Пункт Меню №1 %#a")]
        private static void NewMenuItem()
        {

        }

        [MenuItem("Geekbrains/Пункт меню №2 %g")]
        private static void NewNestedOption()
        {
        }

        [MenuItem("Geekbrains/Пункт меню №3 _g")]
        private static void NewOptionWithHotkey()
        {
        }

        [MenuItem("Geekbrains/Пункт меню/Пункт меню №3 _g")]
        private static void NewOptionWithHot()
        {
        }

        [MenuItem("Assets/Geekbrains")]
        private static void LoadAdditiveScene()
        {
        }

        [MenuItem("Assets/Create/Geekbrains")]
        private static void AddConfig()
        {
        }

        [MenuItem("CONTEXT/Rigidbody/Geekbrains")]
        private static void NewOpenForRigidBody()
        {
        }

    }
}
