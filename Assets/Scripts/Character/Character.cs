/***********************
  File Name   :   Character.cs
  Description :   define a Character struct and Emotion enum. This allow a Sprite to be assigned to each of the emotion.
  Author/s    :   Sakyawira Nanda Ruslim
  Mail        :   Sakyawira@gmail.com
********************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum Emotion
{
    Neutral,
    Angry,
    Happy,
    Joy,
    Sad
}

[System.Serializable]
public struct Character
{
    public string Name;
    public Sprite Neutral;
    public Sprite Angry;
    public Sprite Happy;
    public Sprite Joy;
    public Sprite Sad;
}