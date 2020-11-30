using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public static int level = 1;
    //private static float XP = 1.0f;

    public bool inBattle;
    private bool isMoving;

    public float moveSpeed;

    public LayerMask EnemyTile;

    private Vector2 input;

    private Animator animator;

    public GameManager gm;

    private void Awake()
    {
        inBattle = false;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        inBattle = gm.battling;

        if (!inBattle)
        {
            if (!isMoving)
            {
                input.x = Input.GetAxisRaw("Horizontal");
                input.y = Input.GetAxisRaw("Vertical");

                if (input.x != 0)
                {
                    input.y = 0;
                }

                if (input != Vector2.zero)
                {
                    animator.SetFloat("moveX", input.x);
                    animator.SetFloat("moveY", input.y);

                    var targetPos = transform.position;
                    targetPos.x += input.x;
                    targetPos.y += input.y;

                    StartCoroutine(Move(targetPos));
                }
            }

            animator.SetBool("isMoving", isMoving);
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null; 
        }
        transform.position = targetPos;

        isMoving = false;

        CheckForEncounter();
    }

    void CheckForEncounter()
    {
        if(Physics2D.OverlapBox(transform.position, new Vector2(0.3f, 0.2f), 0.0f, EnemyTile) != null)
        {
            if(Random.Range(1, 101) <= 10)
            {
                gm.StartRegularBattle();
            }
        }
    }
}
