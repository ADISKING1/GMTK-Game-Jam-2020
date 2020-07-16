using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float time = 3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destruct(time));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Object.Destroy(this.gameObject);
    }

    IEnumerator Destruct(float time)
    {
        yield return new WaitForSeconds(time);
        Object.Destroy(this.gameObject);
    }
}
