﻿using UnityEditor;
using UnityEngine;
using UnityPickers;
using UnityPickers.Utility;

namespace Editor.UnityPickers
{
	[CustomPropertyDrawer(typeof(AssetPickerAttribute))]
	[CustomPropertyDrawer(typeof(ScriptableObject), true)]
	public class AssetPickerDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var assetType = fieldInfo.FieldType;
			if (assetType.IsUnityCollection())
				assetType = assetType.GetElementType();

			var a = fieldInfo.GetAttribute<AssetPickerAttribute>();

			AssetPicker.ShowPropertyField(
				position, property, fieldInfo,
				label, assetType,
				he => a == null || he.Path.Contains(a.Path)
			);
		}

	}
}