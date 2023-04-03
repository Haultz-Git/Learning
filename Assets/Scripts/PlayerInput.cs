using UnityEngine;


public enum Lanes
{
    left, centre, right
}
public class PlayerInput : MonoBehaviour
{
    [SerializeField] Transform[] lanesTransform;
    Lanes currentlane;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Sprite[] sprites;


    private float playerPositionY;
    // Start is called before the first frame update
    void Start()
    {
        MorphShape();

        currentlane = global::Lanes.centre;
        playerPositionY=transform.position.y;
    }
    private void MorphShape()
    {
        //Assign a sprite for the player
        int rand =Random.Range(0, sprites.Length);
        _spriteRenderer.sprite = sprites[rand];
        switch (rand)
        {
            case 0:
                gameObject.tag = "Circle";
                break;

            case 1:
                gameObject.tag = "Square";
                break;
            case 2:
                gameObject.tag = "Triangle";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
    }
    private void MoveLeft()
    {
        switch (currentlane)
        {
            case (global::Lanes.left):
                return;
            case (global::Lanes.centre):
                currentlane = global::Lanes.left;
                transform.position = new Vector3(lanesTransform[0].position.x, playerPositionY, 0);
                return;
            case (global::Lanes.right):
                currentlane = global::Lanes.centre;
                transform.position = new Vector3(lanesTransform[1].position.x, playerPositionY, 0);
                return;
        }
    }
    private void MoveRight()
    {
        switch (currentlane)
        {
            case (global::Lanes.left):
                currentlane = global::Lanes.centre;
                transform.position = new Vector3(lanesTransform[1].position.x, playerPositionY, 0);
                return;
            case (global::Lanes.centre):
                currentlane = global::Lanes.right;
                transform.position = new Vector3(lanesTransform[2].position.x, playerPositionY, 0);
                return;
            case (global::Lanes.right):
                return;
        }
    }
}
