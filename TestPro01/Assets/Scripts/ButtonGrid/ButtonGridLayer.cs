using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGridLayer : MonoBehaviour
{
    public GameObject GridContainer;

    private  int row = 1;
    private int col;
    private int objCounter = 0;
    private bool isSmaller = false;
    private int numberOfButton = 16;
    private int _imageWidth = 100;
    private int _imageHeight = 100;
    private int _offset = 10;
    private List<Color> myColor = new List<Color>();
    // Start is called before the first frame update
    void Start()
    {
        CreateColorList();
        PrepareGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PrepareGrid()
    {
        SetContainer();
        SetColumn();
        ShowGridObject();
    }
    void SetContainer()
    {
        //GridContainer.AddComponent<Image>();
        GridContainer.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height / 4);
        GridContainer.GetComponent<RectTransform>().pivot = new Vector2(1, 1);
    }

    void SetColumn()
    {
        if((row * (_imageHeight + _offset)) > GridContainer.GetComponent<RectTransform>().sizeDelta.y)
        {
            Debug.Log("Rows exceded Please reduce the number of rows! Thank you.");
        }
        else
        {
            col = (int)GridContainer.GetComponent<RectTransform>().sizeDelta.x / (_imageWidth + _offset);
            SetRow(col);
        }
    }

    void ShowGridObject()
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (objCounter == 16)
                {
                    break;
                }
                else
                {
                    var GridObject = new GameObject();
                    GridObject.name = "Grid Conteiner";
                    GridObject.transform.SetParent(GridContainer.transform);
                    GridObject.AddComponent<RectTransform>();
                    GridObject.GetComponent<RectTransform>().pivot = new Vector2(1, 1);
                    GridObject.GetComponent<RectTransform>().sizeDelta = new Vector2(_imageWidth, _imageHeight);
                    GridObject.GetComponent<RectTransform>().position = new Vector3((GridContainer.GetComponent<RectTransform>().position.x - _offset - (j * (GridObject.GetComponent<RectTransform>().sizeDelta.x + _offset))), (GridContainer.GetComponent<RectTransform>().position.y - _offset - (i * (GridObject.GetComponent<RectTransform>().sizeDelta.y + _offset))), 1);
                    GridObject.AddComponent<Image>();
                    GridObject.GetComponent<Image>().color = myColor[j];
                    objCounter++;
                    Debug.Log(objCounter);
                }
            }
        }
    }

    void CreateColorList()
    {
        myColor.Add(Color.red);
        myColor.Add(Color.magenta);
        myColor.Add(Color.green);
        myColor.Add(Color.grey);
        myColor.Add(Color.black);
        myColor.Add(Color.grey);
        myColor.Add(Color.green);
        myColor.Add(Color.cyan);
        myColor.Add(Color.blue);
    }

    void SetRow(int colNum)
    {
        while (!isSmaller)
        {
            if(numberOfButton > colNum)
            {
                row++;
                numberOfButton = numberOfButton - colNum;
            }
            else
            {
                isSmaller = true;
            }
        }
    }
}
