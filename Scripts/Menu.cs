using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject canvas;
    public GameObject NasilOynanirButton;
    public GameObject cancelButton;
    public GameObject textBack;
    public GameObject nasilOynanirText;
    public GameObject Credit1;
    public GameObject Credit2;
    public GameObject Credit3;
    public GameObject oyunYukleniyorYazisi;
    void Start()
    {
        oyunYukleniyorYazisi.SetActive(false);
    }
    public void PlayButton()
    {   // Play butonuna tıklandığında 1. Sahneye (Oynanış sahnesine) gidilsin.
        SceneManager.LoadScene(1);
        oyunYukleniyorYazisi.SetActive(true);
    }
    public void MenuButton()
    {   // Menu butonuna tıklandığında 0. Sahneye (Ana menüye) gidilsin.
        SceneManager.LoadScene(0);
    }

    public void QuitButton()
    {   // Quit butonuna tıklandığında oyundan çıkılsın.
        Application.Quit();
    }
    public void NasilOynanir()
    {
        canvas.SetActive(false);
        NasilOynanirButton.SetActive(false);
        cancelButton.SetActive(true);
        textBack.SetActive(true);
        nasilOynanirText.SetActive(true);
        Credit1.SetActive(true);
        Credit2.SetActive(true);
        Credit3.SetActive(true);
    }
    public void Cancel()
    {
        NasilOynanirButton.SetActive(true);
        cancelButton.SetActive(false);
        textBack.SetActive(false);
        nasilOynanirText.SetActive(false);
        canvas.SetActive(true);
        Credit1.SetActive(false);
        Credit2.SetActive(false);
        Credit3.SetActive(false);
    }
}
