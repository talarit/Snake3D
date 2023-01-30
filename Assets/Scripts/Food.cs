using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] int HP;
    [SerializeField] GameObject _this;
 

    private void OnCollisionEnter (Collision collision)
    {
        //еду съели
        if (collision.gameObject.tag == "Player")
        {
            Destroy(_this);
        }
    }
}
