using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SQLite4Unity3d;
using System.Linq;

public class DictonaryUIController : MonoBehaviour
{

    public GameObject itemPrefab; // 用于显示数据的预制件
    public Transform contentTransform; // ScrollView的Content区域

    public DataController dataController;

    [Header("UI Elements")]
    public TMP_InputField wordInput;
    public TMP_InputField meaningInput;
    public TMP_InputField chineseMeaningInput;

    private void Start()
    {
        // 获取数据
        string[] words = dataController.GetWords();

        // 动态生成并添加预制件
        foreach (var item in words)
        {
            // itemPrefab . rectTransform . pos y + = itemPrefab. height
            itemPrefab.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 100);
            var itemGO = Instantiate(itemPrefab, contentTransform);
            // get itemgo children ui text mesh pro
            var itemText = itemGO.GetComponentInChildren<TextMeshProUGUI>();
            itemText.text = item.ToString();
        }

        //set content height
        contentTransform.GetComponent<RectTransform>().sizeDelta = new Vector2(0, words.Length * 100);
    }

    public void OnAddButtonClicked()
    {
        dataController.InsertWord(wordInput.text, meaningInput.text, chineseMeaningInput.text, true);
        //clear input field
        wordInput.text = "";
        meaningInput.text = "";
        chineseMeaningInput.text = "";
    }
}

