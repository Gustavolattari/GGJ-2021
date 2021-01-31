using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerretControllerScript : MonoBehaviour
{
    Animator anim;
    AnimalAI ai;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        ai = GetComponent<AnimalAI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ai.shouldRun || !ai.isHiden)
        {
            anim.SetBool("Run", true);
        }//if should be moving
        else
            anim.SetBool("Run", false);
    }
}
