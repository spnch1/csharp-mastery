using GameDataParser;
using GameDataParser.App;
using GameDataParser.DataAccess;
using GameDataParser.Logger;
using GameDataParser.UserInteraction;

var userInteraction = new ConsoleUserInteraction();

var app = new App(
    userInteraction,
    new GameJsonParser(),
    new Logger("log.txt"),
    new GamesPrinter(userInteraction));

app.Run();