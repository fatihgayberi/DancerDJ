using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiscControl : MonoBehaviour
{
    MusicEditor musicEditor;
    [SerializeField] GameObject[] dancerGirl;
    [SerializeField] GameObject dancer;
    [SerializeField] GameObject discController;
    [SerializeField] Slider comboBar;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        musicEditor = FindObjectOfType<MusicEditor>();
        animator = dancer.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Touch();
    }

    void Touch()
    {
        if (Input.GetMouseButton(0))
        {
            float x;

            x = Input.GetAxis("Mouse X");

            if (x > 0)
            {
                discController.transform.Rotate(0, 2f, 0, Space.World);
            }
            else if (x < 0)
            {
                discController.transform.Rotate(0, -2f, 0, Space.World);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.GetComponent<Image>().sprite == musicEditor.GetNoteInBoard())
        {
            string newAnimation;


            comboBar.value += 1;
            newAnimation = "Dance" + comboBar.value;
            animator.SetBool(newAnimation, true);

            if (comboBar.value == comboBar.maxValue)
            {

            }
        }
    }
}
