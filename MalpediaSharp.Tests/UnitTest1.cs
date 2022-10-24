namespace MalpediaSharp.Tests;

public class Tests
{
    private IMalpediaClient client;

    [SetUp]
    public void Setup()
    {
        client = new MalpediaClient(Environment.GetEnvironmentVariable("MALPEDIA_TOKEN"));
    }

    [Test]
    public async Task TestAPICheck()
    {
        Assert.That(await client.CheckApi(), Is.EqualTo("Valid token."));
    }
    

    [Test]
    public async Task TestFindActor()
    {
        var actor = await client.FindActor("apt28");
        Assert.That(actor.Count, Is.GreaterThan(0));
    }

}