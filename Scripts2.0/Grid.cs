using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    private float _centered = 0f;
    [SerializeField]
    private GameObject _cell;

    public static bool gameOver = false;

    public static int w = 10;
    public static int h = 10;
    public static Element[,] elements = new Element[w, h];

    void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j < h; j++)
            {
                Instantiate(_cell, new Vector2(i + _centered, j + _centered), Quaternion.identity);
            }
        }
    }

    public static void UncoverMines()
    {
        foreach (Element elem in elements)
        {
            if (elem.mine)
            {
                elem.LoadTexture(0);
            }
        }
    }

    public static bool mineAt (int x, int y)
    {
        if(x >= 0 && y >= 0 && x < w && y < h)
        {
            return elements[x, y].mine;
        }
        return false;
    }

    public static int adjacentMines (int x, int y)
    {
        int count = 0;

        if (mineAt(x, y + 1)) ++count;
        if (mineAt(x + 1, y + 1)) ++count;
        if (mineAt(x + 1, y)) ++count;
        if (mineAt(x + 1, y - 1)) ++count;
        if (mineAt(x, y - 1)) ++count;
        if (mineAt(x - 1, y - 1)) ++count;
        if (mineAt(x - 1, y)) ++count;
        if (mineAt(x - 1, y + 1)) ++count;

        return count + 1;
    }

    public static void FFuncover (int x, int y, bool[,] visited)
    {
        if (x >= 0 && y >= 0 && x < w && y < h)
        {

            if (visited[x, y])
            {
                return;
            }

            elements[x, y].LoadTexture(adjacentMines(x, y));

            if (adjacentMines(x,y) > 1)
            {
                return;
            }

            visited[x, y] = true;

            FFuncover(x - 1, y, visited);
            FFuncover(x + 1, y, visited);
            FFuncover(x, y - 1, visited);
            FFuncover(x, y + 1, visited);
            FFuncover(x - 1, y - 1, visited);
            FFuncover(x + 1, y - 1, visited);
            FFuncover(x - 1, y + 1, visited);
            FFuncover(x + 1, y + 1, visited);
        }
    }

    public static bool isFinished()
    {
        foreach(Element elem in elements)
        {
            if (elem.isCovered() && !elem.mine)
            {
                return false;
            }
        }
        return true;
    }
}
