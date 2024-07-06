using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class txtPaperController : MonoBehaviour
{

    public DataController dataController;
    public GameObject Player;
    public string[] textList;

    // Start is called before the first frame update
    void Start()
    {

    }      

    // Update is called once per frame
    void Update()
    {
        // if player type the first letter of txtPaper text, remove the first letter
        if (Input.anyKeyDown)
        {
            if (Input.inputString.Length == 0)
            {
                return;
            }
            if (GetComponent<TextMeshProUGUI>().text.Length > 0)
            {
                string WhitespaceSymbol = PlayerPrefs.GetString("WhitespaceSymbol", " ");
                if (GetComponent<TextMeshProUGUI>().text[0] == Input.inputString[0] && GetComponent<TextMeshProUGUI>().text[0] != WhitespaceSymbol[0])
                {
                    GetComponent<TextMeshProUGUI>().text = GetComponent<TextMeshProUGUI>().text.Substring(1);
                    //create bullet
                    Player.GetComponent<PlayerController>().Shoot();
                    return;
                }
                if (Input.inputString[0] == ' ' && GetComponent<TextMeshProUGUI>().text[0] == WhitespaceSymbol[0])
                {
                    GetComponent<TextMeshProUGUI>().text = GetComponent<TextMeshProUGUI>().text.Substring(1);
                    //create bullet
                    Player.GetComponent<PlayerController>().Shoot();
                }
            }
        }
    }

    public void AddPaperContent()
    {
        // get all the words from data controller
        string[] words = dataController.GetWords();
        //randomly select 5 words
        string[] selectedWords = new string[5];
        for (int i = 0; i < 5; i++)
        {
            selectedWords[i] = words[Random.Range(0, words.Length)];
        }
        //add these words to txtPaper
        string WhitespaceSymbol = PlayerPrefs.GetString("WhitespaceSymbol", " ");
        if (GetComponent<TextMeshProUGUI>().text == "")
        {
            GetComponent<TextMeshProUGUI>().text = string.Join(WhitespaceSymbol, selectedWords);
        }
        else
        {
            GetComponent<TextMeshProUGUI>().text += WhitespaceSymbol + string.Join(WhitespaceSymbol, selectedWords);
        }
    }
}
