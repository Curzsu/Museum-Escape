using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float patrolRange = 5.0f; // 巡逻半径
    public float chaseRange = 3.0f; // 追击半径
    public float chaseSpeed = 2.0f; // 追击速度
    public float patrolSpeed = 1.0f; // 巡逻速度
    public Transform[] waypoints; // 巡逻点数组
    private int currentWaypointIndex = 0; // 当前巡逻点索引
    private Transform player; // 玩家
    private Vector3 initialPosition; // 起始位置
    private bool isChasing = false; // 是否在追击
    public AudioClip audioClip;
    private AudioSource audioSource;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        initialPosition = transform.position;
        // 创建一个 AudioSource 组件并添加到当前对象上
        audioSource = gameObject.AddComponent<AudioSource>();

        // 将 AudioClip 赋值给 AudioSource
        audioSource.clip = audioClip;
    }

    private void Update()
    {
        if (!isChasing)
        {
            Patrol();
        }
        else
        {
            Chase();
            
        }
    }

    private void Patrol()
    {
        if (Vector3.Distance(transform.position, initialPosition) > patrolRange)
        {
            // 超出巡逻范围，返回起始位置
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, patrolSpeed * Time.deltaTime);
        }
        else
        {
            // 在巡逻范围内，移动到下一个巡逻点
            Vector3 target = waypoints[currentWaypointIndex].position;
            target.y = transform.position.y; // 垂直方向不变
            Vector3 direction = Vector3.ProjectOnPlane(target - transform.position, Vector3.up); // 只在水平方向上移动
            transform.position += direction.normalized * patrolSpeed * Time.deltaTime;

            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
            {
                // 到达当前巡逻点，选择下一个巡逻点
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }

            if (IsPlayerInRange(chaseRange))
            {
                // 玩家进入追击范围，切换状态为追击
                isChasing = true;
                Debug.Log("666666");
                // 播放 AudioClip
                audioSource.Play();
            }
        }
    }

    private void Chase()
    {
        Vector3 target = player.position;
        target.y = transform.position.y; // 垂直方向不变
        Vector3 direction = Vector3.ProjectOnPlane(target - transform.position, Vector3.up); // 只在水平方向上移动
        transform.position += direction.normalized * chaseSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, player.position) < 0.2f)
        {
            // 到达追击点，停止追击
            isChasing = false;
        }

        if (!IsPlayerInRange(chaseRange * 2))
        {
            // 玩家不在视野范围内，返回原位
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, patrolSpeed * Time.deltaTime);
            isChasing = false;
        }
    }

    private bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.position) <= range && player.CompareTag("Player");
    }
}
