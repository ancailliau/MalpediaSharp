using MalpediaSharp;

var client = new MalpediaClient(Environment.GetEnvironmentVariable("MALPEDIA_TOKEN"));
Console.WriteLine(await client.CheckApi());
