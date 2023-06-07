using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flick : MonoBehaviour
{
    public float pushForce = 10.0f;
    public float speed = 1.0f;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private float startTime;
    private float journeyLength;

    void Start()
    {
        startPoint = transform.Find("startPoint").position;
        endPoint = transform.Find("endPoint").position;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPoint, endPoint);
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startPoint, endPoint, fracJourney);
        if (fracJourney >= 1.0f)
        {
            Vector3 temp = startPoint;
            startPoint = endPoint;
            endPoint = temp;
            startTime = Time.time;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            Vector3 pushDirection = other.transform.position - transform.position;
            pushDirection.Normalize();
            rb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
    }
}


