
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    [SerializeField] private Transform minX, maxX, minZ, maxZ;

    public Vector3 GetRandomSpawnLocation()
    {
        return new Vector3().GetRandomVector3(minX.position.x, maxX.position.x, minZ.position.z, maxZ.position.z);
    }
}
