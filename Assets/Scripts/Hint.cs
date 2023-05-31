using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Hint : MonoBehaviour
{
    void Start()
    {
        Text text = GameObject.FindWithTag("TeleportHint").GetComponent<Text>();
        text.DOFade(1, 6);
        
    }
}
