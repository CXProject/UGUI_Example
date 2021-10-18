//---------------------------------------------------------------------------------------
// Author: xuan_chen_work@foxmail.com
// Date: 2021-10-18 15:49:46
// Name: ItemIconSetting
//---------------------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;

namespace Carved_ScrollView_Example
{
    internal class ItemIconSetting : MonoBehaviour
    {
        public ItemData Data;
        public Image IconImage;

        private void OnEnable()
        {
            if (UIConfig.Instance.IconDict.TryGetValue(Data.IconName, out var sprite))
            {
                IconImage.sprite = sprite;
            }
            else
            {
                Debug.LogError("No exit Icon");
            }
        }
    }
}

