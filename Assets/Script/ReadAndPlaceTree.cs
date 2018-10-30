using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadAndPlaceTree : MonoBehaviour {

    public GameObject tree;
    public TextAsset data;

    private string text;

    // Use this for initialization
    void Start () {
        if (data != null)
        {
            text = data.ToString();
            text = text.Replace('.', ',');
            processText(text);
        }
    }
	
	private void processText(string text)
    {
        string[] lines = text.Split('\n');
        foreach (string line in lines){

            string[] treeData = line.Split(';');
            if(treeData.Length == 5)
            {

            GameObject treeTemp = Instantiate(tree, new Vector3(float.Parse(treeData[0]),  float.Parse(treeData[2]), float.Parse(treeData[1])), tree.transform.rotation, transform) as GameObject;
            
            //update the houppier scale
            GameObject houppier = treeTemp.transform.GetChild(0).gameObject;
            float heightHouppier = ((houppier.GetComponent<MeshFilter>()).mesh.bounds).size.z;
            float houppierSize = (float.Parse(treeData[3]) - float.Parse(treeData[2]));
            float scale = houppierSize / heightHouppier;
            houppier.transform.localScale = new Vector3(scale,scale,scale);

            //update the leaves position and scale
            GameObject leaves = treeTemp.transform.GetChild(1).gameObject;

            //put leaves on houppier
            leaves.transform.localPosition = new Vector3(leaves.transform.localPosition.x, leaves.transform.localPosition.y, houppierSize);

            //calculate the actual topTree
            float topHeightLeaves = ((leaves.GetComponent<MeshFilter>()).mesh.bounds).max.z + houppierSize;

            //calculate the treetop based on the z tree
            float treetop = float.Parse(treeData[4]) - float.Parse(treeData[2]);

            float leavesScale =  (treetop -houppierSize ) / (topHeightLeaves - houppierSize);
            //scale leaves on z

            leaves.transform.localScale = new Vector3(1, 1, leavesScale);
            }
        }
    }
}
