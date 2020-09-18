using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public float jumpPower = 10f;
    bool onGround = false;
    Rigidbody2D Dinobody;



    public Animator anim;



    public TextMeshProUGUI currentScore;
    public TextMeshProUGUI highScore;
    int score = 0;


    private Vector2 startTouchPosition, endTouchPosition;

 


    void Jump()
    {
        Dinobody.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
    }

    void Duck()
    {
        Dinobody.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -jumpPower), ForceMode2D.Impulse);

    }

    void GameOver()
    {
        anim.SetBool("GameisOver", true);
        GameManager.instance.GameOver();
    }


    //jump only when it touches the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            onGround = true;
            anim.SetBool("Jump", false);
        }


        if (collision.collider.tag == "Challenges")
            GameOver();

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            onGround = false;
            anim.SetBool("Jump", true);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            onGround = true;
            anim.SetBool("Jump", false);
        }

    }




    void CountScore()
    {
        if (Time.timeScale == 1f)
        {
            score++;

            if (score % 700 == 0 && score > 0 && score % 1200 != 0)
            {
                Camera.main.GetComponent<Camera>().backgroundColor = new Color(0f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);

            }


            if (score % 700 != 0 && score > 0 && score % 1200 == 0)
            {
                Camera.main.GetComponent<Camera>().backgroundColor = new Color(255f / 255f, 255f / 255f, 255f / 255f, 255f / 255f);

            }


            currentScore.text = score.ToString();

            if (score > PlayerPrefs.GetInt("HighScore", 0)) //whenever score>highscore
            {
                //saving permanently to device
                PlayerPrefs.SetInt("HighScore", score);
                highScore.text = PlayerPrefs.GetInt("HighScore").ToString();

            }
        }
    }





    private void SwipeCheck()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            startTouchPosition = Input.GetTouch(0).position;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            if (endTouchPosition.y > startTouchPosition.y && onGround) //Jump
            {
                Jump();
                anim.SetBool("Duck", false);
                

            }
            if (endTouchPosition.y < startTouchPosition.y)
            {
                Duck();

                if (onGround)
                    anim.SetBool("Duck", true);


            }
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        Dinobody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        highScore.text = PlayerPrefs.GetInt("HighScore", 00000).ToString(); //initial default value, subject to change 


    }

    // Update is called once per frame
    void Update()
    {
        //FOR PC
        /*
        
        if ( (Input.GetKeyDown(KeyCode.Space) || GameManager.instance.Movement() == "Up") && onGround)
        {
            Jump();
            anim.SetBool("Duck", false);
            anim.SetBool("Jump", true);
            
        }

        if ((Input.GetKeyDown(KeyCode.DownArrow) || GameManager.instance.Movement() == "Down"))
        {
            Duck();

            if (onGround)
                anim.SetBool("Duck", true);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) || GameManager.instance.Movement() == "Stationary") //when i leave the down key
        {
            anim.SetBool("Duck", false);
        }
        
         */


        //FOR MOBILE
        SwipeCheck();

        CountScore();


    }




}
