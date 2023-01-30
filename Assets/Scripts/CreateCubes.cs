using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCubes : MonoBehaviour
{
    [SerializeField] private GameObject[] _cubes;
    [SerializeField] private GameObject _road;
    private GameObject _obj;
    private int random;
    private int random2;
    private Vector3 coord;
    private Vector3 coor;
    public Game _game;

    // Start is called before the first frame update
    void Start()
    {
        //создание блоков
        random2 = _game.Random1(5);
        //создание 1 блока
        if (random2 == 1)
        {
            random = _game.Random1(4);
            _obj = _cubes[random];
            coor = _road.transform.localPosition;
            coord.x = coor.x +5;
            coord.y = coor.y + 9;
            coord.z = coor.z -random;
            Instantiate(_obj, coord, Quaternion.identity);
        }
        //создание 2 блоков
        if (random2 == 2)
        {
            for (int i = 0; i < 2; i++)
            {
                random = _game.Random1(5);
                _obj = _cubes[random];
                coor = _road.transform.localPosition;
                coord.x = coor.x + 5;
                coord.y = coor.y + 9;
                coord.z = coor.z-i*2+2.3f;
                Instantiate(_obj, coord, Quaternion.identity);
            }
        }
        //создание 3 блоков
        if (random2 == 3)
        {
            for (int i = 0; i < 3; i++)
            {
                random = _game.Random1(5);
                _obj = _cubes[random];
                coor = _road.transform.localPosition;
                coord.x = coor.x + 5;
                coord.y = coor.y + 9;
                coord.z = coor.z-i*2+2.3f;
                Instantiate(_obj, coord, Quaternion.identity);
            }
        }
        //создание 4 блоков
        if (random2 == 4)
        {
            for (int i = 0; i < 4; i++)
            {
                random = _game.Random1(6);
                _obj = _cubes[random];
                coor = _road.transform.localPosition;
                coord.x = coor.x + 5;
                coord.y = coor.y + 9;
                coord.z = coor.z-i*2+2.3f;
                Instantiate(_obj, coord, Quaternion.identity);
            }
        }
    }
}
