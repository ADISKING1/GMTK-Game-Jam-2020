using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Celestials;

    public float moveSpeed;

    public float time;
    public float destroyTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Creator(time));
    }

    IEnumerator Creator (float time)
    {
        GameObject Celestial = Instantiate(Celestials[Random.Range(0, Celestials.Length)], transform.position, Quaternion.identity);

        Celestial.GetComponent<FlyTowards>().moveSpeed = moveSpeed;


        yield return new WaitForSeconds(time);
        Respawner(time);

        yield return new WaitForSeconds(destroyTime);
        Destroy(Celestial);
    }

    void Respawner(float time)
    {
        if (time >= 2)
            time -= 0.05f;
        moveSpeed += 0.3f;
        StartCoroutine(Creator(time));
    }
}
