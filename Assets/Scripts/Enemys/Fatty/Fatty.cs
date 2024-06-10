using UnityEngine;

public class Fatty : Enemy
{
    [SerializeField] private GameObject _head;
    [SerializeField] private GameObject _body;

    private Animator _bodyAnim;
    private Animator _headAnim;

    private SpriteRenderer _headRenderer;
    private SpriteRenderer _bodyRenderer;

    protected bool _trigger = false;

    protected override void OnTriggerStay2D(Collider2D other)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _trigger = true;
            _bodyAnim.SetBool("Move", false);
            _headAnim.SetBool("Attack", true);
            _bodyAnim.SetBool("Attack", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _trigger = false;
        }
    }

    private void Awake()
    {
        _bodyAnim = _body.GetComponent<Animator>();
        _headAnim = _body.GetComponent<Animator>();

        _headRenderer = _head.GetComponent<SpriteRenderer>();
        _bodyRenderer = _body.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        if (health <= 0)
        {
            _active = false;
            Die();
        }
    }

    protected override void Move()
    {
        if (_active)
        {
            base.Move();

            if (_charge == true && _trigger == false)
            {
                if (_player.transform.position.x < transform.position.x)
                {
                    _headRenderer.flipX = true;
                    _bodyRenderer.flipX = true;
                }
                else
                {
                    _headRenderer.flipX = false;
                    _bodyRenderer.flipX = false;
                }

                _bodyAnim.SetBool("Move", true);
            }

            else _bodyAnim.SetBool("Move", false);
        }

        else _bodyAnim.SetBool("Move", false);
    }
}
