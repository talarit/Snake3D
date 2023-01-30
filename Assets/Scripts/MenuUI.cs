using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuUI : MonoBehaviour
{
    public GameObject MenuUi;
    public GameObject MenuUi2;
    public bool res = false;
    [SerializeField] private Game _game;


    private void Awake()
    {
        Resume1();
    }

    public void Pause()
    {
        //меню игры заново
        MenuUi.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Pause2()
    {
        //меню игры далее
        MenuUi2.SetActive(true);
        Time.timeScale = 0f;
    }


    public void Resume()
    {
        //запуск уровня заново
        MenuUi.SetActive(false);
        MenuUi2.SetActive(false);
        Time.timeScale = 1f;
        _game.RestartGame();

    }
    public void Resume1()
    {
        //запуск уровня
        MenuUi.SetActive(false);
        MenuUi2.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Resume2()
    {
        //запуск уровня далее
        MenuUi.SetActive(false);
        MenuUi2.SetActive(false);
        Time.timeScale = 1f;
        res = true;
    }
}
