using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Mesh spawnerMesh;
    public GameObject monster;
    public bool respawn;
    public float spawnDelay;

    private float currentTime;
    private bool spawning;

    // Start is called before the first frame update
    private void Start()
    {
        Spawn();
        currentTime = spawnDelay;
    }

    // Update is called once per frame
    private void Update()
    {
        if (spawning)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                Spawn();
            }
        }
    }

    public void Respawn()
    {
        spawning = true;
        currentTime = spawnDelay;
    }

    private void Spawn()
    {
        IEnemy instance = Instantiate(monster, transform.position, Quaternion.identity).GetComponent<IEnemy>();
        instance.Spawner = this;
        spawning = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawMesh(monster.GetComponent<MeshFilter>().sharedMesh, transform.position, Quaternion.identity, Vector3.one);
        //Gizmos.DrawIcon(transform.position, "portal.png", true);
    }
}
