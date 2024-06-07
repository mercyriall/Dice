using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Animator _headAnimation;
    [SerializeField] private SpriteRenderer _headSprite;
    
    [SerializeField] private Animator _bodyAnimation;
    [SerializeField] private SpriteRenderer _bodySprite;

    private CharacterController _characterController;
    private Parameters _parameters;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _parameters = GetComponent<Parameters>();
    }

    private void FixedUpdate()
    {
        Vector2 move = TakeDirection();

        OnAnimation(move);

        _characterController.Move(move * Time.deltaTime * _parameters.moveSpeed);
    }

    private void OnAnimation(Vector2 move)
    {
        if (move == new Vector2(0, 0))
        {
            //down
            _headAnimation.SetInteger("DirectionX", 0);
            _headAnimation.SetInteger("DirectionY", 0);

            _bodyAnimation.SetInteger("DirectionX", 0);
            _bodyAnimation.SetInteger("DirectionY", 0);
        }
        else if (move == new Vector2(1, 0) || move == new Vector2(-1, 0))
        {
            //side
            _headAnimation.SetInteger("DirectionX", 1);
            _headAnimation.SetInteger("DirectionY", 0);

            _bodyAnimation.SetInteger("DirectionX", 1);
            _bodyAnimation.SetInteger("DirectionY", 0);

            if (move == new Vector2(-1, 0))
            {
                _headSprite.flipX = true;
                _bodySprite.flipX = true;
            }
            else
            {
                _headSprite.flipX = false;
                _bodySprite.flipX = false;
            }

        }
        else if (move == new Vector2(0, 1))
        {
            _headAnimation.SetInteger("DirectionX", 0);
            _headAnimation.SetInteger("DirectionY", 1);

            _bodyAnimation.SetInteger("DirectionX", 0);
            _bodyAnimation.SetInteger("DirectionY", 1);
        }
        else if (move == new Vector2(0, -1))
        {
            _headAnimation.SetInteger("DirectionX", 0);
            _headAnimation.SetInteger("DirectionY", 0);

            _bodyAnimation.SetInteger("DirectionX", 0);
            _bodyAnimation.SetInteger("DirectionY", -1);
        }
    }

    private Vector2 TakeDirection()
    {
        Vector2 move = new(0, 0);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.A))
            {
                move = new Vector2(-1, 0);
            }
            else
            {
                move = new Vector2(1, 0);
            }
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.W))
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
