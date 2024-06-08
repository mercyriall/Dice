using System.Collections.Generic;
using UnityEngine;

public class ActivateRoom : MonoBehaviour
{
    private bool _playerOnRoom = false;
    private List<Enemy> _enemys = new List<Enemy>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _playerOnRoom = true;

            ActivateEnemys();
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            _enemys.Add(collision.gameObject.GetComponent<Enemy>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _playerOnRoom = false;

            DeactivateEnemys();
        }
    }

    private void ActivateEnemys()
    {
        foreach (var enemy in _enemys)
        {
            if (enemy != null)
            {
                enemy.instance.active = true;
            }
        }
    }

    private void DeactivateEnemys()
    {
        foreach (var enemy in _enemys)
        {
            if (enemy != null)
            {
                enemy.instance.active = false;
            }
        }
    }
}
