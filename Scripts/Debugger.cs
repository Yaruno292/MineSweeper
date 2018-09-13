using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour {

    [SerializeField]
    private bool useDebug = false;

    private GameObject _grid;
    private GridMaker _gridmaker;

    // Use this for initialization
    void Start () {
        if (useDebug)
        {
            _grid = GameObject.Find("Grid");
            _gridmaker = _grid.GetComponent<GridMaker>();
        }
	}

	// Update is called once per frame
	void Update () {
        if (useDebug)
        {
            Debug.Log(_gridmaker.cellNum);
        }
	}
}
