using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buster : MonoBehaviour
{
    //public ParticleSystem LE;
    //public ParticleSystem LEf;
    //public ParticleSystem RE;
    //public ParticleSystem REf;
    //public ParticleSystem RVf;
    //public ParticleSystem LVf;
    //public ParticleSystem E;


    public GameObject[] Particles;

    public Movement m;

    public float time = 5f;
    public float blastCooldown = 1f;

    public AudioSource audioSource;

    public AudioClip Busted;
    public AudioClip Fixed;

    // Start is called before the first frame update
    void Start()
    {
        Init();

        m = GetComponent<Movement>();

        StartCoroutine(Starter());

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    IEnumerator Starter()
    {
        yield return new WaitForSeconds(10f);
        StartCoroutine(BusterTimer(time));
    }

    IEnumerator BusterTimer(float time)
    {
        m.currentlyBusted = (Movement.Busted)Random.Range(0, 3);
        
        switch (m.currentlyBusted)
        {
            default:
                Debug.Log("def");
                break;

            case Movement.Busted.R:
                Particles[0].SetActive(true);
                yield return new WaitForSeconds(blastCooldown);
                Particles[1].SetActive(false);
                Particles[3].SetActive(true);
                break;

            case Movement.Busted.L:
                Particles[0].SetActive(true);
                yield return new WaitForSeconds(blastCooldown);
                Particles[2].SetActive(false);
                Particles[4].SetActive(true);
                break;

            case Movement.Busted.V:
                Particles[0].SetActive(true);
                yield return new WaitForSeconds(blastCooldown);
                Particles[1].SetActive(false);
                Particles[2].SetActive(false);
                Particles[5].SetActive(true);
                Particles[6].SetActive(true);
                break;
        }
        audioSource.PlayOneShot(Busted, 1);

        yield return new WaitForSeconds(time);

        Init();
        audioSource.PlayOneShot(Fixed, 0.5f);
        StartCoroutine(BusterTimer(time));
    }

    public void Init()
    {
        foreach (GameObject p in Particles)
        {
            p.SetActive(false);
        }
        Particles[1].SetActive(true);
        Particles[2].SetActive(true);
    }
}
