using UnityEngine;

public class Spawner : MonoBehaviour
{
    public ObjectPool pool;
    public Transform[] spawnPoints;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 0, 2f);
    }

    private void Spawn()
    {
        int index = Random.Range(0, spawnPoints.Length);
        pool.Spawn(spawnPoints[index].transform.position, Quaternion.identity);
    }
}
