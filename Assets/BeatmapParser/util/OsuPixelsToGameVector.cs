using UnityEngine;

namespace BeatmapParser.util
{
    public class OsuPixelsToGameVector
    {
        
        public static Vector2 ConvertToGameVector(Vector2 positionInOsuPixels, Camera mainCamera)
        {
            positionInOsuPixels.y =  384 - positionInOsuPixels.y;
            Vector2 gamePosition = positionInOsuPixels * GetScaleFactor();
            gamePosition.x -= ((512f*GetScaleFactor()) / 2);
            gamePosition.x += Screen.width / 2;
            
            gamePosition.y -= ((384f*GetScaleFactor()) / 2);
            gamePosition.y += Screen.height / 2;
            
            gamePosition = mainCamera.ScreenToWorldPoint(gamePosition);
            return gamePosition;
        }

        public static float GetScaleFactor()
        {
            float scaleFactor = 1f;
            
            if (Screen.width > Screen.height)
            {
                scaleFactor = Screen.height / 384f;
            }
            else
            {
                scaleFactor = Screen.width / 512f;
            }

            
            return scaleFactor - 0.2f;
        }
    }
}