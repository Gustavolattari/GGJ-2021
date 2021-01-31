using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAI : MonoBehaviour
{

    #region Serialized Variables
    [SerializeField]
    private float moveSpeed;
    #endregion

    LevelManager level;
    GameObject hidingPlace;

    [SerializeField]
    public bool isHiden = false;
    public bool playerInRange = false;
    public GameObject playerRef;

    //Run Variables
    float runTime = 3.0f;//run for 3 seconds
    float maxRunTime;
    public bool shouldRun = false;

    private void Awake()
    {
        maxRunTime = runTime;
        level = FindObjectOfType<LevelManager>();
        if (!level)
            Debug.LogError("No level manager found by animal AI");
    }
    // Start is called before the first frame update
    void Start()
    {
        hidingPlace = level.GetHidingPlace();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isHiden)
        {
            Vector3 targ =  hidingPlace.transform.position - transform.position;
            transform.Translate(targ.normalized * Time.deltaTime * moveSpeed, Space.World);
        }
        else if (playerInRange)
        {
            shouldRun = true;
            //Run from player

            //Avoid terrain

            //Avoid clumping with other animals

            //Avoid going off the level
        }
        if (shouldRun)
        {
             if (runTime > 0)
            {
                Vector3 runDir = transform.position - playerRef.transform.position;
                runDir = new Vector3(runDir.x, 0, runDir.z);
                Debug.Log(runDir.normalized);
                transform.Translate(runDir.normalized * Time.deltaTime * moveSpeed);
                runTime -= Time.deltaTime;
            }
            else
            {
                shouldRun = false;
                runTime = maxRunTime;
            }//if run time ended
        }
    }

    public void setHiden(bool hiden)
    {
        isHiden = hiden;
    }
}
