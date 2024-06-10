using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Enemy instance;

    [SerializeField] protected int _health = 3;
    [SerializeField] protected float _movementSpeed = 3;
    [SerializeField] protected float _recharge = 1f;
    [SerializeField] protected float _triggerRange = 200f;

    protected GameObject _player;
    private Rigidbody2D _rb;

    protected float _time = 0f;
    protected bool _charge = false;
    protected bool _active = false;

    public bool active { get { return _active; } set { _active = value; } }
    public bool charge { get { return _charge; } set { _charge = value; } }

    public int health { get { return _health; } set {  _health = value; } }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if ((_time += Time.deltaTime) > _recharge)
            {
                _time = 0;

                Parameters pp = collision.gameObject.GetComponentInParent<Parameters>();
                pp.health -= 1;
                Debug.Log(pp.health);
                collision.gameObject.GetComponentInParent<Dice>().ShuffleCube();

                StartCoroutine(collision.gameObject.GetComponentInParent<State>().GetDamage());
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

        else if (collision.gameObject.tag == "Player")
        {
            Parameters pp = collision.gameObject.GetComponentInParent<Parameters>();
            pp.health -= 1;
            Debug.Log(pp.health);
            collision.gameObject.GetComponentInParent<Dice>().ShuffleCube();

            StartCoroutine(collision.gameObject.GetComponentInParent<State>().GetDamage());
        }
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        if (instance == null)
        {
            instance = this;
        }
    }

    protected virtual void Move()
    {
        {
            _player = GameObject.FindGameObjectWithTag("Player");

            Vector3 distaceVector = _player.transform.position - transform.position;


            if (distaceVector.sqrMagnitude < _triggerRange)
            {
                _charge = true;

                if (transform.position != _player.transform.position)
                {
                    _rb.MovePosition(transform.position + (distaceVector * _movementSpeed / 2 * Time.deltaTime));
                }
            }
            else
            {
                _charge = false;
            }
        }
    }

    public IEnumerator GetDamage()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(255f, 0f, 0f, 255f);

        yield return new WaitForSeconds(0.2f);

        this.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
    }

    protected virtual void Die()
    {
        Destroy(this.gameObject);
    }
}
