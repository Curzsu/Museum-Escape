using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dianxiang : MonoBehaviour
{
    public GameObject ball;
    public GameObject particleEffectA;
    public GameObject particleEffectB;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 隐藏粒子特效a
            particleEffectA.SetActive(false);
            // 显示粒子特效b
            particleEffectB.SetActive(true);

            // 隐藏球体
            ball.SetActive(false);
        }
    }
}

