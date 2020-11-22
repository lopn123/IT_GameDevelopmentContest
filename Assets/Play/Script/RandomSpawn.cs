using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject player;

    private float x;
    private float z;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1, 3);
    }

    private void Spawn()
    {
        if(!GameManager.RandomSpawning)
        {
            x = Random.Range(player.gameObject.transform.position.x - 30f, player.gameObject.transform.position.x + 30f);
            z = Random.Range(player.gameObject.transform.position.z - 30f, player.gameObject.transform.position.z + 30f);

            IsOutMap();

            this.transform.position = new Vector3(x, 0, z);

            GameManager.RandomSpawning = true;
        }   
    }
    
    private void IsOutMap()
    {
        if (x > 92)
        {
            x = 92;
        }
        else if (x < -92)
        {
            x = -92;
        }

        if (z > 35)
        {
            z = 35;
        }
        else if (z < - 35)
        {
            z = -35;
        }
    }
}
