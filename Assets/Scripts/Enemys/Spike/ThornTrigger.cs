using UnityEngine;

public class ThornTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponentInParent<Parameters>().health -= 1;
        }
    }
}
