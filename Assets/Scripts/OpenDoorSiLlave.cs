using UnityEngine;
using System.Collections;

public class OpenDoorSiLlave : MonoBehaviour
{
    public GameObject Puerta2;
    public GameObject Puerta1;

    public GameObject Llave;
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
        if(other.gameObject.tag == "Player" && Llave.activeSelf)
        {
            Puerta1.SetActive(false);
            Puerta2.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Puerta1.SetActive(true);
            Puerta2.SetActive(false);
        }
    }
}
