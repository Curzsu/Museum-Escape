using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpScene : MonoBehaviour
{
    public Animator fadeAnimator; // 引用fade动画的Animator组件

    public void onClick()
    {
        StartCoroutine(LoadSceneWithFade());
    }

    IEnumerator LoadSceneWithFade()
    {
        // 播放fade动画
        fadeAnimator.SetTrigger("FadeOut");

        // 等待动画播放完毕
        yield return new WaitForSeconds(fadeAnimator.GetCurrentAnimatorStateInfo(0).length);

        // 跳转到下一个场景
        SceneManager.LoadScene("LoadingScreen");
    }
}