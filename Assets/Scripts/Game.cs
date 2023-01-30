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
        //проверка есть ли здоровье
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
        //добавление дороги
        if (other.CompareTag("road"))
        {
            _spawner.Spawn();
        }

        //касание стены
        if (other.CompareTag("breaked"))
        {
            _menuUI.Pause();
        }

    }
    private void OnCollisionStay(Collision collision)
    {
        //касание куба
        if (collision.gameObject.tag == "cubes")
        {
            health--;
            score++;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //касание еды +10
        if (collision.gameObject.tag == "food")
        {
            //звук еды
            _audio.PlayOneShot(audioClip,10f);
            health += 10;
            
        }
        //касание еды +25
        if (collision.gameObject.tag == "food2")
        {
            //звук еды
            _audio.PlayOneShot(audioClip,10f);
            health += 25;

        }
    }
    private void Update()
    {
        //отображение данных на экране
        _texth.text= $"{health}";
        _textscore.text = $"{score}";
        _textlevel.text = $"{LevelIndex}";
        //здоровье 0
        if (health <= 0)
        {
            _menuUI.Pause();
        }

        //при получении новых 100 очков - новый уровень
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

        //увеличение змейки, максимум 5
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
        //рандом
        random = Random.Range(0, random);
        return random;
    }
    public int LevelIndex
    {
        //сохраниение значения уровня на следующий уровень
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);

        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }

    }



    public int HealthIndex
    {
        //сохраниение значения здоровья на следующий уровень
        get => PlayerPrefs.GetInt(HealthIndexKey, 0);

        private set
        {
            PlayerPrefs.SetInt(HealthIndexKey, value);
            PlayerPrefs.Save();
        }

    }

    public int CountIndex
    {
        //сохраниение значения очков на следующий уровень
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
        //вызов меню
        _menuUI.Pause2();
    } 

    private void Reload()
    {
        //новый уровень
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartGame()
    {
        //обнуления значений
        LevelIndex = 1;
        health = 100;
        score = 0;
        HealthIndex = 0;
        CountIndex = 0;
    }

}
