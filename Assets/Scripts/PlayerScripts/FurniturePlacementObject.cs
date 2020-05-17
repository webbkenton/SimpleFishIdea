using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FurniturePlacementObject : MonoBehaviour
{
    static Vector3 mousePosition;
    public GameObject PlacementTracker;
    public FurnitureScriptableObject Furniture;
    private SpriteRenderer thisSprite;
    private Image SpriteImage;

    // Start is called before the first frame update
    void Start()
    {
        SpriteImage = this.GetComponent<Image>();
        thisSprite = PlacementTracker.GetComponent<SpriteRenderer>();
        thisSprite.color = new Color(thisSprite.color.a, thisSprite.color.b, thisSprite.color.g, 0);
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        PlacementTracker.transform.position = mousePosition;

        if (CursorLock.instance.cursorObject.activeInHierarchy)
        {
            Furniture = CursorLock.instance.Furniture;
            thisSprite = CursorLock.instance.cursorObject.GetComponent<SpriteRenderer>();
            thisSprite.color = new Color(thisSprite.color.a, thisSprite.color.b, thisSprite.color.g, 125);
            SpriteImage.sprite = CursorLock.instance.ObjectRenderer.sprite;

        }
    }
}
