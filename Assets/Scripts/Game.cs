using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] Spawner _spawner;
    [SerializeField] GameObject _gameObject;
    public int score;
    public int health;
    [SerializeField] Text _texth;
    [SerializeField] Text _textscore;
    [SerializeField] Text _textlevel;
    [SerializeField] MenuUI _menuUI;
    private int counttail=0;
    [SerializeField] Tail _tail;
    public AudioClip audioClip;
    private AudioSource _audio;


    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _audio.Play();
        //�������� ���� �� ��������
        if (HealthIndex > 0)
        {
            score = CountIndex;
            health = HealthIndex;
        }
        else
       {
           RestartGame();
       }
    }
    
    private void OnTriggerEnter(Collider other)

    {
        //���������� ������
        if (other.CompareTag("road"))
        {
            _spawner.Spawn();
        }

        //������� �����
        if (other.CompareTag("breaked"))
        {
            _menuUI.Pause();
        }

    }
    private void OnCollisionStay(Collision collision)
    {
        //������� ����
        if (collision.gameObject.tag == "cubes")
        {
            health--;
            score++;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //������� ��� +10
        if (collision.gameObject.tag == "food")
        {
            //���� ���
            _audio.PlayOneShot(audioClip,10f);
            health += 10;
            
        }
        //������� ��� +25
        if (collision.gameObject.tag == "food2")
        {
            //���� ���
            _audio.PlayOneShot(audioClip,10f);
            health += 25;

        }
    }
    private void Update()
    {
        //����������� ������ �� ������
        _texth.text= $"{health}";
        _textscore.text = $"{score}";
        _textlevel.text = $"{LevelIndex}";
        //�������� 0
        if (health <= 0)
        {
            _menuUI.Pause();
        }

        //��� ��������� ����� 100 ����� - ����� �������
        if (score >= 100*LevelIndex)
        {
            HealthIndex = health;
            CountIndex = score;
            LevelIndex++;
            Reload2();
        }
        if(_menuUI.res)
        {
            Reload();
        }

        //���������� ������, �������� 5
        if ((health>100)&&(counttail==0))
        {
            _tail.AddCircle();
            counttail++;
        }
        if ((health < 100) && (counttail == 1))
        {
            _tail.RemoveCircle();
            counttail--;
        }
        if ((health > 200) && (counttail == 1))
        {
            _tail.AddCircle();
            counttail++;
        }
        if ((health < 200) && (counttail == 2))
        {
            _tail.RemoveCircle();
            counttail--;
        }
        if ((health > 300) && (counttail == 2))
        {
            _tail.AddCircle();
            counttail++;
        }
        if ((health < 300) && (counttail == 3))
        {
            _tail.RemoveCircle();
            counttail--;
        }
        if ((health > 400) && (counttail == 3))
        {
            _tail.AddCircle();
            counttail++;
        }
        if ((health < 400) && (counttail == 4))
        {
            _tail.RemoveCircle();
            counttail--;
        }
        if ((health > 400) && (counttail == 4))
        {
            _tail.AddCircle();
            counttail++;
        }
        if ((health < 500) && (counttail == 4))
        {
            _tail.RemoveCircle();
            counttail--;
        }
    }
    public int Random1(int random)
    {
        //������
        random = Random.Range(0, random);
        return random;
    }
    public int LevelIndex
    {
        //����������� �������� ������ �� ��������� �������
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);

        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }

    }



    public int HealthIndex
    {
        //����������� �������� �������� �� ��������� �������
        get => PlayerPrefs.GetInt(HealthIndexKey, 0);

        private set
        {
            PlayerPrefs.SetInt(HealthIndexKey, value);
            PlayerPrefs.Save();
        }

    }

    public int CountIndex
    {
        //����������� �������� ����� �� ��������� �������
        get => PlayerPrefs.GetInt(CountIndexKey, 0);

        set
        {
            PlayerPrefs.SetInt(CountIndexKey, value);
            PlayerPrefs.Save();
        }

    }

    private const string LevelIndexKey = "LevelIndex";
    private const string CountIndexKey = "CountIndex";
    private const string HealthIndexKey = "HealthIndex";


     private void Reload2()
    {
        //����� ����
        _menuUI.Pause2();
    } 

    private void Reload()
    {
        //����� �������
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartGame()
    {
        //��������� ��������
        LevelIndex = 1;
        health = 100;
        score = 0;
        HealthIndex = 0;
        CountIndex = 0;
    }

}
