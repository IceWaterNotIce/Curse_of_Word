using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InputPlayerHealthController : MonoBehaviour
{
    public void UpdateHealth(float health)
    {
        // get the input field
        GetComponent<TMP_InputField>().text = health.ToString();
    }
}
