using UnityEngine;

public enum PlayerState {
    Alive,
    Death
}
public enum EnemyShape {
    Square,
    Diamond,
    Triangle,
    Rectangle,
    Ready
}
public enum GameState { 
    Start,
    Play,
    End
}
public delegate void ClampPosition (Transform obj );
    public class Delegate {
        public static ClampPosition cantExitDelegate;
    }
