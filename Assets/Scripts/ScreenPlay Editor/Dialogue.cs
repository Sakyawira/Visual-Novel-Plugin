/***********************
  File Name   :   Dialogue.cs
  Description :   define a system to render the text, image (based on character name and emotion), and choices of a line of a dialogue
  Author/s    :   Sakyawira Nanda Ruslim
  Mail        :   Sakyawira@gmail.com
********************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public struct Line
{
    public string CharacterName; 
    public Emotion CharacterEmotion;
    // public AudioClip talkingClip;
    public string talkingText;
}

public class Dialogue : MonoBehaviour
{
    // To take the created ScriptableObject database
    public CharacterDatabase CharacterDB;

    // Scripting System
    public List<Line> DialogueLines;
    public List<Choice> Choices;

    // Audio
    public AudioClip TextBGM;
    private AudioSource TextVoice;
    private AudioSource SFXSource;

    // Text
    public GameObject dialogueBox;
    public GameObject choiceBox;
    public GameObject choiceBox2;
    public string currentText = "";
    private bool isTextTime = true;
    private int m = 0;

    // Character Sprite
    private Image spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        SFXSource = GetComponent<AudioSource>();
        TextVoice = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<Image>();
        m = 0;
    }

    void NextScene()
    {
        // Add Script to go to the next level
        string NextLevel = GameObject.Find("Branches").GetComponent<StoryTags>().GetNextLevel();
        SceneManager.LoadScene(NextLevel);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (m < DialogueLines.Count && isTextTime)
            {
                Skip();
            }
            else if (m == DialogueLines.Count && Choices.Count == 0)
            {
                NextScene();
            }
        }

        if (m == DialogueLines.Count && Choices.Count != 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                DialogueLines = Choices[0].DialogueBranch;

                GameObject.Find("Player").GetComponent<PlayerTags>().AddTag(Choices[0].Tag);

                Choices.Clear();
                m = 0;
                if (DialogueLines.Count != 0)
                {
                    Skip();
                }
                else 
                {
                    NextScene();
                }
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                DialogueLines = Choices[1].DialogueBranch;

                GameObject.Find("Player").GetComponent<PlayerTags>().AddTag(Choices[1].Tag);

                Choices.Clear();
                m = 0;
                if (DialogueLines.Count != 0)
                {
                    Skip();
                }
                else
                {
                    NextScene();
                }
            }
        }
    }

    public void Continue()
    {
        if (m < DialogueLines.Count && isTextTime)
        {
            Skip();
        }
        else if (m == DialogueLines.Count && Choices.Count == 0)
        {
            NextScene();
        }
    }

    public void MakeChoice(int _choiceNumber)
    {
        DialogueLines = Choices[_choiceNumber].DialogueBranch;

        GameObject.Find("Player").GetComponent<PlayerTags>().AddTag(Choices[_choiceNumber].Tag);

        Choices.Clear();
        m = 0;
        if (DialogueLines.Count != 0)
        {
            Skip();
        }
        else
        {
            NextScene();
        }
    }

    void Skip()
    {
        PlayText();
        ChangeSprite();
        ShowChoice();
        m++;
    }

    void PlayText()
    {
        isTextTime = false;
        StartCoroutine(ShowText(DialogueLines[m].talkingText));
    }

    void ChangeSprite()
    {
         Character iCharacter = CharacterDB.Characters.Find(x => x.Name == DialogueLines[m].CharacterName);

        switch (DialogueLines[m].CharacterEmotion)
        {
            case Emotion.Neutral:
                spriteRenderer.sprite = iCharacter.Neutral;
                break;
            case Emotion.Angry:
                spriteRenderer.sprite = iCharacter.Angry;
                break;
            case Emotion.Happy:
                spriteRenderer.sprite = iCharacter.Happy;
                break;
            case Emotion.Joy:
                spriteRenderer.sprite = iCharacter.Joy;
                break;
            case Emotion.Sad:
                spriteRenderer.sprite = iCharacter.Sad;
                break;
        }
    }

    IEnumerator ShowText(string Text)
    {
        for (int i = 0; i <= Text.Length; i++)
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

    void ShowChoice()
    {
        if (m == DialogueLines.Count - 1)
        {
            if (Choices.Count != 0)
            {
                choiceBox.GetComponent<Text>().text = "Q. " + Choices[0].ChoiceText; //currentChoices;
                choiceBox2.GetComponent<Text>().text = "E. " + Choices[1].ChoiceText;
            }
        }
        else
        {
            choiceBox.GetComponent<Text>().text = "";
            choiceBox2.GetComponent<Text>().text = "";
        }
    }
}

