using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;


namespace GetBingPic{
public class GetPicP{
public int[] GetPageIndex(int y,int m,int d){
    DateTime standard = DateTime.Now;
    DateTime now = new DateTime(y,m,d);
    TimeSpan ts = (standard.Subtract(now));
    int days = (int)Math.Ceiling(ts.TotalDays);
    int page = 1+ (int)(days/12);
    int index = days % 12;
    return new int[2] {page,index};
}
public int[] GetPageIndex(DateTime dt){
    DateTime standard = DateTime.Now;
    TimeSpan ts = (standard.Subtract(dt));
    int days = (int)Math.Ceiling(ts.TotalDays);
    int page = 1+ (int)(days/12);
    int index = days % 12;
    return new int[2] {page,index};
}
public int[] GetPageIndex(){
    DateTime standard = DateTime.Now;
    DateTime now = DateTime.Now;
    TimeSpan ts = (standard.Subtract(now));
    int days = (int)Math.Ceiling(ts.TotalDays);
    Console.WriteLine(ts.TotalDays);
    int page = 1+ (int)(days/12);
    int index = days % 12;
    return new int[2] {page,index};
}
public void GetPic(int page, int index){
    string url = $@"https://bing.ioliu.cn/?p={page}";

    WebClient wc = new WebClient();
    wc.Headers.Add("user-agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36 Edg/108.0.1462.76");
    wc.Encoding = Encoding.UTF8;
    Stream s = wc.OpenRead(url);
    string ss = new StreamReader(s).ReadToEnd();
    //Console.WriteLine(ss);

    HtmlDocument h = new HtmlDocument();
    h.LoadHtml(ss);
    HtmlNode con = h.DocumentNode.SelectSingleNode("/html/body/div[3]");
    HtmlNode lastest = con.ChildNodes[index];
    HtmlNode img = lastest.ChildNodes[0].ChildNodes[3].ChildNodes[2];
    string src = img.Attributes["href"].Value;
    string filen = img.Attributes["title"].Value;
    HtmlNode des = lastest.ChildNodes[0].ChildNodes[2].ChildNodes[0];
    string desc = des.InnerHtml;
    Console.WriteLine("src  "+src);
    Console.WriteLine("desc  "+ desc);

    wc.DownloadFile(src,$"./pic/{filen}.jpg");

}
}
}
