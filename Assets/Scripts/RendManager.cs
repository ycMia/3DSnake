using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendManager : MonoBehaviour
{
    public GameObject gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gm.GetComponent<Gamemanager>().snake.Move();
        if (gm.GetComponent<Gamemanager>().snake.IsEatingApple())
        {
            gm.GetComponent<Gamemanager>().snake.CreateApple();
        }
        if (gm.GetComponent<Gamemanager>().snake.isdead)
        {
            gm.GetComponent<Gamemanager>().snake.PrintSnake(3);
        }
        else
        {
            gm.GetComponent<Gamemanager>().snake.PrintSnake(2);
        }
    }
}
