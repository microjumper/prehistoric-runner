using UnityEngine;

public class Scrollable : MonoBehaviour
{
    public float parallax;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.Translate(Vector2.left * GameManager.GameSpeed * parallax * Time.deltaTime);

        if (transform.position.x < -spriteRenderer.bounds.size.x)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        float offSet = spriteRenderer.bounds.size.x + spriteRenderer.bounds.size.x;

        transform.position = new Vector2(transform.position.x + offSet, transform.position.y);
    }
}
