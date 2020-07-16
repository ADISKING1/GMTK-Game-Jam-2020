using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public enum GameStates {Playing, GameOver};

    public GameStates gs;

    public GameObject gameOver;
    public GameObject player;
    public GameObject deathEffect;

    public Score score;

    public AudioSource audioSource;

    public AudioClip Destroyed;

    // Start is called before the first frame update
    void Start()
    {
        gs = GameStates.Playing;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reloader(0));
        }
    }

    public void SetGameOver()
    {
        gs = GameStates.GameOver;

        Instantiate(deathEffect, player.transform.position, player.transform.rotation);
        player.SetActive(false);

        score.playing = false;

        audioSource.PlayOneShot(Destroyed, 1);
        gameOver.SetActive(true);

        StartCoroutine(Reloader(5));
    }

    public IEnumerator Reloader(float time)
    {
        yield return new WaitForSeconds(time);
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
}
