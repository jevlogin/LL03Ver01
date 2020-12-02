using System.Threading;
using UnityEditor;
using UnityEngine;


namespace JevLogin
{
    public sealed class TestEditorBehaviour : MonoBehaviour
    {
        public float Count = 42;
        [Range(1, 10)]
        public int Step = 2;
        private void Start()
        {
#if UNITY_EDITOR
            for (int i = 0; i < Count; i++)
            {
                EditorUtility.DisplayProgressBar("Загрузка", $" проценты {i}", i / Count);
                Thread.Sleep(Step * 100);
            }
            EditorUtility.ClearProgressBar();
            var isPressed = EditorUtility.DisplayDialog("Вопрос", @"А оно тебе нужно ?", "Ага", "Возможно Нет");
            if (isPressed)
            {
                EditorApplication.isPaused = true;
            }
#endif
        }
    }
}
