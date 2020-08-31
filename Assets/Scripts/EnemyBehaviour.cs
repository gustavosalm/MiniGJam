using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private GameObject player;
    private float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
        transform.Rotate(new Vector3(0,-90,0),Space.Self);
        if(Vector3.Distance(transform.position, player.transform.position) > 1f)
            transform.Translate(new Vector3(speed* Time.deltaTime,0,0));
    }
}
