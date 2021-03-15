/***********************
  File Name   :   CharacterDatabase.cs
  Description :   define a Scritable Object where player can store Characters, to then be used in the ScreenPlay setup
  Author/s    :   Sakyawira Nanda Ruslim
  Mail        :   Sakyawira@gmail.com
********************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Character Database", fileName = "New Character Database")]
public class CharacterDatabase : ScriptableObject
{
    public List<Character> Characters;
}