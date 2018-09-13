using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaker : MonoBehaviour {

    private int _width = 10;
    private int _height = 10;
    private float _centered = -4.5f;
    public int cellNum = 0;

    [SerializeField]
    private GameObject _cell;

    public CellCheck[,] elements = new CellCheck[25,25];

	// Use this for initialization
	void Start () {
        CreateGrid();
	}

    public void ShowMines()
    {
        foreach(CellCheck cells in elements)
        {
            if (cells.bomb)
            {
                cells.spriteRender.sprite = cells.emptyTextures[10];
            }
        }
    }

    void CreateGrid ()
    {
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                Instantiate(_cell, new Vector2(i + _centered, j + _centered), Quaternion.identity);
                cellNum += 1;
            }
        }
    }
}
