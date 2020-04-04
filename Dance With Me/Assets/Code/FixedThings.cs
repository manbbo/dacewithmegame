using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

[Serializable]
public class FixedThings
{
    public static Boolean firstTime = true, paused = false, prompting = true;
    public static int bestPoints = 0;
}

public class GetState
{
    public static Boolean getDamage = false;
    public static int speed = 1;

}
