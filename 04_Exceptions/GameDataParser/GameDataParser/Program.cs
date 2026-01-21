using GameDataParser;

var userInteraction = new ConsoleUserInteraction();

var app = new App(
    userInteraction,
    new GameJsonParser(),
    new Logger("log.txt"),
    new GamesPrinter(userInteraction));

app.Run();