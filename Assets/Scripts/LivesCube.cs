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
        //�������� �����
        health_cub = Random.Range(10, 50);
        _hpSlider.maxValue = health_cub;
        _textHP.text= $"{health_cub}";
    }

    // Update is called once per frame
    void Update()
    {
        _hpSlider.value = health_cub;
        _textHP.text = $"{health_cub}";
        //����������� ����� �� ��������
        if (_this !=null)
        {
            Destroy(_this, 30);
        }
        //����������� ����� ��� �������
        if (health_cub<=0)
        {
            Destroy(_this);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        //���������� �������� ����� ��� �������
        if (collision.gameObject.tag=="Player")
        {
            health_cub -= 1;
            //������� ������ (������� ����)
            Lose.GetComponent<ParticleSystem>().Play();
        }
    }

}
