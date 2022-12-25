using EitaaGram;
using EitaaGram.BotLib.BotClient;
using EitaaGram.BotLib.Methods;

EitaaGramBotClient client = new EitaaGramBotClient("bot38493:6cbde657-fc3b-4081-9a93-5f888f972b63");


//var me = await client.GetMeAsync();

//if (me is null)
//{
//    Console.WriteLine("operation failed");
//    return;
//}

try
{
    var res = await client.SendMessageAsync("miti222", "salam dada");
}
catch
{
    Console.WriteLine("kos asb");
}

Console.ReadKey();