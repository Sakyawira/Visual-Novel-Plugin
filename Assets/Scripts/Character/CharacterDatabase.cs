using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Character Database", fileName = "New Character Database")]
public class CharacterDatabase : ScriptableObject
{
    public List<Character> Characters;
}
