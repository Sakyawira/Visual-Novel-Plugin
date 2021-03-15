/***********************
  File Name   :   Choice.cs
  Description :   define the variables controlled by a choice, each choice the player makes will decide the dialogue branch they will go to and the story tag they will get
  Author/s    :   Sakyawira Nanda Ruslim
  Mail        :   Sakyawira@gmail.com
********************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Choice
{
    public string ChoiceText;
    public List<Line> DialogueBranch;
    public string Tag;
}