using UnityEngine;

public class OpenDoor2 : MonoBehaviour
{

    public GameObject meleeEnemy;
    public GameObject rangedEnemy;
    public GameObject door;
    public int killedEnemiesNeeded = 0;
    private int deadEnemies = 0;
    private bool open = false;



    private void Update()
    {
        if (deadEnemies == killedEnemiesNeeded)
        {
            if (!open)
            {
                open = true;
                door.GetComponent<OpenDoor>().OpenTheDoor();
            }
        }
    }

    public void EnemyDied()
    {
        print(deadEnemies);
        deadEnemies += 1;
    }
}
