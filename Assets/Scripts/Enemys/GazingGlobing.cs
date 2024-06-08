using System.Collections;
using UnityEngine;

public class GazingGlobing : Enemy
{
    [SerializeField] private GameObject _head;
    [SerializeField] private GameObject _body;

    private Animator _bodyAnim;

    private SpriteRenderer _headRenderer;
    private SpriteRenderer _bodyRenderer;

    private void Awake()
    {
        _bodyAnim = _body.GetComponent<Animator>();

        _headRenderer = _head.GetComponent<SpriteRenderer>();
        _bodyRenderer = _body.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        if (_health <= 0)
        {
            _active = false;
            StartCoroutine(DieAnimation());
        }
    }

    private IEnumerator DieAnimation()
    {
        _bodyAnim.SetBool("Die", true);

        yield return new WaitForSeconds(0.2f);

        _head.SetActive(false);

        yield return new WaitForSeconds(0.6f);

        Die();
    }

    public override void Die()
    {
        base.Die();
    }

    public override void Move()
    {
        if (_active)
        {
            base.Move();

            if (_charge == true)
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