using System.Xml.Linq;

namespace WaveFunctionCollapse.Tests;

public class Helper_Test
{
    [Fact]
    public void LoadBitmap_FilenameIs3Bricks_ReturnExpectedValues()
    {
        var name = "3Bricks";
        var (bitmap, SX, SY) = BitmapHelper.LoadBitmap($"samples/{name}.png");
        Assert.Equal(1024, bitmap.Length);
        Assert.Equal(32, SX);
        Assert.Equal(32, SY);
    }

    [Fact]
    public void Get_FilenameIsSamples_ReturnExpectedValues()
    {
        XDocument xdoc = XDocument.Load("samples.xml");
        IEnumerable<XElement> enumerable = xdoc.Root.Elements("overlapping", "simpletiled");
        XElement firstXelem = enumerable.First();
        string firstXelemName = firstXelem.Get<string>("name");
        int firstXelemN = firstXelem.Get<int>("N");
        bool firstXelemPeriodic = firstXelem.Get<bool>("periodic");
        Assert.Equal("Chess", firstXelemName);
        Assert.Equal(2, firstXelemN);
        Assert.True(firstXelemPeriodic);
        Assert.Equal(88, enumerable.Count());
        string getNullDefault = firstXelem.Get<string>(null);
        Assert.Null(getNullDefault);
        // TODO
        //   <overlapping name="Chess" N="2" size="47" periodic="True" screenshots="1"/>
    }
}