using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public void MoveLeft()
    {
        transform.position = new Vector3(transform.position.x - 18.8f, transform.position.y, transform.position.z);
    }

    public void MoveRight()
    {
        transform.position = new Vector3(transform.position.x + 18.8f, transform.position.y, transform.position.z);
    }

    public void MoveUp()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 10.8f, transform.position.z);
    }
}

