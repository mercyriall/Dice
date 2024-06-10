using UnityEngine;

public class Fart : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _parent;

    private float _recharge = 1f;
    private float _time = 0f;

    private void OnTriggerStay2D(Collider2D collision)
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

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void CancelAttack()
    {
        _parent.SetActive(false);

        FartAttack.instance.CancelAttack();
    }
}
