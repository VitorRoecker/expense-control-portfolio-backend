namespace ExpenseControl.Infra.External_Dependence
{
    public class AppSettings
    {
        public ConnectionStrings? ConnectionStrings { get; set; }
        public Jwt? JWT { get; set; }
    }

    public class Jwt
    {
        public string? Key { get; set; }
    }

    public class ConnectionStrings
    {
        public string? Default { get; set; }
    }
}
