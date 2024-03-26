using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigateTo : MonoBehaviour
{
    public void LoadScene(String LevelName){
        SceneManager.LoadScene(LevelName);
    }
}
