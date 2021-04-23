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
    Sad,
    Annoyed,
    Shocked,
    Sleepy,
    Sweat,
    Smug,
    Laugh,
    Sweet
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

    // 1
    public Sprite Neutral;
    // 2
    public Sprite Angry;
    // 3
    public Sprite Happy;
    // 4
    public Sprite Joy;
    // 5
    public Sprite Sad;
    // 6
    public Sprite Annoyed;
    // 7
    public Sprite Shocked;
    // 8
    public Sprite Sleepy;
    // 9
    public Sprite Sweat;
    // 10
    public Sprite Smug;
    // 11
    public Sprite Laugh;
    // 12
    public Sprite Sweet;
}