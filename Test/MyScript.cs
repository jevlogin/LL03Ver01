using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class MyScript : MonoBehaviour
    {
        public int Count = 10;
        public int Offset = 1;
        public GameObject Obj;

        public float Test;
        private Transform _root;

        private void Start()
        {
            CreateObj();
        }

        public void CreateObj()
        {
            _root = new GameObject("Root").transform;
            for (int i = 0; i < Count; i++)
            {
                Instantiate(Obj, new Vector3(0, Offset * i, 0), Quaternion.identity, _root);
            }
        }

        public void AddComponent()
        {
            gameObject.AddComponent<Rigidbody>();
            gameObject.AddComponent<MeshRenderer>();
            gameObject.AddComponent<BoxCollider>();
        }

        public void RemoveComponent()
        {
            DestroyImmediate(GetComponent<Rigidbody>());
            DestroyImmediate(GetComponent<MeshRenderer>());
            DestroyImmediate(GetComponent<BoxCollider>());
        }
    }
}
