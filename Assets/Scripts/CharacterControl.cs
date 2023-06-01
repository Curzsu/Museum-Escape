using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public GameObject playerModel;//获取人物模型
    public float moveSpeed = 5;
    public float angularSpeed = 135;
    public float jumpForce = 5;
    //获取 NPCManager 对话框物体
    public GameObject NPCManager;
    private bool isGrounded = true;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        NPCManager = GameObject.Find("NPCManager");
        NPCManager.SetActive(false);//默认对话框为禁用状态
    }

    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        Jump();
        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit hit;
            //切记！！！光线投射方法里2个碰撞体要是相同类型的，才能打到
            if (Physics.Raycast(playerModel.transform.position + (new Vector3(0, 0.15f, 0)), playerModel.transform.forward, out hit, 10f, LayerMask.GetMask("NPC")))
            {
                if (hit.transform.name != null)
                {
                    NPCManager.SetActive(true);//启用对话框     
                    NPCController npcController = NPCManager.GetComponent<NPCController>();
                    if (npcController != null)
                    {
                        //相同的laptop模型的名字不同，这里就传入名字的的参数区分每个laptop需要显示的信息
                        npcController.ShowMeeage(hit.transform.name);
                    }

                }
            }

        }
    }

    void Move()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * v * Time.deltaTime * moveSpeed);
        transform.Rotate(Vector3.up * h * Time.deltaTime * angularSpeed);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}