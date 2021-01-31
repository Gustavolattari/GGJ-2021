using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DN_InGameUI : MonoBehaviour
{
    public GameObject StartUI;
    private Animator StartAnimator;
    public GameObject HTPUI;
    private Animator HTPAnimator;
    public GameObject CreditUI;
    private Animator CreditAnimator;
    public GameObject QuitUI;
    private Animator QuitAnimator;

    public GameObject blur;
    public GameObject PaperFlip;
    private AudioSource PaperFlipSound;
    public GameObject EndScreen;
    public bool PauseNow;
    public GameObject[] ButtonGroup;
    // Start is called before the first frame update
    void Start()
    {
        StartAnimator = StartUI.GetComponent<Animator>();
        HTPAnimator = HTPUI.GetComponent<Animator>();
        CreditAnimator = CreditUI.GetComponent<Animator>();
        QuitAnimator = QuitUI.GetComponent<Animator>();

        PaperFlipSound = PaperFlip.GetComponent<AudioSource>();

        HTPAnimator.SetBool("Out", true);
        StartAnimator.SetBool("Out", true);
        CreditAnimator.SetBool("Out", true);
        QuitAnimator.SetBool("Out", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Freeze();
        }
      
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
    public void HTPActivate()
    {
        PaperFlipSound.Play();
        HTPAnimator.SetBool("Active", true);
        StartAnimator.SetBool("Out", true);
        CreditAnimator.SetBool("Out", true);
        QuitAnimator.SetBool("Out", true);
    }
    public void HTPInactive()
    {
        PaperFlipSound.Play();
        HTPAnimator.SetBool("Active", false);
        StartAnimator.SetBool("Out", false);
        CreditAnimator.SetBool("Out", false);
        QuitAnimator.SetBool("Out", false);
    }
    
    public void Restart(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void QuitToMainMenu(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void Freeze()
    {
        
        HTPAnimator.SetBool("Out", false);
        StartAnimator.SetBool("Out", false);
        CreditAnimator.SetBool("Out", false);
        QuitAnimator.SetBool("Out", false);
        blur.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        HTPAnimator.SetBool("Out", true);
        StartAnimator.SetBool("Out", true);
        CreditAnimator.SetBool("Out", true);
        QuitAnimator.SetBool("Out", true);
        blur.SetActive(false);
    }

    public void Endgame()
    {
        StartUI.SetActive(false);
        EndScreen.SetActive(true);
        HTPAnimator.SetBool("Out", false);
        CreditAnimator.SetBool("Out", false);
        QuitAnimator.SetBool("Out", false);
        Time.timeScale = 0;
    }


}
