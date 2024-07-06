using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PaperController : MonoBehaviour
{

    private GameObject txtPaper;
    private DataController dataController;

    // Start is called before the first frame update
    void Start()
    {
        // 在運行時查找名為 "txtPaper" 的遊戲物件
        txtPaper = GameObject.Find("txtPaper");
        if (txtPaper == null)
        {
            Debug.LogError("txtPaper game object not found in the scene.");
        }
        // 在運行時查找名為 "DataController" 的遊戲物件
        dataController = GameObject.Find("DataController").GetComponent<DataController>();
        if (dataController == null)
        {
            Debug.LogError("DataController game object not found in the scene.");
        }
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
            //add paper content
            txtPaper.GetComponent<txtPaperController>().AddPaperContent();
            //destroy paper
            Destroy(gameObject);
        }
    }

    
}

