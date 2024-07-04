using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPrefsController : MonoBehaviour
{

    //input field for whitespace symbol
    public TMP_InputField inputShitespaceSymbol;
    // Start is called before the first frame update
    void Start()
    {
        inputShitespaceSymbol.text = PlayerPrefs.GetString("WhitespaceSymbol", " ");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetWhitespaceSymbol(string symbol)
    {
        PlayerPrefs.SetString("WhitespaceSymbol", symbol);
        PlayerPrefs.Save();
    }


}
