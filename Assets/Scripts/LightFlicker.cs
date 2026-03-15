using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour
{
    public GameObject darkness;
    public GameObject toolLight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            darkness.SetActive(false);
            toolLight.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
