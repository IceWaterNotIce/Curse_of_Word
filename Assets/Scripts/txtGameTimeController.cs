using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class txtGameTimeController : MonoBehaviour
{

    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float nowTime = Time.time;
        float gameTime = nowTime - startTime;
        // show as mm:ss
        GetComponent<TextMeshProUGUI>().text = string.Format("{0:00}:{1:00}", (int)gameTime / 60, (int)gameTime % 60);
    }
}
