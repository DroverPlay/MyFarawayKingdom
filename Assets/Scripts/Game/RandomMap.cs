using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMap : MonoBehaviour
{
    [Header("Карты")]
    //[SerializeField] private GameObject _map1;
    //[SerializeField] private GameObject _map2;
    //[SerializeField] private GameObject _map3;
    [SerializeField] private List<GameObject> _map;

    void Start()
    {
        int rnd = Random.Range(0, _map.Count);

        _map[rnd].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
