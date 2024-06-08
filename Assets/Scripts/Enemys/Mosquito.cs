using UnityEngine;

public class Mosquito : Enemy
{
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        if (_health <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        base.Die();
    }


    public override void Move()
    {
        if (_active == true)
        {
            base.Move();
            if (_charge == true)
            {
                if (_player.transform.position.x < transform.position.x)
                {
                    _spriteRenderer.flipX = true;
                }
                else
                {
                    _spriteRenderer.flipX = false;
                }
            }
        } 
    }
}
