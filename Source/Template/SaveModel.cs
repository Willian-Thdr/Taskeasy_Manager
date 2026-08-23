public class SaveModel
{
    public static string Connect(int num, string name, int pref, string data)
    {
        return $$"""
        Itm.{{num}}...{
            Nome:{{name}}
            Preferência:{{pref}}
            Data de inicio:{{data}}
        }
        """;
    }
}