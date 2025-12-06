using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kukla : MonoBehaviour
{
    private Animator animator;
    public bool hasarAliyorMu;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        animator.SetBool("HasarAlma", hasarAliyorMu);
    }

    
}
