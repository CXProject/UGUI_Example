//---------------------------------------------------------------------------------------
// Author: xuan_chen_work@foxmail.com
// Date: 2021-10-18 16:48:18
// Name: CarvedScrollViewMover
//---------------------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.EventSystems;

namespace Carved_ScrollView_Example
{
    [RequireComponent(typeof(EventTrigger))]
    [RequireComponent(typeof(CarvedScrollViewSetting))]
    public class CarvedScrollViewMover : MonoBehaviour
    {
        [SerializeField] private ItemIconSetting IconPrefab;
        [SerializeField] private RectTransform AnchorPoint;
        [SerializeField] private RectTransform ItemContent;
        
        private EventTrigger m_Trigger;
        private CarvedScrollViewSetting m_Setting;

        private void Awake()
        {
            m_Trigger = GetComponent<EventTrigger>();
            m_Setting = GetComponent<CarvedScrollViewSetting>();
        }
    }
}


