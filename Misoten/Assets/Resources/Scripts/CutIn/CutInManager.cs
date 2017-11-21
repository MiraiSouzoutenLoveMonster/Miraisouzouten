using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CutInManager : MonoBehaviour {

    public CutIn[] cutInResources;        //カットインのリソース

    public GameObject[] panrentResources;

    static CutIn[] cutInSources;          //静的にアクセスするための受け皿


    static GameObject[] parents;

	// Use this for initialization
	void Start () {
        cutInSources = new CutIn[cutInResources.Length];
        parents = new GameObject[panrentResources.Length];
        //インスペクタでアタッチされたリソースを静的配列にコピーする
        Array.Copy(cutInResources,cutInSources,cutInResources.Length);
        Array.Copy(panrentResources, parents, panrentResources.Length);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //カットイン生成関数。インデックスで指定
    static public CutIn CreateCutIn(int index,int display)
    {
        //不正な値を検知する
        if(index < 0 || index >= cutInSources.Length)
        {
            return null;
        }

        if (display < 0 || display >= parents.Length)
        {
            return null;
        }

        CutIn c = Instantiate(cutInSources[index], parents[display].transform);

        return c;
    }
}
