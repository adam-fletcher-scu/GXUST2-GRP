using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public AudioSource gdAudio;
    private Rigidbody rb;
    Animator animator;

    private float moveX;
    private float moveY;

    public float moveSpeed =  1;

    private int count;
    public TextMeshProUGUI countText;
    public GameObject winPanel;
    public GameObject losePanel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();    
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

    public void Update()
    {
        bool forward = Input.GetKey ("w");
        bool backward = Input.GetKey("s");
        bool jumping = Input.GetKey("space");

        if (jumping)
        {
            animator.SetBool("isJumping", true);
        }

        if (!jumping)
        {
            animator.SetBool("isJumping", false);
        }


        if (forward)
        {
            animator.SetBool("isWalking", true);
        }

        if (!forward)
        {
            animator.SetBool("isWalking", false);
        }

        if (backward)
        {
            animator.SetBool("isBackward", true);
        }

        if (!backward)
        {
            animator.SetBool("isBackward", false);
        }


    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            gdAudio.Play();
            count = count + 1;
            SetCountText();
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("BadPickup"))
        {
            count = count - 1;
            SetCountText();
            other.gameObject.SetActive(false);
            animator.SetTrigger("deathTouch");            
            StartCoroutine("PlayDeath", "AdamsScene");
        }
    }

    public void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if(count >= 5)
        {
            winPanel.SetActive(true);
        }
    }

    IEnumerator PlayDeath(string sceneName)
    {
        yield return new WaitForSeconds(5);
        losePanel.SetActive(true);
        yield return new WaitForSeconds(5);
        losePanel.SetActive(false);
        SceneManager.LoadScene(sceneName);
    }
}
