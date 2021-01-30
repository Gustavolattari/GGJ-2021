using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DN_MainMenuMannager : MonoBehaviour
{
    public GameObject StartUI;
    private Animator StartAnimator;
    // Start is called before the first frame update
    void Start()
    {
        StartAnimator = StartUI.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartHover()
    {
        StartAnimator.SetBool("Hover", true);
    }
    public void StopHover()
    {
        StartAnimator.SetBool("Hover", false);
    }
}
