using UnityEngine;

public class AscensorBaja : MonoBehaviour
{
    public GameObject ascensorBajaTrigger;

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
            ascensorBajaTrigger.SetActive(true);
        }
    }
}
