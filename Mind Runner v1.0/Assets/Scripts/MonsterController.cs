using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float moveSpeed;
    private float moveSpeedStore;
    public float speedMultiplier;

    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;

    private float speedMilestoneCount;
    private float speedMilestoneCountStore;

    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        speedMilestoneCount = speedIncreaseMilestone;

        moveSpeedStore = moveSpeed;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;
        speedMilestoneCountStore = speedMilestoneCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveSpeed < 14)
        {
            if (transform.position.x > speedMilestoneCount)
            {
                speedMilestoneCount += speedIncreaseMilestone;

                speedIncreaseMilestone *= speedMultiplier;

                moveSpeed *= speedMultiplier;
            }
        }
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(moveSpeed, rigidBody.velocity.y);
    }

    public void ResetSpeed()
    {
        moveSpeed = moveSpeedStore;
        speedIncreaseMilestone = speedIncreaseMilestoneStore;
        speedMilestoneCount = speedMilestoneCountStore;
    }
}
