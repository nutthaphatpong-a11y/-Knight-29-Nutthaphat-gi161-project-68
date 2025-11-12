using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnee;
    [SerializeField] private float spawnCooldown = 1f;
    [SerializeField] private BoxCollider2D spawnArea;

    private float spawnTime;

    void Start()
    {
       

        spawnTime = spawnCooldown;
    }

    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            Spawn();
            spawnTime = spawnCooldown;
        }
    }

    void Spawn()
    {


        
        Bounds bounds = spawnArea.bounds;

        // สุ่มตำแหน่งภายในขอบเขตของ box
        float xPos = Random.Range(bounds.min.x, bounds.max.x);
        float yPos = Random.Range(bounds.min.y, bounds.max.y);

        Vector3 spawnPos = new Vector3(xPos, yPos, 0f);

        Instantiate(spawnee, spawnPos, Quaternion.identity);
    }
}
