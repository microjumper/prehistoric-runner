using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public Pickup[] pickups;

    private SpriteRenderer spriteRenderer;

    private Pickup pickup;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        pickup = pickups[Random.Range(0, pickups.Length)];
        spriteRenderer.sprite = pickup.sprite;
    }

    void Update()
    {
        transform.Translate(Vector2.left * GameManager.GameSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.UpdateScore(pickup.points);
            Disable();
        }

        if (collision.gameObject.CompareTag("Deactivator"))
        {
            Disable();
        }
    }

    private void Disable()
    {
        transform.position = transform.parent.position;
        gameObject.SetActive(false);
    }
}
