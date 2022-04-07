using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void Level0()
    {
        SceneManager.LoadScene("Level0");
    }
    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Boss()
    {
        SceneManager.LoadScene("Boss");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
