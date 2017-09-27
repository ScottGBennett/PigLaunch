using System;
using UnityEngine;

namespace Assets.FantasyMonsters.Scripts
{
    /// <summary>
    /// Take a screnshoot in play mode [S]
    /// </summary>
    public class Screenshot : MonoBehaviour
    {
        public int SuperSize = 1;

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                var filename = Convert.ToString(DateTime.Now).Replace("/", "-").Replace(":", "-") + ".png";

                ScreenCapture.CaptureScreenshot(filename, SuperSize);
                Debug.Log(filename);
            }
        }
    }
}