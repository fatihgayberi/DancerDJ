using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicEditor : MonoBehaviour
{
    DiscControl discControl;

    [SerializeField] Sprite[] musicNotes;
    [SerializeField] GameObject noteBoard;
    [SerializeField] Slider notesTimer;
    Sprite boardInNote;

    // Start is called before the first frame update
    void Start()
    {
        discControl = FindObjectOfType<DiscControl>();
        NotesGenarator();
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    // nota degisimi icin sayac dondurur
    void Timer()
    {
        notesTimer.value -= Time.deltaTime;

        if (notesTimer.value <= 0) // sayaci sifirlar
        {
            NotesGenarator();
            notesTimer.value = notesTimer.maxValue;
            discControl.DiscDjActivator(true);
        }
    }

    // random nota olusturur
    void NotesGenarator()
    {
        int num = Random.Range(0, musicNotes.Length);
        boardInNote = musicNotes[num];
        noteBoard.GetComponent<Image>().sprite = boardInNote;
    }

    // ekrandaki notayi return eder
    public Sprite GetNoteInBoard()
    {
        return boardInNote;
    }

}
