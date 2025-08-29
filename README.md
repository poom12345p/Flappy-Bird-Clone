## Technical decisions
## Core Structure
```mermaid
graph TD;
    GameManager-->MainMenuStateManager
    MainMenuStateManager --> MainMenuUI
    GameManager-->GamePlayStateManager
    GameManager-->PlayerControl
    GameManager-->ScoreSaveControl
    GamePlayStateManager-->ObstacleManager
    GamePlayStateManager-->ScoreManager
    GamePlayStateManager-->PlayerInputControl
    GamePlayStateManager-->ResultUI
    ScoreManager-->ScoreUI
```
This Diagram show how each class Relate to each other,class below will be controled by above class
##  Sigleton
```mermaid
classDiagram
    BaseSingleton <|-- GameManager
    BaseSingleton <|-- SoundManager
    BaseSingleton <|-- ObjectPoolManager
    class  BaseSingleton{
      +T Instance
      +OnInitialize()
    }
    class  GameManager{
      +StartGame()
      +GoToMainMenu()
      +SaveScore()
    }
    class ObjectPoolManager{
      +Get(IPoolable)
      +Release(IPoolable)
    }
     class SoundManager{
      +PlayBGM(AudioClip)
      +PlaySound(AudioClip)
    }
```
- I decided to implement a base Singleton class to simplify the creation of singleton-behavior managers across the game. The main managers that use this pattern are:
    - GameManager → Controls overall game flow and sections (state management).
    - SoundManager → Handles background music, SFX, and volume settings.
    - ObjectPoolManager → Manages reusable objects through pooling, avoiding costly Instantiate/Destroy operations.
- Pros
    - Using Sigleton make it s easly to control and acess variable.
- Cons
    - need to understart what class should be or shouldn't be sigleton, and need to careful with memory leak and initalize sequnce if not manager properly.
## SoundManager
## ObjectPoolManager
## State Manager 
```mermaid
classDiagram
    GameManager --> StateManager
    StateManager <|-- GamePlayStateManager
    StateManager <|-- MainMenuStateManager
    class StateManager{
      +InitState()
      +EnterState()
      +ExitState()()
    }
    class  GameManager{
      -GoToState(StateManage)
    }
```

