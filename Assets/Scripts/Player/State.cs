using UnityEngine;

public class State : MonoBehaviour
{
    public static State instance;

    private Parameters _parameters;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        _parameters = GetComponent<Parameters>();
    }

    private void Update()
    {
        if (_parameters.health <= 0)
        {
            Dead();
        }
    }

    public void CubeBuff()
    {
        if (_parameters.cubeSide == 1)
        {
            _parameters.health -= 1;
            Debug.Log("Isaac health = " + _parameters.health);
        }

        else if (_parameters.cubeSide == 2)
        {
            _parameters.moveSpeed -= 3;
        }
        
        else if (_parameters.cubeSide == 3)
        {
            _parameters.moveSpeed += 3;
        }
        
        else if (_parameters.cubeSide == 4)
        {
            if (_parameters.health < 5)
            {
                _parameters.health += 1;
            }
            Debug.Log("Isaac health = " + _parameters.health);
        }
        
        else if (_parameters.cubeSide == 5)
        {
            _parameters.attackSpeed -= 0.2f;
            _parameters.projectileSpeed += 3;
        }
   
        else if (_parameters.cubeSide == 6)
        {
            if (_parameters.health < 5)
            {
                _parameters.health += 1;
            }

            _parameters.moveSpeed += 3;
            _parameters.attackSpeed -= 0.2f;
            _parameters.projectileSpeed += 3;
        }
    }

    public void CubeBuffDecline()
    {
        if (_parameters.cubeSide == 2)
        {
            _parameters.moveSpeed += 3;
        }

        else if (_parameters.cubeSide == 3)
        {
            _parameters.moveSpeed -= 3;
        }

        else if (_parameters.cubeSide == 5)
        {
            _parameters.attackSpeed += 0.2f;
            _parameters.projectileSpeed -= 3;
        }

        else if (_parameters.cubeSide == 6)
        {
            _parameters.moveSpeed -= 3;
            _parameters.attackSpeed += 0.2f;
            _parameters.projectileSpeed -= 3;
        }
    }

    private void Dead()
    {
        Debug.Log("ISAAC IS DEAD");
    }
}
