using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.UI;
using Unity.VisualScripting;
public class UIController : MonoBehaviour
{
    // txtmeshpro object list for key ( A-Z )


    [Header("Setting Panel")]
    [SerializeField] private GameObject SettingPanel;
    [SerializeField] private Button btnSaveGame;
    [SerializeField] private Button btnExitGame;
    [SerializeField] private Button btnBackHome;
    [SerializeField] private Button btnContinue;

    [Header("Gaming UI")]
    // show the words which are waiting player to type
    [SerializeField] private TextMeshProUGUI txtPaper;


    [Header("Font")]
    public TMP_FontAsset fontGeneral;
    public TMP_FontAsset fontKeyPressed;

    public float timeToResetFont = 0.1f;

    public LevelManager levelManager;
    public DataController dataController;


    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

        
    }
    
    void LateUpdate()
    {
        
    }

    public void ToggleSettingPanel()
    {
        if (SettingPanel.activeSelf)
        {
            SettingPanel.SetActive(false);
            levelManager.ResumeGame();
        }
        else
        {
            SettingPanel.SetActive(true);
            levelManager.StopGame();
        }
    }


}
