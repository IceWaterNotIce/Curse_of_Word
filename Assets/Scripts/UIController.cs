using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.TextCore.Text;
using Unity.VisualScripting;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    // txtmeshpro object list for key ( A-Z )


    [Header("UI")]
    [SerializeField] private GameObject SettingPanel;
    //tmp btn
    [SerializeField] private Button btnContinue;
    [SerializeField] private TextMeshProUGUI txtPaper;
    [SerializeField] private TextMeshProUGUI txtSaveGame;
    public TMP_InputField inputField;
    public List<TMP_Text> keyTexts;

    [Header("Font")]
    public TMP_FontAsset fontGeneral;
    public TMP_FontAsset fontKeyPressed;

    [Header("Time")]
    public float timeToResetFont = 0.1f;


    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

        for (int i = 0; i < keyTexts.Count; i++)
        {
            if (inputField.text.ToLower() == keyTexts[i].text.ToLower())
            {
                keyTexts[i].font = fontKeyPressed;
                //set a clock to reset the font
                StartCoroutine(ResetFont(keyTexts[i]));
            }
        }
    }
    IEnumerator ResetFont(TMP_Text text)
    {
        yield return new WaitForSeconds(timeToResetFont);
        text.font = fontGeneral;
    }
    void LateUpdate()
    {
        // clear all content in field
        inputField.text = "";
    }

    public void addKeyText()
    {
        // random [a-z] character and add to txtPaper text
        txtPaper.text += (char)('a' + Random.Range(0, 26));
    }
}
