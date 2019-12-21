using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Player Player;
    public Spirit Spirit;
    public List<Spawner> Spawners;
    public Canvas DeathScreen;
    public Canvas PauseScreen;
    public Text ChronoDisplay;
    public InfosUI InfosUI;
    public GrassExpand GrassExpand;

    public LevelState LevelState;

    float increment = 0;
    Vector3 scaleMin;
    Vector3 scaleMax;
    float tscale = 0;
    float chronosBombe = 0;

    public List<float> Chronos;

    public static Manager Instance { get; set; }
    public bool IsPaused { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DeathScreen.gameObject.SetActive(false);
        chronosBombe = Chronos[0];
        InfosUI.gameObject.SetActive(true);
        scaleMin = Spirit.transform.localScale;
        scaleMax = Vector3.one * 2;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            IsPaused = !IsPaused;

        }
        if (InfosUI.IsReady)
        {
            IsPaused = false;
            InfosUI.gameObject.SetActive(false);

            if ( Spirit.IsDead)
            {
                //Time.timeScale = 0;
                DeathScreen.gameObject.SetActive(true);

            }
            SwitchLevel();
            chronosBombe -= Time.deltaTime;
            ChronoDisplay.text = chronosBombe.ToString();
            switch (LevelState)
            {
                case LevelState.Level1:
                    tscale += Time.deltaTime;


                    increment = tscale / Chronos[0];
                    GrassExpand.Duration = tscale / Chronos[0];
                    Spirit.transform.localScale = Vector3.Lerp(scaleMin, scaleMax, increment);
                    break;
                case LevelState.Level2:

                    tscale += Time.deltaTime;
                    
                    increment = tscale / Chronos[1];
                    GrassExpand.Duration = tscale / Chronos[1];
                    Spirit.transform.localScale = Vector3.Lerp(scaleMin, scaleMax, increment);
                    break;
                case LevelState.Level3:
                    tscale += Time.deltaTime;

                    increment = tscale / Chronos[2];
                    GrassExpand.Duration = tscale / Chronos[2];
                    Spirit.transform.localScale = Vector3.Lerp(scaleMin, scaleMax, increment);

                    break;
                case LevelState.Finish:


                    break;
            }
        }
        else
        {
            IsPaused = true;

        }



    }


    void SwitchLevel()
    {
        if (chronosBombe <= 0)
        {
            switch (LevelState)
            {
                case LevelState.Level1:
                    //InfosUI.IsReady = false;
                    Spirit.transform.localScale = scaleMin;
                    chronosBombe = Chronos[1];
                   // Player.AllSeeds.Add(new SeedBarnes());
                    LevelState = LevelState.Level2;
                    InfosUI.Index = 0;
                    InfosUI.IndexImage = 0;
                    InfosUI.ChangeLevelLine(LevelState);
                    InfosUI.gameObject.SetActive(true);
                    InfosUI.DrawLines();

                    break;
                case LevelState.Level2:
                //    InfosUI.IsReady = false;
                    Spirit.transform.localScale = scaleMin;
                  //  Player.AllSeeds.Add(new SeedChilliPepper());
                    chronosBombe = Chronos[2];
                    LevelState = LevelState.Level3;
                    InfosUI.Index = 0;
                    InfosUI.IndexImage = 0;
                    InfosUI.ChangeLevelLine(LevelState);
                    InfosUI.gameObject.SetActive(true);
                    InfosUI.DrawLines();

                    break;
                case LevelState.Level3:
                   // InfosUI.IsReady = false;
                    LevelState = LevelState.Finish;
                    InfosUI.Index = 0;
                    InfosUI.IndexImage = 0;
                    InfosUI.ChangeLevelLine(LevelState);
                    InfosUI.gameObject.SetActive(true);
                    InfosUI.DrawLines();

                    break;
                case LevelState.Finish:
                    // InfosUI.IsReady = false;
                    InfosUI.Index = 0;
                    InfosUI.IndexImage = 0;

                    InfosUI.gameObject.SetActive(true);
                    break;
            }
        }
    }
}