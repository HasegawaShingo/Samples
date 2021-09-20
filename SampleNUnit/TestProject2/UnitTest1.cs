using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using NUnit.Framework;

namespace TestProject2
{
    public class Tests
    {
        string TestSourceDirectoryPath;

        [SetUp]
        public void Setup()
        {
            // ���̓t�@�C�������s�t�H���_���ɃR�s�[���܂��B
            // ���ɁA���͂ɑ΂���o�̓t�@�C��������ꍇ�Ȃ񂩂́A����ŏ��������Ȃ��ƑO�����̃t�@�C�����c�����Ⴄ�B
            var sourceTestFilePath = @"..\..\..\TestInputFile";
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var destinationPath = Path.Combine(assemblyPath, @"TestInputFile");

            var absSourceTestFileURI = new System.Uri(Path.Combine(assemblyPath, sourceTestFilePath)).AbsolutePath;

            if (Directory.Exists(destinationPath))
                Directory.Delete(destinationPath, true);

            Directory.CreateDirectory(destinationPath);

            foreach (var file in Directory.GetFiles(absSourceTestFileURI))
                File.Copy(file, Path.Combine(destinationPath, Path.GetFileName(file)));

            TestSourceDirectoryPath = destinationPath;
        }

        [Test]
        public void Test1()
        {
            // app.config�̓��e�������ɍ��킹�ď��������B
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["InputSource"].Value = @".\TestInputFile\HogeHoge1.txt";
            config.Save();
            // ���t�@�C������ݒ��ǂݎ��悤�ɁA�ݒ�̍X�V�������܂��B
            // ��������Ȃ��ƁA���̎����ŕύX���ꂽ�l���g�������邱�ƂɂȂ�񂷁B
            ConfigurationManager.RefreshSection("appSettings");

            var target = new SampleNUnit_net48.Form1();
            var actual = target.ReadSourceFile();

            var expected = new List<string>();
            CollectionAssert.AreEqual(actual, expected);
            target.Close();
        }

        [Test]
        public void Test2()
        {
            // app.config�̓��e�������ɍ��킹�ď��������B
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["InputSource"].Value = @".\TestInputFile\Source1.txt";
            config.Save();
            // ���t�@�C������ݒ��ǂݎ��悤�ɁA�ݒ�̍X�V�������܂��B
            // ��������Ȃ��ƁA���̎����ŕύX���ꂽ�l���g�������邱�ƂɂȂ�񂷁B
            ConfigurationManager.RefreshSection("appSettings");

            var target = new SampleNUnit_net48.Form1();
            var actual = target.ReadSourceFile();

            var expected = new List<string>() { "1,10,100,1000,InputFile1" };
            CollectionAssert.AreEqual(actual, expected);
            target.Close();
        }
    }
}