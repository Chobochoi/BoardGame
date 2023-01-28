using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTest : MonoBehaviour
{
    public static int StringToHash = Animator.StringToHash("ABC");
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Plz();
    }

    void Plz()
    {
        animator.SetTrigger(StringToHash);
    }
}
