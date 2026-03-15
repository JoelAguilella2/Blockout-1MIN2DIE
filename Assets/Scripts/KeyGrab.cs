using UnityEngine;
using System.Collections;

public class KeyGrab : MonoBehaviour
{
    public GameObject keyPlayer;
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
            keyPlayer.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
