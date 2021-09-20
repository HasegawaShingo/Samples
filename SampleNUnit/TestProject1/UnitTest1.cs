using System.Reflection;
using NUnit.Framework;

namespace TestProject1;
public class Tests
{
    // NUnit���g���Ă݂悤�I

    [SetUp]
    public void Setup()
    {
    }

    /// <summary>
    /// ��񂾂��̏ꍇ
    /// </summary>
    [Test]
    public void Test1()
    {
        var actual = SampleNUnit.Class1.Sum(1, 5);
        Assert.AreEqual(actual, 6);
    }

    /// <summary>
    /// �e�X�g�P�[�X���g�����e�X�g�B�ŏ��A�ő�A���E�l�Ȃ񂩂ɂ悢�ˁB
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
    /// ����ł��ǂ��B
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


    // ���̃e�X�g�P�[�X�Ȃ�Ƃ���
    [TestCaseSource("test5_casesource")]
    public void test5(List<string> testData)
    {
        Assert.Pass();
    }

    static IList<object> test5_casesource = new List<object>
    {
        new object[] { new List<string> { "1,1,������,1" } }
    };

    // �����OK
    [TestCaseSource("test6_caseset")]
    public void test6(List<string> testData, List<List<string>> expected)
    {
        Assert.Pass();
    }

    // �W���O�z��Ƀe�X�g���\�b�h�̈������i�[���Ă�������
    static object[][] test6_caseset()
    {
        // create testdata
        var testdata = new List<string> { "1,1,������,1" };

        // create expected data
        var expected = new List<List<string>>();
        var expectedData = new List<string> { "1", "1", "������", "1" };
        expected.Add(expectedData);

        // create return object
        object[][] result = { new object[] { testdata, expected } };
        return result;
    }


    [TestCaseSource("test7_caseset")]
    public void test7(string filePath, List<string> expectedReadLines)
    {
        var actual = SampleNUnit.Class1.ReadLines(filePath);
        CollectionAssert.AreEqual(actual, expectedReadLines);
    }

 
    static object[][] test7_caseset()
    {
        // ���\�[�X������s�t�H���_�Ƀt�H���_����āA�t�@�C���������o���Ă�����̂���ԊȒP�����B
        var currentPath = Directory.GetCurrentDirectory();
        var resourceFolderPath = Path.Combine(currentPath, @"..\..\..\TestInputFile");
        var absoluteResoucePath = new Uri(resourceFolderPath).AbsolutePath;

        var testFolder = Path.Combine(currentPath, "TestInputFile");
        if (Directory.Exists(testFolder))
            Directory.Delete(testFolder, true);

        Directory.CreateDirectory(testFolder);
        foreach(var file in Directory.GetFiles(absoluteResoucePath))
        {
            File.Copy(file, Path.Combine(testFolder, Path.GetFileName(file)), true);
        }

        // �����܂ł̓e�X�g�N���X�̏��������Ɉ�񂾂����s�����΂�낵�B
        // ����Ȋ����ł���΁A�e�X�g���s�̊��Ɉˑ������ɁA�R�~�b�g���Ă���t�H���_�[�̍\����
        // �ς��Ȃ�����A�ǂ̊J�����ł����s�o����B

        var testFile = Path.Combine(testFolder, $"{nameof(Resource.Source1)}.txt");

        var expectedList = new List<string> { Resource.Source1 };

        object[][] result =
        {
            new object[]{testFile, expectedList }
        };
        return result;
    }
}