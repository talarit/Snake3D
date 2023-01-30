using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonRestart : MonoBehaviour
{
    [SerializeField] MenuUI _menu;
    public void StartButton()
    {
        //кнопка заново
        SceneManager.LoadScene("SampleScene");
        _menu.Resume();
    }
    public void StartButton1()
    {
        //кнопка далее
        _menu.Resume2();
    }
}
