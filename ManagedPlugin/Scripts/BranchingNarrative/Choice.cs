using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace VNPlugin
{
    [System.Serializable]
    public struct Choice
    {
        public string ChoiceText;
        public List<Line> DialogueBranch;
        public string Tag;
    }
}

