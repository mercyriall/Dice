using UnityEngine;

public class Parameters : MonoBehaviour
{
    [SerializeField] private int _health = 5;
    [SerializeField] private float _moveSpeed = 6f;
    [SerializeField] private float _attackSpeed = 0.5f;
    [SerializeField] private float _projectileSpeed = 7f;
    private int _cubeSide = 0;

    public int health { get { return _health; } set { _health = value; } }

    public float moveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }

    public float attackSpeed { get { return _attackSpeed; } set { _attackSpeed = value; } }

    public float projectileSpeed { get { return _projectileSpeed; } set { _projectileSpeed = value; } }

    public int cubeSide { get { return _cubeSide; } set { _cubeSide = value; } }
}
