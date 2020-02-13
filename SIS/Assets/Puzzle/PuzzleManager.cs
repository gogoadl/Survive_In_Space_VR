using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject[] beacons;
    public int isDoorOpen;

    // Start is called before the first frame update
    void Start()
    {
        isDoorOpen = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int x = 0;
        foreach(GameObject beacon in beacons) {
            if (beacon.GetComponent<Beacon>().isLightOn == 1) {
                x += 1;
            }
        }

        if (x == 3) {
            isDoorOpen = 1;
        }
    }
}
