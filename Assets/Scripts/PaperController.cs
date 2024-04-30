using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if the distance between player and paper > 100, destroy paper
        if (Vector3.Distance(transform.position, GameObject.Find("Player").transform.position) > 100)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //repeat 10 times
            for (int i = 0; i < 10; i++)
            {
                //add a random character to txtPaper text
                GameObject.Find("canvasUI").GetComponent<UIController>().addKeyText();
            }
            //destroy paper
            Destroy(gameObject);
        }
    }
}
