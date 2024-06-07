using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health = 3;
    [SerializeField] private float _movementSpeed = 3;
    [SerializeField] private float _recharge = 1f;
    [SerializeField] private float _triggerRange = 200f;

    private GameObject _player;
    private Rigidbody2D _rb;

    private float _time = 0f;

    public int health { get { return _health; } set {  _health = value; } }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if ((_time += Time.deltaTime) > _recharge)
            {
                _time = 0;

                Parameters pp = collision.gameObject.GetComponentInParent<Parameters>();
                pp.health -= 1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if (collision.gameObject.name == "Left")
            {
                transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y);
            }
            if (collision.gameObject.name == "Right")
            {
                transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y);
            }
            if (collision.gameObject.name == "Up")
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.2f);
            }
            if (collision.gameObject.name == "Down")
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.2f);
            }
        }
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        Vector3 distaceVector = _player.transform.position - transform.position;

        if (distaceVector.sqrMagnitude < _triggerRange)
        {
            if (transform.position != _player.transform.position)
            {
                _rb.MovePosition(transform.position + (distaceVector * _movementSpeed / 2 * Time.deltaTime));
            }
        }
    }

    private void Update()
    {
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
