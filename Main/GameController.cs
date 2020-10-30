using System;
using UnityEngine;
using UnityEngine.UI;

namespace JevLogin
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        [SerializeField] private Text _finishGameLabel;
        private ListInteractableObject _interactableObject;
        private DisplayEndGame _displayEndGame;

        private void Awake()
        {
            _interactableObject = new ListInteractableObject();
            _displayEndGame = new DisplayEndGame(_finishGameLabel);
            foreach (var item in _interactableObject)
            {
                if (item is BadBonus badBonus)
                {
                    badBonus.CaughPlayer += CaughPlayer;
                    badBonus.CaughPlayer += _displayEndGame.GameOver;
                }
            }
        }

        private void CaughPlayer(object value, CaughtPlayerEventArgs args)
        {
            Time.timeScale = 0.0f;
        }

        private void Update()
        {
            for (var i = 0; i < _interactableObject.Count; i++)
            {
                var interactableObject = _interactableObject[i];

                if (interactableObject == null)
                {
                    continue;
                }

                if (interactableObject is IFlay flay)
                {
                    flay.Flay();
                }
                if (interactableObject is IFlicker flicker)
                {
                    flicker.Flicker();
                }
                if (interactableObject is IRotation rotation)
                {
                    rotation.Rotation();
                }
                
            }
        }

        public void Dispose()
        {
            foreach (var interactableObject in _interactableObject)
            {
                if (interactableObject is InteractiveObject interactiveObject)
                {
                    if (interactableObject is BadBonus badBonus)
                    {
                        badBonus.CaughPlayer -= CaughPlayer;
                        badBonus.CaughPlayer -= _displayEndGame.GameOver;
                    }
                    Destroy(interactiveObject.gameObject);
                }
            }
        }
    }
}