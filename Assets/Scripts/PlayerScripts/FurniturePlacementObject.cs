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

    // Start is called before the first frame update
    void Start()
    {
        thisSprite = PlacementTracker.GetComponent<SpriteRenderer>();
        thisSprite.color = new Color(thisSprite.color.r, thisSprite.color.g, thisSprite.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        PlacementTracker.transform.position = mousePosition;
        Furniture = CursorLock.instance.Furniture;
        thisSprite = CursorLock.instance.cursorObject.GetComponent<SpriteRenderer>();
        thisSprite.sprite = Furniture.sprite;
        thisSprite.color = new Color(thisSprite.color.r, thisSprite.color.g, thisSprite.color.b, .5f);

    }
}
