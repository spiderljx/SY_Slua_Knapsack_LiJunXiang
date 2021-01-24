/****************************************************
    文件：KnapsackSys.cs
	作者：李俊祥
    邮箱: 2219385316@qq.com
    日期：#CreateTime#
	功能：背包系统
*****************************************************/

using UnityEngine;
using SLua;
using System;
using UnityEngine.Events;
using UnityEngine.UI;

[CustomLuaClass]
public class GameRoot : MonoBehaviour
{


	[CustomLuaClass]
	private delegate void updateDelegate(object self);

	private updateDelegate update;

	[CustomLuaClass]
	private delegate void Test();

	private Test test;


	// 背包模块
	private LuaSvr knapsackSvr;
	private LuaTable luaText;
	private LuaFunction luaUpdate;
	private LuaFunction luatestFunction;

	// 其他模块  todo


	private void Start()
	{
		SetGridLayoutCellSize();
		// 初始化背包模块
		knapsackSvr = new LuaSvr();
		knapsackSvr.init(null, () =>
		{
			luaText = (LuaTable) knapsackSvr.start("lua/KnapsackSys");
			luaUpdate = (LuaFunction) luaText["update"];
			update = luaUpdate.cast<updateDelegate>();

			// c#调用lua 
			luatestFunction = (LuaFunction) luaText["Test"];
			test = luatestFunction.cast<Test>();
		});

	}

	#region 设置GridlayoutGroup组件属性
	private void SetGridLayoutCellSize()
	{
		float ScreenWidth = Screen.width;
		float cellSizeX = (ScreenWidth - 240 - _gridLayoutGroup.spacing.x * 4) / 5;
		_gridLayoutGroup.cellSize = new Vector2(cellSizeX, cellSizeX);
	}

	private void SetContentHeight(int length)
	{
		int row = (int)Mathf.Ceil( length / 5.0f );
		contentTransform.sizeDelta = new Vector2(contentTransform.sizeDelta.x,
			row * _gridLayoutGroup.cellSize.y + (row - 1) * _gridLayoutGroup.spacing.y);
	}
	
	#endregion


private void Update()
	{
		//SetGridLayoutCellSize();
		if (update != null)
		{
			update(luaText);
		}
//
//		if (Input.GetMouseButtonDown(1))
//		{
//			if (test != null)
//			{
//				test();
//			}
//			else
//
//			{
//				Debug.Log("null");
//			}
//
//		}
//		

	}


[SerializeField] private GridLayoutGroup _gridLayoutGroup;
[SerializeField] private RectTransform contentTransform;
}