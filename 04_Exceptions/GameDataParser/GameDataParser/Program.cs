using GameDataParser;

var app = new App(
    new UserInteraction(),
    new JsonParser(),
    new Logger("log.txt"));

app.Run();