using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public GameObject Loading;

    // Update is called once per frame
    public void LoadSc()
    {
        Loading.SetActive(true);
        SceneManager.LoadScene(1);
    }
}
