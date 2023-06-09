﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public Rigidbody rb;
    public GameObject deathUI;
    public bool isDeath = false;
    public Transform ghost;
    

    private void Update()
    {
        // 获取目标物体的当前位置
        Vector3 objPos = ghost.position;
        if (objPos.y < -30)
        {
            isDeath = true;
            Die();
        }
        if (currentHealth <= 10 && currentHealth != 0)
        {
             rb = GetComponent<Rigidbody>();
             rb.constraints = RigidbodyConstraints.None;
        } 
        else if (currentHealth <= 0)
        {
            
            isDeath = true;
            rb.constraints = RigidbodyConstraints.FreezePosition;
            Die();
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(20);
        }

        if (collision.gameObject.CompareTag("Cherry"))
        {
            AddHealth(20);
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void AddHealth(int health)
    {
        currentHealth += health;
        healthBar.SetHealth(currentHealth);
        GameObject cherry = GameObject.FindWithTag("Cherry");
        Destroy(cherry);
    }

    public void Die()
    {
        deathUI = GameObject.FindWithTag("Death");
        deathUI.SetActive(true);
    }
}