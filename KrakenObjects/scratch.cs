public class Result
{
    #region Public Properties

    public string last { get; set; }
    public object[][] XXBTZUSD { get; set; }

    #endregion Public Properties
}

public class Rootobject
{
    #region Public Properties

    public object[] error { get; set; }
    public Result result { get; set; }

    #endregion Public Properties
}