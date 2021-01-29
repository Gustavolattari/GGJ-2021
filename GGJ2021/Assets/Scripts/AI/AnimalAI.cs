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

    bool isHiden = false;


    private void Awake()
    {
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
            Vector3 targ = hidingPlace.transform.position - transform.position;
            transform.Translate(targ.normalized * Time.deltaTime * moveSpeed);
        }
    }

    public void setHiden(bool hiden)
    {
        isHiden = hiden;
    }
}
