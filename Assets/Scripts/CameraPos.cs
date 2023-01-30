using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CameraPosData
{
    [SerializeField] private float _speed3;
    [SerializeField] private float offset = 3f;

    public float Speed3 { get => _speed3; set => _speed3 = value; }
    public float Offset { get => offset; set => offset = value; }
}
public class CameraPos : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private Transform _transform;
    private CameraPosData CameraData => Settings.I.CameraPosData;
    // Start is called before the first frame update

    private void Awake()
    {

        _transform = transform;


    }
    //движение камеры
    void FixedUpdate()
    {
        Vector3 vektor = new Vector3(_target.position.x - CameraData.Offset,_transform.position.y,_transform.position.z);
        _transform.position = Vector3.Lerp(_transform.position, vektor, CameraData.Speed3 * Time.deltaTime);
    }
}
