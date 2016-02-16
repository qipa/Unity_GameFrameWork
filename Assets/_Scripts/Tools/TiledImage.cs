using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
[AddComponentMenu("UI/TiledImage")]
public class TiledImage : RawImage
{
    protected override void OnRectTransformDimensionsChange()
    {
        base.OnRectTransformDimensionsChange();
        Vector2 size = rectTransform.sizeDelta;
        this.uvRect = new Rect(0, 0, size.x / texture.width * canvas.scaleFactor, size.y / texture.height * canvas.scaleFactor);
    }
}
