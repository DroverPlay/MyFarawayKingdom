using UnityEngine;

public class PipeMoving : MonoBehaviour
{
    [Header("Настройки")]
    [SerializeField] private float _speedMoving;

    [SerializeField] private GameObject _parent;

    private void Update()
    {
        transform.position += Vector3.left * _speedMoving * Time.deltaTime;
    }
}
