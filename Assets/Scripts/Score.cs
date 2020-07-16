using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;

    public int scoreValue;

    public static int highScoreValue;

    public bool playing = true;

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        scoreValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            if (timer < 1)
            {
                timer += Time.deltaTime;
            }
            else
            {
                AddScore();
                timer = 0;
            }
        }
        else
        {
            if (scoreValue > highScoreValue)
                highScoreValue = scoreValue;
        }
        score.text = "Your Score: " + scoreValue + "\n" + "High Score: " + highScoreValue;
    }

    public void AddScore()
    {
        scoreValue += 1;
    }
}
