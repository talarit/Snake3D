using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;

    void Update()
    {
        //����������� ������ ����� 35 ������
        Destroy(_gameObject,35);

    }
}
