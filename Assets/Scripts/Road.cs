using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;

    void Update()
    {
        //уничтожение дороги через 35 секунд
        Destroy(_gameObject,35);

    }
}
