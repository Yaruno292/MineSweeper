using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellCheck : MonoBehaviour {

    public bool bomb;
    private int _number;

    [SerializeField]
    public Sprite[] emptyTextures;

    public SpriteRenderer spriteRender;
    private GameObject _grid;
    private GridMaker _gridmaker;

    private int x;
    private int y;


    // Use this for initialization
    void Start() {
        _grid = GameObject.Find("Grid");
        _gridmaker = _grid.GetComponent<GridMaker>();
        spriteRender = GetComponent<SpriteRenderer>();
        bomb = Random.value < 0.15;

        x = (int)this.transform.position.x + 10;
        y = (int)this.transform.position.y + 10;
        Debug.Log(x);
        Debug.Log(y);

        _gridmaker.elements[x, y] = this;
    }

    private void GetNum()
    {
        _number = _gridmaker.cellNum;
        //Debug.Log(_number);
    }

    private void OnMouseDown()
    {
        SetTexture(1);
    }


    private void SetTexture(int amount) {

        if (bomb)
        {
            _gridmaker.ShowMines();
            spriteRender.sprite = emptyTextures[10];
        }
        else
        {
            spriteRender.sprite = emptyTextures[amount];
        }
    }
}
