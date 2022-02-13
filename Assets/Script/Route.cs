using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{    
    public List<Transform> childNodeList = new List<Transform>();
    Transform[] childObjects;

    void OnDrawGizmos(){
        Gizmos.color = new Color(1, 0, 0, 0); ;      //modficare colore della linea
       
        FillNodes();

        for(int i=0; i< childNodeList.Count; i++)
        {
            Vector3 currentPos = childNodeList[i].position;
            if(i>0)
            {
                Vector3 prevPos = childNodeList[i-1].position;
                Gizmos.DrawLine(prevPos, currentPos);
            } 
        }
    }
    
    void FillNodes(){
        childNodeList.Clear();
        childObjects = GetComponentsInChildren<Transform>();

        foreach(Transform child in childObjects)
        {   
            if(child != this.transform){
                childNodeList.Add(child);
            }
        }
    }
}
