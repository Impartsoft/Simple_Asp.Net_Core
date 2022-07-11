
public class Rootobject
{
    public Logging Logging { get; set; }
    public string AllowedHosts { get; set; }
    public Connectionstrings ConnectionStrings { get; set; }
    public string Test1 { get; set; }
    public Test2 Test2 { get; set; }
}

public class Logging
{
    public Loglevel LogLevel { get; set; }
}

public class Loglevel
{
    public string Default { get; set; }
    public string Microsoft { get; set; }
    public string MicrosoftHostingLifetime { get; set; }
    public string MicrosoftEntityFrameworkCoreDatabaseCommand { get; set; }
}

public class Connectionstrings
{
    public string PostgereSql { get; set; }
}

public class Test2
{
    public string Test21 { get; set; }
}
