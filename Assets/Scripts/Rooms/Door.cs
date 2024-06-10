using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform _thisRoomPosition;
    [SerializeField] private GameObject[] _rooms;
    [SerializeField] private Transform _exit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Camera camera = Camera.main;

            if (_exit.GetComponent<CheckRoomCreated>().roomCreated == false)
            {
                CreateRoom();
            }

            if (transform.position.y < _exit.position.y)
            {
                collision.transform.position = new Vector2(collision.transform.position.x, _exit.position.y);

                camera.GetComponent<CameraMovement>().MoveUp();
            }
            else
            {
                if (transform.position.x < _exit.transform.position.x)
                {
                    camera.GetComponent<CameraMovement>().MoveRight();
                }
                else if (transform.position.x > _exit.transform.position.x)
                {
                    camera.GetComponent<CameraMovement>().MoveLeft();
                }

                collision.transform.position = new Vector2(_exit.position.x, collision.transform.position.y);
            }
        }
    }

    private void CreateRoom()
    {
        if (transform.position.x > _exit.transform.position.x)
        {
            Vector2 createPosition = new Vector2(_thisRoomPosition.position.x - 18.8f, _thisRoomPosition.position.y);
            Instantiate(_rooms[Random.Range(0, _rooms.Length)], createPosition, Quaternion.identity);
        }
        else if (transform.position.x < _exit.transform.position.x)
        {
            Vector2 createPosition = new Vector2(_thisRoomPosition.position.x + 18.8f, _thisRoomPosition.position.y);
            Instantiate(_rooms[Random.Range(0, _rooms.Length)], createPosition, Quaternion.identity);
        }
        else if (transform.position.y < _exit.transform.position.y)
        {
            Vector2 createPosition = new Vector2(_thisRoomPosition.position.x, _thisRoomPosition.position.y + 10.8f);
            Instantiate(_rooms[Random.Range(0, _rooms.Length)], createPosition, Quaternion.identity);
        }
    }
}
