using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public int Index { get; set; } = 0;
    public Text TextUI;
    public List<string> TextLines; 
    // Start is called before the first frame update
    void Start()
    {
        TextUI.text = TextLines.FirstOrDefault();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void DrawLines()
    {
        Index++; 
        if(Index< TextLines.Count)
        {
            TextUI.text = TextLines[Index];
            Debug.Log(TextLines[Index]);
        }
        else if (Index == TextLines.Count)
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
