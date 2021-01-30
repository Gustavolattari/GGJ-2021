using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DN_MainMenuMannager : MonoBehaviour
{
    public GameObject StartUI;
    private Animator StartAnimator;
    public GameObject HTPUI;
    private Animator HTPAnimator;
    public GameObject CreditUI;
    private Animator CreditAnimator;
    public GameObject QuitUI;
    private Animator QuitAnimator;
    // Start is called before the first frame update
    void Start()
    {
        StartAnimator = StartUI.GetComponent<Animator>();
        HTPAnimator = HTPUI.GetComponent<Animator>();
        CreditAnimator = CreditUI.GetComponent<Animator>();
        QuitAnimator = QuitUI.GetComponent<Animator>();
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
    public void StartHTPHover()
    {
        HTPAnimator.SetBool("Hover", true);
    }
    public void StopHTPHover()
    {
        HTPAnimator.SetBool("Hover", false);
    }
    public void StartCreditHover()
    {
        CreditAnimator.SetBool("Hover", true);
    }
    public void StopCreditHover()
    {
        CreditAnimator.SetBool("Hover", false);
    }
    public void StartQuitHover()
    {
        QuitAnimator.SetBool("Hover", true);
    }
    public void StopQuitHover()
    {
        QuitAnimator.SetBool("Hover", false);
    }
}
