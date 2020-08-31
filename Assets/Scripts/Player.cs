using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Transform tr;
    private float hor, ver;
    private bool playing = false;
    public Vector3 mousePos;
    public GameObject arrow, spawnedArrow, tasksBar, currentTask;
    private TasksManager tm;
    public string alvo;
    public int cont, meta, child;
    public DynamicJoystick joystick;

    // Start is called before the first frame update
    void Start()
    {        
        rb = gameObject.GetComponent<Rigidbody2D>();
        tr = gameObject.GetComponent<Transform>();
        tm = GameObject.FindWithTag("TasksManager").GetComponent<TasksManager>();
        child = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // hor = Input.GetAxisRaw("Horizontal");
        // ver = Input.GetAxisRaw("Vertical");
        hor = joystick.Horizontal;
        ver = joystick.Vertical;
        rb.velocity = new Vector2(speed * hor, speed * ver);
        Shot();
       
        if(Input.GetKeyDown(KeyCode.Q))
            tasksBar.SetActive(!tasksBar.activeInHierarchy);
    }

    public void TaskProgress()
    {
        cont = (cont + 1 < meta) ? cont + 1 : 0;
        if(cont == 0)
        {       
            Destroy(tasksBar.transform.GetChild(0).gameObject); 
            child++;
            tm.NextTask();
        }
        else
            currentTask.GetComponent<Text>().text = "Mate " + meta + " " + alvo + " \n " + cont + "/" + meta;
    }
    public void NewTask(string alv, int mt)
    {
        print(1);
        alvo = alv;
        meta = mt;
        cont = 0;
        currentTask = tasksBar.transform.GetChild(child).gameObject;
        currentTask.SetActive(true);
        currentTask.GetComponent<Text>().text = "Mate " + meta + " " + alvo + " \n " + cont + "/" + meta;
    }

    void Shot()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetKeyDown(KeyCode.Mouse0) && playing)
        {
            spawnedArrow = Instantiate(arrow, transform.position, Quaternion.identity);   
            spawnedArrow.transform.parent = this.transform;
            spawnedArrow.transform.up = new Vector2(this.transform.position.x - mousePos.x, this.transform.position.y - mousePos.y);
        }
        if(Input.GetKeyUp(KeyCode.Mouse0) && playing && spawnedArrow)
        {
            spawnedArrow.GetComponent<ArrowBehaviour>().loading = false;
            spawnedArrow = null;
        }        
    }

    public void Play()
    {
        playing = true;
        speed = 7;
    }
}


