using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct CubeData
{
    public string color;
    public float positionX, positionZ, scaleY;
    public int id;

    public CubeData(string color, float positionX, float positionZ, float scaleY, int id)
    {
        this.color = color;
        this.positionX = positionX;
        this.positionZ = positionZ;
        this.scaleY = scaleY;
        this.id = id;
    }
}


public class ShowData : MonoBehaviour {

    public Text text;

    private Dictionary<string,CubeData> dataList;

    // Use this for initialization
	void Start () {
        TextAsset data = Resources.Load("dataCube") as TextAsset;
        string dataStr = data.ToString();
        string[] dataLines = dataStr.Split('\n');
        dataList = new Dictionary<string,CubeData>();
        FillDataList(dataLines);
    }
	
	// Update is called once per frame
	private void FillDataList(string[] dataLines) {

		for(int i = 0; i < dataLines.Length; i++)
        {
            string line = dataLines[i];
            line = line.Replace('.', ',');
            string[] lineData = line.Split(';');
            CubeData temp = new CubeData( lineData[1], float.Parse(lineData[2]), float.Parse(lineData[3]), float.Parse(lineData[4]),i+1);
            dataList.Add(lineData[0],temp);
        }
	}

    public void showData(string owner)
    {
        if(dataList.ContainsKey(owner))
        {
            string temp = " owner : " + owner + '\n';
            temp += " color : " + dataList[owner].color + '\n';
            temp += " positionX : " + dataList[owner].positionX + '\n';
            temp += " positionZ : " + dataList[owner].positionZ + '\n';
            temp += " scaleY : " + dataList[owner].scaleY + '\n';
            text.text = temp;
        }
        else
        {
            text.text = "no data for this cube";
        }
    }

    public void resetUi()
    {
            text.text = "";
    }
}
