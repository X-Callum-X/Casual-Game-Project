using UnityEngine;

public class SpawnPlayerUnit : MonoBehaviour
{
    public GameObject unitToSpawn;
    public GameObject unitSpawnPoint;

    public void Spawn()
    {
        Instantiate(unitToSpawn, unitSpawnPoint.transform.position, Quaternion.identity);
    }
}
