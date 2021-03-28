public class GameManager
{
    private static GameManager _instance;
    private int _currentLevelId;
    public int CurrentLevelId
    {
        get
        {
            return _currentLevelId;
        }
        set
        {
            _currentLevelId = value;
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameManager();
            }
            return _instance;
        }
    }

	public void SetGameplayScene(int id)
	{		
		CurrentLevelId = id;
	}
}
