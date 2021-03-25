using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void Update()
    {
        if(transform.position.x < -10)
        {
            gameObject.SetActive(false);
        }    
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.left * GameManager.GameSpeed * Time.fixedDeltaTime);
    }
}
