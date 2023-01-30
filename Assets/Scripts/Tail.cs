using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _tail;
    private List<Transform> _snakeCircle = new List<Transform>();
    private List<Vector3> _position = new List<Vector3>();
    public float CircleDiametr;

    // Start is called before the first frame update
    void Start()
    {
        _position.Add(_head.position);   
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (_head.position - _position[0]).magnitude;
        if (distance>CircleDiametr)
        {
            Vector3 direction = (_head.position - _position[0]).normalized;
            _position.Insert(0, _position[0]+direction*CircleDiametr);
            _position.RemoveAt(_position.Count-1);
            distance -= CircleDiametr;
        }

        for (int i = 0; i<_snakeCircle.Count;i++) {
            _snakeCircle[i].position = Vector3.Lerp(_position[i + 1], _position[i], distance/CircleDiametr);
        }
    }
    public void AddCircle()
    {
        Transform circle = Instantiate (_tail, _position[_position.Count - 1], Quaternion.identity,transform);
        _snakeCircle.Add(circle);
        _position.Add(circle.position);
    }

    public void RemoveCircle()
    {
        Destroy(_snakeCircle[0].gameObject);
        _snakeCircle.RemoveAt(0);
        _position.RemoveAt(1);
    }
}
