using UnityEngine;

public class Pterodactyl : MonoBehaviour
{
    public float speed; 

    private new Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void OnEnable ()
    {
        rigidbody.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }
}
