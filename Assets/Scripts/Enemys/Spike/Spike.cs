using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private GameObject _thorn;

    private void ActiveThorn()
    {
        _thorn.SetActive(true);
    }

    private void DeactiveThorn()
    {
        _thorn.SetActive(false);
    }
}
