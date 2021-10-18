//---------------------------------------------------------------------------------------
// Author: xuan_chen_work@foxmail.com
// Date: 2021-10-18 14:41:23
// Name: CarvedScrollViewSetting
//---------------------------------------------------------------------------------------
using System.Collections.Generic;
using UnityEngine;

namespace Carved_ScrollView_Example
{
    [RequireComponent(typeof(RectTransform))]
internal class CarvedScrollViewSetting : MonoBehaviour
{
    [Tooltip("X向偏移百分比")]
    public AnimationCurve OffsetCurve;
    [Tooltip("Y向基本间隔大小")]
    public float SpacingRatio;
    [Tooltip("Y向间隔调整大小")]
    public AnimationCurve SpacingCurve;
    [Tooltip("Scale值百分比")]
    public AnimationCurve ScaleCurve;
    [Tooltip("alpha值百分比")]
    public AnimationCurve AlphaCurve;

#if DEBUG
    private RectTransform panel;
    private List<Vector3> _posTopList = new List<Vector3>();
    private List<Vector3> _posDownList = new List<Vector3>();
    [SerializeField]
    private float size = 100f;
    //[SerializeField]
    private float Height;
    //[SerializeField]
    private float Width;
    //[SerializeField]
    private float Spacing;

    private Vector3[] ConPos;
    
    private void OnDrawGizmos()
    {
        if (OffsetCurve == null) return;
        if (SpacingCurve == null) return;
        if (ScaleCurve == null) return;
        if (AlphaCurve == null) return;
        
        _posTopList.Clear();
        _posDownList.Clear();
        if (panel == null)
            panel = GetComponent<RectTransform>();
        ConPos = new Vector3[4];
        panel.GetWorldCorners(ConPos);
        Height = ConPos[1].y - ConPos[0].y;
        Width = ConPos[2].x - ConPos[1].x;
        Spacing = Mathf.Clamp(SpacingRatio, 0.01f, 1f) * Height;
        _posTopList.Add(transform.position);
        _posDownList.Add(transform.position);
        Vector3 tempPos;
        float yRatio;
        //向上找上限
        do
        {
            tempPos = _posTopList[_posTopList.Count - 1] + new Vector3(0, Spacing);
            _posTopList.Add(tempPos);
        } while (tempPos.y < ConPos[1].y + Spacing);
        //向下找下限
        do
        {
            tempPos = _posDownList[_posDownList.Count - 1] + new Vector3(0, -Spacing);
            _posDownList.Add(tempPos);
        } while (tempPos.y > ConPos[0].y - Spacing);

        //设置每个点的具体位置和UI大小
        //设置原点
        _posTopList[0] = SetPreview(transform.position);
        _posDownList[0] = _posTopList[0];
        //设置向上的点
        Vector3 pos = _posTopList[0];
        for (int i = 1; i < _posTopList.Count; i++)
        {
            yRatio = (ConPos[1].y - _posTopList[i].y) / Height;
            pos.y += Spacing * (1 + SpacingCurve.Evaluate(yRatio));
            //Debug.LogWarning($"Pre:{yRatio}/{Spacing * (1 + SpacingCurve.Evaluate(yRatio))}");
            _posTopList[i] = SetPreview(pos);

            Gizmos.color = Color.green;
            Gizmos.DrawLine(_posTopList[i - 1], _posTopList[i]);
        }

        pos = _posDownList[0];
        for (int i = 1; i < _posDownList.Count; i++)
        {
            yRatio = (ConPos[1].y - _posDownList[i].y) / Height;
            pos.y -= Spacing * (1 + SpacingCurve.Evaluate(yRatio));
            //FrameWork.LogUtils.Log(Spacing * (1 + SpacingCurve.Evaluate(yRatio)));
            _posDownList[i] = SetPreview(pos);

            Gizmos.color = Color.green;
            Gizmos.DrawLine(_posDownList[i - 1], _posDownList[i]);
        }
    }

    private Vector3 SetPreview(Vector3 pos)
    {
        var yRatio = (ConPos[1].y - pos.y) / Height;
        pos.x = (1 - OffsetCurve.Evaluate(yRatio)) * Width;
        Gizmos.color = Color.red + new Color(0, 0, 0, AlphaCurve.Evaluate(yRatio) - 1);
        //Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pos, size * ScaleCurve.Evaluate(yRatio) / 2);
        return pos;
    }

#endif
}
}


