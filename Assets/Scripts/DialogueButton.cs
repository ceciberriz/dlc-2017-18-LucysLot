using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueButton : MonoBehaviour {

    private TextManager textManager;

    // Use this for initialization
    void Start()
    {
        textManager = gameObject.AddComponent(typeof(TextManager)) as TextManager;
        // get rid of this
        TruthValue.Main();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnClick()
    {
        Debug.Log("mouse down!!!");
        textManager.SetButtonClicked();
    }
}

