using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasksManager : MonoBehaviour
{
    private Player ps;
    private Task[] dio = new Task[3];
    private Task[] apo = new Task[3];
    private int taskCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        ps = GameObject.FindWithTag("Player").GetComponent<Player>();

        dio[0] = new Task(3, "Bixo");
        dio[1] = new Task(5, "Bixo2");
        dio[taskCount].SetTask(ps);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextTask()
    {
        taskCount++;
        dio[taskCount].SetTask(ps);        
    }
}

public struct Task
{
    public int metaT;
    public string alvoT;
    public void SetTask(Player sla)
    {
        sla.NewTask(alvoT, metaT);
    }
    public Task(int met, string alvt)
    {
        metaT = met;
        alvoT = alvt;
    }
}
