using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //脚本需要挂载在camera 父对象上,保持相机与物件的相对距离
    public Gamemanager gm;
    
    void Update()
    {
        GetComponent<Transform>().position = Vector3.Lerp(GetComponent<Transform>().position,gm.snake.GetVisualHeadPosition(), 0.2f);
    }
}