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

    [SerializeField] private Button btnSetting;
    [SerializeField] private Button btnReturn;
    private Stack<GameObject> panelStack = new Stack<GameObject>();
    [SerializeField] private TextMeshProUGUI txtPaper;

    [Header("Dictionary Panel")]

    [SerializeField] private GameObject DictionaryPanel;



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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoBack();
        }
    }

    void LateUpdate()
    {

    }

    public void ToggleSettingPanel()
    {
        if (SettingPanel.activeSelf)
        {
            SettingPanel.SetActive(false);
            btnSetting.gameObject.SetActive(true);
            btnReturn.gameObject.SetActive(false);

            levelManager.ResumeGame();
        }
        else
        {
            SettingPanel.SetActive(true);
            btnSetting.gameObject.SetActive(false);
            btnReturn.gameObject.SetActive(true);
            panelStack.Push(SettingPanel);
            levelManager.StopGame();
        }
    }



    public void GoBack()
    {
        if (panelStack.Count > 1)
        {
            panelStack.Pop().SetActive(false);
            panelStack.Peek().SetActive(true);
        }
        if (panelStack.Count == 1)
        {
            ToggleSettingPanel();
        }
    }
}
