using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public void FirstLVL()
    {
        SceneManager.LoadScene("FirstLVL");
    }
    public void SecondLVL()
    {
        SceneManager.LoadScene("SecondLVL");
    }
}
