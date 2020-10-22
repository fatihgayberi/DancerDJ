using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiscControl : MonoBehaviour
{
    MusicEditor musicEditor;
    [SerializeField] GameObject[] dancerGirl;
    [SerializeField] GameObject dancer;
    [SerializeField] GameObject canvasObj;
    [SerializeField] GameObject discController;
    [SerializeField] Slider comboBar;

    Animator animator;
    int animNum;

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

    // diski saga sola dondurme islemini gerceklestirir
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

    // diskin ignesinin degdigi objeleri kontrol eder
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.GetComponent<Image>().sprite == musicEditor.GetNoteInBoard())
        {
            comboBar.value += 1;

            DiscDjActivator(false);
            AnimationEditor();

            if (comboBar.value == comboBar.maxValue) // eslestirmeleri tamamlarsa Winner durumuna gecer
            {
                Win();
                canvasObj.SetActive(false);
            }
        }
    }

    // ekrandaki danscilari aktif eder
    void Win()
    {
        for (int i = 0; i < dancerGirl.Length; i++)
        {
            dancerGirl[i].SetActive(true);
        }
    }

    // ignenin true ve false olmasini saglar
    public void DiscDjActivator(bool mode)
    {
        gameObject.GetComponent<Collider>().enabled = mode;
    }

    // animasyonlari oynatir
    void AnimationEditor()
    {
        string newAnimation;
        animNum++;
        newAnimation = "Dance" + animNum;
        animator.SetBool(newAnimation, true);
    }
}
