using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject wind;
    public GameObject windFactory;

    //주기
    float span = 3.0f;
    float delta = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;

        if (this.delta > this.span)
        {
            this.delta = 0;

            GameObject go = Instantiate(wind) as GameObject;
            go.transform.position = windFactory.transform.position;
        }
    }
}
