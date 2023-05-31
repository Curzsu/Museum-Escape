using UnityEngine;

public class TeleSound : MonoBehaviour
{
    public AudioClip audioClip;
    public float volume = 0.5f;
    
    void Start()
    {
        // 创建一个 AudioSource 组件并添加到当前对象上
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();

        // 将 AudioClip 赋值给 AudioSource
        audioSource.clip = audioClip;

        // 设置 AudioSource 的其他参数，例如播放音量、是否循环、在 Awake 中预加载等
        audioSource.volume = 1f;
        audioSource.loop = false;
        audioSource.playOnAwake = false;
        audioSource.volume = volume;

        // 播放 AudioClip
        audioSource.Play();
    }
}