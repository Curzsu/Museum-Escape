using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flick : MonoBehaviour
{
    public float pushForce = 10.0f;//被弹开距离
    //两点巡逻
    public float speed = 1.0f; // 移动速度
    private Vector3 startPoint;
    private Vector3 endPoint;
    private float startTime;
    private float journeyLength;

    void Start()
    {
        //在物体开始移动前执行，初始化起点、终点、开始时间和总距离
        startPoint = GameObject.Find("startPoint").transform.position;
        endPoint = GameObject.Find("endPoint").transform.position;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPoint, endPoint);
    }

    void Update()
    {
        //每帧调用一次，根据已经移动的距离计算当前位置，并通过插值函数（Lerp）将物体平滑地移动到目标位置。如果物体已经到达终点，则交换起点和终点，并重新开始移动
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startPoint, endPoint, fracJourney);
        if (fracJourney >= 1.0f)
        {
            Vector3 temp = startPoint;
            startPoint = endPoint;
            endPoint = temp;
            startTime = Time.time;
        }
    }
    //进入区域弹开
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            Vector3 pushDirection = other.transform.position - transform.position;
            pushDirection.Normalize();
            rb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }
}

