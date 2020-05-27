using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringManager : MonoBehaviour
{
    public List<string> myAnswerList = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in myAnswerList)
        {
            char[] ch = item.ToCharArray();
            foreach (var c in ch)
            {
                Debug.Log(c);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
