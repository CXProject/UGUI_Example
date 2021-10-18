using System;
using System.Collections.Generic;
using UnityEngine;

namespace Carved_ScrollView_Example
{
    internal class UIConfig : MonoBehaviour
    {
        [SerializeField] private List<string> IconKeys;
        [SerializeField] private List<Sprite> IconVals;
        public static UIConfig Instance;
        public Dictionary<string, Sprite> IconDict;
    
        private void Awake()
        {
            if(Instance != null)
                Destroy(this);
            else
                Instance = this;

            IconDict = new Dictionary<string, Sprite>();
            for (int i = 0; i < IconKeys.Count; i++)
            {
                if (IconDict.ContainsKey(IconKeys[i]))
                {
                    Debug.LogError("Has same key");
                    continue;
                }

                if (i >= IconVals.Count)
                {
                    Debug.LogError("Over the val count");
                    break;
                }

                IconDict.Add(IconKeys[i], IconVals[i]);
            }
        }
    }
}

