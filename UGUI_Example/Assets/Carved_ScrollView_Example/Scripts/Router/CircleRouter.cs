//---------------------------------------------------------------------------------------
// Author: xuan_chen_work@foxmail.com
// Date: 2021-10-18 19:00:01
// Name: CricleRouter
//---------------------------------------------------------------------------------------

using System;
using UnityEngine;

namespace Carved_ScrollView_Example
{
    public class CircleRouter : MonoBehaviour, IRouter
    {
        [SerializeField] private Transform CenterPoint;
        [SerializeField] private float Radius;
        

        public Vector3 GetPos(float ratio)
        {
            var ang = ratio * 2 * Mathf.PI;
            var res = CenterPoint.position;
            res.x += Mathf.Sin(ang) * Radius;
            res.y += Mathf.Cos(ang) * Radius;
            return res;
        }

        private void OnDrawGizmos()
        {
            if(CenterPoint == null) return;
            Gizmos.color = Color.red;
            var add = 1f / 72f;
            var count = 0f;
            while (count < 1)
            {
                Gizmos.DrawLine(GetPos(count), GetPos(count + add));
                count += add;
            }
            Gizmos.DrawLine(GetPos(count), GetPos(0));
        }
    }
}