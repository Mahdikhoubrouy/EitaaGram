using EitaaGram;
using EitaaGram.BotLib.BotClient;
using EitaaGram.BotLib.Methods;

EitaaGramBotClient client = new EitaaGramBotClient("bot38493:6cbde657-fc3b-4081-9a93-5f888f972b63");


var me = await client.GetMeAsync();

Console.WriteLine(me.first_name);

Console.ReadKey();