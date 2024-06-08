using UnityEngine;

public class GazingoDeadAnimation : MonoBehaviour
{
    [SerializeField] private GameObject _head;

    private void HideHead()
    {
        _head.SetActive(false);
    }
}
