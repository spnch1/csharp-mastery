namespace GameDataParser;

[Serializable]
public class InvalidJsonException(string filePath, string jsonString, Exception? inner = null) 
    : Exception($"JSON in the {filePath} was not a valid format.", inner)
{
    public string JsonString { get; } = jsonString;

    public override string Message => 
        $"{base.Message}{Environment.NewLine}JSON Body:{Environment.NewLine}{JsonString}";
}