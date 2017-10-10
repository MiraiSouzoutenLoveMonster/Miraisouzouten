using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitManager : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        int count = 0;
        // ボタンを trueのを探す
        for (int i = 0; i < AndroidInputManager.GetConnectInputCount(); i++)
        {
            if (AndroidInputManager.GetAndroidInput(i).GetRepeat() == true)
            {
                count++;
            }
        }

        if ( count == AndroidInputManager.GetConnectInputCount())
        {

            MultiFadeManager.SetNextFade("Title", 0);
        }
    }
}
