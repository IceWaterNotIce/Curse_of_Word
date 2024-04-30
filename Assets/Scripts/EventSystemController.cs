using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class EventSystemManger : MonoBehaviour
{

    public TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnEnable()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EventSystem.current.SetSelectedGameObject(inputField.gameObject);
    }
}
