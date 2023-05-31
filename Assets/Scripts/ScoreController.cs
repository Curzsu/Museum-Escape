using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public int currentScore = 0;  // 当前分数值
    public Text scoreText;        // 分数UI文本组件

    void Start()
    {
        // 获取分数UI文本组件
        scoreText = GetComponent<Text>();
        UpdateScoreText();
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
        scoreText.text = "100/" + currentScore.ToString();
    }
}