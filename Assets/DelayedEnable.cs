using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedEnable : MonoBehaviour
{
    public GameObject TargetGameObject;
	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds(5);
	    TargetGameObject.SetActive(true);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
