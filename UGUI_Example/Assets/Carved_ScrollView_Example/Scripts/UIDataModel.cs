//---------------------------------------------------------------------------------------
// Author: xuan_chen_work@foxmail.com
// Date: 2021-10-18 16:14:47
// Name: UIDataModel
//---------------------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

namespace Carved_ScrollView_Example
{
    internal class UIDataModel : MonoBehaviour
    {
        [SerializeField]private List<string> _itemList;
        private List<ItemData> _datas;
        public IEnumerable<ItemData> ItemList => _datas;
        public static UIDataModel Instance;

        private void Awake()
        {
            if(Instance != null)
                Destroy(this);
            else
                Instance = this;

            _datas = new List<ItemData>();
            foreach (var name in _itemList)
            {
                _datas.Add(new ItemData(name));
            }
        }
    }
}