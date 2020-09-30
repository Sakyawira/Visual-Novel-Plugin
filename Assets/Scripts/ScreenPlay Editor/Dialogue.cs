using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Line
{
    public Sprite characterSprite;
    public AudioClip talkingClip;
    public string talkingText;
}

public class Dialogue : MonoBehaviour
{
    // Scripting System
    public Line[] DialogueLines;

    // Audio
    public AudioClip TextBGM;
    private AudioSource TextVoice;
    private AudioSource SFXSource;

    // Text
    public GameObject dialogueBox;
    public string currentText = "";
    private bool isTextTime = true;
    private int m = 0;

    // Character Sprite
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        SFXSource = GetComponent<AudioSource>();
        TextVoice = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        m = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (m < DialogueLines.Length && isTextTime)
            {
                PlayText();
                ChangeSprite();
                m++;
            }
        }
    }

    void PlayText()
    {
        isTextTime = false;
        // TalkingSource.PlayOneShot(DialogueLines[m].talkingClip);
        StartCoroutine(ShowText(DialogueLines[m].talkingText));
    }

    void ChangeSprite()
    {
        spriteRenderer.sprite = DialogueLines[m].characterSprite;
    }

    IEnumerator ShowText(string Text)
    {
        for (int i = 0; i < Text.Length; i++)
        {
            TextVoice.PlayOneShot(TextBGM);
            currentText = Text.Substring(0, i);
            dialogueBox.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(0.07f);
            if (i == Text.Length - 1)
            {
                isTextTime = true;
            }
        }
    }
}

