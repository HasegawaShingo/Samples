using NUnit.Framework;

namespace TestProject1;
public class Tests
{
    // NUnitを使ってみよう！

    [SetUp]
    public void Setup()
    {
    }

    /// <summary>
    /// 一回だけの場合
    /// </summary>
    [Test]
    public void Test1()
    {
        var actual = SampleNUnit.Class1.Sum(1, 5);
        Assert.AreEqual(actual, 6);
    }

    /// <summary>
    /// テストケースを使ったテスト。最小、最大、境界値なんかによいね。
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="expected"></param>
    [TestCase(100, 200, 300)]
    [TestCase(1, 2, 3)]
    public void Test2(int a, int b, int expected)
    {
        Assert.AreEqual(SampleNUnit.Class1.Sum(a, b), expected);
    }

    /// <summary>
    /// これでも良い。
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [TestCase(100, 200, ExpectedResult = 300)]
    [TestCase(1, 2, ExpectedResult = 3)]
    public int test3(int a, int b)
    {
        return SampleNUnit.Class1.Sum(a, b);
    }


    // このテストケースならとおる
    [TestCaseSource("test5_casesource")]
    public void test5(List<string> testData)
    {
        Assert.Pass();
    }

    static IList<object> test5_casesource = new List<object>
    {
        new object[] { new List<string> { "1,1,あああ,1" } }
    };

    // これもOK
    [TestCaseSource("test6_caseset")]
    public void test6(List<string> testData, List<List<string>> expected)
    {
        Assert.Pass();
    }

    // ジャグ配列にテストメソッドの引数を格納していく感じ
    static object[][] test6_caseset()
    {
        // create testdata
        var testdata = new List<string> { "1,1,あああ,1" };

        // create expected data
        var expected = new List<List<string>>();
        var expectedData = new List<string> { "1", "1", "あああ", "1" };
        expected.Add(expectedData);

        // create return object
        object[][] result = { new object[] { testdata, expected } };
        return result;
    }

}