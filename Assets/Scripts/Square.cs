using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    private void OnEnable()
    {
        float x = Random.Range(-3f, 3f);
        transform.position = new Vector3(x, 3, 0);

        float size = Random.Range(0.5f, 1.5f);
        transform.localScale = new Vector3(size, size, 1);
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -5f)
        {
            Destroy(this.gameObject, .5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Balloon")
        {
            GameManager.I.GameOver();
        }
    }
}
