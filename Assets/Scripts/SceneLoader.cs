using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {
        // 延迟3秒后执行 LoadScene 函数
        Invoke("LoadScene", 5f);

    }

    void LoadScene()
    {
        SceneManager.LoadScene("Maze");
    }
}