
using UnityEngine;

public class AnimationStateMachine : MonoBehaviour
{

    public bool isrun;
    public bool isidle;
    public bool iswalk;

    private Rigidbody2D rb;

    void start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    
