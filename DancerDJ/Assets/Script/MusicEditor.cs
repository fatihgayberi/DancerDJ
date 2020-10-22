using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicEditor : MonoBehaviour
{
    [SerializeField] Sprite[] musicNotes;
    [SerializeField] GameObject noteBoard;
    [SerializeField] Slider notesTimer;
    Sprite boardInNote;

    // Start is called before the first frame update
    void Start()
    {
        NotesGenarator();
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    void Timer()
    {
        notesTimer.value -= Time.deltaTime;

        if (notesTimer.value <= 0)
        {
            NotesGenarator();
            notesTimer.value = notesTimer.maxValue;
        }
    }

    void NotesGenarator()
    {
        int num = Random.Range(0, musicNotes.Length);
        boardInNote = musicNotes[num];
        Debug.Log("Num: " + num);

        noteBoard.GetComponent<Image>().sprite = boardInNote;
    }

    public Sprite GetNoteInBoard()
    {
        return boardInNote;
    }

}
