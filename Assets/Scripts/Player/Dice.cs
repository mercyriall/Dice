using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] private float _recharge = 1f;
    [SerializeField] private GameObject _cube;

    private Animator _animator;
    private Parameters _parameters;

    private bool _shuffle = true;

    private float _time;

    private void Awake()
    {
        _animator = _cube.GetComponent<Animator>();
        _parameters = GetComponent<Parameters>();
    }


    private void Update()
    {
        if ((_time += Time.deltaTime) > _recharge)
        {
            if (Input.GetKeyDown(KeyCode.Q) && _shuffle == true)
            {
                _time = 0.0f;

                _parameters.cubeSide = Random.Range(1, 7);
                State.instance.CubeBuff();  // важно ставить после присвоения стороны кубика

                _shuffle = false;

                _animator.SetBool("Shuffle", _shuffle);
                _animator.SetInteger("CubeFace", _parameters.cubeSide);
            }
            else if (Input.GetKeyDown(KeyCode.Q) && _shuffle == false)
            {
                _time = 0.0f;

                State.instance.CubeBuffDecline(); // важно ставить до сброса стороны кубика

                _parameters.cubeSide = 0;
                _shuffle = true;

                _animator.SetBool("Shuffle", _shuffle);
                _animator.SetInteger("CubeFace", _parameters.cubeSide);
            }
        }
    }

    public void ShuffleCube()
    {
        if (_shuffle != true)
        {
            _time = 0.0f;

            State.instance.CubeBuffDecline(); // важно ставить до сброса стороны кубика

            _parameters.cubeSide = 0;
            _shuffle = true;

            _animator.SetBool("Shuffle", _shuffle);
            _animator.SetInteger("CubeFace", _parameters.cubeSide);
        }
    }
}
