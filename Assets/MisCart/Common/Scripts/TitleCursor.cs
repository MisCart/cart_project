using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using Title.UI;
using Title;

public class TitleCursor : MonoBehaviour {
    

    private int width = Screen.width;
    private int height = Screen.height;

    private int move = 3;
    private int Xpos = 0;
    private int Ypos = 0;
    [DllImport("user32.dll")]
    public static extern bool SetCursorPos(int x, int y);

    [SerializeField]private UICanvas uICanvas;
    [SerializeField] private GameObject CharacterSelectMenu;
    [SerializeField] private GameObject CartSelectMenu;
    [SerializeField] private GameObject StageSelectMenu;

    // Use this for initialization
    void Start()
    {
        Xpos = width / 2;
        Ypos = height / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Xpos-=move;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Xpos+=move;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Ypos-=move;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Ypos+=move;
        }

        SetCursorPos(Xpos, Ypos);

        if (CharacterSelectMenu.activeSelf)
        {
           
        }else if (CartSelectMenu.activeSelf)
        {

        }else if (StageSelectMenu.activeSelf)
        {

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                uICanvas.OnClick();
            }
        }
        
    }
}
