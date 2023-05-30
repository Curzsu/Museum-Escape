using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed = 5f;
    public float seeDistance = 5f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < seeDistance)
        {
            transform.LookAt(player.transform);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            transform.LookAt(startPosition);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, startPosition) < 0.1f)
            {
                transform.position = startPosition;
            }
        }
    }
}