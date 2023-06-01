using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingController : MonoBehaviour
{
    public GameObject uiPanel; // 你的UI界面对象
    public Texture2D pointer; //设置光标样式(texture type 要设置成 Cursor才有效)
    public Slider volumeSlider;
    public AudioSource bgmAudioSource;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            uiPanel.SetActive(true); // 显示UI界面
            Cursor.lockState = CursorLockMode.None;//显示鼠标指针
            Cursor.SetCursor(pointer, new Vector2(16, 16), CursorMode.Auto); //切换光标的样式
            Time.timeScale = 0; // 暂停游戏
        }
    }

    private void Start()
    {
        // 设置拖拽条的初始值为背景音乐音量
        volumeSlider.value = bgmAudioSource.volume;
    }

    // 拖拽条数值发生改变时调用的方法
    public void OnVolumeSliderChanged(float value)
    {
        // 设置背景音乐音量为拖拽条的值
        bgmAudioSource.volume = value;
    }

    // 隐藏UI界面的方法
    public void HideUIPanel()
    {
        uiPanel.SetActive(false); //隐藏UI界面
        Cursor.lockState = CursorLockMode.Locked;//鼠标隐藏
        Time.timeScale = 1; // 恢复游戏
    }

    // 退出游戏的方法
    public void QuitGame()
    {
        Application.Quit();
    }
}

