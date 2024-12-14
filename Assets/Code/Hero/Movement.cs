using UnityEngine;

public class Movement : MonoBehaviour
{
    
    [SerializeField]private bool runmode = false;
    [SerializeField]private float runspeed;
    [SerializeField]private float walkspeed;
    [SerializeField]private float Jumpforce;
    private Rigidbody2D rb;
    private StaminaComponents staminaComponents;
    private AnimStateMachine anim;

    void Start() { 
        rb = GetComponent<Rigidbody2D>();
        staminaComponents = GetComponent<StaminaComponents>();
        anim = GetComponent<AnimStateMachine>();
    }

    void Update()
    {
      Move();
      Jump();
    }

    void InputServise()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            runmode = !runmode;
        }
    }

    void Jump() {
        if(Input.GetKey(KeyCode.Space) && rb.velocity.y == 0 && staminaComponents.currentStamina >= 7) {
            staminaComponents.currentStamina -= 7;
            rb.AddForce(new Vector2(0, Jumpforce ), ForceMode2D.Impulse);
        }

    }

    void Move() {
        if (Input.GetKey(KeyCode.D)) {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) , transform.localScale.y);
            if (runmode)

            {
                anim.isrun = true;
                rb.AddForce(new Vector2(runspeed * Time.deltaTime,0), ForceMode2D.Impulse);
            }
            else
            {
                anim.iswalk = true;
                rb.AddForce(new Vector2(walkspeed * Time.deltaTime,0), ForceMode2D.Impulse);
            }
            rb.AddForce(new Vector2(walkspeed * Time.deltaTime,0), ForceMode2D.Impulse);
            // rb.velocity = new Vector2(Movespeed, 0);

        if (Input.GetKey(KeyCode.A)) {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) * -1 , transform.localScale.y);
            if (runmode)
            {
                anim.isrun = true;
                rb.AddForce(new Vector2(runspeed * Time.deltaTime -1,0), ForceMode2D.Impulse);
            }
            else
            {
               anim.iswalk = true;
                rb.AddForce(new Vector2(walkspeed * Time.deltaTime -1,0), ForceMode2D.Impulse);
            }
            rb.AddForce(new Vector2(walkspeed * Time.deltaTime,0), ForceMode2D.Impulse);
            rb.AddForce(new Vector2(walkspeed * Time.deltaTime -1,0), ForceMode2D.Impulse);
            // rb.velocity = new Vector2(Movespeed * -1, 0);
        }
    }


    }
}

