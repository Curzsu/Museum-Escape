using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public AudioClip pickupSound;
    public AudioClip destroySound;
    public GameObject pickupEffect;
    public GameObject destroyEffect;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 播放拾取音效
            audioSource.PlayOneShot(pickupSound);

            // 播放拾取特效
            Instantiate(pickupEffect, transform.position, Quaternion.identity);

            // 销毁物体
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        // 播放销毁音效
        AudioSource.PlayClipAtPoint(destroySound, transform.position);

        // 播放销毁特效
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
    }
}