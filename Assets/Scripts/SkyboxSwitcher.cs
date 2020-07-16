using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxSwitcher : MonoBehaviour
{
    public GameObject[] skyboxes;

    public float time = 5;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeSkybox(time));
    }

    // Update is called once per frame
    IEnumerator ChangeSkybox(float time)
    {

        foreach (GameObject skybox in skyboxes)
        {
            skybox.SetActive(false);
        }

        skyboxes[Random.Range(0, 7)].SetActive(true);

        yield return new WaitForSeconds(time);
        StartCoroutine(ChangeSkybox(time));
    }
}
