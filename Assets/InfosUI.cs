using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfosUI : MonoBehaviour
{
    public int Index { get; set; } = 0;
    public int IndexImage { get; set; } = 0;
    public bool IsReady { get; set; } = false;
    public bool ImageStop { get; set; } = false;
   

    public Text TextUI;
    public Image InfosImage;
    public List<Sprite> ImageToDisplay { get; set; }
    public List<Sprite> ImageToDisplay1;
    public List<Sprite> ImageToDisplay2;
    public List<Sprite> ImageToDisplay3;
    public List<string> TextLines { get; set; }
    public List<string> TextLinesLevel1;
    public List<string> TextLinesLevel2;
    public List<string> TextLinesLevel3;
    public List<string> TextLinesFinish;

    


    // Start is called before the first frame update
    void Start()
    {
        TextLines = TextLinesLevel1;
        TextUI.text = TextLines.FirstOrDefault();
        ImageToDisplay = ImageToDisplay1;

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void DrawLines()
    {
        DrawImage();
        Index++;
        if (Index < TextLines.Count)
        {
            TextUI.text = TextLines[Index];
            

        }
        else if (Index == TextLines.Count)
        {
            if(Manager.Instance.LevelState == LevelState.Finish)
            {
                SceneManager.LoadScene("Menu");
            }
            else
            {
                IsReady = true;
                gameObject.SetActive(false);

            }

        }
        
    }

    public void DrawImage()
    {
       
        if (!ImageStop)
        {
            IndexImage++;
            if ( ImageToDisplay == null)
            {
                InfosImage.sprite = null;
                ImageStop = true;
            }
            else
            {
                if (IndexImage < ImageToDisplay.Count)
                {
                    InfosImage.sprite = ImageToDisplay[IndexImage];

                }
                else if (IndexImage == ImageToDisplay.Count)
                {
                    ImageStop = true;
                }
            }
           
            
        }
    }

    public void ChangeLevelLine(LevelState levelState)
    {
        switch (levelState)
        {
            case LevelState.Level2:
                TextLines = TextLinesLevel2;
                ImageToDisplay = ImageToDisplay2;
                break;
            case LevelState.Level3:
                TextLines = TextLinesLevel3;
                ImageToDisplay = ImageToDisplay3;
                break;
            case LevelState.Finish:
                TextLines = TextLinesFinish;
                ImageToDisplay = null;
                break;
        }
    }

    private void OnEnable()
    {
        IsReady = false;
        Manager.Instance.IsPaused = true;
    }

    private void OnDisable()
    {
        IsReady = true;
        Manager.Instance.IsPaused = false;
    }
}