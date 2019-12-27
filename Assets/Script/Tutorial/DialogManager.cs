using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text name;
    public Text dialog;
    private Queue<string> sentences;
    public Animator animator;
    public Animation animation;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

    }
    public void StartDialog(ObjectDialog dialog) {
        animator.SetBool("isOpen", true);
        print(animator.GetBool("isOpen"));
        while (animator.GetBool("isOpen") == false)
        {
            print("lalala");
            Time.timeScale = 1;
        }
        Time.timeScale = 0;
        name.text = dialog.name;

        sentences.Clear();
        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);

        }
        DisplayNextSentence();

    }
     public void DisplayNextSentence()
    {
        if (sentences.Count == 0) {
            EndDialog();
            print("be");
            return;
            
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
     
      
    }
    IEnumerator TypeSentence(string sentence) {
        dialog.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialog.text += letter;
            yield return null;
        }
        }
        IEnumerator SpeedOfGame()
        {
            while (Time.timeScale < 1) {
            
                Time.timeScale = Time.timeScale + 0.01f;
            print(Time.timeScale);
            yield return null;
            }
            

        }
    void EndDialog() {
        Time.timeScale = 0.3f;
            StartCoroutine(SpeedOfGame());
        animator.SetBool("isOpen", false);
        
        print("lolll");
      //  GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(false);
       
    }
}
