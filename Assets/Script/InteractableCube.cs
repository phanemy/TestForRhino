using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableCube : MonoBehaviour {

    public string owner;
    private ShowData dataManager;
    private bool isDisplay;
    // Use this for initialization
	void Awake () {
        isDisplay = false;
		GameObject temp = GameObject.FindWithTag("DataManager");
        dataManager = temp.GetComponent<ShowData>();
    }

    private void OnMouseDown()
    {
        if(!isDisplay)
        {
            dataManager.showData(owner);
            isDisplay = true;
        }
    }

    private void OnMouseExit()
    {
        if (isDisplay)
        {
            isDisplay = false;
            dataManager.resetUi();
        }
    }
}
