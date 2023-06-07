using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMaze : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("LoadingScreen2");
        }
    }
}