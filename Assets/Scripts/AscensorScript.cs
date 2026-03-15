using UnityEngine;
using System.Collections;

public class AscensorScript : MonoBehaviour
{
    public GameObject ascensor;

    public bool aSubir;

    public bool aBajar;

    public float timerPocoArriba;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aSubir = false;
        aBajar = false;
        timerPocoArriba = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(aSubir)
        {
            timerPocoArriba += Time.deltaTime;
            if(timerPocoArriba >= 0.1f)
            {
                timerPocoArriba = 0;
                ascensor.transform.position = new Vector3(ascensor.transform.position.x, ascensor.transform.position.y + 0.2f, ascensor.transform.position.z);
                if(ascensor.transform.position.y > 25.25f) aSubir = false;
            }
        }
        if(aBajar)
        {
            timerPocoArriba += Time.deltaTime;
            if(timerPocoArriba >= 0.1f)
            {
                timerPocoArriba = 0;
                ascensor.transform.position = new Vector3(ascensor.transform.position.x, ascensor.transform.position.y - 0.2f, ascensor.transform.position.z);
                if(ascensor.transform.position.y < 16f) aBajar = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            aSubir = true;
        }
    }
}
