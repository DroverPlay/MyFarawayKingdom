using UnityEngine;

public class PipeRandom : MonoBehaviour
{
    [Header("Настройки")]
    [SerializeField] private float _minHight = -3f;
    [SerializeField] private float _maxHight = 3f;
    [SerializeField] private float _range = 4f;
    [SerializeField] private float _maxTime = 1.5f;
    [SerializeField] private float _destroyTime = 10f;

    [SerializeField] GameObject Pipe;

    private float _timer;

    private void Update()
    {
        if (_timer > _maxTime)
        {
            CreateObj();
            _timer = 0;
        }
        _timer += Time.deltaTime;
    }
    private void CreateObj()
    {
        Vector3 spawn = transform.position + new Vector3(0, Random.Range(_minHight, _maxHight));
        GameObject newObj = Instantiate(Pipe, spawn, Quaternion.identity);

        Destroy(newObj, _destroyTime);
    }
}
