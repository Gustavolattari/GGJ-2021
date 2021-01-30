using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Serialized Variables
    [SerializeField]
    List<GameObject> SpawnTypes;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject Spawn(Vector3 worldPos, int spawnIndex)
    {
        GameObject inst = Instantiate(SpawnTypes[spawnIndex]);
        inst.transform.position = worldPos;
        return inst;
    }
}
