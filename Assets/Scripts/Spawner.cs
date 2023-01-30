using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _roads;
    [SerializeField] private float _roadLength;
    private GameObject _road;
    // Start is called before the first frame update
    void Start()
    {
        //создание первой дороги
        Vector3 posit2 = new Vector3(20f, 0f, 0f);
        _road = Instantiate(_roads[Random.Range(0, 1)], posit2, Quaternion.identity);  
    }


    //создание дороги
    public void Spawn()
    {
        Vector3 posit = new Vector3((_road.transform.position.x + _roadLength), 0, 0);
        _road = Instantiate(_roads[Random.Range(0, 3)], posit, Quaternion.identity);
    }
}
