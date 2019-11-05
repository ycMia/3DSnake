using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    //朝向      上 下   左 右
    //0         3   4   1   2
    //1         3   4   5   0
    //2         3   4   0   5
    //3         1   2   5   0
    //4         1   2   5   0
    //5         3   4   2   1
    public GameObject gm;
    public int myDest;
    public Toggle toggle;

    //Z+ Up     1
    //Z- Down   2
    //X- Left   5
    //X+ Right  0

    public void MOnClick()
    {
        gm.GetComponent<Gamemanager>().snake.isButtonDown = true;

        if (!toggle.isOn)
            switch (gm.GetComponent<Gamemanager>().snake.GetDestnation())
            {
                case 0:
                    switch (myDest)
                    {
                        case 5:
                            gm.GetComponent<Gamemanager>().snake.ExDestnation(1);
                            break;
                        case 0:
                            gm.GetComponent<Gamemanager>().snake.ExDestnation(2);
                            break;
                        case 1:
                            gm.GetComponent<Gamemanager>().snake.ExDestnation(3);
                            break;
                        case 2:
                            gm.GetComponent<Gamemanager>().snake.ExDestnation(4);
                            break;
                    }
                    break;
                case 1:
                    switch (myDest)
                    {
                        case 5:
                            gm.GetComponent<Gamemanager>().snake.ExDestnation(5);
                            break;
                        case 0:
                            gm.GetComponent<Gamemanager>().snake.ExDestnation(0);
                            break;
                        case 1:
                            gm.GetComponent<Gamemanager>().snake.ExDestnation(3);
                            break;
                        case 2:
                            gm.GetComponent<Gamemanager>().snake.ExDestnation(4);
                            break;
                    }
                    break;
                case 2:
                    switch (myDest)
                    {
                        case 5:
                            gm.GetComponent<Gamemanager>().snake.ExDestnation(0);
                            break;
                        case 0:
                            gm.GetComponent<Gamemanager>().snake.ExDestnation(5);
                            break;
                        case 1:
                            gm.GetComponent<Gamemanager>().snake.ExDestnation(3);
                            break;
                        case 2:
                            gm.GetComponent<Gamemanager>().snake.ExDestnation(4);
                            break;
                    }
                    break;
                case 3:
                    switch (myDest)
                    {
                        case 5:
                            gm.GetComponent<Gamemanager>().snake.ExDestnation(5);
                            break;
                        case 0:
                            gm.GetComponent<Gamemanager>().snake.ExDestnation(0);
                            break;
                        case 1:
                            gm.GetComponent<Gamemanager>().snake.ExDestnation(1);
                            break;
                        case 2:
                            gm.GetComponent<Gamemanager>().snake.ExDestnation(2);
                            break;
                    }
                    break;
                case 4:
                    switch (myDest)
                    {
                        case 5:
                            gm.GetComponent<Gamemanager>().snake.ExDestnation(5);
                            break;
                        case 0:
                            gm.GetComponent<Gamemanager>().snake.ExDestnation(0);
                            break;
                        case 1:
                            gm.GetComponent<Gamemanager>().snake.ExDestnation(1);
                            break;
                        case 2:
                            gm.GetComponent<Gamemanager>().snake.ExDestnation(2);
                            break;
                    }
                    break;
                case 5:
                    switch (myDest)
                    {
                        case 5:
                            gm.GetComponent<Gamemanager>().snake.ExDestnation(2);
                            break;
                        case 0:
                            gm.GetComponent<Gamemanager>().snake.ExDestnation(1);
                            break;
                        case 1:
                            gm.GetComponent<Gamemanager>().snake.ExDestnation(3);
                            break;
                        case 2:
                            gm.GetComponent<Gamemanager>().snake.ExDestnation(4);
                            break;
                    }
                    break;

                default:
                    break;
            }
        else
            gm.GetComponent<Gamemanager>().snake.ExDestnation(myDest);
    }

    public void Reset()
    {
        gm.GetComponent<Gamemanager>().snake.needReCreate = true;
    }

    public void PauseGame()
    {
        if (gm.GetComponent<Gamemanager>().paused == true)
            gm.GetComponent<Gamemanager>().paused = false;
        else
            gm.GetComponent<Gamemanager>().paused = true;
    }
}
