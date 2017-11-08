using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        else
        {
            Destroy(this);
        }
        
    }

    [Header("Character")]
    public GameObject[] Characters;
    public GameObject Player;
    public GameObject PlayerSpawn;

    [Header("UI")]
    public Image PanicBar;
    public GameObject Pausemenu;
    public GameObject EventObj;
    public GameObject PanicObj;

    [Header("Variables")]
    public float PanicAmount;
    public float CurrentPanic;
    public float GameTimer = 0;
    public float CurrentTime = 0;

    [Header("Other")]
    public GameObject BusObj;
    public Animator BusAnim;
    public bool GameOver = false;

    // Use this for initialization
    void Start ()
    {
        //spawn the selected character and make it a parent of the empty GO.
        Player = Instantiate(Characters[0], PlayerSpawn.transform.position, PlayerSpawn.transform.rotation);
        Player.transform.SetParent(PlayerSpawn.transform);

        CurrentPanic = PanicAmount;
        CurrentTime = GameTimer;
        GameOver = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //starting Game Timer
        CurrentTime -= Time.deltaTime;

        //make sure we can quit at all times
        if(Input.GetKey(KeyCode.Escape))
        {
            //functionality for pausing the game.
            Pausemenu.SetActive(true);
            Time.timeScale = 0;
        }

        if(CurrentTime <= 0)
        {
            NextLevel();
            CurrentTime = 0;
            GameOver = true;
        }


        if(CurrentPanic > PanicAmount)
        {
            CurrentPanic = PanicAmount;
        }

        else if(CurrentPanic <= 0)
        {
            //Add Losing logic here   
            //TODO: Losing
        }

        if (IntruderBehaviour.HasReachedDestination == true)
        {
            StartCountdown();
        }
	}

    void StartCountdown()
    {
        CurrentPanic -= Time.deltaTime;

        PanicBar.fillAmount = CurrentPanic / PanicAmount;
    }

    void NextLevel()
    {
        PanicObj.SetActive(false);
        EventObj.SetActive(false);

        //add logic for fading out screeen                                                                          TODO: fade screen

        BusAnim.SetTrigger("StartDrive");
        StartCoroutine(WaitNextLevel());

    }

    //used to load next level
    IEnumerator WaitNextLevel()
    {
        yield return new WaitForSeconds(4);
        //start fading out the level
        float fadeTime = GetComponent<FadeScript>().BeginFade(1);

        yield return new WaitForSeconds(fadeTime);
        int SceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(SceneIndex);
    }
}
