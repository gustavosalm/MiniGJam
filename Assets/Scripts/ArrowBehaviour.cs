using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    private GameObject player;
    private Vector3 mp;
    private Vector3 direc;
    private float speed = 10;
    public bool loading = true;
    private Vector3 mainScale;
    private float scale;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        mainScale = transform.localScale;
        mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        scale = Vector3.Distance(player.transform.position, mp) - 10;
        transform.localScale = new Vector3(transform.localScale.x, mainScale.y * ((scale < 1) ? ((scale > 0.5f) ? scale : 0.5f) : 1));

        Task tarefa = new Task(3, "Bixo");
    }

    // Update is called once per frame
    void Update()
    {    
        mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //print(Vector3.Distance(player.transform.position, mp) - 10);
        if(loading)
        {
            direc = new Vector3(player.transform.position.x - mp.x, player.transform.position.y - mp.y);
            scale = Vector3.Distance(player.transform.position, mp) - 9.5f;
            transform.localScale = new Vector3(transform.localScale.x, mainScale.y * ((scale < 1) ? ((scale > 0.5f) ? scale : 0.5f) : 1));
            transform.up = direc;
        }
        else
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
            transform.parent = null;
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Bixo")
        {
            if(col.gameObject.tag == player.GetComponent<Player>().alvo)
                player.GetComponent<Player>().TaskProgress();
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }
}
