/****************************************************
    文件：ResSys.cs
	作者：李俊祥
    邮箱: 2219385316@qq.com
    日期：#CreateTime#
	功能：资源加载模块
*****************************************************/

using UnityEngine;
using SLua;

namespace  UnityEngine
{
	[CustomLuaClass]
	public class ResSys : MonoBehaviour 
	{
		/// <summary>
		/// 加载Resources文件下制定路径及名字的Sprite图片
		/// </summary>
		public  Sprite ResourcesSprite(string path)
		{

			return Resources.Load<Sprite>(path);
		}
	}
}
