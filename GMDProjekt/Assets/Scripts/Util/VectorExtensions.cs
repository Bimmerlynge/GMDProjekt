using UnityEngine;


public static class VectorExtensions
{
    public static Vector3 GetIsometricVector3(this Vector2 vector)
    {
        var buffer = new Vector3(vector.x, 0, vector.y);
        var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, -45, 0));
        return matrix.MultiplyPoint3x4(buffer);
    }

    public static Vector3 GetRandomVector3(this Vector3 vector, float minX, float maxX, float minZ, float maxZ)
    {
        return new Vector3(
            Random.Range(minX, maxX),
            0.5f,
            Random.Range(minZ, maxZ)
        );
    }
    
}
