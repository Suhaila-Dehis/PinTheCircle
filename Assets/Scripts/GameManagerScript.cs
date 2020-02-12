using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instace;

    private Button shootButton;
    [SerializeField]
    private GameObject needle;

    [SerializeField]
    private int howManyNeedles;

    private GameObject[] gameNeedles;
    private float needleDistance = 0.5f;
    private int needleIndex = 0;


    private void Awake()
    {
        if (instace == null)
        {
            instace = this;
        }
        GetButton();

    }
    private void Start()
    {
        CreateNeedls();
    }

    void GetButton()
    {
        shootButton = GameObject.Find("Fire - Button").GetComponent<Button>();
        shootButton.onClick.AddListener(() => ShootTheNeedle());
    }

    public void ShootTheNeedle()
    {
        gameNeedles[needleIndex].GetComponent<NeedleMovement>().FireNeedle();
        needleIndex++;
        if (needleIndex == gameNeedles.Length)
        {
            Debug.Log("the game is finished");
            shootButton.onClick.RemoveAllListeners();
        }
    }


    void CreateNeedls()
    {
        gameNeedles = new GameObject[howManyNeedles];
        Vector3 temp = transform.position;

        for (int i = 0; i < gameNeedles.Length; i++)
        {
            gameNeedles[i] = Instantiate(needle, temp, Quaternion.identity) as GameObject;
            temp.y -= needleDistance;
        }
    }

    public void InstantiateNeedle()
    {
        Instantiate(needle, transform.position, Quaternion.identity);
    }


}