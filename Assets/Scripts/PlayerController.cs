using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public float health = 100.0f;
    private Vector3 targetPosition;
    private float speed = 5.0f;
    private float minDistance = 0.1f;


    [SerializeField] private GameObject PlayerCamera;
    [SerializeField] private float cameraDistance = 16.0f;
    [SerializeField] private GameObject pointerPrefab;
    [SerializeField] private GameObject bulletPrefab;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI txtPaper;
    [SerializeField] private TMP_InputField inputPlayerHealth;
    // Start is called before the first frame update
    void Start()
    {
        AddHealth(0);
    }

    // Update is called once per frame
    void Update()
    {
        // get mouse click position and move player to this position
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // only get x,z position
                targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                //clear all pointers in the scene
                GameObject[] pointers = GameObject.FindGameObjectsWithTag("Pointer");
                foreach (GameObject pointer in pointers)
                {
                    Destroy(pointer);
                }
                // create a object from prefab "pointer" to show the target position
                Instantiate(pointerPrefab, targetPosition, Quaternion.identity);
            }
        }

        if (Vector3.Distance(transform.position, targetPosition) > minDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }

        //#region camera follow player position with a range

        // if the distance between player and camera is greater than 50, move camera 
        if (Vector3.Distance(transform.position, PlayerCamera.transform.position) > cameraDistance)
        {
            Vector3 newPosition = new Vector3(transform.position.x, PlayerCamera.transform.position.y, transform.position.z);
            PlayerCamera.transform.position = Vector3.MoveTowards(PlayerCamera.transform.position, newPosition, speed * Time.deltaTime);
        }

        //#endregion

        // if player type the first letter of txtPaper text, remove the first letter
        if (Input.anyKeyDown)
        {
            if (Input.inputString.Length == 0)
            {
                return;
            }
            if (txtPaper.text.Length > 0 && txtPaper.text[0] == Input.inputString[0])
            {
                txtPaper.text = txtPaper.text.Substring(1);
                //create bullet
                Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            }
        }
    }

    public void AddHealth(float value)
    {
        health += value;
        //update UI
        inputPlayerHealth.GetComponent<InputPlayerHealthController>().UpdateHealth(health);
        if (health <= 0)
        {
            //game over
            GameObject.Find("LevelManager").GetComponent<LevelManager>().GameOver();
        }
    }
}
