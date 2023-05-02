using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GoalManage : MonoBehaviour
{
        public GameObject p;
        public GameObject b;
        public GameObject c;
        public GameObject d;
        private void Start()
        {
            p = GameManager.instance.puck;
            b = GameObject.FindGameObjectWithTag("Respawn");
            Debug.Log("Found " + b.name);
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}


