using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gui : MonoBehaviour {

    [SerializeField]
    private AudioClip[] _songs;

    [SerializeField]
    private AudioClip _booom;
    [SerializeField]
    private AudioClip _win;

    private int _rdom;

    private GameObject _textObj;
    private Text _text;
    private int _time = 0;

    private GameObject _winScreen;
    private GameObject _loseScreen;

    private GameObject _soundObj;
    private AudioSource _sound;

    void Start()
    {
        _winScreen = GameObject.Find("Win");
        _loseScreen = GameObject.Find("GameOver");
        _loseScreen.SetActive(false);
        _winScreen.SetActive(false);

        _soundObj = GameObject.Find("Music");
        _sound = _soundObj.GetComponent<AudioSource>();
        RandomSong();

        _textObj = GameObject.Find("TimerText");
        _text = _textObj.GetComponent<Text>();
        StartCoroutine(Timer());
    }

    private void RandomSong()
    {
        _rdom = Random.Range(0, 3);
        _sound.clip = _songs[_rdom];
        _sound.Play();
    }

    IEnumerator Timer()
    {
        while(Grid.gameOver == false)
        {
            yield return new WaitForSeconds(1);
            _time += 1;
            _text.text = " " + _time;
        }
    }

    public void Restart()
    {
        Grid.gameOver = false;
        SceneManager.LoadScene("SampleScene");
    }

    public void HasWon()
    {
        _winScreen.SetActive(true);
        _sound.clip = _win;
        _sound.Play();
    }

    public void HasLost()
    {
        _loseScreen.SetActive(true);
        _sound.clip = _booom;
        _sound.Play();
    }
}
