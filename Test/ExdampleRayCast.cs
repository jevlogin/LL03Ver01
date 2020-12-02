using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class ExdampleRayCast : MonoBehaviour
    {
        private Camera _cams;

        private void Start()
        {
            _cams = Camera.main;

            //RaycastHit raycastHit;
            //if (Physics.Raycast(_cams.ScreenPointToRay(Input.mousePosition), out raycastHit, 100.0f))
            if (Physics.Raycast(_cams.ScreenPointToRay(Input.mousePosition), out _, 100.0f))
            {

            }
        }
    }
}
