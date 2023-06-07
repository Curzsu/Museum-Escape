using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public int currentScore = 0;  // 当前分数值
    public Text scoreText;        // 分数UI文本组件
    public GameObject teleport;
    public GameObject teleportHints;
    public AudioClip audioClip;
    public float volume = 0.5f;
    
    void Start()
    {
        teleport = GameObject.FindWithTag("Teleport");
        teleportHints = GameObject.FindWithTag("TeleportHint");
        teleportHints.SetActive(false);
        teleport.SetActive(false);
        // 获取分数UI文本组件
        scoreText = GetComponent<Text>();
        UpdateScoreText();
        // 创建一个 AudioSource 组件并添加到当前对象上
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();

        // 将 AudioClip 赋值给 AudioSource
        audioSource.clip = audioClip;

        // 设置 AudioSource 的其他参数，例如播放音量、是否循环、在 Awake 中预加载等
        audioSource.volume = 1f;
        audioSource.loop = false;
        audioSource.playOnAwake = false;
        audioSource.volume = volume;
    }

    // 增加分数值
    public void AddScore(int score)
    {
        currentScore += score;
        UpdateScoreText();
        
    }

    // 更新分数UI文本
    void UpdateScoreText()
    {
        scoreText.text = "50/" + currentScore.ToString();
        if (currentScore >= 50 && currentScore < 52)
        {
            teleport.SetActive(true);
            teleportHints.SetActive(true);
            // 播放音乐
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.PlayOneShot(audioClip, volume);
            }
            
        }
    }
}