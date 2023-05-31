using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Vector3 coinStartPosition;
    public float rotationSpeed = 15f; // 旋转速度
    void Start()
    {
        // 记录金币的初始位置
        coinStartPosition = transform.position;
    }

    void Update()
    {
        // 让物体绕着 Y 轴旋转
        transform.Rotate(0f, rotationSpeed * Time.deltaTime*4, 0f);
        
        // 找到"Player"的玩家对象
        GameObject player = GameObject.FindWithTag("Player");

        // 计算金币与玩家之间的距离
        float distance = Vector3.Distance(transform.position, player.transform.position);

        // 当金币与玩家之间的距离小于等于0.5f时，开始移动金币，否则将金币返回到初始位置
        if (distance <= 6.5f)
        {
            // 使金币向玩家飞去，采用Lerp函数进行平滑的运动
            transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * 6f);

            // 当金币与玩家之间的距离小于等于0.2f时，销毁金币
            if (distance <= 0.55f)
            {
                CollectCoin(player);
            }
        }
        else
        {
            // 将金币返回到初始位置，等待下一次靠近玩家时再次飞行
            transform.position = coinStartPosition;
        }
    }

    void CollectCoin(GameObject player)
    {
        Destroy(gameObject);
    }
}