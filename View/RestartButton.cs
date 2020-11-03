using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace JevLogin
{
    public class RestartButton
    {
        private Button _restartButton;

        public RestartButton(Button restartButton)
        {
            _restartButton = restartButton.GetComponent<Button>();
            _restartButton.gameObject.SetActive(false);
        }

        public void RestartGame()
        {
            Debug.Log($"Перезагрузка.");
            SceneManager.LoadScene(0);
            Time.timeScale = 1.0f;
        }
    }
}