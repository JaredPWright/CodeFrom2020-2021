 public static bool[] versesHeard;
    [SerializeField] private bool hasWon = true;

    void Awake()
    {
        versesHeard = new bool[7];

        for(int i = 0; i < versesHeard.Length; i++)
        {
            versesHeard[i] = false;
        }
    }

    void Update()
    {
        for(int i = 0; i < versesHeard.Length; i++)
        {
            if(!versesHeard[i])
            {
                hasWon = false;
                break;
            }
        }

        if(hasWon)
        {
            Invoke("QuitGame", 10f);
        }
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MenuScreen");
    }