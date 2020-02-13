using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject puzzleManager;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {        
        if (puzzleManager.GetComponent<PuzzleManager>().isDoorOpen == 1) {
                animator.SetInteger("isPuzzleClear", 1);
        }
        else {
                animator.SetInteger("isPuzzleClear", 0);
        }
    }
}
