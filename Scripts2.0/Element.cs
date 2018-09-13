using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour {

    public bool mine;

    public Sprite[] emptytextures;
    public Sprite mineTexture;

    private GameObject _guiObj;
    private Gui _gui;

	// Use this for initialization
	void Start () {
        mine = Random.value < 0.15;
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        Grid.elements[x, y] = this;

        _guiObj = GameObject.Find("Main Camera");
        _gui = _guiObj.GetComponent<Gui>();
	}
	
    public void LoadTexture (int adjacentCount)
    {
        if (mine)
        {
            GetComponent<SpriteRenderer>().sprite = mineTexture;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = emptytextures[adjacentCount];
        }
    }

    public bool isCovered ()
    {
        return GetComponent<SpriteRenderer>().sprite.texture.name == "Default";
    }

    private void OnMouseUpAsButton()
    {
        if (mine && Grid.gameOver == false)
        {
            Grid.UncoverMines();
            Debug.Log("u lose");
            Grid.gameOver = true;
            _gui.HasLost();
        }
        else if (Grid.gameOver == false)
        {
            int x = (int)transform.position.x;
            int y = (int)transform.position.y;
            LoadTexture(Grid.adjacentMines(x, y));

            Grid.FFuncover(x, y, new bool[Grid.w, Grid.h]);

            if (Grid.isFinished())
            {
                Debug.Log("you won");
                Grid.gameOver = true;
                _gui.HasWon();
            }
        }
    }
}
