using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    Rigidbody rd;
    gmanager gm;
    public int pointvalue = 5;
    public ParticleSystem p;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        rd.AddForce(Vector3.up * Random.Range(12, 16), ForceMode.Impulse);
        rd.AddTorque(Random.Range(-10,10), Random.Range(-10, 10), Random.Range(-10, 10),ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-4, 4), -6, 0);
        gm = GameObject.Find("GameManager").GetComponent<gmanager>();
    }

    void OnMouseDown()
    {
        if (gm.isplay)
        {
            gm.updateScore(pointvalue);
            Instantiate(p, transform.position, p.transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (!gameObject.CompareTag("bad"))
        {
            gm.gameover();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
