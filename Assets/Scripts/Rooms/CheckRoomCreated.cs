using UnityEngine;

public class CheckRoomCreated: MonoBehaviour
{
    public bool roomCreated;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            roomCreated = true;
        }
    }

    private void Awake()
    {
        roomCreated = false;
    }
}
