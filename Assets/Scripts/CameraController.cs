using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 定义摄像机跟随的逻辑
/// </summary>
public class CameraController : MonoBehaviour {

    [SerializeField]
    private GameObject player;  //用player 来控制相机的水平移动
    [SerializeField]
    private GameObject cameraHandle; //CamerHandle 控制相机的垂直移动

    //public UserInput ui;
    public float horizontalSpeed = 120;
    public float verticalSpeed = 100;
    private float tempEulerX;  //设置一个临时值，用来限制摄像机俯视角旋转大小

    /*相机旋转的时候不能带动模型旋转*/
    private GameObject model;

    private void Awake()
    {
        cameraHandle = transform.parent.gameObject;//获取相机的父物体(cameraHandle)
        player = cameraHandle.transform.parent.gameObject;//获取到player物体
        tempEulerX = 20;
     //   model = player.GetComponent<PlayerController>().playerModel;
   //     Cursor.lockState = CursorLockMode.Locked;//鼠标隐藏

    }


    private void Update()
    {

        //模型不跟着相机旋转
        //记录下模型的旋转角
        Vector3 tempModelEuler = model.transform.eulerAngles;
    
        //相机的水平旋转
    //    player.transform.Rotate(Vector3.up * ui.MouseRight * horizontalSpeed * Time.deltaTime);
        //鼠标前后移动就变化了前后的方向
       // tempEulerX -= ui.MouseUp * verticalSpeed * Time.deltaTime;
        tempEulerX = Mathf.Clamp(tempEulerX, 10, 45);//限制俯视的角度
        //相机的垂直移动,这里就不用全局坐标了，要用局部坐标，转动 cameraHandle 本身
        cameraHandle.transform.localEulerAngles = new Vector3(tempEulerX, 0, 0);

        //模型根据摄像机的转向，重新旋转
        model.transform.eulerAngles = tempModelEuler;

    }



}
