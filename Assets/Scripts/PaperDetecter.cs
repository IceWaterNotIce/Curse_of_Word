using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperDetecter : MonoBehaviour
{

    // player object
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // get all paper objects in the scene
        GameObject[] papers = GameObject.FindGameObjectsWithTag("Paper");
        if (papers.Length == 0)
        {
            // set visibility to false if there is no paper in the scene
            GetComponent<Renderer>().enabled = false;
            return;
        }
        // set visibility to true if there is paper in the scene
        GetComponent<Renderer>().enabled = true;
        // find the paper that is closest to the player
        GameObject closestPaper = null;
        float closestDistance = Mathf.Infinity;
        foreach (GameObject paper in papers)
        {
            float distance = Vector3.Distance(paper.transform.position, player.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPaper = paper;
            }
        }
        //get the direction to the closest paper
        Vector3 direction = closestPaper.transform.position - player.transform.position;
        // show this object in the direction of the closest paper, near the player
        transform.position = player.transform.position + direction.normalized * 2;

        
    }
}
