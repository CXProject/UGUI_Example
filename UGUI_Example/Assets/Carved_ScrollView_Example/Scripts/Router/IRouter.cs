//---------------------------------------------------------------------------------------
// Author: xuan_chen_work@foxmail.com
// Date: 2021-10-18 18:32:31
// Name: IRouter
//---------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Carved_ScrollView_Example
{
    internal interface IRouter
    {
        /// <summary>
        /// Get Position by ratio
        /// </summary>
        /// <param name="ratio">0-1</param>
        /// <returns></returns>
        public Vector3 GetPos(float ratio);
    }
}

