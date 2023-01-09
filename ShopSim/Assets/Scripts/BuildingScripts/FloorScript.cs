using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    public List<Sprite> floorSprites;
    // Start is called before the first frame update
    void Start()
    {
        setFloorSprite(Random.Range(0, floorSprites.Count));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setFloorSprite(int _index)
    {
        if (_index>=0 && _index<floorSprites.Count)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = floorSprites[_index];
            }
        }
    }
}
