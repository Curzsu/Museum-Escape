using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    private Text text;
    private Image img;
    public Health health;
    public bool isDeath;

    void Update()
    {
        isDeath = health.isDeath;
        Debug.Log(isDeath);
        if (isDeath)
        {
            text = GetComponent<Text>();
            img = GetComponent<Image>();
            // 在duration时间内将image的颜色从fromColor变为toColor
            // 可以通过调整Ease函数和Loops参数来控制变化速度和循环次数
            transform.DOShakePosition(4, 0.2f); //在随机方向震动3秒,振幅为3
            text.DOFade(1, 6);
            img.DOFade(1, 6);
            text.DOColor(Color.red, 6); //3秒变红
        }
    }
}