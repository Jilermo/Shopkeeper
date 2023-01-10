using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

// This is only useful for spritesheets that need to be automatically sliced (Sprite Editor > Slice > Automatic)
public class AutoSpriteSlicer
{
	[MenuItem("Tools/Slice Spritesheets %&s")]
	public static void Slice()
	{
		var textures = Selection.GetFiltered<Texture2D>(SelectionMode.Assets);

		foreach (var texture in textures)
		{
			ProcessTexture(texture);
			ProcessTexture(texture);
		}
	}

	static void ProcessTexture(Texture2D texture)
	{
		string path = AssetDatabase.GetAssetPath(texture);
		var importer = AssetImporter.GetAtPath(path) as TextureImporter;

		//importer.isReadable = true;
		importer.textureType = TextureImporterType.Sprite;
		importer.spriteImportMode = SpriteImportMode.Multiple;
		importer.mipmapEnabled = false;
		importer.filterMode = FilterMode.Point;
		importer.spritePivot = Vector2.down;
		importer.textureCompression = TextureImporterCompression.Uncompressed;

		var textureSettings = new TextureImporterSettings(); // need this stupid class because spriteExtrude and spriteMeshType aren't exposed on TextureImporter
		importer.ReadTextureSettings(textureSettings);
		textureSettings.spriteMeshType = SpriteMeshType.Tight;
		textureSettings.spriteExtrude = 0;

		importer.SetTextureSettings(textureSettings);

		//methos for splicing objects

		
		int minimumSpriteSize = 1;
		int extrudeSize = 0;

		Rect[] rects = InternalSpriteUtility.GenerateAutomaticSpriteRectangles(texture, minimumSpriteSize, extrudeSize);
		var rectsList = new List<Rect>(rects);
		rectsList = SortRects(rectsList, texture.width);

		string filenameNoExtension = Path.GetFileNameWithoutExtension(path);
		var metas = new List<SpriteMetaData>();
		int rectNum = 0;

		foreach (Rect rect in rectsList)
		{
			var meta = new SpriteMetaData();
			meta.pivot = Vector2.down;
			meta.alignment = (int)SpriteAlignment.BottomCenter;
			meta.rect = rect;
			meta.name = filenameNoExtension + "_" + rectNum++;
			metas.Add(meta);
		}


		/*
		//Method for splicing character related textures
		int spriteSizeX = 48;
		int spriteSizeY = 96;

		List<SpriteMetaData> metas = new List<SpriteMetaData>();

		for (int c = 0; c < 24; ++c)
		{
			SpriteMetaData meta = new SpriteMetaData();
			meta.rect = new Rect(c * spriteSizeX, 1680, spriteSizeX, spriteSizeY);
			meta.name = 1 + "-" + c;
			metas.Add(meta);
		}

		for (int c = 0; c < 4; ++c)
		{
			SpriteMetaData meta = new SpriteMetaData();
			meta.rect = new Rect(c * spriteSizeX, 1680+48*4, spriteSizeX, spriteSizeY);
			meta.name = 0 + "-" + c;
			metas.Add(meta);
		}*/

		importer.spritesheet = metas.ToArray();

		AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);

		
	}

	static List<Rect> SortRects(List<Rect> rects, float textureWidth)
	{
		List<Rect> list = new List<Rect>();
		while (rects.Count > 0)
		{
			Rect rect = rects[rects.Count - 1];
			Rect sweepRect = new Rect(0f, rect.yMin, textureWidth, rect.height);
			List<Rect> list2 = RectSweep(rects, sweepRect);
			if (list2.Count <= 0)
			{
				list.AddRange(rects);
				break;
			}
			list.AddRange(list2);
		}
		return list;
	}

	static List<Rect> RectSweep(List<Rect> rects, Rect sweepRect)
	{
		List<Rect> result;
		if (rects == null || rects.Count == 0)
		{
			result = new List<Rect>();
		}
		else
		{
			List<Rect> list = new List<Rect>();
			foreach (Rect current in rects)
			{
				if (current.Overlaps(sweepRect))
				{
					list.Add(current);
				}
			}
			foreach (Rect current2 in list)
			{
				rects.Remove(current2);
			}
			list.Sort((a, b) => a.x.CompareTo(b.x));
			result = list;
		}
		return result;
	}
}
