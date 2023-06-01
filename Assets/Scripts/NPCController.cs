using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// NPC互动的对话框
/// 剧情内容编写
/// </summary>
public class NPCController : MonoBehaviour
{
    private string[] Dialog;//对话框内容数组
    private int index = 0;//数组下标
    public Text dialogText;//文字ui                          
    public Texture2D pointer; //设置光标样式(texture type 要设置成 Cursor才有效)
    public GameObject Zone; //添加Box变量

    private void Start()
    {
    }

    //更新对话框内容
    public void ShowMeeage(string Name)
    {

        Cursor.lockState = CursorLockMode.None;//显示鼠标指针
        Cursor.SetCursor(pointer, new Vector2(16, 16), CursorMode.Auto); //切换光标的样式
        //添加显示的信息，根据交互的人物名字不同，，赋值不同的文字
        string[] Dialog01 = new string[] { "信息：.........!!!!!!!",
            "信息：XD，QWQ",
            "信息：可怕的是......",
            "我：后面都是断断续续的杂音。。。。。",
            "信息：我会将此段信息设置定时任务每3分钟重复一次，时间：1960年X月X日" };

        string[] Dialog02 = new string[] { "信息：我们在这发现个遗迹，像是古代建筑.........", "我：。。。。。" };

        string[] Dialog03 = new string[] { "信息：警告！我们在最近的古代建筑建筑中发现了过去的古代人类",
            "信息：但似乎他们异常暴躁，甚至会主动攻击我们...有警员受伤，需要医疗......" ,
            "我：记录在这里就停止了" };

        string[] Dialog04 = new string[] {"...",
            "...",
            "..."};

        string[] Dialog05 = new string[] { "......",
            "......",
            "......" };

        string[] Dialog06 = new string[] {
            "...",
            "..."
        };


        if (Name == "Laptop01")
        {
            Dialog = Dialog01;
            // 显示Box
            Zone.SetActive(true);
        }

        if (Name == "Laptop02")
        {
            Dialog = Dialog02;

        }
        if (Name == "Laptop03")
        {
            Dialog = Dialog03;

        }
        if (Name == "CellPhone01")
        {
            Dialog = Dialog04;
        }

        if (Name == "NPCPolice")
        {
            Dialog = Dialog05;
        }

        if (Name == "CellPhone02")
        {
            Dialog = Dialog06;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (index < Dialog.Length)
            {
                dialogText.text = Dialog[index];
                index++;
            }
            else
            {
                index = 0;
                dialogText.text = Dialog[index];
            }
        }
    }

    //关闭对话框按钮
    public void CloseMessage()
    {
        index = 0;//下标为0，对话重置
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;//鼠标隐藏
    }



}
