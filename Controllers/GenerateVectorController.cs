﻿using UnityEngine;


public class GenerateVectorController : MonoBehaviour
{
    private Transform _transform;
    private Transform[] _transforms;
    private Vector4 _sizeOfPlatform;

    private void GenerateVector4ToGameObject(Transform _transformGround)
    {
        var x = _transformGround.localPosition.x;
        var z = _transformGround.localPosition.z;
        if (TryGetComponent<MeshFilter>(out MeshFilter meshFilter))
        {
            var bounds = meshFilter.sharedMesh.bounds;
            _sizeOfPlatform.x = x + bounds.center.x;
            _sizeOfPlatform.y = z + bounds.center.z;
            _sizeOfPlatform.z = bounds.size.x;
            _sizeOfPlatform.w = bounds.size.z;
        }
        //var bounds = _transformGround.GetComponent<MeshFilter>().sharedMesh.bounds;
    }

    private Transform[] GenerateWaypoints(Transform[] _waypoints)
    {
        Transform[] transforms = GameObject.Instantiate();
        if (_waypoints == null || _waypoints.Length == 0)
        {
            _waypoints = new[] { GeneratePoint() };
        }

        Array.Resize(ref _waypoints, _waypoints.Length + 1);
        _waypoints[_waypoints.Length - 1] = GeneratePoint();

        return _waypoints;
    }



    public Vector3 GeneratePoint()
    {
        Vector3 result = Vector3.one;
        for (int i = 0; i < 50; i++)
        {
            var x = Random.Range(_sizeOfPlatform.x - (_sizeOfPlatform.z / 2), _sizeOfPlatform.x + (_sizeOfPlatform.z / 2));
            var y = 0.5f;
            var z = Random.Range(_sizeOfPlatform.y - (_sizeOfPlatform.w / 2), _sizeOfPlatform.y + (_sizeOfPlatform.w / 2));
            var checkPoint = new Vector3(x, y, z);
            var _ = new Collider[2];
            int numColliders = Physics.OverlapSphereNonAlloc(checkPoint, 2.0f, _);
            //Debug.Log($"i: {i}, numColliders: {numColliders}");
            if (numColliders == 1)
            {
                var ct = Instantiate(_prefab, checkPoint, Quaternion.identity);
                ct.name = name + checkPoint;
                return checkPoint;
            }
        }

        Instantiate(_prefab, result, Quaternion.identity);

        return result;
    }
}
