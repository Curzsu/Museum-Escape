using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneController : MonoBehaviour
{
    public Transform target;      // 物体Box的Transform组件
    public float attractSpeed;    // 吸引速度
    public float attractTime;     // 吸引时间
    public float waitTime;        // 停止吸引时间
    public ParticleSystem attractEffect; // 玩家被吸引时播放的特效

    private bool isAttracting = false;
    private float currentTime = 0f;
    private bool isPlayerControlled = true; // 添加一个bool类型的变量用于控制玩家是否可被操控

    private void Start()
    {
        // 在开始时禁用粒子特效
        attractEffect.Stop();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null && target != null)
            {
                if (isAttracting) // 正在吸引中
                {
                    currentTime += Time.deltaTime;
                    if (currentTime <= attractTime) // 在吸引时间内
                    {
                        // 计算当前位置到目标位置的向量
                        Vector3 direction = target.position - rb.position;

                        // 计算本帧需要移动的距离
                        float distanceThisFrame = attractSpeed * Time.deltaTime;

                        // 按照一定比例将玩家移动到物体Box的位置
                        rb.MovePosition(rb.position + direction.normalized * distanceThisFrame);

                        // 播放粒子特效
                        if (!attractEffect.isPlaying)
                        {
                            attractEffect.Play();
                        }
                    }
                    else // 超过吸引时间
                    {
                        isAttracting = false;
                        currentTime = 0f;

                        // 停止吸引玩家时，将isPlayerControlled设置为true，允许玩家被操控
                        isPlayerControlled = true;

                        // 停止播放粒子特效
                        attractEffect.Stop();
                    }
                }
                else // 不在吸引中
                {
                    currentTime += Time.deltaTime;
                    if (currentTime >= waitTime) // 等待时间已经过去
                    {
                        isAttracting = true;
                        currentTime = 0f;

                        // 进入吸引状态时，将isPlayerControlled设置为false，禁止玩家被操控
                        isPlayerControlled = false;
                    }
                }

                // 在isPlayerControlled为false时，禁用玩家的移动和旋转
                other.GetComponent<CharacterControl>().enabled = isPlayerControlled;
            }
        }
    }
}