using UnityEngine;

namespace Cafe.Devices
{
    public class SpriteCutter
    {
        public GameObject[] CutSprite(SpriteRenderer spriteRenderer, Vector2 spritePosition, Vector2 cutStart,
            Vector2 cutEnd)
        {
            var spriteToCut = spriteRenderer.sprite;
            var verticalCenter = spriteToCut.rect.height / 2;
            var horizontalCenter = spriteToCut.rect.width / 2;
            var verticalOffset = spriteToCut.rect.height - cutStart.y;
            var horizontalOffset = spriteToCut.rect.width - cutEnd.x;

            var upperSprite = Sprite.Create(
                spriteToCut.texture,
                new Rect(
                    spriteToCut.rect.x + horizontalCenter - horizontalOffset,
                    spriteToCut.rect.y + verticalCenter - verticalOffset,
                    spriteToCut.rect.width,
                    verticalCenter + verticalOffset),
                Vector2.zero,
                spriteToCut.pixelsPerUnit,
                0,
                SpriteMeshType.FullRect);

            var lowerSprite = Sprite.Create(
                spriteToCut.texture,
                new Rect(
                    spriteToCut.rect.x,
                    spriteToCut.rect.y,
                    horizontalCenter - horizontalOffset,
                    verticalCenter - verticalOffset),
                Vector2.zero,
                spriteToCut.pixelsPerUnit,
                0,
                SpriteMeshType.FullRect);

            var upperBody = new GameObject("upper body");
            var lowerBody = new GameObject("lower body");

            var upperBodyRenderer = upperBody.AddComponent<SpriteRenderer>();
            upperBodyRenderer.sprite = upperSprite;
            upperBodyRenderer.material = spriteRenderer.material;

            var lowerBodyRenderer = lowerBody.AddComponent<SpriteRenderer>();
            lowerBodyRenderer.sprite = lowerSprite;
            lowerBodyRenderer.material = spriteRenderer.material;

            var xPivotInUnits = spriteToCut.pivot.x / spriteToCut.pixelsPerUnit;
            var yPivotInUnits = spriteToCut.pivot.y / spriteToCut.pixelsPerUnit;

            upperBody.transform.position = spritePosition - new Vector2(
                xPivotInUnits,
                -(lowerSprite.rect.height / spriteToCut.pixelsPerUnit) + yPivotInUnits);

            lowerBody.transform.position = spritePosition - new Vector2(xPivotInUnits, yPivotInUnits);

            return new GameObject[] { upperBody, lowerBody };
        }
    }
}