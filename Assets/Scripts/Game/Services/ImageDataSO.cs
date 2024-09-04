using UnityEngine;

namespace Game.Services
{
    [CreateAssetMenu(fileName = "ImageData", menuName = "Scriptable Objects/ImageData")]
    public class ImageDataSO : ScriptableObject
    {
        [Header("Red Cubes")]
        public Sprite redCube;
        public Sprite redCubeRocket;
        public Sprite redCubeBomb;
        public Sprite redCubeDisco;
        
        [Space, Header("Green Cubes")]
        public Sprite greenCube;
        public Sprite greenCubeRocket;
        public Sprite greenCubeBomb;
        public Sprite greenCubeDisco;
        
        [Space, Header("Blue Cubes")]
        public Sprite blueCube;
        public Sprite blueCubeRocket;
        public Sprite blueCubeBomb;
        public Sprite blueCubeDisco;
        
        [Space, Header("Yellow Cubes")]
        public Sprite yellowCube;
        public Sprite yellowCubeRocket;
        public Sprite yellowCubeBomb;
        public Sprite yellowCubeDisco;
        
        [Space, Header("Pink Cubes")]
        public Sprite pinkCube;
        public Sprite pinkCubeRocket;
        public Sprite pinkCubeBomb;
        public Sprite pinkCubeDisco;
        
        [Space, Header("Purple Cubes")]
        public Sprite purpleCube;
        public Sprite purpleCubeRocket;
        public Sprite purpleCubeBomb;
        public Sprite purpleCubeDisco;
        
        [Space, Header("Balloons")]
        public Sprite balloon;
        public Sprite balloonGreen;
        public Sprite balloonRed;
        public Sprite balloonBlue;
        public Sprite balloonYellow;
        public Sprite balloonPink;
        public Sprite balloonPurple;
        
        [Space, Header("Creates")]
        public Sprite createLayer1;
        public Sprite createLayer2;
        
        [Space, Header("Rockets")]
        public Sprite rocketVertical;
        public Sprite rocketHorizontal;
        
        [Space, Header("Bomb")]
        public Sprite bomb;
        
        [Space, Header("Disco")]
        public Sprite disco;
    }
}