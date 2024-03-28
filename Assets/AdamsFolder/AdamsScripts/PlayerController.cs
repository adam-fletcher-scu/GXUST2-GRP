using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    private float moveX;
    private float moveY;

    public float moveSpeed =  1;

    private int count;
    public TextMeshProUGUI countText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
    }

    public void OnMove(InputValue moveValue)
    {
        Vector2 moveVector = moveValue.Get<Vector2>();

        moveX = moveVector.x;
        moveY = moveVector.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3 (moveX, 0.0f, moveY);

        rb.AddForce (movement * moveSpeed);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            count = count + 1;
            SetCountText();
            other.gameObject.SetActive(false);
        }
    }

    public void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
