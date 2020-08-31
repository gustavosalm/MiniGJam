using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy1, player;
    private float timer;
    private Vector3 pos;
    private float x, y;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartSpawn()
    {
        InvokeRepeating("Spawn", 0f, 2f);
    }

    void Spawn()
    {
        x = Random.Range(16, 20) * ((Random.Range(0, 100) > 50) ? 1 : -1);
        y = Random.Range(9, 15) * ((Random.Range(0, 100) > 50) ? 1 : -1);
        pos = new Vector3(x + player.transform.position.x, y + player.transform.position.y);
        Instantiate(enemy1, pos, Quaternion.identity);
    }
}
