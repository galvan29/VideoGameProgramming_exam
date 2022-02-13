using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCard : MonoBehaviour
{
    public List<Tipo1> childObjects; //description, soldi, sociale, ambientale, economico.
   // public Text textDebug;
    private void Start()
    {
       /* string dataPath = Application.dataPath;
        string[] percorso = Directory.GetFiles(dataPath, "*.asset", SearchOption.AllDirectories);
        foreach (string s in percorso)
        {
            string assetPath = "Assets" + s.Replace(dataPath, "").Replace('\\', '/');
            string nome = assetPath.Split('/')[assetPath.Split('/').Length-1];
            if(assetPath.Contains("Resources/Card"))
            {
                Tipo1 file = Resources.Load<Tipo1>("Card/"+nome.Replace(".asset", ""));
                childObjects.Add(file);
                textDebug.text = textDebug.text+"   "+file.description;
            }
        } */
    }    
   public Tipo1[] prelevaCarte(string tipo)
   {
        List<Tipo1> selectedObjects = new List<Tipo1>();
        for (int i=0; i<childObjects.Count; i++)
        {
            if(childObjects[i].tipologia.CompareTo(tipo)==0)  //true tipologia della carat che mi interessa uguale
            {
                selectedObjects.Add(childObjects[i]);
            }   
        }
        Tipo1[] array = new Tipo1[2];
        int[] a = genera(selectedObjects.Count);
        array[0] = selectedObjects[a[0]];
        array[1] = selectedObjects[a[1]];
        return array;
    }

    public int[] genera(int length)
    {
        int n = Random.Range(0, length);
        int n2 = Random.Range(0, length);
        if (n == n2)
            n2 = (n+1) % length;
        return new int[2] {n,n2};
    } 
}
