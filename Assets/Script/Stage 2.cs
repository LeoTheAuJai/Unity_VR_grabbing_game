using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2 : MonoBehaviour
{
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;

    public GameObject congratulationPanel;
    // Start is called before the first frame update
    void Start()
    {
        congratulationPanel.SetActive(false);
    }
    bool Detection(GameObject target)
    {
        if ((target.transform.position.x < 43.9f && target.transform.position.z < -40.6f) &&
    (target.transform.position.x > 34f && target.transform.position.y > -1.5f && target.transform.position.z > -50.5f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    // Update is called once per framee
    void Update()
    {
        if(Detection(target1) && Detection(target2) && Detection(target3))
        {
            congratulationPanel.SetActive(true);
        }
    }
}
