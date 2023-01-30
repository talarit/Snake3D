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
        //���� ���� ������
        MenuUi.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Pause2()
    {
        //���� ���� �����
        MenuUi2.SetActive(true);
        Time.timeScale = 0f;
    }


    public void Resume()
    {
        //������ ������ ������
        MenuUi.SetActive(false);
        MenuUi2.SetActive(false);
        Time.timeScale = 1f;
        _game.RestartGame();

    }
    public void Resume1()
    {
        //������ ������
        MenuUi.SetActive(false);
        MenuUi2.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Resume2()
    {
        //������ ������ �����
        MenuUi.SetActive(false);
        MenuUi2.SetActive(false);
        Time.timeScale = 1f;
        res = true;
    }
}
