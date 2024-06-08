using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _destroyRange = 300f;

    private GameObject _spownPlace;

    private void Start()
    {
        _spownPlace = GameObject.FindGameObjectWithTag("ProjectileSpown");
    }

    private void Update()
    {
        Vector3 distaceVector = _spownPlace.transform.position - transform.position;

        if (distaceVector.sqrMagnitude > _destroyRange)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().GetDamage();
            collision.GetComponent<Enemy>().health -= 1;

            Destroy(this.gameObject);
        }
    }
}
