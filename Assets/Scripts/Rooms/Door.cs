using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform _exit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (transform.position.y < _exit.position.y)
            {
                collision.transform.position = new Vector2(collision.transform.position.x, _exit.position.y);
            }
            else
            {
                collision.transform.position = new Vector2(_exit.position.x, collision.transform.position.y);
            }
        }
    }
}
