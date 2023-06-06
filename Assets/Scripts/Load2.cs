using UnityEngine;
using UnityEngine.SceneManagement;

public class Load2 : MonoBehaviour
{
    void Start()
    {
        // 延迟3秒后执行 LoadScene 函数
        Invoke("LoadScene", 5f);
    }

    void LoadScene()
    {
        SceneManager.LoadScene("LoadingScreen2");
    }
}