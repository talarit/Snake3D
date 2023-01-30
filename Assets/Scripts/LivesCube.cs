using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesCube : MonoBehaviour
{
    private int health_cub;
    [SerializeField] GameObject _this;
    [SerializeField] private Slider _hpSlider;
    [SerializeField] private Text _textHP;
    [SerializeField] private GameObject Lose;
    // Start is called before the first frame update
    void Start()
    {
        //здоровье блока
        health_cub = Random.Range(10, 50);
        _hpSlider.maxValue = health_cub;
        _textHP.text= $"{health_cub}";
    }

    // Update is called once per frame
    void Update()
    {
        _hpSlider.value = health_cub;
        _textHP.text = $"{health_cub}";
        //уничтожение блока со временем
        if (_this !=null)
        {
            Destroy(_this, 30);
        }
        //уничтожение блока при касании
        if (health_cub<=0)
        {
            Destroy(_this);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        //уменьшение здоровья блока при касании
        if (collision.gameObject.tag=="Player")
        {
            health_cub -= 1;
            //система частиц (осколки куба)
            Lose.GetComponent<ParticleSystem>().Play();
        }
    }

}
