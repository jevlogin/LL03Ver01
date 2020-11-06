using UnityEngine;


public class GenerateVectorController
{
    private Vector4 _sizeOfPlatform;

    public Vector4 GenerateVector4ToGameObject(Transform _transformGround)
    {
        var x = _transformGround.localPosition.x;
        var z = _transformGround.localPosition.z;

        if (_transformGround.TryGetComponent(out MeshFilter meshFilter))
        {
            var bounds = meshFilter.sharedMesh.bounds;
            _sizeOfPlatform.x = x + bounds.center.x;
            _sizeOfPlatform.y = z + bounds.center.z;
            _sizeOfPlatform.z = bounds.size.x;
            _sizeOfPlatform.w = bounds.size.z;
        }
        //var bounds = _transformGround.GetComponent<MeshFilter>().sharedMesh.bounds;

        return _sizeOfPlatform;
    }

    public Vector3 GetVector3GeneratePoint()
    {
        Vector3 result = Vector3.one;
        for (int i = 0; i < 100; i++)
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
                var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = checkPoint;
                cube.GetComponent<BoxCollider>().isTrigger = true;

                cube.name += checkPoint;
                return checkPoint;
            }
        }

        var cubeNegative = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubeNegative.GetComponent<BoxCollider>().isTrigger = true;
        cubeNegative.transform.position = result;
        cubeNegative.name += result;

        return result;
    }


}
