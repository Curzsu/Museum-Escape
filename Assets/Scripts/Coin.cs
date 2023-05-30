using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Vector3 coinStartPosition;

    void Start()
    {
        // 找到标签为"coin"的金币对象，并记录它的初始位置
        GameObject coin = GameObject.FindWithTag("coin");
        coinStartPosition = coin.transform.position;
    }

    void Update()
    {
        // 找到标签为"coin"的金币与"Player"的玩家对象
        GameObject coin = GameObject.FindWithTag("coin");
        GameObject player = GameObject.FindWithTag("Player");

        // 计算金币与玩家之间的距离
        float distance = Vector3.Distance(coin.transform.position, player.transform.position);

        // 当金币与玩家之间的距离小于等于0.5f时，开始移动金币，否则不执行后续代码
        if (distance <= 6.5f)
        {
            // 使金币向玩家飞去，采用Lerp函数进行平滑的运动
            coin.transform.position = Vector3.Lerp(coin.transform.position, player.transform.position, Time.deltaTime * 6f);

            // 当金币与玩家之间的距离小于等于0.2f时，销毁金币
            if (distance <= 0.3f)
            {
                Destroy(coin);
            }
        }
        else
        {
            // 将金币返回到初始位置，等待下一次靠近玩家时再次飞行
            coin.transform.position = coinStartPosition;
        }
    }
}
