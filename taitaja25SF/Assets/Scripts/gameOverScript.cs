using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameOverScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("lvl1");
    }
}
