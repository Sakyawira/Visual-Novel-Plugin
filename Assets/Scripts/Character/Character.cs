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

//[System.Serializable]
//public struct EmotionSprites
//{
//    public Emotion emotion;
//    public Sprite sprite;
//}

//[System.Serializable]
//public class DictionaryOfStringAndInt : SerializableDictionary<string, int> { }

[System.Serializable]
public struct Character
{
    // public EmotionSprites[] Emotions;
    // int ayam;
    //public DictionaryOfStringAndInt EmotionSprites;
   
    public string Name;

    public Sprite Neutral;
    public Sprite Angry;
    public Sprite Happy;
    public Sprite Joy;
    public Sprite Sad;
}