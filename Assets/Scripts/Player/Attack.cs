using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private GameObject _spownPosition;

    private Parameters _parameters;
    private Rigidbody2D _projectileRb;
    private float _time;

    private void Awake()
    {
        _parameters = GetComponent<Parameters>();
    }

    private void FixedUpdate()
    {
        Vector2 move = TakeDirection();

        if ((_time += Time.deltaTime) > _parameters.attackSpeed)
        {
            if (move != new Vector2(0, 0))
            {
                _time = 0.0f;

                _projectileRb = Instantiate(_projectile, _spownPosition.transform.position, Quaternion.identity).gameObject.GetComponent<Rigidbody2D>();
                _projectileRb.velocity = move * _parameters.projectileSpeed;
            }
        }
    }

    private Vector2 TakeDirection()
    {
        Vector2 move = new(0, 0);

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                move = new Vector2(-1, 0);
            }
            else
            {
                move = new Vector2(1, 0);
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                move = new Vector2(0, 1);
            }
            else
            {
                move = new Vector2(0, -1);
            }
        }

        return move;
    } 
}
