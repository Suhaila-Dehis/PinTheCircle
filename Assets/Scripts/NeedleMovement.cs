using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject needleBody;

    [SerializeField]
    private float forceY = 10f;

    private bool touchedTheCircle = false;
    private bool canFireNeedle;

    private Rigidbody2D myBody;

    private void Awake()
    {
        Initialize();
    }

    void Initialize()
    {
        needleBody.SetActive(false);
        myBody = this.GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        if (canFireNeedle)
        {
            myBody.velocity = new Vector2(0, forceY);
        }        
    }

    public void FireNeedle()
    {
        needleBody.SetActive(true);
        myBody.isKinematic = false;
        canFireNeedle = true;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (touchedTheCircle)
            return;

        if (target.tag.Equals("Circle"))
        {
            Debug.Log("On Trigger Enter > " + target.tag);
            canFireNeedle = false;
            touchedTheCircle = true;
            myBody.isKinematic = true;
            myBody.velocity = new Vector2(0, 0);
            gameObject.transform.SetParent(target.transform);
            if (ScoreManagerScript.instance != null)
            {
                ScoreManagerScript.instance.SetScore();
            }
        }
    }
}// NeedleMovementScript