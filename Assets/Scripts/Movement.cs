using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovementData
{
    [SerializeField] private float speed;
    [SerializeField] private float _speed2;

    public float Speed { get => speed; set => speed = value; }
    public float Speed2 { get => _speed2; set => _speed2 = value; }
}

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _transform;
    [SerializeField] private Camera _camera;
    [SerializeField] private Game _game;
    private MovementData Data =>Settings.I.MovementData;
    private Vector3 _direction;
    private Vector3 _velocity;

    void Update()
    {
        //управление влево и вправо с помощью клавиш
        if ((Input.GetKeyDown(KeyCode.A))|| (Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+0.2f);
        }
        if ((Input.GetKeyDown(KeyCode.D))|| (Input.GetKeyDown(KeyCode.RightArrow)))
        {
            this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.2f);
        }
        _velocity = new Vector3(Data.Speed2*_game.LevelIndex,0,_direction.z * Data.Speed);
    }
    //движение змейки
    private void FixedUpdate()
    {
        _rigidbody.velocity = _velocity;
    }
}
