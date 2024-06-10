using UnityEngine;

public class FartAttack : MonoBehaviour
{
    public static FartAttack instance;

    [SerializeField] private GameObject _attack;
    [SerializeField] private Enemy _enemy;

    [SerializeField] private Animator _head;
    [SerializeField] private Animator _body;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Fart()
    {
        _attack.SetActive(true);
    }

    public void CancelAttack()
    {
        _head.SetBool("Attack", false);
        _body.SetBool("Attack", false);
        _body.SetBool("Move", true);
    }
}
